using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("productCategories")]
[ApiController]
public class ProductCategoryController : ControllerBase
{
    private readonly ApplicationDatabaseContext _context;

    public ProductCategoryController(ApplicationDatabaseContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductCategory>>> GetProductCategories()
    {
        var productCategories = await _context.ProductCategories.ToListAsync();
        if (productCategories == null || productCategories.Count == 0)
        {
            return NotFound("No Product Categories found.");
        }
        return Ok(productCategories);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductCategory>> GetProductCategory(int id)
    {
        var productCategory = await _context.ProductCategories.FindAsync(id);
        if (productCategory == null)
        {
            return NotFound();
        }

        return Ok(productCategory);
    }

    [HttpPost]
    public async Task<ActionResult<ProductCategory>> CreateProductCategory(ProductCategory productCategory)
    {
        if (productCategory == null)
        {
            return BadRequest("ProductCategory is null");
        }

        _context.ProductCategories.Add(productCategory);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetProductCategory), new { id = productCategory.ProductCategoryID }, productCategory);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProductCategory(int id, ProductCategory productCategory)
    {
        if (id != productCategory.ProductCategoryID)
        {
            return BadRequest("ProductCategory ID mismatch");
        }

        _context.Entry(productCategory).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.ProductCategories.Any(e => e.ProductCategoryID == id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProductCategory(int id)
    {
        var productCategory = await _context.ProductCategories.FindAsync(id);
        if (productCategory == null)
        {
            return NotFound();
        }

        _context.ProductCategories.Remove(productCategory);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
