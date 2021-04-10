using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using ODataEFCore.Interfaces;

namespace ODataEFCore.Controllers
{
    public class ODataProductsController : ODataController
    {
        private readonly IAdventureWorksRepository _repository;

        public ODataProductsController(IAdventureWorksRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [EnableQuery]
        [ODataRoute("AllProducts()")]
        public IActionResult Get()
        {
            return Ok(_repository.GetProducts());
        }

        [HttpGet]
        [EnableQuery]
        [ODataRoute("ProductsById(id={id})")]
        public IActionResult Get(int id)
        {
            return Ok(_repository.GetProducts(id));
        }
    }
}
