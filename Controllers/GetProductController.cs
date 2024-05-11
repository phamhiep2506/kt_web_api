using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Dtos;
using Services;

namespace Controller;

[ApiController]
[Route("api/[controller]")]
public class GetProductController : ControllerBase
{
    private readonly ILogger<BuyProductController> _logger;
    private readonly ApplicationDbContext _context;

    public GetProductController(
        ILogger<BuyProductController> logger,
        ApplicationDbContext context
    )
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    public IActionResult GetProduct()
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        ResponseDto res = new GetProductService(_context).GetProduct();
        return Ok(res);
    }
}
