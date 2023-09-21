using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiteECommerce_TP_.Models
{
    public class Order
    {
        [Column("ord_id")]
        public Guid Id { get; set; }

        [Column("ord_order_date")]
        public DateTime OrderDate { get; set; }

        [Column("ord_delivery_date")]
        public DateTime DeliveryDate { get; set; }

        [Column("ord_receipt_date")]
        public DateTime ReceiptDate { get; set; }

        [Column("ord_price")]
        public int Price { get; set; }

        [DefaultValue("in progress")]
        [Column("ord_status")]
        public string Status { get; set; }

        [Column("ord_user")]
        public User User { get; set; }

        /*                          RELATIONS                           */

        [Column("ordered_products")]
        public List<Product> OrderedProducts { get; set; }
    }
}
