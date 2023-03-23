
using FluentValidation;

using ToDoApplication.Application.DTOs;

namespace ToDoApplication.Application.Valitaors;

internal class CardValidator: AbstractValidator<CardDTO>
{
    public CardValidator()
    {
        RuleFor( c => c.id)
                            .NotNull()
                                    .WithErrorCode("400")
                                    .WithMessage("Card Id can not be Empty.")
                            .InclusiveBetween(1 , long.MaxValue)
                                    .WithErrorCode("400")
                                    .WithMessage("Card Id must be between 1 and "+ long.MaxValue.ToString() + ")");
                                    
                                    
                            

        RuleFor( c => c.title)
                            .NotEmpty()
                                    .WithErrorCode("400")
                                    .WithMessage("Card's Title can not be Empty.")
                            .MinimumLength(3)
                                    .WithErrorCode("400")
                                    .WithMessage("Card's Title must be at least 3 charachters")
                            .MaximumLength(100)
                                    .WithErrorCode("400")
                                    .WithMessage("Card's Title must be at most 100 charachters");
                             
                           
    }    
}

internal class CardCreationValiadtor: AbstractValidator<CardCreationDTO>
{

    public CardCreationValiadtor()
    {
       RuleFor( c => c.title)
                            .NotEmpty()
                                    .WithErrorCode("400")
                                    .WithMessage("Card's Title can not be Empty.")
                            .MinimumLength(3)
                                    .WithErrorCode("400")
                                    .WithMessage("Card's Title must be at least 3 charachters")
                            .MaximumLength(100)
                                    .WithErrorCode("400")
                                    .WithMessage("Card's Title must be at most 100 charachters");
                            
    }

}