using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;
using System.ComponentModel.DataAnnotations;


namespace Vidly.ViewModels
{
    public class MoviesFormViewModel
    {
        public byte? Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }
        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }
        [Required]
        [Range(1, 20)]
        [Display(Name = "Number In Stock")]
        public int? NumberInStock { get; set; }
        public MoviesFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            GenreId = movie.GenreId;
            NumberInStock = movie.NumberInStock;
        }
        public MoviesFormViewModel()
        {
            Id = 0;
        }
        public IEnumerable<Genre> Genres { get; set; }
        public string Title 
        {
            get
            {
                return  (Id != 0) ?  "Edit Movie":  "New Movie";
            }
        }
    }
}