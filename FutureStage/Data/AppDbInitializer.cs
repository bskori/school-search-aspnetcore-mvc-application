using FutureStage.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FutureStage.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using(var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Country
                if (!context.Countries.Any())
                {
                    context.Countries.AddRange(new List<Country>()
                    {
                        new Country()
                        {
                            CountryName = "India"
                        },
                        new Country()
                        {
                            CountryName = "USA"
                        },
                        new Country()
                        {
                            CountryName = "China"
                        },
                        new Country()
                        {
                            CountryName = "Australia"
                        },
                        new Country()
                        {
                            CountryName = "China"
                        },
                        new Country()
                        {
                            CountryName = "Japan"
                        },
                        new Country()
                        {
                            CountryName = "Indonesia"
                        },
                        new Country()
                        {
                            CountryName = "Africa"
                        },
                        new Country()
                        {
                            CountryName = "Brazil"
                        },
                        new Country()
                        {
                            CountryName = "Germany"
                        },
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
