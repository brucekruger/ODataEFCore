using System.Linq;
using ODataEFCore.Dto;

namespace ODataEFCore.Interfaces
{
    public interface IAdventureWorksRepository
    {
        IQueryable<ProductDto> GetProducts();
        IQueryable<ProductDto> GetProducts(int id);
    }
}