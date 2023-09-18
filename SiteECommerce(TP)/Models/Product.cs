using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiteECommerce_TP_.Models
{
    public class Product
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("height")]
        public float Height { get; set; }

        [Column("lenght")]
        public float Length { get; set; }

        [Column("width")]
        public float Width { get; set; }

        [Column("weight")]
        public float Weigth { get; set; }

        [Column("capacity")]
        public int Capacity { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("primary_color")]
        public string Color { get; set; }

        [Column("constructor")]
        public string Constructor { get; set; }

        [Column("price")]
        public float Price { get; set; }

        [Column("picture")]
        public string Picture { get; set; }

        [Column("order_count")]
        public int OrderCount { get; set; }

        [DefaultValue(true)]
        [Column("is_active")]
        public bool IsActive { get; set; }
    }
}
