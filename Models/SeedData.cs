using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcPasteBin.Data;
using System;
using System.Linq;

namespace MvcPasteBin.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcPasteBinContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcPasteBinContext>>()))
        {
            // Look for any movies.
            if (context.PasteBin.Any())
            {
                return;   // DB has been seeded
            }
            context.PasteBin.AddRange(
                new PasteBin
                {
                    Url = "When Harry Met Sally",
                    CreateDate = DateTime.Parse("1989-2-12"),
                    Paste = "Romantic Comedy"
                },
                new PasteBin
                {
                    Url = "Ghostbusters ",
                    CreateDate = DateTime.Parse("1984-3-13"),
                    Paste = "Comedy"
                },
                new PasteBin
                {
                    Url = "Ghostbusters 2",
                    CreateDate = DateTime.Parse("1986-2-23"),
                    Paste = "Comedy"
                },
                new PasteBin
                {
                    Url = "Rio Bravo",
                    CreateDate = DateTime.Parse("1959-4-15"),
                    Paste = "Western"
                }
            );
            context.SaveChanges();
        }
    }
}