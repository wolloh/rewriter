using AutoMapper;
using rewriter.OrderService.Models;

namespace rewriter.api.Controllers.Article.Models
{
    public class OrderResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
    public class OrderResponseProfile : Profile
    {
        public OrderResponseProfile()
        {
            CreateMap<OrderModel, OrderResponse>();
        }
    }
}
