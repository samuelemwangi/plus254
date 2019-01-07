namespace App.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
        public short UnitsOnOrder { get; set; }
        public short ReorderLevel { get; set; }
        public bool Discontinued { get; set; }

        //Foreign Key
        public long? CategoryID { get; set; }

        public Category Category { get; set; }
    }
}
