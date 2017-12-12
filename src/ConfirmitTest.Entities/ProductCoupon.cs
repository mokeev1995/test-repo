namespace ConfirmitTest.Entities
{
    public class ProductCoupon
    {
        public string Key { get; set; }
        public uint Value { get; set; }
        public Product Product { get; set; }
    }
}