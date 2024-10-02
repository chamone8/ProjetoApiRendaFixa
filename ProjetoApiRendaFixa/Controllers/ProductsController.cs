using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjetoApiRendaFixa.CQRS.Commands;
using ProjetoApiRendaFixa.CQRS.Queries;
using ProjetoApiRendaFixa.Models;
using ProjetoApiRendaFixa.Services.Command;
using ProjetoApiRendaFixa.Services.Query;

namespace ProjetoApiRendaFixa.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductCommandService _productCommandService;
        private readonly IProductQueryService _productQueryService;
        private readonly IPurchaseQueryService _purchaseQueryService;

        public ProductsController(IProductCommandService productCommandService, IProductQueryService productQueryService, IPurchaseQueryService purchaseQueryService)
        {
            _productCommandService = productCommandService;
            _productQueryService = productQueryService;
            _purchaseQueryService = purchaseQueryService;
        }

        [HttpPost("purchase")]
        public async Task<IActionResult> PurchaseProduct(GetProductsQuery query)
        {
            var dados = new Purchase()
            {
                ProductId = query.IdProduct,
                AccountId = query.IdAccount,
                Quantity = query.Quantity
            };
            await _productCommandService.PurchaseProduct(dados);
            return Ok();

        }

        [HttpGet("GetPurchasesByAccount")]
        public async Task<IActionResult> GetPurchasesAll(Guid AccountId)
        {
            var result = await _purchaseQueryService.GetCustomerPurchasesAsync(AccountId);
            return Ok(result);
        }

        [HttpGet("GetProduct")]
        public async Task<IActionResult> GetProduct(Guid Id)
        {
            var result = await _productQueryService.GetProductByIdAsync(Id);
            return Ok(result);
        }

        [HttpGet("GetProductAll")]
        public async Task<IActionResult> GetProductAll()
        {
            var result = await _productQueryService.GetAllProductsAsync();
            return Ok(result);
        }

        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand createProductCommand)
        {
            // Log para verificar o comando recebido
            Console.WriteLine(JsonConvert.SerializeObject(createProductCommand));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _productCommandService.CreateProduct(createProductCommand);
            return Ok(result);
        }

    }
}
