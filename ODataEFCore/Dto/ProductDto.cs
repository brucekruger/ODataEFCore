using System.ComponentModel.DataAnnotations;

namespace ODataEFCore.Dto
{
    public class ProductDto
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public string Color { get; set; }
        public decimal ListPrice { get; set; }
        public string Size { get; set; }
        public string SizeUnitMeasureCode { get; set; }
        public string WeightUnitMeasureCode { get; set; }
        public decimal? Weight { get; set; }
        public int DaysToManufacture { get; set; }
        public string ProductLine { get; set; }
        public string Class { get; set; }
        public string Style { get; set; }
        public string ModelName { get; set; }
        public string ModelCatalogDescription { get; set; }
        public string ModelInstructions { get; set; }
    }
}
