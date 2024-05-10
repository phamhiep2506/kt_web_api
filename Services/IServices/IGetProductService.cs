using Models.Dtos;

namespace Services.IServices;

public interface IGetProductService
{
    public ResponseDto<ResponseGetProductDto> GetProduct();
}
