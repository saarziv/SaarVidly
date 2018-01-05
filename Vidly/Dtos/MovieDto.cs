using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        public byte GenreId { get; set; }

        public GenreDto Genre { get; set; }

        public DateTime DateAdded { get; set; }
        
        public DateTime ReleaseDate { get; set; }
        
        [Range(1, 20)]
        public int NumberInStock { get; set; }

        [Display(Name = "Availability")]
        public int Availability { get; set; }
    }
}