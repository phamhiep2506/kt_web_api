using Models;
using Models.Dtos;
using Services.IServices;

namespace Services;

public class BuyProductService : IBuyProductService
{
    private readonly ApplicationDbContext _context;

    public BuyProductService(ApplicationDbContext context)
    {
        _context = context;
    }

    public ResponseDto BuyProduct(BuyProductDto buyProductDto)
    {
        ProductDetail? productDetail = _context
            .ProductDetails?.Where(x =>
                x.ProductDetailId == buyProductDto.ProductId
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

        if (productDetail.Quantity <= 0)
        {
            return new ResponseDto()
            {
                status = "error",
                message = "Sản phẩm hết hàng"
            };
        }

        if (productDetail.Quantity < buyProductDto.Quantity)
        {
            return new ResponseDto()
            {
                status = "error",
                message = "Sản phẩm không đủ"
            };
        }

        if (productDetail.Quantity >= buyProductDto.Quantity)
        {
            productDetail.Quantity -= buyProductDto.Quantity;
        }

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

            productDetail.Quantity -= buyProductDto.Quantity;

            _context.Update(productDetail);
            _context.SaveChanges();
        }

        return new ResponseDto()
        {
            status = "success",
            message = "Mua sản phẩm thành công",
        };
    }
}
