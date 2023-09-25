using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiteECommerce_TP_.Models
{
    public class Product
    {
        [Column("p_id")]
        public Guid Id { get; set; }

        [Column("p_name")]
        public string Name { get; set; }

        [Column("p_height")]
        public float Height { get; set; }

        [Column("p_lenght")]
        public float Length { get; set; }

        [Column("p_width")]
        public float Width { get; set; }

        [Column("p_weight")]
        public float Weigth { get; set; }

        [Column("p_capacity")]
        public int Capacity { get; set; }

        [Column("p_description")]
        public string Description { get; set; }

        [Column("p_primary_color")]
        public string Color { get; set; }

        [Column("p_constructor")]
        public string Constructor { get; set; }

        [Column("p_price")]
        public float Price { get; set; }

        [Column("p_picture")]
        public string Picture { get; set; }

        [Column("p_order_count")]
        public int OrderCount { get; set; }

        private bool _isActive = true;
        [Column("p_is_active")]
        public bool IsActive
        {
            get 
            { 
                return _isActive; 
            }
            set 
            { 
                _isActive = value; 
            }
        }

        /*                          RELATIONS                           */

        [Column("opinions")]
        public List<Opinion> Opinions { get; set; }

        [Column("orders")]
        public List<Order> Orders { get; set; }
    }
}
