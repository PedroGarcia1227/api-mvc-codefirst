using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("supplier")]
[ApiController]
public class supplierController : ControllerBase
{
    private readonly ApplicationDatabaseContext _context;

    public supplierController(ApplicationDatabaseContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Supplier>>> GetSuppliers()
    {
        var suppliers = await _context.Suppliers.ToListAsync();
        if (suppliers == null || suppliers.Count == 0)
        {
            return NotFound("No suppliers found.");
        }
        return Ok(suppliers);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Supplier>> GetSupplier(int id)
    {
        var supplier = await _context.Suppliers.FindAsync(id);
        if (supplier == null)
        {
            return NotFound();
        }

        return Ok(supplier);
    }

    [HttpPost]
    public async Task<ActionResult<Supplier>> CreateSupplier(Supplier supplier)
    {
        if (supplier == null)
        {
            return BadRequest("supplier is null");
        }

        _context.Suppliers.Add(supplier);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetSupplier), new { id = supplier.SupplierID }, supplier);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Updatesupplier(int id, Supplier supplier)
    {
        if (id != supplier.SupplierID)
        {
            return BadRequest("supplier ID mismatch");
        }

        _context.Entry(supplier).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Suppliers.Any(e => e.SupplierID == id))
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
    public async Task<IActionResult> DeleteSupplier(int id)
    {
        var supplier = await _context.Suppliers.FindAsync(id);
        if (supplier == null)
        {
            return NotFound();
        }

        _context.Suppliers.Remove(supplier);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
