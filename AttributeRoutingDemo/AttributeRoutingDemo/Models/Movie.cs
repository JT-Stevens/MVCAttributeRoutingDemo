using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AttributeRoutingDemo.Models
{
    public class Movie
    {
        [Required]
        [Key]
        public int MovieID { get; set; }

        [Required]
        [Display(Name = "Movie Title")]
        public string MovieTitle { get; set; }

        public virtual ICollection<Actor> Actors { get; set; }


    }
}