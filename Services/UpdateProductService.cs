using AutoMapper;
using Models;
using Models.Dtos;
using Services.IServices;

namespace Services;

public class UpdateProductService : IUpdateProductService
{
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;

    public UpdateProductService(IMapper mapper, ApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public ResponseDto<ResponseUpdateProductDto> UpdateProduct(UpdateProductDto updateProductDto)
    {
        ProductDetail? productDetail = _context
            .ProductDetails?
            .Where(x => x.ProductDetailName == updateProductDto.ProductName)
            .SingleOrDefault();

        if(productDetail == null)
        {
            return new ResponseDto<ResponseUpdateProductDto>()
            {
                status = "error",
                message = "Sản phẩm không tồn tại"
            };
        }

        productDetail.Quantity = updateProductDto.Quantity;
        productDetail.Price = updateProductDto.Price;

        _context.Update(productDetail);
        _context.SaveChanges();

        ResponseUpdateProductDto responseUpdateProductDto = _mapper.Map<
            ProductDetail,
            ResponseUpdateProductDto
        >(productDetail);

        return new ResponseDto<ResponseUpdateProductDto>()
        {
            status = "success",
            message = "Sửa sản phẩm thành công",
            items = new List<ResponseUpdateProductDto>()
            {
                responseUpdateProductDto
            }
        };
    }
}
