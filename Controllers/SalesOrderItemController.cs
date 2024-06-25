using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("salesOrderItems")]
[ApiController]
public class SalesOrderItemController : ControllerBase
{
    private readonly ApplicationDatabaseContext _context;

    public SalesOrderItemController(ApplicationDatabaseContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SalesOrderItem>>> GetsalesOrderItems()
    {
        var salesOrderItems = await _context.SalesOrderItems.ToListAsync();
        if (salesOrderItems == null || salesOrderItems.Count == 0)
        {
            return NotFound("No salesOrderItems found.");
        }
        return Ok(salesOrderItems);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SalesOrderItem>> GetSalesOrderItem(int id)
    {
        var salesOrderItem = await _context.SalesOrderItems.FindAsync(id);
        if (salesOrderItem == null)
        {
            return NotFound();
        }

        return Ok(salesOrderItem);
    }

    [HttpPost]
    public async Task<ActionResult<SalesOrderItem>> CreateSalesOrderItem(SalesOrderItem salesOrderItem)
    {
        _context.SalesOrderItems.Add(salesOrderItem);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetSalesOrderItem), new { salesOrderId = salesOrderItem.SalesOrderID, productId = salesOrderItem.ProductID }, salesOrderItem);
    }

    [HttpPut("{salesOrderId}/{productId}")]
    public async Task<IActionResult> UpdateSalesOrderItem(int salesOrderId, int productId, SalesOrderItem salesOrderItem)
    {
        if (salesOrderId != salesOrderItem.SalesOrderID || productId != salesOrderItem.ProductID)
        {
            return BadRequest("SalesOrderItem ID mismatch");
        }

        _context.Entry(salesOrderItem).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.SalesOrderItems.Any(e => e.SalesOrderID == salesOrderId && e.ProductID == productId))
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

    [HttpDelete("{salesOrderId}/{productId}")]
    public async Task<IActionResult> DeleteSalesOrderItem(int salesOrderId, int productId)
    {
        var salesOrderItem = await _context.SalesOrderItems
            .FirstOrDefaultAsync(e => e.SalesOrderID == salesOrderId && e.ProductID == productId);

        if (salesOrderItem == null)
        {
            return NotFound();
        }

        _context.SalesOrderItems.Remove(salesOrderItem);
        await _context.SaveChangesAsync();

        return NoContent();
    }

}
