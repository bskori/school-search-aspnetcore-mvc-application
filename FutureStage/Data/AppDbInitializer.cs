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

                //Quota
                if (!context.Quotos.Any())
                {
                    context.Quotos.AddRange(new List<Quoto>()
                    {
                        new Quoto()
                        {
                            QuotoTitle = "General/Open Category",
                            QuotoDescription = "This category comprises applicants who do not fall under any specific reserved category. They compete for admission based on general merit or specific admission criteria set by the institution."
                        },
                        new Quoto()
                        {
                            QuotoTitle = "Scheduled Castes (SC)",
                            QuotoDescription = "Reserved for individuals belonging to historically disadvantaged castes or Dalits in India."
                        },
                         new Quoto()
                        {
                            QuotoTitle = "Scheduled Tribes (ST)",
                            QuotoDescription = "Reserved for individuals belonging to specific indigenous or tribal communities in India."
                        },
                          new Quoto()
                        {
                            QuotoTitle = "Economically Weaker Section (EWS)",
                            QuotoDescription = "Introduced in some countries to provide reservations for economically disadvantaged sections of society, irrespective of their caste or ethnicity."
                        },
                           new Quoto()
                        {
                            QuotoTitle = "Other Backward Classes (OBC)",
                            QuotoDescription = "Reserved for individuals belonging to socially and educationally disadvantaged groups, excluding SCs and STs, in India"
                        },
                            new Quoto()
                        {
                            QuotoTitle = "Persons with Disabilities (PWD)",
                            QuotoDescription = "Reserved for individuals with physical or mental disabilities, with appropriate provisions for accessibility and support."
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

                
                
            }
        }
    }
}
