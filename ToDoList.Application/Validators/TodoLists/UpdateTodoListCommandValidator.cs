using FluentValidation;
using ToDoList.Application.Features.TodoLists.Commands;

namespace ToDoList.Application.Validators.TodoLists;

public sealed class UpdateTodoListCommandValidator : AbstractValidator<UpdateTodoListCommand>
{
    public UpdateTodoListCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required.");

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(200).WithMessage("Title must not exceed 200 characters.");

        RuleFor(x => x.DueDate)
            .GreaterThanOrEqualTo(DateTime.UtcNow.Date)
            .WithMessage("DueDate must be today or in the future.")
            .When(x => x.DueDate.HasValue);
    }
}
