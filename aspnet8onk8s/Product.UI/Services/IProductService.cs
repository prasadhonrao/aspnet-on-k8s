namespace Product.UI.Services
{
    public interface IProductService
    {
        IEnumerable<ProductModel> GetProducts();
    }
}