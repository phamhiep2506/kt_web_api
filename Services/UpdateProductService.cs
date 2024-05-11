using Models;
using Models.Dtos;
using Services.IServices;

namespace Services;

public class UpdateProductService : IUpdateProductService
{
    private readonly ApplicationDbContext _context;

    public UpdateProductService(ApplicationDbContext context)
    {
        _context = context;
    }

    public ResponseDto UpdateProduct(UpdateProductDto updateProductDto)
    {
        ProductDetail? productDetail = _context
            .ProductDetails?.Where(x =>
                x.ProductDetailId == updateProductDto.ProductId
            )
            .SingleOrDefault();

        if (productDetail == null)
        {
            return new ResponseDto()
            {
                status = "error",
                message = "Sản phẩm không tồn tại"
            };
        }

        int diffQuantity = productDetail.Quantity - updateProductDto.Quantity;

        productDetail.Quantity = updateProductDto.Quantity;

        _context.Update(productDetail);
        _context.SaveChanges();

        while (productDetail?.ParentId != null)
        {
            productDetail = _context
                .ProductDetails?.Where(x =>
                    x.ProductDetailId == productDetail.ParentId
                )
                .SingleOrDefault();

            if (productDetail == null)
            {
                break;
            }

            productDetail.Quantity -= diffQuantity;

            _context.Update(productDetail);
            _context.SaveChanges();
        }

        return new ResponseDto()
        {
            status = "success",
            message = "Sửa sản phẩm thành công",
        };
    }
}
