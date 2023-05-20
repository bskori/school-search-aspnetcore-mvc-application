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

                //State
                if (!context.States.Any())
                {
                    context.States.AddRange(new List<State>() 
                    { 
                        new State()
                        {
                            StateName = "Maharashtra"
                        },
                        new State()
                        {
                            StateName = "Uttar Pradesh"
                        },
                        new State()
                        {
                            StateName = "Madhya Pradesh"
                        },
                        new State()
                        {
                            StateName = "Banglore"
                        },
                        new State()
                        {
                            StateName = "Karnatka"
                        },
                        new State()
                        {
                            StateName = "Hyderabad"
                        },
                        new State()
                        {
                            StateName = "Rajasthan"

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

                //Scools ----------------------------

                //FeeHead
                if (!context.FeeHeads.Any())
                {
                    context.FeeHeads.AddRange(new List<FeeHead>() { 
                        new FeeHead()
                        {
                            FeeHeadTitle = "Tuition Fees",
                            FeeHeadDescription ="These are the basic fees charged for attending the school and receiving educational instruction. Tuition fees can vary based on factors such as grade level, curriculum, and whether the school is public or private."
                        },
                        new FeeHead()
                        {
                            FeeHeadTitle = "Registration/Admission Fees",
                            FeeHeadDescription ="This fee is usually charged when a student initially enrolls in the school. It covers administrative costs associated with processing the application and securing a spot for the student."
                        },
                         new FeeHead()
                        {
                            FeeHeadTitle = "Examination Fees",
                            FeeHeadDescription ="Schools often charge fees for conducting examinations, including midterm exams, final exams, or external assessments like standardized tests or board examinations."
                        }, new FeeHead()
                        {
                            FeeHeadTitle = "Activity/Extracurricular Fees",
                            FeeHeadDescription ="These fees are associated with participation in extracurricular activities such as sports teams, clubs, field trips, or special events. They may cover equipment, uniforms, transportation, or other related expenses."
                        }, new FeeHead()
                        {
                            FeeHeadTitle = "Laboratory Fees",
                            FeeHeadDescription =" If a school offers science or computer laboratories, they may charge additional fees to cover the maintenance, supplies, and equipment required for practical experiments or hands-on learning."
                        },
                    });
                    context.SaveChanges();
                }


            }
        }
    }
}
