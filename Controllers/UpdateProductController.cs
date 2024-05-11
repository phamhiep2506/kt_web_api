using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Dtos;
using Services;

namespace Controller;

[ApiController]
[Route("api/[controller]")]
public class UpdateProductController : ControllerBase
{
    private readonly ILogger<BuyProductController> _logger;
    private readonly ApplicationDbContext _context;

    public UpdateProductController(
        ILogger<BuyProductController> logger,
        ApplicationDbContext context
    )
    {
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

        ResponseDto res = new UpdateProductService(_context).UpdateProduct(
            updateProductDto
        );
        return Ok(res);
    }
}
