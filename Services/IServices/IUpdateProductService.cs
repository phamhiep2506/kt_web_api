using Models.Dtos;

namespace Services.IServices;

public interface IUpdateProductService
{
    public ResponseDto<ResponseUpdateProductDto> UpdateProduct(UpdateProductDto updateProductDto);
}
