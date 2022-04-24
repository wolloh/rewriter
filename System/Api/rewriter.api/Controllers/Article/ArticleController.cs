
namespace rewriter.api.Controllers.Article;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rewriter.api.Controllers.Article.Models;
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class ArticleController : ControllerBase
    {
        private readonly ILogger<ArticleController> logger;
        public ArticleController(ILogger<ArticleController> logger)
        {
            this.logger=logger;
        }
        [HttpGet("")]
        public List<Article> GetArticles()
        {
        return new List<Article>()
            {
                new Article() {
                    Title = "f",
                     Id =1}
            };
        }
    }

