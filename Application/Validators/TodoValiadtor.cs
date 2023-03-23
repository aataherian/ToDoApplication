using FluentValidation;
using ToDoApplication.Application.DTOs;

namespace ToDoApplication.Application.Valitaors;

public class TodoValitor: AbstractValidator<TodoDTO>
{
    public TodoValitor()
    {
        RuleFor( t => t.id)
                            .NotNull()
                            .InclusiveBetween(1, long.MaxValue)
                            .WithMessage("Todo's Id must be supplied (between 1 and"+ long.MaxValue+").");
        RuleFor( t => t.title)
                            .NotEmpty()
                            .MinimumLength(3)
                            .MaximumLength(100)
                            .WithMessage("Todo's Title must be between 3 to 100 characters.");

    }
}