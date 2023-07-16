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
                            FacilityName = "AC Classes",
                            FacilityIcon = "AC Classes"
                        },
                        new Facility()
                        {
                            FacilityName = "Wifi",
                            FacilityIcon = "Wifi"
                        },
                        new Facility()
                        {
                            FacilityName = "Smart Classes",
                            FacilityIcon = "Smart Classes"
                            
                        },
                        new Facility()
                        {
                            FacilityName = "Boys Hostel",
                            FacilityIcon = "Boys Hostel"
                        },
                        new Facility()
                        {
                            FacilityName = "Girls Hostel",
                            FacilityIcon = "Girls Hostel"
                        },
                        new Facility()
                        {
                            FacilityName = "Indoor Sports",
                            FacilityIcon = "Indoor Sports"
                        },
                        new Facility()
                        {
                            FacilityName = "Outdoor Sports",
                            FacilityIcon = "Outdoor Sports"
                        },
                        new Facility()
                        {
                            FacilityName = "Transportation",
                            FacilityIcon = "Transportation"
                        },
                        new Facility()
                        {
                            FacilityName = "Gym",
                            FacilityIcon = "Gym"
                        },
                        new Facility()
                        {
                            FacilityName = "Cafeteria/Canteen",
                            FacilityIcon="Cafeteria/Canteen"
                        },
                        new Facility()
                        {
                            FacilityName = "Computer Lab",
                            FacilityIcon="Computer Lab"
                        },
                        new Facility()
                        {
                            FacilityName = "Science Lab",
                            FacilityIcon="Science Lab"
                        },
                        new Facility()
                        {
                            FacilityName = "CCTV",
                            FacilityIcon = "CCTV"
                        },
                        new Facility()
                        {
                            FacilityName = "Playground",
                            FacilityIcon = "Playground"
                        },
                        new Facility()
                        {
                            FacilityName = "Library/Reading Room",
                            FacilityIcon = "Library/Reading Room"
                        },
                        new Facility()
                        {
                            FacilityName = "Day Care",
                            FacilityIcon = "Day Care" 
                        },
                        new Facility()
                        {
                            FacilityName = "Dance",
                            FacilityIcon = "Dance"
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
                            StandardName = "Pre Nursery",

                        },
                        new Standard()
                        {
                            StandardName = "LKG",
                          
                        },
                        new Standard()
                        {
                            StandardName = "UKG",
                           
                        },
                        new Standard()
                        {
                            StandardName = "Class 1",
                          
                        },
                        new Standard()
                        {
                            StandardName = "Class 2",
                           
                        },
                        new Standard()
                        {
                            StandardName = "Class 3",
                           
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
                            EducationBoardName = "CBSE",
                           
                        },
                        new EducationBoard()
                        {
                            EducationBoardName = "ICSE",
                           
                        },
                        new EducationBoard()
                        {
                            EducationBoardName = "State Board",
                            
                        },
                        new EducationBoard()
                        {
                            EducationBoardName = "CISCE",
                           
                        },
                        new EducationBoard()
                        {
                            EducationBoardName = "IB Board",
                            
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
                            FeeHeadName = "Tuition Fees",
                            
                        },
                        new FeeHead()
                        {
                            FeeHeadName = "Registration/Admission Fees",
                            
                        },
                         new FeeHead()
                        {
                            FeeHeadName = "Examination Fees",
                            
                        }, new FeeHead()
                        {
                            FeeHeadName = "Activity/Extracurricular Fees",
                            
                        }, new FeeHead()
                        {
                            FeeHeadName = "Laboratory Fees",
                            
                        },
                    });
                    context.SaveChanges();
                }

                //Quota
                if (!context.Quotos.Any())
                {
                    context.Quotos.AddRange(new List<Quoto>()
                    {
                        new Quoto()
                        {
                            QuotoName = "General/Open Category"
                           
                        },
                        new Quoto()
                        {
                            QuotoName = "Scheduled Castes (SC)"
                          
                        },
                         new Quoto()
                        {
                            QuotoName = "Scheduled Tribes (ST)"
                           
                        },
                          new Quoto()
                        {
                            QuotoName = "Economically Weaker Section (EWS)"
                          
                        },
                           new Quoto()
                        {
                            QuotoName = "Other Backward Classes (OBC)"
                           
                        },
                            new Quoto()
                        {
                            QuotoName = "Persons with Disabilities (PWD)"
                         
                        },

                    });
                    context.SaveChanges();
                }

                //School
                if (!context.Schools.Any())
                {
                    context.Schools.AddRange(new List<School>()
                    {
                        new School()
                        {
                            Name = "Elpro International School",
                            Address = "Elpro Compound, Near Shridhar Nagar, Pimpri Chinchwad, Pune, Maharashtra - 411017",
                            EmailID = "admissions@elproschools.edu.in",
                            ContactNo = "1234567891",
                            EstablishmentDate = Convert.ToDateTime("2009-08-23"),
                            Password = "demo@1234",
                            ConfirmPassword = "demo@1234",
                            ImagePath = "/Images/SchoolsImage/demo_img.jpg",
                            AreaID = 8
                        },
                        new School()
                        {
                            Name = "Empros International School",
                            Address = "IBMR Campus MIDC C Block, Behind Double Hilton By Tree Hotel, Chinchwad, Pimpri Chinchwad, Pune, Maharashtra - 411017",
                            EmailID = " empros@asmedu.org",
                            ContactNo = "1234567891",
                            EstablishmentDate = Convert.ToDateTime("2011-08-3"),
                            Password = "demo@1234",
                            ConfirmPassword = "demo@1234",
                            ImagePath = "/Images/SchoolsImage/demo_img.jpg",
                            AreaID = 8
                        },
                        new School()
                        {
                            Name = "Global Talent International School",
                            Address = "plot no 1, Pimpri Chinchwad, Pune, Maharashtra - 411017",
                            EmailID = "globaltalenthm@gmail.com",
                            ContactNo = "1234567891",
                            EstablishmentDate = Convert.ToDateTime("2013-05-13"),
                            Password = "demo@1234",
                            ConfirmPassword = "demo@1234",
                            ImagePath = "/Images/SchoolsImage/demo_img.jpg",
                            AreaID = 8
                        },
                        new School()
                        {
                            Name = "Orchids The International Schoo",
                            Address = "Next to Luxury Living, Near Yashopuram Housing Society, Gawade Nagar Chinchwad, Pimpri-Chinchwad, Pimpri Chinchwad, Pune, Maharashtra - 411017",
                            EmailID = "marketing.chinchwad@orchids.edu.in",
                            ContactNo = "1234567891",
                            EstablishmentDate = Convert.ToDateTime("2004-08-3"),
                            Password = "demo@1234",
                            ConfirmPassword = "demo@1234",
                            ImagePath = "/Images/SchoolsImage/demo_img.jpg",
                            AreaID = 8
                        },
                        new School()
                        {
                            Name = "VIBGYOR Rise School",
                            Address = " CTS No. 4780, Survey No. 127/1A/1A/A (Part) Opposite Hilton Double Tree, Akurdi, Pimpri Chinchwad, Pune, Maharashtra - 411017",
                            EmailID = "helpdesk.vi10216@vibgyorrise.com",
                            ContactNo = "1234567891",
                            EstablishmentDate = Convert.ToDateTime("2009-08-23"),
                            Password = "demo@1234",
                            ConfirmPassword = "demo@1234",
                            ImagePath = "/Images/SchoolsImage/demo_img.jpg",
                            AreaID = 8
                        }
                    });
                    context.SaveChanges(); 
                }

                //School_Standard
                if (!context.SchoolStandards.Any())
                {
                    context.SchoolStandards.AddRange(new List<SchoolStandard>()
                    {
                        new SchoolStandard
                        {
                            IntakeCapacity = 23,
                            StandardID = 1,
                            SchoolID = 7
                        },
                        new SchoolStandard
                        {
                            IntakeCapacity = 33,
                            StandardID = 2,
                            SchoolID = 7
                        },
                        new SchoolStandard
                        {
                            IntakeCapacity = 13,
                            StandardID = 3,
                            SchoolID = 7
                        },
                        new SchoolStandard
                        {
                            IntakeCapacity = 45,
                            StandardID = 4,
                            SchoolID = 7
                        },
                        new SchoolStandard
                        {
                            IntakeCapacity = 37,
                            StandardID = 5,
                            SchoolID = 8
                        },
                        new SchoolStandard
                        {
                            IntakeCapacity = 48,
                            StandardID = 4,
                            SchoolID = 8
                        },
                        new SchoolStandard
                        {
                            IntakeCapacity = 28,
                            StandardID = 2,
                            SchoolID = 8
                        },
                        new SchoolStandard
                        {
                            IntakeCapacity = 48,
                            StandardID = 1,
                            SchoolID = 8
                        },
                        new SchoolStandard
                        {
                            IntakeCapacity = 48,
                            StandardID = 3,
                            SchoolID = 8
                        },
                        new SchoolStandard
                        {
                            IntakeCapacity = 42,
                            StandardID = 3,
                            SchoolID = 9
                        },
                        new SchoolStandard
                        {
                            IntakeCapacity = 55,
                            StandardID = 2,
                            SchoolID = 9
                        },
                        new SchoolStandard
                        {
                            IntakeCapacity = 46,
                            StandardID = 6,
                            SchoolID = 9
                        },
                        new SchoolStandard
                        {
                            IntakeCapacity = 39,
                            StandardID = 4,
                            SchoolID = 10
                        },
                        new SchoolStandard
                        {
                            IntakeCapacity = 41,
                            StandardID = 2,
                            SchoolID = 10
                        },
                        new SchoolStandard
                        {
                            IntakeCapacity = 36,
                            StandardID = 3,
                            SchoolID = 10
                        },
                        new SchoolStandard
                        {
                            IntakeCapacity = 66,
                            StandardID = 5,
                            SchoolID = 11
                        },
                        new SchoolStandard
                        {
                            IntakeCapacity = 56,
                            StandardID = 4,
                            SchoolID = 11
                        },
                        new SchoolStandard
                        {
                            IntakeCapacity = 44,
                            StandardID = 2,
                            SchoolID = 11
                        },
                        new SchoolStandard
                        {
                            IntakeCapacity = 21,
                            StandardID = 3,
                            SchoolID = 12
                        },
                        new SchoolStandard
                        {
                            IntakeCapacity = 28,
                            StandardID = 5,
                            SchoolID = 12
                        },
                        new SchoolStandard
                        {
                            IntakeCapacity = 48,
                            StandardID = 6,
                            SchoolID = 12
                        }
                    });
                    context.SaveChanges();
                }

                //Standard_Fees
                if (!context.StandardFees.Any())
                {
                    context.StandardFees.AddRange(new List<StandardFees>() { 
                        new StandardFees()
                        {
                            Amount = 4400,
                            SchoolStandardID = 11,
                            FeeHeadID = 1
                        },
                        new StandardFees()
                        {
                            Amount = 4000,
                            SchoolStandardID = 12,
                            FeeHeadID = 1
                        },
                        new StandardFees()
                        {
                            Amount = 5000,
                            SchoolStandardID = 13,
                            FeeHeadID = 1
                        },
                        new StandardFees()
                        {
                            Amount = 5800,
                            SchoolStandardID = 14,
                            FeeHeadID = 1
                        },
                        new StandardFees()
                        {
                            Amount = 6000,
                            SchoolStandardID = 15,
                            FeeHeadID = 1
                        },
                        new StandardFees()
                        {
                            Amount = 4500,
                            SchoolStandardID = 16,
                            FeeHeadID = 1
                        },
                        new StandardFees()
                        {
                            Amount = 4800,
                            SchoolStandardID = 17,
                            FeeHeadID = 1
                        },
                        new StandardFees()
                        {
                            Amount = 4900,
                            SchoolStandardID = 18,
                            FeeHeadID = 1
                        },
                        new StandardFees()
                        {
                            Amount = 5100,
                            SchoolStandardID = 19,
                            FeeHeadID = 1
                        },
                        new StandardFees()
                        {
                            Amount = 5400,
                            SchoolStandardID = 20,
                            FeeHeadID = 1
                        },
                        new StandardFees()
                        {
                            Amount = 3400,
                            SchoolStandardID = 21,
                            FeeHeadID = 1
                        },
                        new StandardFees()
                        {
                            Amount = 4700,
                            SchoolStandardID = 22,
                            FeeHeadID = 1
                        },
                        new StandardFees()
                        {
                            Amount = 7000,
                            SchoolStandardID = 23,
                            FeeHeadID = 1
                        },
                        new StandardFees()
                        {
                            Amount = 2500,
                            SchoolStandardID = 24,
                            FeeHeadID = 1
                        },
                        new StandardFees()
                        {
                            Amount = 3200,
                            SchoolStandardID = 25,
                            FeeHeadID = 1
                        },
                        new StandardFees()
                        {
                            Amount = 9500,
                            SchoolStandardID = 26,
                            FeeHeadID = 1
                        },
                        new StandardFees()
                        {
                            Amount = 8200,
                            SchoolStandardID = 27,
                            FeeHeadID = 1
                        },
                        new StandardFees()
                        {
                            Amount = 9700,
                            SchoolStandardID = 28,
                            FeeHeadID = 1
                        },
                        new StandardFees()
                        {
                            Amount = 7700,
                            SchoolStandardID = 29,
                            FeeHeadID = 1
                        },
                        new StandardFees()
                        {
                            Amount = 8200,
                            SchoolStandardID = 30,
                            FeeHeadID = 1
                        },
                        new StandardFees()
                        {
                            Amount = 9900,
                            SchoolStandardID = 31,
                            FeeHeadID = 1
                        }
                    });
                    context.SaveChanges();
                }

                
            }
        }
    }
}
