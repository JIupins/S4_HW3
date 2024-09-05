using S4_HW3.Contracts.Requests;
using S4_HW3.Contracts.Responses;
using S4_HW3.Models;

namespace S4_HW3.Abstractions
{
    public interface IProductService
    {
        public int AddProduct(ProductCreateRequest product);
        public IEnumerable<ProductResponse> GetProducts();
        public ProductResponse GetProductById(int id);
        public bool DeleteProduct(int id);
        public bool UpdatePrice(int idProduct, int price);
        public bool DeleteCategory(string category);
        public string GetCsv(IEnumerable<Product> products);
    }
}