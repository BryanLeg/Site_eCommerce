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
        public string Mail { get; set; }

        [Column("u_password")]
        public string Password { get; set; }

        [Column("u_phone_number")]
        public string PhoneNumber { get; set; }

        [Column("u_firstname")]
        public string Firstname { get; set; }

        [Column("u_lastname")]
        public string Lastname { get; set; }

        [Column("u_address")]
        public string Address { get; set; }

        [Column("u_postal_code")]
        public string PostalCode { get; set; }

        [Column("u_city")]
        public string City { get; set; }

        [Column("u_country")]
        public string Country { get; set; }

        private string _role = "Client";
        [Column("u_role")]
        public string Role 
        { 
            get
            {
                return _role;
            }
            set
            {
                _role = value;
            }
        }

        private bool _isActive = true;
        [Column("u_is_active")]
        public bool IsActive { 
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

        [Column("orders")]
        public List<Order> Orders { get; set; }

        [Column("opinions")]
        public List<Opinion> Opinions { get; set; }
    }
}
