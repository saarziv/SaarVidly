using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class NewRentalDto
    {
        public int CustomerId { get; set; }
        public List<int> MoviesId { get; set; }
    }
}