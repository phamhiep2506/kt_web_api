using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Dtos;
using Services;

namespace Controller;

[ApiController]
[Route("api/[controller]")]
public class BuyProductController : ControllerBase
{
    private readonly ILogger<BuyProductController> _logger;
    private readonly ApplicationDbContext _context;

    public BuyProductController(
        ILogger<BuyProductController> logger,
        ApplicationDbContext context
    )
    {
        _logger = logger;
        _context = context;
    }

    [HttpPost]
    public IActionResult BuyProduct(BuyProductDto buyProductDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        ResponseDto res = new BuyProductService(_context).BuyProduct(
            buyProductDto
        );
        return Ok(res);
    }
}
