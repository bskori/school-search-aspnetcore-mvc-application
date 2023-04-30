﻿using FutureStage.Models;
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
                            CountryName = "India",
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

                //State
                if (!context.States.Any())
                {
                    context.States.AddRange(new List<State>() 
                    { 
                        new State()
                        {
                            StateName = "Maharashtra",
                            CountryID = 11
                        },
                        new State()
                        {
                            StateName = "Uttar Pradesh",
                            CountryID = 11
                        },
                        new State()
                        {
                            StateName = "Madhya Pradesh",
                            CountryID = 11
                        },
                        new State()
                        {
                            StateName = "Banglore",
                            CountryID = 11
                        },
                        new State()
                        {
                            StateName = "Karnatka",
                            CountryID = 11
                        },
                        new State()
                        {
                            StateName = "Hyderabad",
                            CountryID = 11
                        },
                        new State()
                        {
                            StateName = "Rajasthan",
                            CountryID = 11
                        },
                    });
                    context.SaveChanges();
                }

                //City
                if (!context.Cities.Any())
                {
                    context.Cities.AddRange(new List<City>() { 
                        new City()
                        {
                            CityName = "Mumbai",
                            StateID = 1
                        },
                        new City()
                        {
                            CityName = "Banglore",
                            StateID = 5
                        },
                        new City()
                        {
                            CityName = "Pune",
                            StateID = 1
                        },
                        new City()
                        {
                            CityName = "Lucknow",
                            StateID = 2
                        },
                        new City()
                        {
                            CityName = "Ghaziabad",
                            StateID = 2
                        },
                        new City()
                        {
                            CityName = "Kanpur",
                            StateID = 2
                        },
                        new City()
                        {
                            CityName = "Indore",
                            StateID = 3
                        },
                        new City()
                        {
                            CityName = "Bhopal",
                            StateID = 3
                        },
                    });
                    context.SaveChanges();
                }

                //Area
                if (!context.Areas.Any())
                {
                    context.Areas.AddRange(new List<Area>()
                    {
                        new Area()
                        {
                            AreaName = "Pimpri-Chinchwad",
                            CityID = 3
                        },
                        new Area()
                        {
                            AreaName = "Hadapsar",
                            CityID = 3
                        },
                        new Area()
                        {
                            AreaName = "Viman Nagar",
                            CityID = 3
                        },
                        new Area()
                        {
                            AreaName = "Andheri",
                            CityID = 1
                        },
                        new Area()
                        {
                            AreaName = "Bandra",
                            CityID = 1
                        },
                        new Area()
                        {
                            AreaName = "Goregaon",
                            CityID = 1
                        },
                        new Area()
                        {
                            AreaName = "Whitefield",
                            CityID = 2
                        },
                        new Area()
                        {
                            AreaName = "Indiranagar",
                            CityID = 2
                        },
                        new Area()
                        {
                            AreaName = "Hazratganj",
                            CityID = 4
                        },
                        new Area()
                        {
                            AreaName = "Gomti Nagar",
                            CityID = 4
                        },
                        new Area()
                        {
                            AreaName = "Vijay Nagar",
                            CityID = 3
                        },
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}