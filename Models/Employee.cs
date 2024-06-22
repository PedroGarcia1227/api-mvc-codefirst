public class Employee
{
    public required int EmployeeID { get; set; }
    public required string Name { get; set; }
    public required DateOnly BirthDate { get; set; }
    public required DateOnly HireDate { get; set; }
    public required string Address {get; set; }
    public required string City{ get; set; }
    public required string State { get; set; }
    public required string PostalCode { get; set; }
    public required string Phone { get; set; }
    public int ReportTo { get; set; }

    public decimal CalculateSalesComission(List<SalesOrder> salesOrders)
    {
        decimal salesComissionTotal = 0.0M;

        foreach (var salesOrder in salesOrders)
        {
            if (salesOrder.EmployeeID == EmployeeID)
            {
                salesComissionTotal += 0.05M * salesOrder.Total;
            }
        }

        return Math.Round(salesComissionTotal, 2);
    }
}