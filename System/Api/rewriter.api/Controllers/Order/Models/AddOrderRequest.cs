using AutoMapper;
using FluentValidation;
using rewriter.api.Controllers.Article.Models;
using rewriter.OrderService.Models;

namespace rewriter.api.Controllers.Article.Models
{
    public class AddOrderRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
    public class AddBookResponseValidator : AbstractValidator<AddOrderRequest>
    {
        public AddBookResponseValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Empty Title")
                .MaximumLength(20).WithMessage("Not allowed size of title");
            RuleFor(x => x.Description)
               .MaximumLength(30).WithMessage("Not allowed size of desctiption");
        }
    }
}
    public class AddOrderRequestProfile : Profile
{
    public AddOrderRequestProfile()
    {
        CreateMap<AddOrderRequest, AddOrderModel>();
    }
}