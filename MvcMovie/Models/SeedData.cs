using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcMovieContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcMovieContext>>()))
        {
            // Look for any movies.
            if (context.Movie.Any())
            {
                return;   // DB has been seeded
            }
            context.Movie.AddRange(
                new Movie
                {
                    Title = "The Cokeville Miracle",
                    ReleaseDate = DateTime.Parse("2015-9-8"),
                    Genre = "Drama",
                    Price = 15.89M,
                    Rating = "PG-13"
                },
                new Movie
                {
                    Title = "The Other Side of Heaven ",
                    ReleaseDate = DateTime.Parse("2003-4-1"),
                    Genre = "Drama",
                    Price = 13.71M,
                    Rating = "PG"
                },
                new Movie
                {
                    Title = "Meet the Mormons",
                    ReleaseDate = DateTime.Parse("2014-10-10"),
                    Genre = "Documentary",
                    Price = 6.61M,
                    Rating = "PG"
                },
                new Movie
                {
                    Title = "Mr. Krueger's Christmas",
                    ReleaseDate = DateTime.Parse("1980-12-21"),
                    Genre = "Family",
                    Price = 29.90M,
                    Rating = "Not Rated"
                }
            );
            context.SaveChanges();
        }
    }
}
