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
                    Rating = "PG-13",
                    IMDB_ID = "tt3877296"
                },
                new Movie
                {
                    Title = "17 Miracles",
                    ReleaseDate = DateTime.Parse("2011-6-03"),
                    Genre = "History",
                    Price = 5.99M,
                    Rating = "PG",
                    IMDB_ID = "tt1909270"
                },
                new Movie
                {
                    Title = "The Other Side of Heaven ",
                    ReleaseDate = DateTime.Parse("2003-4-1"),
                    Genre = "Drama",
                    Price = 13.71M,
                    Rating = "PG",
                    IMDB_ID = "tt0250371"
                },
                new Movie
                {
                    Title = "The Best Two Years",
                    ReleaseDate = DateTime.Parse("2004-2-20"),
                    Genre = "Comedy",
                    Price = 2.99M,
                    Rating = "PG",
                    IMDB_ID = "tt0377038"
                },
                new Movie
                {
                    Title = "Meet the Mormons",
                    ReleaseDate = DateTime.Parse("2014-10-10"),
                    Genre = "Documentary",
                    Price = 6.61M,
                    Rating = "PG",
                    IMDB_ID = "tt4003774"
                },
                new Movie
                {
                    Title = "The Saratov Approach",
                    ReleaseDate = DateTime.Parse("2013-10-09"),
                    Genre = "Drama",
                    Price = 9.99M,
                    Rating = "PG-13",
                    IMDB_ID = "tt2887322"
                },
                new Movie
                {
                    Title = "Mr. Krueger's Christmas",
                    ReleaseDate = DateTime.Parse("1980-12-21"),
                    Genre = "Family",
                    Price = 29.90M,
                    Rating = "Not Rated",
                    IMDB_ID = "tt0081190"
                }
            );
            context.SaveChanges();
        }
    }
}
