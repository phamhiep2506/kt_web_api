using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Dtos;
using Services;

namespace Controller;

[ApiController]
[Route("api/[controller]")]
public class UpdateProductController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ILogger<BuyProductController> _logger;
    private readonly ApplicationDbContext _context;

    public UpdateProductController(
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
    public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        ResponseDto<ResponseUpdateProductDto> res = new UpdateProductService(
            _mapper,
            _context
        ).UpdateProduct(updateProductDto);
        return Ok(res);
    }
}
