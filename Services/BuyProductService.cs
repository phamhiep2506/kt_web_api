using AutoMapper;
using Models;
using Models.Dtos;
using Services.IServices;

namespace Services;

public class BuyProductService : IBuyProductService
{
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;

    public BuyProductService(IMapper mapper, ApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }
    public ResponseDto<ResponseBuyProductDto> BuyProduct(BuyProductDto buyProductDto)
    {
        ProductDetail? productDetail = _context
            .ProductDetails?
            .Where(x => x.ProductDetailName == buyProductDto.ProductName)
            .SingleOrDefault();

        if(productDetail == null)
        {
            return new ResponseDto<ResponseBuyProductDto>()
            {
                status = "error",
                message = "Sản phẩm không tồn tại"
            };
        }

        if(productDetail.Quantity <= 0)
        {
            return new ResponseDto<ResponseBuyProductDto>()
            {
                status = "error",
                message = "Sản phẩm hết hàng"
            };
        }

        if(productDetail.Quantity < buyProductDto.Quantity)
        {
            return new ResponseDto<ResponseBuyProductDto>()
            {
                status = "error",
                message = "Sản phẩm không đủ"
            };
        }

        if(productDetail.Quantity >= buyProductDto.Quantity)
        {
            productDetail.Quantity = productDetail.Quantity - buyProductDto.Quantity;
        }

        _context.Update(productDetail);
        _context.SaveChanges();

        ResponseBuyProductDto responseBuyProductDto = _mapper
            .Map<ProductDetail, ResponseBuyProductDto>(productDetail);
        responseBuyProductDto.BuyQuantity = buyProductDto.Quantity;
        responseBuyProductDto.SumPrice = buyProductDto.Quantity * responseBuyProductDto.Price;

        return new ResponseDto<ResponseBuyProductDto>()
        {
            status = "success",
            message = "Mua sản phẩm thành công",
            items = new List<ResponseBuyProductDto>() { responseBuyProductDto }
        };
    }

}
