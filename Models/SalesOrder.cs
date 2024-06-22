public class SalesOrder
{
    public required int SalesOrderID { get; set; }
    public required int CustomerID { get; set; }
    public required int EmployeeID { get; set; }
    public required int ShipperID { get; set; }
    public required DateTime OrderDate { get; set; }
    public DateTime EstimatedDeliveryDate { get; set; }
    public required decimal Freight { get; set; }
    public required decimal Total { get; set; }
    public List<SalesOrderItem> SalesOrderItems { get; set; }

    public SalesOrder()
    {
        SalesOrderItems = new List<SalesOrderItem>();
    }

    public bool AddItem(SalesOrderItem item)
    {
        if (item == null)
        {
            return false;
        }

        SalesOrderItems.Add(item);
        return true;
    }

    public bool RemoveItem(SalesOrderItem item)
    {
        if (item == null || !SalesOrderItems.Contains(item))
        {
            return false;
        }

        SalesOrderItems.Remove(item);
        return true;
    }

    public double CalculateSalesOrderTotal()
    {
        double total = 0.0;

        foreach (var item in SalesOrderItems)
        {
            total += (double)(item.Quantity * item.UnitPrice);
        }

        total += (double)Freight;
        return total;
    }
}