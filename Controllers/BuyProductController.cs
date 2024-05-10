using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Dtos;
using Services;

namespace Controller;

[ApiController]
[Route("api/[controller]")]
public class BuyProductController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ILogger<BuyProductController> _logger;
    private readonly ApplicationDbContext _context;

    public BuyProductController(
        IMapper mapper,
        ILogger<BuyProductController> logger,
        ApplicationDbContext context
    )
    {
        _mapper = mapper;
        _logger = logger;
        _context = context;
    }

    [HttpPost]
    public IActionResult BuyProduct(BuyProductDto buyProductDto)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest();
        }

        ResponseDto<ResponseBuyProductDto> res = new BuyProductService(_mapper, _context).BuyProduct(buyProductDto);
        return Ok(res);
    }
}
