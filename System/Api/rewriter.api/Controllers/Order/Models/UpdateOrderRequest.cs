using AutoMapper;
using FluentValidation;
using rewriter.OrderService.Models;

namespace rewriter.api.Controllers.Article.Models
{
    public class UpdateOrderRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
    public class UpdateBookResponseValidator : AbstractValidator<UpdateOrderRequest>
    {
        public UpdateBookResponseValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Empty Title")
                .MaximumLength(20).WithMessage("Not allowed size of title");
            RuleFor(x => x.Description)
               .MaximumLength(30).WithMessage("Not allowed size of desctiption");
        }
    }
    public class UpdateOrderRequestProfile : Profile
    {
        public UpdateOrderRequestProfile()
        {
            CreateMap<UpdateOrderRequest, OrderModel>();
        }
    }
}
