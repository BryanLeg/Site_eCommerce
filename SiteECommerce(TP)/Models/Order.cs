using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiteECommerce_TP_.Models
{
    public class Order
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("order_date")]
        public DateTime OrderDate { get; set; }

        [Column("delivery_date")]
        public DateTime DeliveryDate { get; set; }

        [Column("receipt_date")]
        public DateTime ReceiptDate { get; set; }

        [Column("price")]
        public int Price { get; set; }

        [DefaultValue("in progress")]
        [Column("status")]
        public string Status { get; set; }

        [Column("user")]
        public User User { get; set; }

        /*                          RELATIONS                           */

        [Column("ordered_products")]
        public List<Product> OrderedProducts { get; set; }
    }
}
