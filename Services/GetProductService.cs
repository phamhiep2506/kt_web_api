using Models;
using Services.IServices;

namespace Services;

public class GetProductService : IGetProductService
{
    private readonly ApplicationDbContext _context;

    public GetProductService(ApplicationDbContext context)
    {
        _context = context;
    }

    public ResponseProductDto GetProduct()
    {
        List<ProductDetail>? productDetails = _context.ProductDetails?.ToList();

        if (productDetails == null)
        {
            return new ResponseProductDto()
            {
                status = "error",
                message = "Lấy sản phẩm thất bại",
            };
        }

        return new ResponseProductDto()
        {
            status = "success",
            message = "Lấy sản phẩm thành công",
            items = productDetails
        };
    }
}
