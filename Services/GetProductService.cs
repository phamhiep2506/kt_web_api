using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Dtos;
using Services.IServices;

namespace Services;

public class GetProductService : IGetProductService
{
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;

    public GetProductService(IMapper mapper, ApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public ResponseDto<ResponseGetProductDto> GetProduct()
    {
        return new ResponseDto<ResponseGetProductDto>()
        {
            status = "success",
            message = "Lấy sản phẩm thành công",
        };
    }
}
