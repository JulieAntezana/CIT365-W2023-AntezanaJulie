﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Net.WebRequestMethods;
using Microsoft.AspNetCore.Http;

namespace MvcMovie.Models;

public class Movie
{
    public int Id { get; set; }

    [StringLength(60, MinimumLength = 3)]
    [Required(ErrorMessage = "Title is required")]
    public string? Title { get; set; }
    

    [Display(Name = "Release Date"), DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [Required(ErrorMessage = "Release date is required")]
    public DateTime ReleaseDate { get; set; }

    [Range(1, 100), DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18, 2)")]
    [Required(ErrorMessage = "Price is required")]
    public decimal Price { get; set; }

    [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$"), StringLength(30)]
    [Required(ErrorMessage = "Genre is required")]
    public string? Genre { get; set; }


    [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$"), StringLength(9)]
    [Required(ErrorMessage = "Rating is required")]
    public string? Rating { get; set; }


    [Display(Name = "IMDB ID")]
    public string? IMDB_ID { get; set; }
}
