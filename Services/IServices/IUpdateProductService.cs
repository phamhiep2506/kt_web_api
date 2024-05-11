using Models.Dtos;

namespace Services.IServices;

public interface IUpdateProductService
{
    public ResponseDto UpdateProduct(UpdateProductDto updateProductDto);
}
