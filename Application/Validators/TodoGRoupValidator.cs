using FluentValidation;
using ToDoApplication.Application.DTOs;

namespace ToDoApplication.Application.Valitaors;

internal class TodoGRoupValidator: AbstractValidator<TodoGroupDTO>
{
    public TodoGRoupValidator()
    {
        RuleFor(t => t.id)
                            .NotNull()
                            .InclusiveBetween(1 , long.MaxValue)
                            .WithMessage("TodoGroup'Id must be supplied(between 1 and " + long.MaxValue+ ").");

        RuleFor( t => t.title)
                            .NotEmpty()
                            .MinimumLength(3)
                            .MaximumLength(100)
                            .WithMessage("TodoGroup's Title Must be 3 to 100 characters.");
    }
}