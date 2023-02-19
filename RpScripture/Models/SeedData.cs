using Microsoft.EntityFrameworkCore;
using RpScripture.Data;

namespace RpScripture.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new RpScriptureContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<RpScriptureContext>>()))
        {
            if (context == null || context.Scripture == null)
            {
                throw new ArgumentNullException("Null RpScriptureContext");
            }

            // Look for any movies.
            if (context.Scripture.Any())
            {
                return;   // DB has been seeded
            }

            context.Scripture.AddRange(
                    new Scripture
                    {
                        Book = "Moses",
                        Chapter = "1",
                        Verse = "39",
                        Notes = "This is my work and my glory",
                        EntryDate = DateTime.Parse("2023-2-17")
                    },

                    new Scripture
                    {
                        Book = "James",
                        Chapter = "1",
                        Verse = "5",
                        Notes = "If any of you lack wisdom, let him ask of God.",
                        EntryDate = DateTime.Parse("2022-2-17")
                    },

                    new Scripture
                    {
                        Book = "Alma",
                        Chapter = "32",
                        Verse = "21",
                        Notes = "If ye have faith ye hope for things which are not seen, which are true.",
                        EntryDate = DateTime.Parse("2021-2-17")
                    },

                    new Scripture
                    {
                        Book = "Ether",
                        Chapter = "12",
                        Verse = "27",
                        Notes = " If men come unto me I will show unto them their weakness",
                        EntryDate = DateTime.Parse("2020-2-17")
                    }
                );
            context.SaveChanges();
        }
    }
}

