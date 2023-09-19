using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiteECommerce_TP_.Models
{
    public class Opinion
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("content")]
        public string Content { get; set; }

        [DefaultValue(false)]
        [Column("is_visible")]
        public bool IsVisible { get; set; }

        [Column("rating")]
        public int Rating { get; set; }

        [Column("User")]
        public User User { get; set; }

        [Column("Product")]
        public Product Product { get; set; }
    }
}
