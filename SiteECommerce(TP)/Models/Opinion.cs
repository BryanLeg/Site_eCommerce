using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiteECommerce_TP_.Models
{
    public class Opinion
    {
        [Column("op_id")]
        public Guid Id { get; set; }

        [Column("op_content")]
        public string Content { get; set; }

        private bool _isVisible = false;
        [Column("op_is_visible")]
        public bool IsVisible 
        { 
            get
            {
                return _isVisible;
            }
            set
            {
                _isVisible = value;
            }
        }

        [Column("op_rating")]
        public int Rating { get; set; }

        [Column("op_user")]
        public User User { get; set; }

        [Column("op_product")]
        public Product Product { get; set; }
    }
}
