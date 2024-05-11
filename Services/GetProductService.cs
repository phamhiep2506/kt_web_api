using Models;
using Models.Dtos;
using Services.IServices;

namespace Services;

public class GetProductService : IGetProductService
{
    private readonly ApplicationDbContext _context;

    public GetProductService(ApplicationDbContext context)
    {
        _context = context;
    }

    public ResponseDto GetProduct()
    {
        return new ResponseDto()
        {
            status = "success",
            message = "Lấy sản phẩm thành công",
        };
    }
}
