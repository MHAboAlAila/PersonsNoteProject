using MediatR;
using PersonsNoteBook.Core.Entities;
using PersonsNoteBook.Services.Dtos;

namespace PersonsNoteBook.Services.Queries
{
    public record GetActivatedPersonsQuery : IRequest<IEnumerable<PersonDto>>
    {

    }
}
