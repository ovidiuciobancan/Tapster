using System;
using System.Collections.Generic;
using System.Linq;
using Tapster.DataAccess.Repositories;
using Tapster.DomainEntities.Entities;
using Tapster.DomainEntities.Enums;
using Utils.EntityFrameworkCore.Extensions;

namespace Tapster.DataAccess.Seeders
{
   

    public class MockupSeeder : ISeeder<AppDbContext>
    {
        public void Seed(AppDbContext context)
        {
            if (!context.Managers.Any())
            {
                context.Clients.AddRange(MockupData.Clients);
                context.Managers.AddRange(MockupData.Managers);

                context.SaveChanges();

                var venues = context.Venues.ToList();

                foreach (var venue in context.Venues)
                {
                    var categories = MockupData.Categories;

                    SetVenueId(categories, venue.Id);
                    foreach (var category in categories)
                    {
                        venue.Categories.Add(category);
                    }
                    
                }

                context.SaveChanges();
            }
        }

        private void SetVenueId(List<Category> categories, Guid venueId)
        {
            foreach (var c in categories)
            {
                c.VenueId = venueId;
                SetVenueId((List<Category>)c.SubCategories, venueId);
            }
        }
    }

    class MockupData
    {
        public static List<Manager> Managers => new List<Manager>
        {
            new Manager
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Venues = new List<Venue>()
                    {
                        new Venue
                        {
                            Name = "Skod BAR",
                            Address = "Rødovre Parkvej 150, 2610 Rødovre, Danem",
                            ImageUrl = "https://secure.cdn1.wdpromedia.com/resize/mwImage/1/640/360/75/dam/wdpro-assets/gallery/dining/downtown-disney/jock-lindseys-hangar-bar/jock-lindseys-hangar-bar-g00.jpg?1520569685058",
                            Waiters = new List<Waiter>
                            {
                                new Waiter
                                {
                                    FirstName = "Waiter 1",
                                    LastName = "Waiter 1"
                                },
                                new Waiter
                                {
                                    FirstName = "Laura",
                                    LastName = "Waiter"
                                },
                                new Waiter
                                {
                                    FirstName = "Ovidiu",
                                    LastName = "Waiter"
                                }
                            },
                            Tables = new List<Table>
                            {
                                new Table
                                {
                                    Name = "Table1",
                                    Description = "First Table to the right",
                                    Capacity = 4
                                },
                                new Table
                                {
                                    Name = "Table2",
                                    Description = "First Table to the left",
                                    Capacity = 2
                                },
                                new Table
                                {
                                    Name = "Table3",
                                    Description = "First Table to the right",
                                    Capacity = 4
                                },
                                new Table
                                {
                                    Name = "Table4",
                                    Description = "First Table to the left",
                                    Capacity = 2
                                },
                                new Table
                                {
                                    Name = "Table5",
                                    Description = "First Table to the right",
                                    Capacity = 4
                                },
                            },
                        },
                        new Venue
                        {
                            Name = "The old dog bath",
                            Description = "",
                            Address = "Rødovrevej 79, 2610 Rødovre, Danemarca",
                            ImageUrl = "https://img.theculturetrip.com/840x440/smart//wp-content/uploads/2016/09/main-bar-at-tir-na-nog.jpg",
                            Site = "https://www.detgamlehundebad.dk/",
                            Waiters = new List<Waiter>
                            {
                                new Waiter
                                {
                                    FirstName = "Waiter 1",
                                    LastName = "Waiter 1"
                                },
                                new Waiter
                                {
                                    FirstName = "Laura",
                                    LastName = "Waiter"
                                },
                                new Waiter
                                {
                                    FirstName = "Ovidiu",
                                    LastName = "Waiter"
                                }
                            },
                            Tables = new List<Table>
                            {
                                new Table
                                {
                                    Name = "Table1",
                                    Description = "First Table to the right",
                                    Capacity = 4
                                },
                                new Table
                                {
                                    Name = "Table2",
                                    Description = "First Table to the left",
                                    Capacity = 2
                                },
                                new Table
                                {
                                    Name = "Table3",
                                    Description = "First Table to the right",
                                    Capacity = 4
                                },
                                new Table
                                {
                                    Name = "Table4",
                                    Description = "First Table to the left",
                                    Capacity = 2
                                },
                                new Table
                                {
                                    Name = "Table5",
                                    Description = "First Table to the right",
                                    Capacity = 4
                                },
                            },

                        },
                        new Venue
                        {
                            Name = "Restaurant Granen",
                            Description = "Our restaurant has room for approx. 60 seated guests, and we always strive to serve delicious food at club prices - children are very welcome.",
                            Address = "Peter Bangs Vej 147, 2000 Frederiksberg, Danemarca",
                            ImageUrl = "http://static.asiawebdirect.com/m/bangkok/portals/bangkok-com/homepage/magazine/5-best-gogo-bars/pagePropertiesImage/badabingpatpong-2.jpg",
                            Site = "http://www.kb-boldklub.dk/om-kb/faciliteter/restauranter/restaurant-granen/",
                            Waiters = new List<Waiter>
                            {
                                new Waiter
                                {
                                    FirstName = "Waiter 1",
                                    LastName = "Waiter 1"
                                },
                                new Waiter
                                {
                                    FirstName = "Laura",
                                    LastName = "Waiter"
                                },
                                new Waiter
                                {
                                    FirstName = "Ovidiu",
                                    LastName = "Waiter"
                                }
                            },
                            Tables = new List<Table>
                            {
                                new Table
                                {
                                    Name = "Table1",
                                    Description = "First Table to the right",
                                    Capacity = 4
                                },
                                new Table
                                {
                                    Name = "Table2",
                                    Description = "First Table to the left",
                                    Capacity = 2
                                },
                                new Table
                                {
                                    Name = "Table3",
                                    Description = "First Table to the right",
                                    Capacity = 4
                                },
                                new Table
                                {
                                    Name = "Table4",
                                    Description = "First Table to the left",
                                    Capacity = 2
                                },
                                new Table
                                {
                                    Name = "Table5",
                                    Description = "First Table to the right",
                                    Capacity = 4
                                },
                            },
                        },
                        new Venue
                        {
                            Name = "Restaurant Granen",
                            Description = "Our restaurant has room for approx. 60 seated guests, and we always strive to serve delicious food at club prices - children are very welcome.",
                            Address = "Peter Bangs Vej 147, 2000 Frederiksberg, Danemarca",
                            ImageUrl = "http://static.asiawebdirect.com/m/bangkok/portals/bangkok-com/homepage/magazine/5-best-gogo-bars/pagePropertiesImage/badabingpatpong-2.jpg",
                            Site = "http://www.kb-boldklub.dk/om-kb/faciliteter/restauranter/restaurant-granen/",
                            Waiters = new List<Waiter>
                            {
                                new Waiter
                                {
                                    FirstName = "Waiter 1",
                                    LastName = "Waiter 1"
                                },
                                new Waiter
                                {
                                    FirstName = "Laura",
                                    LastName = "Waiter"
                                },
                                new Waiter
                                {
                                    FirstName = "Ovidiu",
                                    LastName = "Waiter"
                                }
                            },
                            Tables = new List<Table>
                            {
                                new Table
                                {
                                    Name = "Table1",
                                    Description = "First Table to the right",
                                    Capacity = 4
                                },
                                new Table
                                {
                                    Name = "Table2",
                                    Description = "First Table to the left",
                                    Capacity = 2
                                },
                                new Table
                                {
                                    Name = "Table3",
                                    Description = "First Table to the right",
                                    Capacity = 4
                                },
                                new Table
                                {
                                    Name = "Table4",
                                    Description = "First Table to the left",
                                    Capacity = 2
                                },
                                new Table
                                {
                                    Name = "Table5",
                                    Description = "First Table to the right",
                                    Capacity = 4
                                },
                            },
                        },
                        new Venue
                        {
                            Name = "Restaurant Granen",
                            Description = "Our restaurant has room for approx. 60 seated guests, and we always strive to serve delicious food at club prices - children are very welcome.",
                            Address = "Peter Bangs Vej 147, 2000 Frederiksberg, Danemarca",
                            ImageUrl = "http://static.asiawebdirect.com/m/bangkok/portals/bangkok-com/homepage/magazine/5-best-gogo-bars/pagePropertiesImage/badabingpatpong-2.jpg",
                            Site = "http://www.kb-boldklub.dk/om-kb/faciliteter/restauranter/restaurant-granen/",
                            Waiters = new List<Waiter>
                            {
                                new Waiter
                                {
                                    FirstName = "Waiter 1",
                                    LastName = "Waiter 1"
                                },
                                new Waiter
                                {
                                    FirstName = "Laura",
                                    LastName = "Waiter"
                                },
                                new Waiter
                                {
                                    FirstName = "Ovidiu",
                                    LastName = "Waiter"
                                }
                            },
                            Tables = new List<Table>
                            {
                                new Table
                                {
                                    Name = "Table1",
                                    Description = "First Table to the right",
                                    Capacity = 4
                                },
                                new Table
                                {
                                    Name = "Table2",
                                    Description = "First Table to the left",
                                    Capacity = 2
                                },
                                new Table
                                {
                                    Name = "Table3",
                                    Description = "First Table to the right",
                                    Capacity = 4
                                },
                                new Table
                                {
                                    Name = "Table4",
                                    Description = "First Table to the left",
                                    Capacity = 2
                                },
                                new Table
                                {
                                    Name = "Table5",
                                    Description = "First Table to the right",
                                    Capacity = 4
                                },
                            },
                        },
                        new Venue
                        {
                            Name = "Skod BAR",
                            Address = "Rødovre Parkvej 150, 2610 Rødovre, Danem",
                            ImageUrl = "https://secure.cdn1.wdpromedia.com/resize/mwImage/1/640/360/75/dam/wdpro-assets/gallery/dining/downtown-disney/jock-lindseys-hangar-bar/jock-lindseys-hangar-bar-g00.jpg?1520569685058",
                            Waiters = new List<Waiter>
                            {
                                new Waiter
                                {
                                    FirstName = "Waiter 1",
                                    LastName = "Waiter 1"
                                },
                                new Waiter
                                {
                                    FirstName = "Laura",
                                    LastName = "Waiter"
                                },
                                new Waiter
                                {
                                    FirstName = "Ovidiu",
                                    LastName = "Waiter"
                                }
                            },
                            Tables = new List<Table>
                            {
                                new Table
                                {
                                    Name = "Table1",
                                    Description = "First Table to the right",
                                    Capacity = 4
                                },
                                new Table
                                {
                                    Name = "Table2",
                                    Description = "First Table to the left",
                                    Capacity = 2
                                },
                                new Table
                                {
                                    Name = "Table3",
                                    Description = "First Table to the right",
                                    Capacity = 4
                                },
                                new Table
                                {
                                    Name = "Table4",
                                    Description = "First Table to the left",
                                    Capacity = 2
                                },
                                new Table
                                {
                                    Name = "Table5",
                                    Description = "First Table to the right",
                                    Capacity = 4
                                },
                            },
                        },
                        new Venue
                        {
                            Name = "The old dog bath",
                            Description = "",
                            Address = "Rødovrevej 79, 2610 Rødovre, Danemarca",
                            ImageUrl = "https://img.theculturetrip.com/840x440/smart//wp-content/uploads/2016/09/main-bar-at-tir-na-nog.jpg",
                            Site = "https://www.detgamlehundebad.dk/",
                            Waiters = new List<Waiter>
                            {
                                new Waiter
                                {
                                    FirstName = "Waiter 1",
                                    LastName = "Waiter 1"
                                },
                                new Waiter
                                {
                                    FirstName = "Laura",
                                    LastName = "Waiter"
                                },
                                new Waiter
                                {
                                    FirstName = "Ovidiu",
                                    LastName = "Waiter"
                                }
                            },
                            Tables = new List<Table>
                            {
                                new Table
                                {
                                    Name = "Table1",
                                    Description = "First Table to the right",
                                    Capacity = 4
                                },
                                new Table
                                {
                                    Name = "Table2",
                                    Description = "First Table to the left",
                                    Capacity = 2
                                },
                                new Table
                                {
                                    Name = "Table3",
                                    Description = "First Table to the right",
                                    Capacity = 4
                                },
                                new Table
                                {
                                    Name = "Table4",
                                    Description = "First Table to the left",
                                    Capacity = 2
                                },
                                new Table
                                {
                                    Name = "Table5",
                                    Description = "First Table to the right",
                                    Capacity = 4
                                },
                            },

                        },
                        new Venue
                        {
                            Name = "Restaurant Granen",
                            Description = "Our restaurant has room for approx. 60 seated guests, and we always strive to serve delicious food at club prices - children are very welcome.",
                            Address = "Peter Bangs Vej 147, 2000 Frederiksberg, Danemarca",
                            ImageUrl = "http://static.asiawebdirect.com/m/bangkok/portals/bangkok-com/homepage/magazine/5-best-gogo-bars/pagePropertiesImage/badabingpatpong-2.jpg",
                            Site = "http://www.kb-boldklub.dk/om-kb/faciliteter/restauranter/restaurant-granen/",
                            Waiters = new List<Waiter>
                            {
                                new Waiter
                                {
                                    FirstName = "Waiter 1",
                                    LastName = "Waiter 1"
                                },
                                new Waiter
                                {
                                    FirstName = "Laura",
                                    LastName = "Waiter"
                                },
                                new Waiter
                                {
                                    FirstName = "Ovidiu",
                                    LastName = "Waiter"
                                }
                            },
                            Tables = new List<Table>
                            {
                                new Table
                                {
                                    Name = "Table1",
                                    Description = "First Table to the right",
                                    Capacity = 4
                                },
                                new Table
                                {
                                    Name = "Table2",
                                    Description = "First Table to the left",
                                    Capacity = 2
                                },
                                new Table
                                {
                                    Name = "Table3",
                                    Description = "First Table to the right",
                                    Capacity = 4
                                },
                                new Table
                                {
                                    Name = "Table4",
                                    Description = "First Table to the left",
                                    Capacity = 2
                                },
                                new Table
                                {
                                    Name = "Table5",
                                    Description = "First Table to the right",
                                    Capacity = 4
                                },
                            },
                        },
                        new Venue
                        {
                            Name = "Restaurant Granen",
                            Description = "Our restaurant has room for approx. 60 seated guests, and we always strive to serve delicious food at club prices - children are very welcome.",
                            Address = "Peter Bangs Vej 147, 2000 Frederiksberg, Danemarca",
                            ImageUrl = "http://static.asiawebdirect.com/m/bangkok/portals/bangkok-com/homepage/magazine/5-best-gogo-bars/pagePropertiesImage/badabingpatpong-2.jpg",
                            Site = "http://www.kb-boldklub.dk/om-kb/faciliteter/restauranter/restaurant-granen/",
                            Waiters = new List<Waiter>
                            {
                                new Waiter
                                {
                                    FirstName = "Waiter 1",
                                    LastName = "Waiter 1"
                                },
                                new Waiter
                                {
                                    FirstName = "Laura",
                                    LastName = "Waiter"
                                },
                                new Waiter
                                {
                                    FirstName = "Ovidiu",
                                    LastName = "Waiter"
                                }
                            },
                            Tables = new List<Table>
                            {
                                new Table
                                {
                                    Name = "Table1",
                                    Description = "First Table to the right",
                                    Capacity = 4
                                },
                                new Table
                                {
                                    Name = "Table2",
                                    Description = "First Table to the left",
                                    Capacity = 2
                                },
                                new Table
                                {
                                    Name = "Table3",
                                    Description = "First Table to the right",
                                    Capacity = 4
                                },
                                new Table
                                {
                                    Name = "Table4",
                                    Description = "First Table to the left",
                                    Capacity = 2
                                },
                                new Table
                                {
                                    Name = "Table5",
                                    Description = "First Table to the right",
                                    Capacity = 4
                                },
                            },
                        },
                        new Venue
                        {
                            Name = "Restaurant Granen",
                            Description = "Our restaurant has room for approx. 60 seated guests, and we always strive to serve delicious food at club prices - children are very welcome.",
                            Address = "Peter Bangs Vej 147, 2000 Frederiksberg, Danemarca",
                            ImageUrl = "http://static.asiawebdirect.com/m/bangkok/portals/bangkok-com/homepage/magazine/5-best-gogo-bars/pagePropertiesImage/badabingpatpong-2.jpg",
                            Site = "http://www.kb-boldklub.dk/om-kb/faciliteter/restauranter/restaurant-granen/",
                            Waiters = new List<Waiter>
                            {
                                new Waiter
                                {
                                    FirstName = "Waiter 1",
                                    LastName = "Waiter 1"
                                },
                                new Waiter
                                {
                                    FirstName = "Laura",
                                    LastName = "Waiter"
                                },
                                new Waiter
                                {
                                    FirstName = "Ovidiu",
                                    LastName = "Waiter"
                                }
                            },
                            Tables = new List<Table>
                            {
                                new Table
                                {
                                    Name = "Table1",
                                    Description = "First Table to the right",
                                    Capacity = 4
                                },
                                new Table
                                {
                                    Name = "Table2",
                                    Description = "First Table to the left",
                                    Capacity = 2
                                },
                                new Table
                                {
                                    Name = "Table3",
                                    Description = "First Table to the right",
                                    Capacity = 4
                                },
                                new Table
                                {
                                    Name = "Table4",
                                    Description = "First Table to the left",
                                    Capacity = 2
                                },
                                new Table
                                {
                                    Name = "Table5",
                                    Description = "First Table to the right",
                                    Capacity = 4
                                },
                            },
                        },
                        new Venue
                        {
                            Name = "Skod BAR",
                            Address = "Rødovre Parkvej 150, 2610 Rødovre, Danem",
                            ImageUrl = "https://secure.cdn1.wdpromedia.com/resize/mwImage/1/640/360/75/dam/wdpro-assets/gallery/dining/downtown-disney/jock-lindseys-hangar-bar/jock-lindseys-hangar-bar-g00.jpg?1520569685058",
                            Waiters = new List<Waiter>
                            {
                                new Waiter
                                {
                                    FirstName = "Waiter 1",
                                    LastName = "Waiter 1"
                                },
                                new Waiter
                                {
                                    FirstName = "Laura",
                                    LastName = "Waiter"
                                },
                                new Waiter
                                {
                                    FirstName = "Ovidiu",
                                    LastName = "Waiter"
                                }
                            },
                            Tables = new List<Table>
                            {
                                new Table
                                {
                                    Name = "Table1",
                                    Description = "First Table to the right",
                                    Capacity = 4
                                },
                                new Table
                                {
                                    Name = "Table2",
                                    Description = "First Table to the left",
                                    Capacity = 2
                                },
                                new Table
                                {
                                    Name = "Table3",
                                    Description = "First Table to the right",
                                    Capacity = 4
                                },
                                new Table
                                {
                                    Name = "Table4",
                                    Description = "First Table to the left",
                                    Capacity = 2
                                },
                                new Table
                                {
                                    Name = "Table5",
                                    Description = "First Table to the right",
                                    Capacity = 4
                                },
                            },
                        },
                        new Venue
                        {
                            Name = "The old dog bath",
                            Description = "",
                            Address = "Rødovrevej 79, 2610 Rødovre, Danemarca",
                            ImageUrl = "https://img.theculturetrip.com/840x440/smart//wp-content/uploads/2016/09/main-bar-at-tir-na-nog.jpg",
                            Site = "https://www.detgamlehundebad.dk/",
                            Waiters = new List<Waiter>
                            {
                                new Waiter
                                {
                                    FirstName = "Waiter 1",
                                    LastName = "Waiter 1"
                                },
                                new Waiter
                                {
                                    FirstName = "Laura",
                                    LastName = "Waiter"
                                },
                                new Waiter
                                {
                                    FirstName = "Ovidiu",
                                    LastName = "Waiter"
                                }
                            },
                            Tables = new List<Table>
                            {
                                new Table
                                {
                                    Name = "Table1",
                                    Description = "First Table to the right",
                                    Capacity = 4
                                },
                                new Table
                                {
                                    Name = "Table2",
                                    Description = "First Table to the left",
                                    Capacity = 2
                                },
                                new Table
                                {
                                    Name = "Table3",
                                    Description = "First Table to the right",
                                    Capacity = 4
                                },
                                new Table
                                {
                                    Name = "Table4",
                                    Description = "First Table to the left",
                                    Capacity = 2
                                },
                                new Table
                                {
                                    Name = "Table5",
                                    Description = "First Table to the right",
                                    Capacity = 4
                                },
                            },

                        },
                        new Venue
                        {
                            Name = "Restaurant Granen",
                            Description = "Our restaurant has room for approx. 60 seated guests, and we always strive to serve delicious food at club prices - children are very welcome.",
                            Address = "Peter Bangs Vej 147, 2000 Frederiksberg, Danemarca",
                            ImageUrl = "http://static.asiawebdirect.com/m/bangkok/portals/bangkok-com/homepage/magazine/5-best-gogo-bars/pagePropertiesImage/badabingpatpong-2.jpg",
                            Site = "http://www.kb-boldklub.dk/om-kb/faciliteter/restauranter/restaurant-granen/",
                            Waiters = new List<Waiter>
                            {
                                new Waiter
                                {
                                    FirstName = "Waiter 1",
                                    LastName = "Waiter 1"
                                },
                                new Waiter
                                {
                                    FirstName = "Laura",
                                    LastName = "Waiter"
                                },
                                new Waiter
                                {
                                    FirstName = "Ovidiu",
                                    LastName = "Waiter"
                                }
                            },
                            Tables = new List<Table>
                            {
                                new Table
                                {
                                    Name = "Table1",
                                    Description = "First Table to the right",
                                    Capacity = 4
                                },
                                new Table
                                {
                                    Name = "Table2",
                                    Description = "First Table to the left",
                                    Capacity = 2
                                },
                                new Table
                                {
                                    Name = "Table3",
                                    Description = "First Table to the right",
                                    Capacity = 4
                                },
                                new Table
                                {
                                    Name = "Table4",
                                    Description = "First Table to the left",
                                    Capacity = 2
                                },
                                new Table
                                {
                                    Name = "Table5",
                                    Description = "First Table to the right",
                                    Capacity = 4
                                },
                            },
                        },
                        new Venue
                        {
                            Name = "Restaurant Granen",
                            Description = "Our restaurant has room for approx. 60 seated guests, and we always strive to serve delicious food at club prices - children are very welcome.",
                            Address = "Peter Bangs Vej 147, 2000 Frederiksberg, Danemarca",
                            ImageUrl = "http://static.asiawebdirect.com/m/bangkok/portals/bangkok-com/homepage/magazine/5-best-gogo-bars/pagePropertiesImage/badabingpatpong-2.jpg",
                            Site = "http://www.kb-boldklub.dk/om-kb/faciliteter/restauranter/restaurant-granen/",
                            Waiters = new List<Waiter>
                            {
                                new Waiter
                                {
                                    FirstName = "Waiter 1",
                                    LastName = "Waiter 1"
                                },
                                new Waiter
                                {
                                    FirstName = "Laura",
                                    LastName = "Waiter"
                                },
                                new Waiter
                                {
                                    FirstName = "Ovidiu",
                                    LastName = "Waiter"
                                }
                            },
                            Tables = new List<Table>
                            {
                                new Table
                                {
                                    Name = "Table1",
                                    Description = "First Table to the right",
                                    Capacity = 4
                                },
                                new Table
                                {
                                    Name = "Table2",
                                    Description = "First Table to the left",
                                    Capacity = 2
                                },
                                new Table
                                {
                                    Name = "Table3",
                                    Description = "First Table to the right",
                                    Capacity = 4
                                },
                                new Table
                                {
                                    Name = "Table4",
                                    Description = "First Table to the left",
                                    Capacity = 2
                                },
                                new Table
                                {
                                    Name = "Table5",
                                    Description = "First Table to the right",
                                    Capacity = 4
                                },
                            },
                        },
                        new Venue
                        {
                            Name = "Restaurant Granen",
                            Description = "Our restaurant has room for approx. 60 seated guests, and we always strive to serve delicious food at club prices - children are very welcome.",
                            Address = "Peter Bangs Vej 147, 2000 Frederiksberg, Danemarca",
                            ImageUrl = "http://static.asiawebdirect.com/m/bangkok/portals/bangkok-com/homepage/magazine/5-best-gogo-bars/pagePropertiesImage/badabingpatpong-2.jpg",
                            Site = "http://www.kb-boldklub.dk/om-kb/faciliteter/restauranter/restaurant-granen/",
                            Waiters = new List<Waiter>
                            {
                                new Waiter
                                {
                                    FirstName = "Waiter 1",
                                    LastName = "Waiter 1"
                                },
                                new Waiter
                                {
                                    FirstName = "Laura",
                                    LastName = "Waiter"
                                },
                                new Waiter
                                {
                                    FirstName = "Ovidiu",
                                    LastName = "Waiter"
                                }
                            },
                            Tables = new List<Table>
                            {
                                new Table
                                {
                                    Name = "Table1",
                                    Description = "First Table to the right",
                                    Capacity = 4
                                },
                                new Table
                                {
                                    Name = "Table2",
                                    Description = "First Table to the left",
                                    Capacity = 2
                                },
                                new Table
                                {
                                    Name = "Table3",
                                    Description = "First Table to the right",
                                    Capacity = 4
                                },
                                new Table
                                {
                                    Name = "Table4",
                                    Description = "First Table to the left",
                                    Capacity = 2
                                },
                                new Table
                                {
                                    Name = "Table5",
                                    Description = "First Table to the right",
                                    Capacity = 4
                                },
                            },
                        },
                        new Venue
                        {
                            Name = "Skod BAR",
                            Address = "Rødovre Parkvej 150, 2610 Rødovre, Danem",
                            ImageUrl = "https://secure.cdn1.wdpromedia.com/resize/mwImage/1/640/360/75/dam/wdpro-assets/gallery/dining/downtown-disney/jock-lindseys-hangar-bar/jock-lindseys-hangar-bar-g00.jpg?1520569685058",
                            Waiters = new List<Waiter>
                            {
                                new Waiter
                                {
                                    FirstName = "Waiter 1",
                                    LastName = "Waiter 1"
                                },
                                new Waiter
                                {
                                    FirstName = "Laura",
                                    LastName = "Waiter"
                                },
                                new Waiter
                                {
                                    FirstName = "Ovidiu",
                                    LastName = "Waiter"
                                }
                            },
                            Tables = new List<Table>
                            {
                                new Table
                                {
                                    Name = "Table1",
                                    Description = "First Table to the right",
                                    Capacity = 4
                                },
                                new Table
                                {
                                    Name = "Table2",
                                    Description = "First Table to the left",
                                    Capacity = 2
                                },
                                new Table
                                {
                                    Name = "Table3",
                                    Description = "First Table to the right",
                                    Capacity = 4
                                },
                                new Table
                                {
                                    Name = "Table4",
                                    Description = "First Table to the left",
                                    Capacity = 2
                                },
                                new Table
                                {
                                    Name = "Table5",
                                    Description = "First Table to the right",
                                    Capacity = 4
                                },
                            },
                        },
                        new Venue
                        {
                            Name = "The old dog bath",
                            Description = "",
                            Address = "Rødovrevej 79, 2610 Rødovre, Danemarca",
                            ImageUrl = "https://img.theculturetrip.com/840x440/smart//wp-content/uploads/2016/09/main-bar-at-tir-na-nog.jpg",
                            Site = "https://www.detgamlehundebad.dk/",
                            Waiters = new List<Waiter>
                            {
                                new Waiter
                                {
                                    FirstName = "Waiter 1",
                                    LastName = "Waiter 1"
                                },
                                new Waiter
                                {
                                    FirstName = "Laura",
                                    LastName = "Waiter"
                                },
                                new Waiter
                                {
                                    FirstName = "Ovidiu",
                                    LastName = "Waiter"
                                }
                            },
                            Tables = new List<Table>
                            {
                                new Table
                                {
                                    Name = "Table1",
                                    Description = "First Table to the right",
                                    Capacity = 4
                                },
                                new Table
                                {
                                    Name = "Table2",
                                    Description = "First Table to the left",
                                    Capacity = 2
                                },
                                new Table
                                {
                                    Name = "Table3",
                                    Description = "First Table to the right",
                                    Capacity = 4
                                },
                                new Table
                                {
                                    Name = "Table4",
                                    Description = "First Table to the left",
                                    Capacity = 2
                                },
                                new Table
                                {
                                    Name = "Table5",
                                    Description = "First Table to the right",
                                    Capacity = 4
                                },
                            },

                        },
                        new Venue
                        {
                            Name = "Restaurant Granen",
                            Description = "Our restaurant has room for approx. 60 seated guests, and we always strive to serve delicious food at club prices - children are very welcome.",
                            Address = "Peter Bangs Vej 147, 2000 Frederiksberg, Danemarca",
                            ImageUrl = "http://static.asiawebdirect.com/m/bangkok/portals/bangkok-com/homepage/magazine/5-best-gogo-bars/pagePropertiesImage/badabingpatpong-2.jpg",
                            Site = "http://www.kb-boldklub.dk/om-kb/faciliteter/restauranter/restaurant-granen/",
                            Waiters = new List<Waiter>
                            {
                                new Waiter
                                {
                                    FirstName = "Waiter 1",
                                    LastName = "Waiter 1"
                                },
                                new Waiter
                                {
                                    FirstName = "Laura",
                                    LastName = "Waiter"
                                },
                                new Waiter
                                {
                                    FirstName = "Ovidiu",
                                    LastName = "Waiter"
                                }
                            },
                            Tables = new List<Table>
                            {
                                new Table
                                {
                                    Name = "Table1",
                                    Description = "First Table to the right",
                                    Capacity = 4
                                },
                                new Table
                                {
                                    Name = "Table2",
                                    Description = "First Table to the left",
                                    Capacity = 2
                                },
                                new Table
                                {
                                    Name = "Table3",
                                    Description = "First Table to the right",
                                    Capacity = 4
                                },
                                new Table
                                {
                                    Name = "Table4",
                                    Description = "First Table to the left",
                                    Capacity = 2
                                },
                                new Table
                                {
                                    Name = "Table5",
                                    Description = "First Table to the right",
                                    Capacity = 4
                                },
                            },
                        },
                        new Venue
                        {
                            Name = "Restaurant Granen",
                            Description = "Our restaurant has room for approx. 60 seated guests, and we always strive to serve delicious food at club prices - children are very welcome.",
                            Address = "Peter Bangs Vej 147, 2000 Frederiksberg, Danemarca",
                            ImageUrl = "http://static.asiawebdirect.com/m/bangkok/portals/bangkok-com/homepage/magazine/5-best-gogo-bars/pagePropertiesImage/badabingpatpong-2.jpg",
                            Site = "http://www.kb-boldklub.dk/om-kb/faciliteter/restauranter/restaurant-granen/",
                            Waiters = new List<Waiter>
                            {
                                new Waiter
                                {
                                    FirstName = "Waiter 1",
                                    LastName = "Waiter 1"
                                },
                                new Waiter
                                {
                                    FirstName = "Laura",
                                    LastName = "Waiter"
                                },
                                new Waiter
                                {
                                    FirstName = "Ovidiu",
                                    LastName = "Waiter"
                                }
                            },
                            Tables = new List<Table>
                            {
                                new Table
                                {
                                    Name = "Table1",
                                    Description = "First Table to the right",
                                    Capacity = 4
                                },
                                new Table
                                {
                                    Name = "Table2",
                                    Description = "First Table to the left",
                                    Capacity = 2
                                },
                                new Table
                                {
                                    Name = "Table3",
                                    Description = "First Table to the right",
                                    Capacity = 4
                                },
                                new Table
                                {
                                    Name = "Table4",
                                    Description = "First Table to the left",
                                    Capacity = 2
                                },
                                new Table
                                {
                                    Name = "Table5",
                                    Description = "First Table to the right",
                                    Capacity = 4
                                },
                            },
                        },
                        new Venue
                        {
                            Name = "Restaurant Granen",
                            Description = "Our restaurant has room for approx. 60 seated guests, and we always strive to serve delicious food at club prices - children are very welcome.",
                            Address = "Peter Bangs Vej 147, 2000 Frederiksberg, Danemarca",
                            ImageUrl = "http://static.asiawebdirect.com/m/bangkok/portals/bangkok-com/homepage/magazine/5-best-gogo-bars/pagePropertiesImage/badabingpatpong-2.jpg",
                            Site = "http://www.kb-boldklub.dk/om-kb/faciliteter/restauranter/restaurant-granen/",
                            Waiters = new List<Waiter>
                            {
                                new Waiter
                                {
                                    FirstName = "Waiter 1",
                                    LastName = "Waiter 1"
                                },
                                new Waiter
                                {
                                    FirstName = "Laura",
                                    LastName = "Waiter"
                                },
                                new Waiter
                                {
                                    FirstName = "Ovidiu",
                                    LastName = "Waiter"
                                }
                            },
                            Tables = new List<Table>
                            {
                                new Table
                                {
                                    Name = "Table1",
                                    Description = "First Table to the right",
                                    Capacity = 4
                                },
                                new Table
                                {
                                    Name = "Table2",
                                    Description = "First Table to the left",
                                    Capacity = 2
                                },
                                new Table
                                {
                                    Name = "Table3",
                                    Description = "First Table to the right",
                                    Capacity = 4
                                },
                                new Table
                                {
                                    Name = "Table4",
                                    Description = "First Table to the left",
                                    Capacity = 2
                                },
                                new Table
                                {
                                    Name = "Table5",
                                    Description = "First Table to the right",
                                    Capacity = 4
                                },
                            },
                        },
                    }
                }
        };
        public static List<Category> Categories => new List<Category>()
        {
                new Category
                {
                    Name = "Appetizers",
                    Description = "Appetizers description",
                    Products = new List<Product>()
                    {
                        new Product
                        {
                            Name = "Marinated Cheese",
                            Description = "This special appetizer always makes it to our neighborhood parties and is the first to disappear at the buffet table. It’s attractive, delicious—and easy!",
                            Price = 5,
                            Currency = CurrencyTypes.EUR,
                            IsAvailable = true
                        },
                        new Product
                        {
                            Name = "Cranberry Cream Cheese SpreadGet",
                            Description = "This festive dip is a snap to make, taking only 10 minutes from start to finish. Thanks to its hint of sweetness, both kids and adults will gobble it up",
                            Price = 5,
                            Currency = CurrencyTypes.EUR,
                            IsAvailable = true
                        },
                        new Product
                        {
                            Name = "Pickled Pepperoncini Deviled EggsGet",
                            Description = "It’s hard to resist these adorable deviled trees on our buffet table. The avocado filling has pepperoncini and cilantro for extra zip",
                            Price = 10,
                            Currency = CurrencyTypes.EUR,
                            IsAvailable = true
                        }
                    }
                },
                new Category
                {
                    Name = "Breakfast",
                    Description = "Breakfast description",
                    Products = new List<Product>()
                    {
                        new Product
                        {
                            Name = "Bacon and eggs",
                            Description = "Breakfast Description",
                            Price = 10,
                            Currency = CurrencyTypes.EUR,
                            IsAvailable = true
                        },
                        new Product
                        {
                            Name = "Bagel and cream cheese",
                            Description = "Breakfast Description",
                            Price = 10,
                            Currency = CurrencyTypes.EUR,
                            IsAvailable = true
                        },
                        new Product
                        {
                            Name = "Breakfast sandwich",
                            Description = "Breakfast Description",
                            Price = 15,
                            Currency = CurrencyTypes.EUR,
                            IsAvailable = true
                        }
                    }
                },
                new Category
                {
                    Name = "Pizza",
                    Description = "Pizza description",
                    Products = new List<Product>()
                    {
                        new Product
                        {
                            Name = "Capriciosa",
                            Description = "Capriciosa Description",
                            Price = 20,
                            Currency = CurrencyTypes.EUR,
                            IsAvailable = true
                        },
                        new Product
                        {
                            Name = "Diavola",
                            Description = "Diavola Description",
                            Price = 20,
                            Currency = CurrencyTypes.EUR,
                            IsAvailable = true
                        },
                    }
                },
                new Category
                {
                    Name = "Drinks",
                    Description = "Drinks description",
                    SubCategories = new List<Category>()
                    {
                        new Category
                        {
                            Name = "Beer",
                            Description = "Beer Desc",
                            Products = new List<Product>()
                            {
                                new Product
                                {
                                    Name = "Carlsberg",
                                    Description = "",
                                    Price = 7,
                                    Currency = CurrencyTypes.EUR,
                                    IsAvailable = true
                                },
                                new Product
                                {
                                    Name = "Tuborg",
                                    Description = "",
                                    Price = 6,
                                    Currency = CurrencyTypes.EUR,
                                    IsAvailable = true
                                }
                            }
                        },
                        new Category
                        {
                            Name = "Wine",
                            SubCategories = new List<Category>()
                            {
                                new Category
                                {
                                    Name = "White Wine",
                                    Products = new List<Product>
                                    {
                                        new Product
                                        {
                                            Name = "Chardonnay",
                                            Price = 20,
                                            Currency = CurrencyTypes.EUR,
                                            IsAvailable = true
                                        },
                                    },
                                },
                                new Category
                                {
                                    Name = "Red Wine",
                                    Products = new List<Product>
                                    {
                                        new Product
                                        {
                                            Name = "Shiraz",
                                            Price = 20,
                                            Currency = CurrencyTypes.EUR,
                                            IsAvailable = true
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
        };
        public static List<Client> Clients => new List<Client>
        {
            new Client
            {
                FirstName = "Client",
                LastName = "Client",
            },
            new Client
            {
                FirstName = "Laura",
                LastName = "Client"
            },
            new Client
            {
                FirstName = "Ovidiu",
                LastName = "Client"
            }
        };
    }
}
