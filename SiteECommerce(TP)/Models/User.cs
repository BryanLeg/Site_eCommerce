using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace SiteECommerce_TP_.Models
{
    public class User
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("mail")]
        public string Name { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("phone_number")]
        public int PhoneNumber { get; set; }

        [Column("firstname")]
        public string Firstname { get; set; }

        [Column("lastname")]
        public string Lastname { get; set; }

        [Column("adress")]
        public string Adress { get; set; }

        [Column("postal_code")]
        public int PostalCode { get; set; }

        [Column("city")]
        public string City { get; set; }

        [Column("country")]
        public string Country { get; set; }

        [DefaultValue("client")]
        [Column("role")]
        public string Role { get; set; }

        [DefaultValue(true)]
        [Column("is_active")]
        public bool IsActive { get; set; }

        /*                          RELATIONS                           */

        [Column("orders")]
        public List<Order> Orders { get; set; }

        [Column("opinions")]
        public List<Opinion> Opinions { get; set; }
    }
}
