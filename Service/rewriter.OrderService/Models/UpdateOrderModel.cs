using FluentValidation;

namespace rewriter.OrderService.Models
{
    public class UpdateOrderModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
    public class UpdateBookModelValidator : AbstractValidator<UpdateOrderModel>
    {
        public UpdateBookModelValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Empty Title")
                .MaximumLength(20).WithMessage("Not allowed size of title");
            RuleFor(x => x.Description)
               .MaximumLength(30).WithMessage("Not allowed size of desctiption");
        }
    }
}
