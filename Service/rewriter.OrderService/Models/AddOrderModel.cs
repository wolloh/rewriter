using FluentValidation;

namespace rewriter.OrderService.Models
{
    public class AddOrderModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
    public class AddBookModelValidator : AbstractValidator<AddOrderModel>
    {
        public AddBookModelValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Empty Title")
                .MaximumLength(20).WithMessage("Not allowed size of title");
            RuleFor(x => x.Description)
               .MaximumLength(30).WithMessage("Not allowed size of desctiption");
        }
    }
}
