using MediatR;
using Microsoft.Data.SqlClient;
using Dapper;
using PersonsNoteBook.Services.Queries;
using PersonsNoteBook.Services.Dtos;

namespace PersonsNoteBook.Services.Queries
{
    public class GetActivePersonsHandler : IRequestHandler<GetActivatedPersonsQuery, IEnumerable<PersonDto>>
    {
        private string _connectionString = string.Empty;

        public GetActivePersonsHandler()
        {
            _connectionString = "Server=MHASANLAPTOP;Database=DemoDB;Trusted_Connection=True;Encrypt=False;";
        }
        async Task<IEnumerable<PersonDto>> IRequestHandler<GetActivatedPersonsQuery, IEnumerable<PersonDto>>.Handle(GetActivatedPersonsQuery request, CancellationToken cancellationToken)
        {
            var personsquery = "SELECT P.[Id] as Id, P.[FirstName] as FirstName, P.[LastName] as LastName " +
                               "FROM [NoteBook].[Persons] P " +
                               "Where P.Active = 1";
            using(var connection = new SqlConnection(_connectionString))
            {
                var persons = await connection.QueryAsync<PersonDto>(personsquery);

                foreach (PersonDto person in persons)
                {
                    var addressquery = "SELECT [Id], [Country], [PoBox], [City], [Street], [Apartment] " +
                                       "FROM [NoteBook].[Addresses] " +
                                       "WHERE [PersonId] = @Id";
                    var addresses = await connection.QueryAsync<AddressDto>(addressquery, new { person.Id });
                    person.Addresses = addresses.ToArray();
                }
                return persons.ToList();
            }
        }
    }
}
