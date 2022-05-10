
namespace rewriter.api.Controllers.Article;

using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rewriter.api.Controllers.Article.Models;
using rewriter.OrderService;
using rewriter.OrderService.Models;

[Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class OrderController : ControllerBase
    {
    private readonly ILogger<OrderController> logger;
    private readonly IOrderService orderService;
    private readonly IMapper mapper;

    public OrderController(ILogger<OrderController> logger,IOrderService  orderService,IMapper mapper)
        {
            this.logger=logger;
        this.orderService = orderService;
        this.mapper = mapper;
    }
        [HttpGet("")]
        public async Task<IEnumerable<OrderResponse>> GetOrders()
        {
        var books = await orderService.GetOrders();
        var response=mapper.Map<IEnumerable<OrderResponse>>(books);
        return response;
        }
    [HttpPost("")]
    public async Task<OrderResponse> AddOrder([FromBody] AddOrderRequest request)
    {
        var model = mapper.Map<AddOrderModel>(request);
        var order=await orderService.AddOrder(model);
        var response=mapper.Map<OrderResponse>(order);
        return response;
    }
    [HttpPut("{id}")]
    public IActionResult UpdateOrder([FromRoute] int id,[FromBody] UpdateOrderRequest request)
    {
        return Ok();
    }
}

