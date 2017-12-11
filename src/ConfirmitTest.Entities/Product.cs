namespace ConfirmitTest.Entities
{
    public class Product
    {
        public int VendorCode { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }

        public static bool operator==(Product first, Product second)
        {
            if (ReferenceEquals(null, first) && !ReferenceEquals(null, second) || 
                ReferenceEquals(null, second) && !ReferenceEquals(null, first))
                return false;
            if (ReferenceEquals(first, second))
                return true;

            return first.Equals(second);
        }

        public static bool operator !=(Product first, Product second)
        {
            return !(first == second);
        }

        protected bool Equals(Product other)
        {
            return VendorCode == other.VendorCode;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Product) obj);
        }

        public override int GetHashCode()
        {
            return VendorCode.GetHashCode();
        }
    }
}