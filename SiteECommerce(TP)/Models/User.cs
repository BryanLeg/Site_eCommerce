using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace SiteECommerce_TP_.Models
{
    public class User
    {
        [Column("u_id")]
        public Guid Id { get; set; }

        [Column("u_mail")]
        public string Name { get; set; }

        [Column("u_password")]
        public string Password { get; set; }

        [Column("u_phone_number")]
        public int PhoneNumber { get; set; }

        [Column("u_firstname")]
        public string Firstname { get; set; }

        [Column("u_lastname")]
        public string Lastname { get; set; }

        [Column("u_adress")]
        public string Adress { get; set; }

        [Column("u_postal_code")]
        public int PostalCode { get; set; }

        [Column("u_city")]
        public string City { get; set; }

        [Column("u_country")]
        public string Country { get; set; }

        [DefaultValue("client")]
        [Column("u_role")]
        public string Role { get; set; }

        [DefaultValue(true)]
        [Column("u_is_active")]
        public bool IsActive { get; set; }

        /*                          RELATIONS                           */

        [Column("orders")]
        public List<Order> Orders { get; set; }

        [Column("opinions")]
        public List<Opinion> Opinions { get; set; }
    }
}
