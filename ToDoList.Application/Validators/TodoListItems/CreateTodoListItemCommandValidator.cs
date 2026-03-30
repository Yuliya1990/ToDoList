using FluentValidation;
using ToDoList.Application.Features.TodoListItems.Commands;
using ToDoList.Domain.Enums;

namespace ToDoList.Application.Validators.TodoListItems;

public sealed class CreateTodoListItemCommandValidator : AbstractValidator<CreateTodoListItemCommand>
{
    public CreateTodoListItemCommandValidator()
    {
        RuleFor(x => x.TodoListId)
            .NotEmpty().WithMessage("TodoListId is required.");

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(200).WithMessage("Title must not exceed 200 characters.");

        RuleFor(x => x.Description)
            .MaximumLength(1000).WithMessage("Description must not exceed 1000 characters.")
            .When(x => x.Description is not null);

        RuleFor(x => x.Priority)
            .NotEmpty().WithMessage("Priority is required.")
            .Must(p => Enum.TryParse<Priority>(p, ignoreCase: true, out _))
            .WithMessage("Priority must be one of: Low, Medium, High.");

        RuleFor(x => x.DueDate)
            .GreaterThanOrEqualTo(DateTime.UtcNow.Date)
            .WithMessage("DueDate must be today or in the future.")
            .When(x => x.DueDate.HasValue);
    }
}
