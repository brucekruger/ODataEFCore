using Microsoft.AspNetCore.Mvc;
using ODataEFCore.Interfaces;

namespace ODataEFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IAdventureWorksRepository _repository;

        public ProductsController(IAdventureWorksRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var result = _repository.GetProducts(id);
            return Ok(result);
        }

        //public IActionResult Get()
        //{
        //    var result = _repository.GetProducts();
        //    return Ok(result);
        //}
    }
}
