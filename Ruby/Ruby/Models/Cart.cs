namespace Ruby.Models
{
    public class Cart
    {
        public Cart()
        {
            CartLines = new List<Property>();
        }
        public List<Property> CartLines { get; set; }

        public decimal FinalPrice
        {
            get 
            {
                decimal sum = 0;
                foreach (Property property in CartLines)
                {
                    sum += property.Price;
                }
                return sum;
            }
        }

    }
}
