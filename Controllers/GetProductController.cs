using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Dtos;
using Services;

namespace Controller;

[ApiController]
[Route("api/[controller]")]
public class GetProductController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ILogger<BuyProductController> _logger;
    private readonly ApplicationDbContext _context;

    public GetProductController(
        IMapper mapper,
        ILogger<BuyProductController> logger,
        ApplicationDbContext context
    )
    {
        _mapper = mapper;
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    public IActionResult GetProduct()
    {
        if(!ModelState.IsValid)
        {
            return BadRequest();
        }

        ResponseDto<ResponseGetProductDto> res = new GetProductService(_mapper, _context).GetProduct();
        return Ok(res);
    }
}
