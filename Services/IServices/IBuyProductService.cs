using Models.Dtos;

namespace Services.IServices;

public interface IBuyProductService
{
    public ResponseDto<ResponseBuyProductDto> BuyProduct(BuyProductDto buyProductDto);
}
