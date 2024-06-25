using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("shipper")]
[ApiController]
public class shipperController : ControllerBase
{
    private readonly ApplicationDatabaseContext _context;

    public shipperController(ApplicationDatabaseContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Shipper>>> GetShippers()
    {
        var shippers = await _context.Shippers.ToListAsync();
        if (shippers == null || shippers.Count == 0)
        {
            return NotFound("No shippers found.");
        }
        return Ok(shippers);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Shipper>> GetShipper(int id)
    {
        var shipper = await _context.Shippers.FindAsync(id);
        if (shipper == null)
        {
            return NotFound();
        }

        return Ok(shipper);
    }

    [HttpPost]
    public async Task<ActionResult<Shipper>> Createshipper(Shipper shipper)
    {
        if (shipper == null)
        {
            return BadRequest("shipper is null");
        }

        _context.Shippers.Add(shipper);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetShipper), new { id = shipper.ShipperID }, shipper);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateShipper(int id, Shipper shipper)
    {
        if (id != shipper.ShipperID)
        {
            return BadRequest("shipper ID mismatch");
        }

        _context.Entry(shipper).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Shippers.Any(e => e.ShipperID == id))
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
    public async Task<IActionResult> DeleteShipper(int id)
    {
        var shipper = await _context.Shippers.FindAsync(id);
        if (shipper == null)
        {
            return NotFound();
        }

        _context.Shippers.Remove(shipper);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
