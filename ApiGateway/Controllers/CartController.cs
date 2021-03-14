using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiGateway.Services;
using Cart;
using Microsoft.AspNetCore.Http;

namespace ApiGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }
        // GET: api/<CartController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CartController>/5
        [HttpGet("{id}")]
        public string Get(string id)
        {
            return "value";
        }

        // GET api/<CartController>/5/total
        [HttpGet("{id}/total")]
        public async  Task<OkObjectResult> GetTotal(string id)
        {
            var result = await _cartService.GetTotal(id);

            return new OkObjectResult(new
            {
                total = result
            });
        }

        // POST api/<CartController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPost("{id}/addItem")]
        public Task<AddItemReply> AddItem([FromBody] AddItemRequest request)
        {
            if (!TryValidateModel(request))
            {
                throw new BadHttpRequestException("Invalid data");
            }

            return _cartService.AddItem(request);
        }


        [HttpPost("{id}/removeItem")]
        public Task<RemoveItemReply> RemoveItem([FromBody] RemoveItemRequest request)
        {
            if (!TryValidateModel(request))
            {
                throw new BadHttpRequestException("Invalid data");
            }

            return _cartService.RemoveItem(request);
        }

        // PUT api/<CartController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CartController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
