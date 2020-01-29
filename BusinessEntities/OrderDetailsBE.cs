namespace BusinessEntities
{
    public class OrderDetailsBE
    {
        public int OrderId { get; set; }
        public string ProductName { get; set; }
        public int ProductId { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
        public double Total { get; set; }
    }
}