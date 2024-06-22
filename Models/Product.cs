public class Product
{
    public required int ProductID
    {
        get;
        set;
    }

    public required int ProductCategoryID
    {
        get;
        set;
    }

    public required string Name
    {
        get;
        set;
    }

    public required decimal UnitPrice
    {
        get;
        set;
    }

    public required int UnitsInStock
    {
        get;
        set;
    }

    public required bool Discontinued
    {
        get;
        set;
    }
}