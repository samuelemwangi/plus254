using App.Application.EntitiesCommandsQueries.Products.Queries.GetProducts;
using App.Application.EntitiesCommandsQueries.Products.Queries.GetProductDetail;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<ProductsViewModel>> GetAll()
        {
            return Ok(await Mediator.Send(new GetProductsQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDetailViewModel>> Get(string id)
        {
            Int64.TryParse(id, out long Id);

            return Ok(await Mediator.Send(new GetProductDetailQuery { ID = Id}));
        }



    }
}
