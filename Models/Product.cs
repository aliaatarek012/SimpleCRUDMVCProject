using System.ComponentModel;

namespace ITIFinalProject.Models
{
    public class Product
    {
        /*----------------------------------------------------*/
        public int ProductId { get; set; }
        [DisplayName("Product Name")]
        public string Title { get; set; }
        [DisplayName("Product Price")]
        public int Price { get; set; }
        [DisplayName("Product Description")]
        public string? Description { get; set; }
        [DisplayName("Product Quantity")]
        public int Quantity { get; set; }
        [DisplayName("Product ImagePath")]
        public string? ImagePath { get; set; }

        /*----------------------------------------------------*/

        // one to Many
        // Category have many Products
        // FK
        public int CategoryId { get; set; }
        // Navigation Property
        public Category Category { get; set; }

    }
}
