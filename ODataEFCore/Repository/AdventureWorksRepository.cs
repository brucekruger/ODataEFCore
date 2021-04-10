using System.Linq;
using ODataEFCore.Dto;
using ODataEFCore.Interfaces;
using ODataEFCore.Models;

namespace ODataEFCore.Repository
{
    public class AdventureWorksRepository : IAdventureWorksRepository
    {
        private readonly AdventureWorks2019Context _context;

        public AdventureWorksRepository(AdventureWorks2019Context context)
        {
            _context = context;
        }

        public IQueryable<ProductDto> GetProducts()
        {
            var products = _context.Products.Join(_context.ProductModels, p => p.ProductModelId,
                m => m.ProductModelId, (p, m) => new ProductDto
                {
                    ProductId = p.ProductId,
                    Name = p.Name,
                    ProductNumber = p.ProductNumber,
                    Color = p.Color,
                    ListPrice = p.ListPrice,
                    Size = p.Size,
                    SizeUnitMeasureCode = p.SizeUnitMeasureCode,
                    WeightUnitMeasureCode = p.WeightUnitMeasureCode,
                    Weight = p.Weight,
                    DaysToManufacture = p.DaysToManufacture,
                    ProductLine = p.ProductLine,
                    Class = p.Class,
                    Style = p.Style,
                    ModelName = m.Name,
                    ModelCatalogDescription = m.CatalogDescription,
                    ModelInstructions = m.Instructions
                }
            );
            return products;
        }

        public IQueryable<ProductDto> GetProducts(int id)
        {
            var products = id == default ? GetProducts() : GetProducts().Where(x => x.ProductId == id);
            return products;
        }
    }
}
