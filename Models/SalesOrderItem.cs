public class SalesOrderItem
{
    public required int SalesOrderID { get; set; }
    public required int ProductID { get; set; }
    public required int Quantity { get; set; }
    public required decimal UnitPrice { get; set; }
    public required decimal Discount { get; set; }
    public required SalesOrder SalesOrder { get; set; }
}