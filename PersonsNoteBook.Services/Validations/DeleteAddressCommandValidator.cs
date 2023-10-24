using FluentValidation;
using PersonsNoteBook.Core.Interfaces;
using PersonsNoteBook.Services.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsNoteBook.Services.Validations
{
    public class DeleteAddressCommandValidator : AbstractValidator<DeleteAddressCommand>
    {
        public DeleteAddressCommandValidator(IPersonRepository personRepository)
        {
            RuleFor(command => command.AddressId)
                .NotEmpty()
                .WithMessage("The Address identifier can't be empty.");

            RuleFor(command => command.PersonId)
                .NotEmpty()
                .WithMessage("The Person identifier can't be empty.")
                .Must(personId => personRepository.IsPersonActive(personId))
                .WithMessage("The Persdon is not Active.");
        }
    }
}
