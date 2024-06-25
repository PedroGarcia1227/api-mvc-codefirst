using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("salesOrders")]
[ApiController]
public class salesOrderController : ControllerBase
{
    private readonly ApplicationDatabaseContext _context;

    public salesOrderController(ApplicationDatabaseContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SalesOrder>>> GetSalesOrders()
    {
        var salesOrders = await _context.SalesOrders.ToListAsync();
        if (salesOrders == null || salesOrders.Count == 0)
        {
            return NotFound("No salesOrders found.");
        }
        return Ok(salesOrders);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SalesOrder>> GetSalesOrder(int id)
    {
        var salesOrder = await _context.SalesOrders.FindAsync(id);
        if (salesOrder == null)
        {
            return NotFound();
        }

        return Ok(salesOrder);
    }

    [HttpPost]
    public async Task<ActionResult<SalesOrder>> CreateSalesOrder(SalesOrder salesOrder)
    {
        if (salesOrder == null)
        {
            return BadRequest("salesOrder is null");
        }

        _context.SalesOrders.Add(salesOrder);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetSalesOrder), new { id = salesOrder.SalesOrderID }, salesOrder);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateSalesOrder(int id, SalesOrder salesOrder)
    {
        if (id != salesOrder.SalesOrderID)
        {
            return BadRequest("salesOrder ID mismatch");
        }

        _context.Entry(salesOrder).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.SalesOrders.Any(e => e.SalesOrderID == id))
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
    public async Task<IActionResult> DeleteSalesOrder(int id)
    {
        var salesOrder = await _context.SalesOrders.FindAsync(id);
        if (salesOrder == null)
        {
            return NotFound();
        }

        _context.SalesOrders.Remove(salesOrder);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
