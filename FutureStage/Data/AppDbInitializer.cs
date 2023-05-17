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
                            CountryID = 1
                        },
                        new State()
                        {
                            StateName = "Uttar Pradesh",
                            CountryID = 1
                        },
                        new State()
                        {
                            StateName = "Madhya Pradesh",
                            CountryID = 1
                        },
                        new State()
                        {
                            StateName = "Banglore",
                            CountryID = 1
                        },
                        new State()
                        {
                            StateName = "Karnatka",
                            CountryID = 1
                        },
                        new State()
                        {
                            StateName = "Hyderabad",
                            CountryID = 1
                        },
                        new State()
                        {
                            StateName = "Rajasthan",
                            CountryID = 1
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
                            StateID = 7
                        },
                        new City()
                        {
                            CityName = "Banglore",
                            StateID = 4
                        },
                        new City()
                        {
                            CityName = "Pune",
                            StateID = 1
                        },
                        new City()
                        {
                            CityName = "Lucknow",
                            StateID = 6
                        },
                        new City()
                        {
                            CityName = "Ghaziabad",
                            StateID = 6
                        },
                        new City()
                        {
                            CityName = "Kanpur",
                            StateID = 6
                        },
                        new City()
                        {
                            CityName = "Indore",
                            StateID = 5
                        },
                        new City()
                        {
                            CityName = "Bhopal",
                            StateID = 5
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
                            CityID = 6
                        },
                        new Area()
                        {
                            AreaName = "Hadapsar",
                            CityID = 6
                        },
                        new Area()
                        {
                            AreaName = "Viman Nagar",
                            CityID = 6
                        },
                        new Area()
                        {
                            AreaName = "Andheri",
                            CityID = 8
                        },
                        new Area()
                        {
                            AreaName = "Bandra",
                            CityID = 8
                        },
                        new Area()
                        {
                            AreaName = "Goregaon",
                            CityID = 8
                        },
                        new Area()
                        {
                            AreaName = "Whitefield",
                            CityID = 7
                        },
                        new Area()
                        {
                            AreaName = "Indiranagar",
                            CityID = 2
                        },
                        new Area()
                        {
                            AreaName = "Hazratganj",
                            CityID = 3
                        },
                        new Area()
                        {
                            AreaName = "Gomti Nagar",
                            CityID = 2
                        },
                        new Area()
                        {
                            AreaName = "Vijay Nagar",
                            CityID = 3
                        },
                    });
                    context.SaveChanges();
                }

                //Facility
                if (!context.Facilities.Any())
                {
                    context.Facilities.AddRange(new List<Facility>()
                    {
                        new Facility()
                        {
                            FacilityTitle = "AC Classes",
                            FacilityDescription = "AC Classes"
                        },
                        new Facility()
                        {
                            FacilityTitle = "Wifi",
                            FacilityDescription = "Wifi"
                        },
                        new Facility()
                        {
                            FacilityTitle = "Smart Classes",
                            FacilityDescription = "Smart Classes"
                            
                        },
                        new Facility()
                        {
                            FacilityTitle = "Boys Hostel",
                            FacilityDescription = "Boys Hostel"
                        },
                        new Facility()
                        {
                            FacilityTitle = "Girls Hostel",
                            FacilityDescription = "Girls Hostel"
                        },
                        new Facility()
                        {
                            FacilityTitle = "Indoor Sports",
                            FacilityDescription = "Indoor Sports"
                        },
                        new Facility()
                        {
                            FacilityTitle = "Outdoor Sports",
                            FacilityDescription = "Outdoor Sports"
                        },
                        new Facility()
                        {
                            FacilityTitle = "Transportation",
                            FacilityDescription = "Transportation"
                        },
                        new Facility()
                        {
                            FacilityTitle = "Gym",
                            FacilityDescription = "Gym"
                        },
                        new Facility()
                        {
                            FacilityTitle = "Cafeteria/Canteen",
                            FacilityDescription="Cafeteria/Canteen"
                        },
                        new Facility()
                        {
                            FacilityTitle = "Computer Lab",
                            FacilityDescription="Computer Lab"
                        },
                        new Facility()
                        {
                            FacilityTitle = "Science Lab",
                            FacilityDescription="Science Lab"
                        },
                        new Facility()
                        {
                            FacilityTitle = "CCTV",
                            FacilityDescription = "CCTV"
                        },
                        new Facility()
                        {
                            FacilityTitle = "Playground",
                            FacilityDescription = "Playground"
                        },
                        new Facility()
                        {
                            FacilityTitle = "Library/Reading Room",
                            FacilityDescription = "Library/Reading Room"
                        },
                        new Facility()
                        {
                            FacilityTitle = "Day Care",
                            FacilityDescription = "Day Care" 
                        },
                        new Facility()
                        {
                            FacilityTitle = "Dance",
                            FacilityDescription = "Dance"
                        },
                    });
                    context.SaveChanges();
                }

                //Standard
                if (!context.Standards.Any())
                {
                    context.Standards.AddRange(new List<Standard>() { 
                        new Standard()
                        {
                            StandardTitle = "Pre Nursery",
                            StandardDescription = "Pre Nursery"
                        },
                        new Standard()
                        {
                            StandardTitle = "LKG",
                            StandardDescription = "LKG"
                        },
                        new Standard()
                        {
                            StandardTitle = "UKG",
                            StandardDescription = "UKG"
                        },
                        new Standard()
                        {
                            StandardTitle = "Class 1",
                            StandardDescription = "Class 1"
                        },
                        new Standard()
                        {
                            StandardTitle = "Class 2",
                            StandardDescription = "Class 2"
                        },
                        new Standard()
                        {
                            StandardTitle = "Class 3",
                            StandardDescription = "Class 3"
                        },
                    });
                    context.SaveChanges();
                }

                //EducationBoard
                if (!context.EducationBoards.Any())
                {
                    context.EducationBoards.AddRange(new List<EducationBoard>() { 
                        new EducationBoard()
                        {
                            EducationBoardTitle = "CBSE",
                            EducationBoardDescription = "CBSE"
                        },
                        new EducationBoard()
                        {
                            EducationBoardTitle = "ICSE",
                            EducationBoardDescription = "ICSE"
                        },
                        new EducationBoard()
                        {
                            EducationBoardTitle = "State Board",
                            EducationBoardDescription = "State Board"
                        },
                        new EducationBoard()
                        {
                            EducationBoardTitle = "CISCE",
                            EducationBoardDescription = "CISCE"
                        },
                        new EducationBoard()
                        {
                            EducationBoardTitle = "IB Board",
                            EducationBoardDescription = "IB Board"
                        },
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
