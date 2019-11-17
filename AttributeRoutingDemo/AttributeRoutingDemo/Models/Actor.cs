using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AttributeRoutingDemo.Models
{
    public class Actor
    {
        [Required]
        [Key]
        public int ActorID { get; set; }

        [Required]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name ="Last Name")]
        public string LastName { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}