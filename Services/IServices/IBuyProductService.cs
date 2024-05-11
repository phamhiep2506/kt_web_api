using Models.Dtos;

namespace Services.IServices;

public interface IBuyProductService
{
    public ResponseDto BuyProduct(BuyProductDto buyProductDto);
}
