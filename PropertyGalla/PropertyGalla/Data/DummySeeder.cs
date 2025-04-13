using System;
using System.Linq;
using PropertyGalla.Models;

namespace PropertyGalla.Data
{
    public static class DummySeeder
    {
        public static void Seed(PropertyGallaContext context)
        {
            if (context.Users.Any()) return; // Prevent re-seeding

            // 1. Users (10 users)
            var users = new[]
            {
                new User
                {
                    UserId = "USE0001",
                    Name = "Qusai Mansoor",
                    Email = "alarkie2210@gmail.com",
                    Password = "e86f78a8a3caf0b60d8e74e5942aa6d86dc150cd3c03338aef25b7d2d7e3acc7",
                    Phone = "01012345678",
                    Role = "admin",
                    CreatedAt = DateTime.Now.AddDays(-30)
                },
                new User
                {
                    UserId = "USE0002",
                    Name = "Adel Abdullah",
                    Email = "mmomo68733@gmail.com",
                    Password = "e86f78a8a3caf0b60d8e74e5942aa6d86dc150cd3c03338aef25b7d2d7e3acc7",
                    Phone = "01023456789",
                    Role = "user",
                    CreatedAt = DateTime.Now.AddDays(-25)
                },
                new User
                {
                    UserId = "USE0003",
                    Name = "Ahmed Adel",
                    Email = "ahmed@gmail.com",
                    Password = "e86f78a8a3caf0b60d8e74e5942aa6d86dc150cd3c03338aef25b7d2d7e3acc7",
                    Phone = "01034567890",
                    Role = "user",
                    CreatedAt = DateTime.Now.AddDays(-20)
                },
                new User
                {
                    UserId = "USE0004",
                    Name = "Sarah Johnson",
                    Email = "sarah.j@example.com",
                    Password = "e86f78a8a3caf0b60d8e74e5942aa6d86dc150cd3c03338aef25b7d2d7e3acc7",
                    Phone = "01045678901",
                    Role = "agent",
                    CreatedAt = DateTime.Now.AddDays(-15)
                },
                new User
                {
                    UserId = "USE0005",
                    Name = "Michael Brown",
                    Email = "michael.b@example.com",
                    Password = "e86f78a8a3caf0b60d8e74e5942aa6d86dc150cd3c03338aef25b7d2d7e3acc7",
                    Phone = "01056789012",
                    Role = "user",
                    CreatedAt = DateTime.Now.AddDays(-10)
                },
                new User
                {
                    UserId = "USE0006",
                    Name = "Emily Wilson",
                    Email = "emily.w@example.com",
                    Password = "e86f78a8a3caf0b60d8e74e5942aa6d86dc150cd3c03338aef25b7d2d7e3acc7",
                    Phone = "01067890123",
                    Role = "agent",
                    CreatedAt = DateTime.Now.AddDays(-8)
                },
                new User
                {
                    UserId = "USE0007",
                    Name = "David Lee",
                    Email = "david.l@example.com",
                    Password = "e86f78a8a3caf0b60d8e74e5942aa6d86dc150cd3c03338aef25b7d2d7e3acc7",
                    Phone = "01078901234",
                    Role = "user",
                    CreatedAt = DateTime.Now.AddDays(-5)
                },
                new User
                {
                    UserId = "USE0008",
                    Name = "Jessica Chen",
                    Email = "jessica.c@example.com",
                    Password = "e86f78a8a3caf0b60d8e74e5942aa6d86dc150cd3c03338aef25b7d2d7e3acc7",
                    Phone = "01089012345",
                    Role = "user",
                    CreatedAt = DateTime.Now.AddDays(-3)
                },
                new User
                {
                    UserId = "USE0009",
                    Name = "Robert Smith",
                    Email = "robert.s@example.com",
                    Password = "e86f78a8a3caf0b60d8e74e5942aa6d86dc150cd3c03338aef25b7d2d7e3acc7",
                    Phone = "01090123456",
                    Role = "agent",
                    CreatedAt = DateTime.Now.AddDays(-2)
                },
                new User
                {
                    UserId = "USE0010",
                    Name = "Lisa Wong",
                    Email = "lisa.w@example.com",
                    Password = "e86f78a8a3caf0b60d8e74e5942aa6d86dc150cd3c03338aef25b7d2d7e3acc7",
                    Phone = "01001234567",
                    Role = "user",
                    CreatedAt = DateTime.Now.AddDays(-1)
                }
            };

            // 2. Properties (15 properties)
            var properties = new[]
            {
                new Property
                {
                    PropertyId = "PRO0001",
                    OwnerId = users[0].UserId,
                    Title = "Cozy Studio in Cyberjaya",
                    Description = "A modern and cozy studio apartment with great amenities.",
                    Location = "Cyberjaya",
                    Price = 1200,
                    Status = "available",
                    CreatedAt = DateTime.Now.AddDays(-25),
                    UpdatedAt = DateTime.Now.AddDays(-5)
                },
                new Property
                {
                    PropertyId = "PRO0002",
                    OwnerId = users[3].UserId,
                    Title = "Luxury Condo with Pool View",
                    Description = "Spacious 3-bedroom condo with amazing pool and city views.",
                    Location = "Kuala Lumpur City Center",
                    Price = 3500,
                    Status = "available",
                    CreatedAt = DateTime.Now.AddDays(-20),
                    UpdatedAt = DateTime.Now.AddDays(-3)
                },
                new Property
                {
                    PropertyId = "PRO0003",
                    OwnerId = users[5].UserId,
                    Title = "Modern Townhouse in Subang",
                    Description = "Newly renovated townhouse with private garden.",
                    Location = "Subang Jaya",
                    Price = 2200,
                    Status = "rented",
                    CreatedAt = DateTime.Now.AddDays(-18),
                    UpdatedAt = DateTime.Now.AddDays(-10)
                },
                new Property
                {
                    PropertyId = "PRO0004",
                    OwnerId = users[0].UserId,
                    Title = "Affordable Apartment for Students",
                    Description = "Perfect for students with nearby universities and amenities.",
                    Location = "Putrajaya",
                    Status = "available",
                    CreatedAt = DateTime.Now.AddDays(-15),
                    UpdatedAt = DateTime.Now.AddDays(-2)
                },
                new Property
                {
                    PropertyId = "PRO0005",
                    OwnerId = users[3].UserId,
                    Title = "Penthouse with Panoramic Views",
                    Description = "Luxurious penthouse with 360-degree city views.",
                    Location = "Mont Kiara",
                    Price = 5000,
                    Status = "available",
                    CreatedAt = DateTime.Now.AddDays(-12),
                    UpdatedAt = DateTime.Now.AddDays(-1)
                },
                new Property
                {
                    PropertyId = "PRO0006",
                    OwnerId = users[5].UserId,
                    Title = "Cozy Bungalow by the Lake",
                    Description = "Peaceful bungalow with private access to the lake.",
                    Location = "Puchong",
                    Price = 2800,
                    Status = "available",
                    CreatedAt = DateTime.Now.AddDays(-10),
                    UpdatedAt = DateTime.Now
                },
                new Property
                {
                    PropertyId = "PRO0007",
                    OwnerId = users[8].UserId,
                    Title = "Modern Studio Near MRT",
                    Description = "Fully furnished studio with easy access to public transport.",
                    Location = "Bangsar",
                    Price = 1500,
                    Status = "rented",
                    CreatedAt = DateTime.Now.AddDays(-8),
                    UpdatedAt = DateTime.Now.AddDays(-7)
                },
                new Property
                {
                    PropertyId = "PRO0008",
                    OwnerId = users[0].UserId,
                    Title = "Family-Friendly Condo",
                    Description = "Great for families with playground and swimming pool.",
                    Location = "Cheras",
                    Price = 1800,
                    Status = "available",
                    CreatedAt = DateTime.Now.AddDays(-7),
                    UpdatedAt = DateTime.Now.AddDays(-1)
                },
                new Property
                {
                    PropertyId = "PRO0009",
                    OwnerId = users[3].UserId,
                    Title = "Luxury Villa with Private Pool",
                    Description = "Exclusive villa with private pool and garden.",
                    Location = "Damansara Heights",
                    Price = 4200,
                    Status = "available",
                    CreatedAt = DateTime.Now.AddDays(-6),
                    UpdatedAt = DateTime.Now
                },
                new Property
                {
                    PropertyId = "PRO0010",
                    OwnerId = users[5].UserId,
                    Title = "Affordable Room for Rent",
                    Description = "Single room in shared apartment with utilities included.",
                    Location = "Setapak",
                    Price = 600,
                    Status = "available",
                    CreatedAt = DateTime.Now.AddDays(-5),
                    UpdatedAt = DateTime.Now
                },
                new Property
                {
                    PropertyId = "PRO0011",
                    OwnerId = users[8].UserId,
                    Title = "Commercial Space for Office",
                    Description = "Prime location commercial space suitable for offices.",
                    Location = "KL Sentral",
                    Price = 5000,
                    Status = "available",
                    CreatedAt = DateTime.Now.AddDays(-4),
                    UpdatedAt = DateTime.Now
                },
                new Property
                {
                    PropertyId = "PRO0012",
                    OwnerId = users[0].UserId,
                    Title = "Waterfront Apartment",
                    Description = "Beautiful apartment with direct waterfront access.",
                    Location = "Penang",
                    Price = 2300,
                    Status = "available",
                    CreatedAt = DateTime.Now.AddDays(-3),
                    UpdatedAt = DateTime.Now
                },
                new Property
                {
                    PropertyId = "PRO0013",
                    OwnerId = users[3].UserId,
                    Title = "Heritage House for Rent",
                    Description = "Charming heritage house with original features.",
                    Location = "Melaka",
                    Price = 1900,
                    Status = "available",
                    CreatedAt = DateTime.Now.AddDays(-2),
                    UpdatedAt = DateTime.Now
                },
                new Property
                {
                    PropertyId = "PRO0014",
                    OwnerId = users[5].UserId,
                    Title = "Serviced Apartment Monthly Rental",
                    Description = "Fully serviced apartment with weekly cleaning included.",
                    Location = "Bukit Bintang",
                    Price = 3200,
                    Status = "rented",
                    CreatedAt = DateTime.Now.AddDays(-1),
                    UpdatedAt = DateTime.Now
                },
                new Property
                {
                    PropertyId = "PRO0015",
                    OwnerId = users[8].UserId,
                    Title = "Gated Community House",
                    Description = "Secure gated community with 24/7 security.",
                    Location = "Petaling Jaya",
                    Price = 3800,
                    Status = "available",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
            };

            // 3. PropertyImages (3-5 images per property)
            var propertyImages = new[]
            {
                // Property 1 images
                new PropertyImage { PropertyId = properties[0].PropertyId, ImageUrl = "https://via.placeholder.com/600x400?text=Cozy+Studio+1" },
                new PropertyImage { PropertyId = properties[0].PropertyId, ImageUrl = "https://via.placeholder.com/600x400?text=Cozy+Studio+2" },
                new PropertyImage { PropertyId = properties[0].PropertyId, ImageUrl = "https://via.placeholder.com/600x400?text=Cozy+Studio+3" },

                // Property 2 images
                new PropertyImage { PropertyId = properties[1].PropertyId, ImageUrl = "https://via.placeholder.com/600x400?text=Luxury+Condo+1" },
                new PropertyImage { PropertyId = properties[1].PropertyId, ImageUrl = "https://via.placeholder.com/600x400?text=Luxury+Condo+2" },
                new PropertyImage { PropertyId = properties[1].PropertyId, ImageUrl = "https://via.placeholder.com/600x400?text=Luxury+Condo+3" },
                new PropertyImage { PropertyId = properties[1].PropertyId, ImageUrl = "https://via.placeholder.com/600x400?text=Luxury+Condo+4" },

                // Property 3 images
                new PropertyImage { PropertyId = properties[2].PropertyId, ImageUrl = "https://via.placeholder.com/600x400?text=Townhouse+1" },
                new PropertyImage { PropertyId = properties[2].PropertyId, ImageUrl = "https://via.placeholder.com/600x400?text=Townhouse+2" },

                // Property 4 images
                new PropertyImage { PropertyId = properties[3].PropertyId, ImageUrl = "https://via.placeholder.com/600x400?text=Student+Apartment+1" },
                new PropertyImage { PropertyId = properties[3].PropertyId, ImageUrl = "https://via.placeholder.com/600x400?text=Student+Apartment+2" },
                new PropertyImage { PropertyId = properties[3].PropertyId, ImageUrl = "https://via.placeholder.com/600x400?text=Student+Apartment+3" },

                // Property 5 images
                new PropertyImage { PropertyId = properties[4].PropertyId, ImageUrl = "https://via.placeholder.com/600x400?text=Penthouse+1" },
                new PropertyImage { PropertyId = properties[4].PropertyId, ImageUrl = "https://via.placeholder.com/600x400?text=Penthouse+2" },
                new PropertyImage { PropertyId = properties[4].PropertyId, ImageUrl = "https://via.placeholder.com/600x400?text=Penthouse+3" },
                new PropertyImage { PropertyId = properties[4].PropertyId, ImageUrl = "https://via.placeholder.com/600x400?text=Penthouse+4" },
                new PropertyImage { PropertyId = properties[4].PropertyId, ImageUrl = "https://via.placeholder.com/600x400?text=Penthouse+5" },

                // Property 6 images
                new PropertyImage { PropertyId = properties[5].PropertyId, ImageUrl = "https://via.placeholder.com/600x400?text=Bungalow+1" },
                new PropertyImage { PropertyId = properties[5].PropertyId, ImageUrl = "https://via.placeholder.com/600x400?text=Bungalow+2" },
                new PropertyImage { PropertyId = properties[5].PropertyId, ImageUrl = "https://via.placeholder.com/600x400?text=Bungalow+3" },

                // Property 7 images
                new PropertyImage { PropertyId = properties[6].PropertyId, ImageUrl = "https://via.placeholder.com/600x400?text=Studio+Near+MRT+1" },
                new PropertyImage { PropertyId = properties[6].PropertyId, ImageUrl = "https://via.placeholder.com/600x400?text=Studio+Near+MRT+2" },

                // Property 8 images
                new PropertyImage { PropertyId = properties[7].PropertyId, ImageUrl = "https://via.placeholder.com/600x400?text=Family+Condo+1" },
                new PropertyImage { PropertyId = properties[7].PropertyId, ImageUrl = "https://via.placeholder.com/600x400?text=Family+Condo+2" },
                new PropertyImage { PropertyId = properties[7].PropertyId, ImageUrl = "https://via.placeholder.com/600x400?text=Family+Condo+3" },

                // Property 9 images
                new PropertyImage { PropertyId = properties[8].PropertyId, ImageUrl = "https://via.placeholder.com/600x400?text=Luxury+Villa+1" },
                new PropertyImage { PropertyId = properties[8].PropertyId, ImageUrl = "https://via.placeholder.com/600x400?text=Luxury+Villa+2" },
                new PropertyImage { PropertyId = properties[8].PropertyId, ImageUrl = "https://via.placeholder.com/600x400?text=Luxury+Villa+3" },
                new PropertyImage { PropertyId = properties[8].PropertyId, ImageUrl = "https://via.placeholder.com/600x400?text=Luxury+Villa+4" },

                // Property 10 images
                new PropertyImage { PropertyId = properties[9].PropertyId, ImageUrl = "https://via.placeholder.com/600x400?text=Affordable+Room+1" },

                // Property 11 images
                new PropertyImage { PropertyId = properties[10].PropertyId, ImageUrl = "https://via.placeholder.com/600x400?text=Commercial+Space+1" },
                new PropertyImage { PropertyId = properties[10].PropertyId, ImageUrl = "https://via.placeholder.com/600x400?text=Commercial+Space+2" },
                new PropertyImage { PropertyId = properties[10].PropertyId, ImageUrl = "https://via.placeholder.com/600x400?text=Commercial+Space+3" },

                // Property 12 images
                new PropertyImage { PropertyId = properties[11].PropertyId, ImageUrl = "https://via.placeholder.com/600x400?text=Waterfront+1" },
                new PropertyImage { PropertyId = properties[11].PropertyId, ImageUrl = "https://via.placeholder.com/600x400?text=Waterfront+2" },

                // Property 13 images
                new PropertyImage { PropertyId = properties[12].PropertyId, ImageUrl = "https://via.placeholder.com/600x400?text=Heritage+House+1" },
                new PropertyImage { PropertyId = properties[12].PropertyId, ImageUrl = "https://via.placeholder.com/600x400?text=Heritage+House+2" },
                new PropertyImage { PropertyId = properties[12].PropertyId, ImageUrl = "https://via.placeholder.com/600x400?text=Heritage+House+3" },
                new PropertyImage { PropertyId = properties[12].PropertyId, ImageUrl = "https://via.placeholder.com/600x400?text=Heritage+House+4" },

                // Property 14 images
                new PropertyImage { PropertyId = properties[13].PropertyId, ImageUrl = "https://via.placeholder.com/600x400?text=Serviced+Apartment+1" },
                new PropertyImage { PropertyId = properties[13].PropertyId, ImageUrl = "https://via.placeholder.com/600x400?text=Serviced+Apartment+2" },

                // Property 15 images
                new PropertyImage { PropertyId = properties[14].PropertyId, ImageUrl = "https://via.placeholder.com/600x400?text=Gated+House+1" },
                new PropertyImage { PropertyId = properties[14].PropertyId, ImageUrl = "https://via.placeholder.com/600x400?text=Gated+House+2" },
                new PropertyImage { PropertyId = properties[14].PropertyId, ImageUrl = "https://via.placeholder.com/600x400?text=Gated+House+3" },
                new PropertyImage { PropertyId = properties[14].PropertyId, ImageUrl = "https://via.placeholder.com/600x400?text=Gated+House+4" }
            };

            // 4. ViewRequests (20 requests)
            var viewRequests = new[]
            {
                new ViewRequest
                {
                    ViewRequestId = "VRQ0001",
                    UserId = users[1].UserId,
                    PropertyId = properties[0].PropertyId,
                    Text = "I would like to schedule a viewing for this weekend.",
                    Status = "pending",
                    CreatedAt = DateTime.Now.AddDays(-5)
                },
                new ViewRequest
                {
                    ViewRequestId = "VRQ0002",
                    UserId = users[2].UserId,
                    PropertyId = properties[1].PropertyId,
                    Text = "Can I view the property tomorrow afternoon?",
                    Status = "approved",
                    CreatedAt = DateTime.Now.AddDays(-4)
                },
                new ViewRequest
                {
                    ViewRequestId = "VRQ0003",
                    UserId = users[4].UserId,
                    PropertyId = properties[2].PropertyId,
                    Text = "Interested in viewing. What times are available?",
                    Status = "rejected",
                    CreatedAt = DateTime.Now.AddDays(-3),
                },
                new ViewRequest
                {
                    ViewRequestId = "VRQ0004",
                    UserId = users[6].UserId,
                    PropertyId = properties[3].PropertyId,
                    Text = "Would like to see the apartment this week.",
                    Status = "pending",
                    CreatedAt = DateTime.Now.AddDays(-2)
                },
                new ViewRequest
                {
                    ViewRequestId = "VRQ0005",
                    UserId = users[7].UserId,
                    PropertyId = properties[4].PropertyId,
                    Text = "Is the penthouse available for viewing on Saturday?",
                    Status = "approved",
                    CreatedAt = DateTime.Now.AddDays(-1)
                },
                new ViewRequest
                {
                    ViewRequestId = "VRQ0006",
                    UserId = users[9].UserId,
                    PropertyId = properties[5].PropertyId,
                    Text = "Requesting a viewing for the bungalow.",
                    Status = "pending",
                    CreatedAt = DateTime.Now
                },
                new ViewRequest
                {
                    ViewRequestId = "VRQ0007",
                    UserId = users[1].UserId,
                    PropertyId = properties[6].PropertyId,
                    Text = "Can I see the studio tomorrow morning?",
                    Status = "approved",
                    CreatedAt = DateTime.Now.AddDays(-3)
                },
                new ViewRequest
                {
                    ViewRequestId = "VRQ0008",
                    UserId = users[2].UserId,
                    PropertyId = properties[7].PropertyId,
                    Text = "Interested in family condo. Available for viewing?",
                    Status = "pending",
                    CreatedAt = DateTime.Now.AddDays(-2)
                },
                new ViewRequest
                {
                    ViewRequestId = "VRQ0009",
                    UserId = users[4].UserId,
                    PropertyId = properties[8].PropertyId,
                    Text = "Would like to schedule a viewing for the villa.",
                    Status = "approved",
                    CreatedAt = DateTime.Now.AddDays(-1)
                },
                new ViewRequest
                {
                    ViewRequestId = "VRQ0010",
                    UserId = users[6].UserId,
                    PropertyId = properties[9].PropertyId,
                    Text = "Request to view the affordable room.",
                    Status = "pending",
                    CreatedAt = DateTime.Now
                },
                new ViewRequest
                {
                    ViewRequestId = "VRQ0011",
                    UserId = users[7].UserId,
                    PropertyId = properties[10].PropertyId,
                    Text = "Need to see the commercial space for our new office.",
                    Status = "approved",
                    CreatedAt = DateTime.Now.AddDays(-4)
                },
                new ViewRequest
                {
                    ViewRequestId = "VRQ0012",
                    UserId = users[9].UserId,
                    PropertyId = properties[11].PropertyId,
                    Text = "Interested in waterfront apartment. Viewing request.",
                    Status = "pending",
                    CreatedAt = DateTime.Now.AddDays(-3)
                },
                new ViewRequest
                {
                    ViewRequestId = "VRQ0013",
                    UserId = users[1].UserId,
                    PropertyId = properties[12].PropertyId,
                    Text = "Can I visit the heritage house this weekend?",
                    Status = "approved",
                    CreatedAt = DateTime.Now.AddDays(-2)
                },
                new ViewRequest
                {
                    ViewRequestId = "VRQ0014",
                    UserId = users[2].UserId,
                    PropertyId = properties[13].PropertyId,
                    Text = "Viewing request for serviced apartment.",
                    Status = "pending",
                    CreatedAt = DateTime.Now.AddDays(-1)
                },
                new ViewRequest
                {
                    ViewRequestId = "VRQ0015",
                    UserId = users[4].UserId,
                    PropertyId = properties[14].PropertyId,
                    Text = "Would like to see the gated community house.",
                    Status = "approved",
                    CreatedAt = DateTime.Now
                },
                new ViewRequest
                {
                    ViewRequestId = "VRQ0016",
                    UserId = users[6].UserId,
                    PropertyId = properties[0].PropertyId,
                    Text = "Second viewing request for the cozy studio.",
                    Status = "pending",
                    CreatedAt = DateTime.Now.AddDays(-2)
                },
                new ViewRequest
                {
                    ViewRequestId = "VRQ0017",
                    UserId = users[7].UserId,
                    PropertyId = properties[1].PropertyId,
                    Text = "Can my partner and I view the luxury condo?",
                    Status = "approved",
                    CreatedAt = DateTime.Now.AddDays(-1)
                },
                new ViewRequest
                {
                    ViewRequestId = "VRQ0018",
                    UserId = users[9].UserId,
                    PropertyId = properties[2].PropertyId,
                    Text = "Viewing request for the townhouse.",
                    Status = "rejected",
                    CreatedAt = DateTime.Now,
                },
                new ViewRequest
                {
                    ViewRequestId = "VRQ0019",
                    UserId = users[1].UserId,
                    PropertyId = properties[3].PropertyId,
                    Text = "Student looking to view the apartment.",
                    Status = "pending",
                    CreatedAt = DateTime.Now.AddDays(-1)
                },
                new ViewRequest
                {
                    ViewRequestId = "VRQ0020",
                    UserId = users[2].UserId,
                    PropertyId = properties[4].PropertyId,
                    Text = "Interested in penthouse. Viewing request.",
                    Status = "approved",
                    CreatedAt = DateTime.Now
                }
            };

            // 5. ContactMessages (25 messages)
            var contactMessages = new[]
            {
                new ContactMessage
                {
                    MessageId = "MSG0001",
                    SenderId = users[1].UserId,
                    ReceiverId = users[0].UserId,
                    PropertyId = properties[0].PropertyId,
                    Message = "Is this apartment still available?",
                    SentAt = DateTime.Now.AddDays(-10)
                },
                new ContactMessage
                {
                    MessageId = "MSG0002",
                    SenderId = users[0].UserId,
                    ReceiverId = users[1].UserId,
                    PropertyId = properties[0].PropertyId,
                    Message = "Yes, it's still available. Would you like to schedule a viewing?",
                    SentAt = DateTime.Now.AddDays(-9)
                },
                new ContactMessage
                {
                    MessageId = "MSG0003",
                    SenderId = users[1].UserId,
                    ReceiverId = users[0].UserId,
                    PropertyId = properties[0].PropertyId,
                    Message = "Yes, please. What times are available this weekend?",
                    SentAt = DateTime.Now.AddDays(-9)
                },
                new ContactMessage
                {
                    MessageId = "MSG0004",
                    SenderId = users[2].UserId,
                    ReceiverId = users[3].UserId,
                    PropertyId = properties[1].PropertyId,
                    Message = "Is the price negotiable for the luxury condo?",
                    SentAt = DateTime.Now.AddDays(-8)
                },
                new ContactMessage
                {
                    MessageId = "MSG0005",
                    SenderId = users[3].UserId,
                    ReceiverId = users[2].UserId,
                    PropertyId = properties[1].PropertyId,
                    Message = "The price is fixed, but we can discuss the terms.",
                    SentAt = DateTime.Now.AddDays(-8)
                },
                new ContactMessage
                {
                    MessageId = "MSG0006",
                    SenderId = users[4].UserId,
                    ReceiverId = users[5].UserId,
                    PropertyId = properties[2].PropertyId,
                    Message = "What's the minimum lease term for the townhouse?",
                    SentAt = DateTime.Now.AddDays(-7)
                },
                new ContactMessage
                {
                    MessageId = "MSG0007",
                    SenderId = users[5].UserId,
                    ReceiverId = users[4].UserId,
                    PropertyId = properties[2].PropertyId,
                    Message = "Minimum lease is 12 months.",
                    SentAt = DateTime.Now.AddDays(-7)
                },
                new ContactMessage
                {
                    MessageId = "MSG0008",
                    SenderId = users[6].UserId,
                    ReceiverId = users[0].UserId,
                    PropertyId = properties[3].PropertyId,
                    Message = "Are utilities included in the rent for the student apartment?",
                    SentAt = DateTime.Now.AddDays(-6)
                },
                new ContactMessage
                {
                    MessageId = "MSG0009",
                    SenderId = users[0].UserId,
                    ReceiverId = users[6].UserId,
                    PropertyId = properties[3].PropertyId,
                    Message = "Water is included, but electricity is separate.",
                    SentAt = DateTime.Now.AddDays(-6)
                },
                new ContactMessage
                {
                    MessageId = "MSG0010",
                    SenderId = users[7].UserId,
                    ReceiverId = users[3].UserId,
                    PropertyId = properties[4].PropertyId,
                    Message = "Is parking included with the penthouse?",
                    SentAt = DateTime.Now.AddDays(-5)
                },
                new ContactMessage
                {
                    MessageId = "MSG0011",
                    SenderId = users[3].UserId,
                    ReceiverId = users[7].UserId,
                    PropertyId = properties[4].PropertyId,
                    Message = "Yes, two parking spaces are included.",
                    SentAt = DateTime.Now.AddDays(-5)
                },
                new ContactMessage
                {
                    MessageId = "MSG0012",
                    SenderId = users[8].UserId,
                    ReceiverId = users[5].UserId,
                    PropertyId = properties[5].PropertyId,
                    Message = "Is the bungalow pet-friendly?",
                    SentAt = DateTime.Now.AddDays(-4)
                },
                new ContactMessage
                {
                    MessageId = "MSG0013",
                    SenderId = users[5].UserId,
                    ReceiverId = users[8].UserId,
                    PropertyId = properties[5].PropertyId,
                    Message = "Small pets are allowed with additional deposit.",
                    SentAt = DateTime.Now.AddDays(-4)
                },
                new ContactMessage
                {
                    MessageId = "MSG0014",
                    SenderId = users[9].UserId,
                    ReceiverId = users[8].UserId,
                    PropertyId = properties[6].PropertyId,
                    Message = "What's the exact distance to the MRT station?",
                    SentAt = DateTime.Now.AddDays(-3)
                },
                new ContactMessage
                {
                    MessageId = "MSG0015",
                    SenderId = users[8].UserId,
                    ReceiverId = users[9].UserId,
                    PropertyId = properties[6].PropertyId,
                    Message = "It's a 5-minute walk to the station.",
                    SentAt = DateTime.Now.AddDays(-3)
                },
                new ContactMessage
                {
                    MessageId = "MSG0016",
                    SenderId = users[1].UserId,
                    ReceiverId = users[0].UserId,
                    PropertyId = properties[7].PropertyId,
                    Message = "Are there good schools nearby the family condo?",
                    SentAt = DateTime.Now.AddDays(-2)
                },
                new ContactMessage
                {
                    MessageId = "MSG0017",
                    SenderId = users[0].UserId,
                    ReceiverId = users[1].UserId,
                    PropertyId = properties[7].PropertyId,
                    Message = "Yes, there are three international schools within 2km.",
                    SentAt = DateTime.Now.AddDays(-2)
                },
                new ContactMessage
                {
                    MessageId = "MSG0018",
                    SenderId = users[2].UserId,
                    ReceiverId = users[3].UserId,
                    PropertyId = properties[8].PropertyId,
                    Message = "Is the villa available for short-term rental?",
                    SentAt = DateTime.Now.AddDays(-1)
                },
                new ContactMessage
                {
                    MessageId = "MSG0019",
                    SenderId = users[3].UserId,
                    ReceiverId = users[2].UserId,
                    PropertyId = properties[8].PropertyId,
                    Message = "Minimum rental period is 6 months.",
                    SentAt = DateTime.Now.AddDays(-1)
                },
                new ContactMessage
                {
                    MessageId = "MSG0020",
                    SenderId = users[4].UserId,
                    ReceiverId = users[5].UserId,
                    PropertyId = properties[9].PropertyId,
                    Message = "Is the room still available? I can move in immediately.",
                    SentAt = DateTime.Now
                },
                new ContactMessage
                {
                    MessageId = "MSG0021",
                    SenderId = users[5].UserId,
                    ReceiverId = users[4].UserId,
                    PropertyId = properties[9].PropertyId,
                    Message = "Yes, it's available. When would you like to view it?",
                    SentAt = DateTime.Now
                },
                new ContactMessage
                {
                    MessageId = "MSG0022",
                    SenderId = users[6].UserId,
                    ReceiverId = users[8].UserId,
                    PropertyId = properties[10].PropertyId,
                    Message = "Is the commercial space suitable for a restaurant?",
                    SentAt = DateTime.Now.AddDays(-2)
                },
                new ContactMessage
                {
                    MessageId = "MSG0023",
                    SenderId = users[7].UserId,
                    ReceiverId = users[0].UserId,
                    PropertyId = properties[11].PropertyId,
                    Message = "What's the maintenance fee for the waterfront apartment?",
                    SentAt = DateTime.Now.AddDays(-1)
                },
                new ContactMessage
                {
                    MessageId = "MSG0024",
                    SenderId = users[8].UserId,
                    ReceiverId = users[3].UserId,
                    PropertyId = properties[12].PropertyId,
                    Message = "Is the heritage house fully furnished?",
                    SentAt = DateTime.Now
                },
                new ContactMessage
                {
                    MessageId = "MSG0025",
                    SenderId = users[9].UserId,
                    ReceiverId = users[5].UserId,
                    PropertyId = properties[13].PropertyId,
                    Message = "What amenities are included in the serviced apartment?",
                }
            };

            // 6. Feedback (10 feedbacks)
            var feedbacks = new[]
            {
                new Feedback
                {
                    FeedbackId = "FED0001",
                    ReviewerId = users[1].UserId,
                    OwnerId = users[0].UserId,
                    Rating = 5,
                    Comment = "Extremely helpful and friendly owner.",
                    SubmittedAt = DateTime.Now.AddDays(-10)
                },
                new Feedback
                {
                    FeedbackId = "FED0002",
                    ReviewerId = users[2].UserId,
                    OwnerId = users[3].UserId,
                    Rating = 4,
                    Comment = "Smooth rental process and fast replies.",
                    SubmittedAt = DateTime.Now.AddDays(-9)
                },
                new Feedback
                {
                    FeedbackId = "FED0003",
                    ReviewerId = users[4].UserId,
                    OwnerId = users[5].UserId,
                    Rating = 2,
                    Comment = "Owner was not responsive after viewing.",
                    SubmittedAt = DateTime.Now.AddDays(-8)
                },
                new Feedback
                {
                    FeedbackId = "FED0004",
                    ReviewerId = users[6].UserId,
                    OwnerId = users[0].UserId,
                    Rating = 5,
                    Comment = "One of the best landlords I’ve met!",
                    SubmittedAt = DateTime.Now.AddDays(-7)
                },
                new Feedback
                {
                    FeedbackId = "FED0005",
                    ReviewerId = users[7].UserId,
                    OwnerId = users[3].UserId,
                    Rating = 3,
                    Comment = "Mixed experience; overall okay.",
                    SubmittedAt = DateTime.Now.AddDays(-6)
                },
                new Feedback
                {
                    FeedbackId = "FED0006",
                    ReviewerId = users[8].UserId,
                    OwnerId = users[5].UserId,
                    Rating = 4,
                    Comment = "Decent support and timely handling.",
                    SubmittedAt = DateTime.Now.AddDays(-5)
                },
                new Feedback
                {
                    FeedbackId = "FED0007",
                    ReviewerId = users[9].UserId,
                    OwnerId = users[8].UserId,
                    Rating = 5,
                    Comment = "Great communication!",
                    SubmittedAt = DateTime.Now.AddDays(-4)
                },
                new Feedback
                {
                    FeedbackId = "FED0008",
                    ReviewerId = users[1].UserId,
                    OwnerId = users[0].UserId,
                    Rating = 1,
                    Comment = "Did not show up for the viewing.",
                    SubmittedAt = DateTime.Now.AddDays(-3)
                },
                new Feedback
                {
                    FeedbackId = "FED0009",
                    ReviewerId = users[2].UserId,
                    OwnerId = users[3].UserId,
                    Rating = 4,
                    Comment = "Nice person, property was clean.",
                    SubmittedAt = DateTime.Now.AddDays(-2)
                },
                new Feedback
                {
                    FeedbackId = "FED0010",
                    ReviewerId = users[4].UserId,
                    OwnerId = users[0].UserId,
                    Rating = 5,
                    Comment = "Highly recommended!",
                    SubmittedAt = DateTime.Now.AddDays(-1)
                }
            };

            // 7. Reports (10 reports)
            var reports = new[]
            {
                new Report
                {
                    ReportId = "REP0001",
                    ReporterId = users[1].UserId,
                    PropertyId = properties[0].PropertyId,
                    Reason = "Misleading price.",
                    Status = "pending",
                    CreatedAt = DateTime.Now.AddDays(-10)
                },
                new Report
                {
                    ReportId = "REP0002",
                    ReporterId = users[2].UserId,
                    PropertyId = properties[1].PropertyId,
                    Reason = "Fake pictures uploaded.",
                    Status = "reviewed",
                    CreatedAt = DateTime.Now.AddDays(-9)
                },
                new Report
                {
                    ReportId = "REP0003",
                    ReporterId = users[4].UserId,
                    PropertyId = properties[2].PropertyId,
                    Reason = "Owner not reachable.",
                    Status = "dismissed",
                    CreatedAt = DateTime.Now.AddDays(-8)
                },
                new Report
                {
                    ReportId = "REP0004",
                    ReporterId = users[6].UserId,
                    PropertyId = properties[3].PropertyId,
                    Reason = "Scam suspicion.",
                    Status = "pending",
                    CreatedAt = DateTime.Now.AddDays(-7)
                },
                new Report
                {
                    ReportId = "REP0005",
                    ReporterId = users[7].UserId,
                    PropertyId = properties[4].PropertyId,
                    Reason = "Property already rented but still listed.",
                    Status = "pending",
                    CreatedAt = DateTime.Now.AddDays(-6)
                },
                new Report
                {
                    ReportId = "REP0006",
                    ReporterId = users[8].UserId,
                    PropertyId = properties[5].PropertyId,
                    Reason = "Incorrect location details.",
                    Status = "reviewed",
                    CreatedAt = DateTime.Now.AddDays(-5)
                },
                new Report
                {
                    ReportId = "REP0007",
                    ReporterId = users[9].UserId,
                    PropertyId = properties[6].PropertyId,
                    Reason = "Listing duplicated.",
                    Status = "pending",
                    CreatedAt = DateTime.Now.AddDays(-4)
                },
                new Report
                {
                    ReportId = "REP0008",
                    ReporterId = users[1].UserId,
                    PropertyId = properties[7].PropertyId,
                    Reason = "Fake reviews on this property.",
                    Status = "dismissed",
                    CreatedAt = DateTime.Now.AddDays(-3)
                },
                new Report
                {
                    ReportId = "REP0009",
                    ReporterId = users[3].UserId,
                    PropertyId = properties[8].PropertyId,
                    Reason = "Owner requests money before viewing.",
                    Status = "pending",
                    CreatedAt = DateTime.Now.AddDays(-2)
                },
                new Report
                {
                    ReportId = "REP0010",
                    ReporterId = users[5].UserId,
                    PropertyId = properties[9].PropertyId,
                    Reason = "Incomplete property description.",
                    Status = "reviewed",
                    CreatedAt = DateTime.Now.AddDays(-1)
                }
            };

            // 8. SavedProperties (10 saved property entries)
            var savedProperties = new[]
            {
                new SavedProperty
                {
                    UserId = users[1].UserId,
                    PropertyId = properties[0].PropertyId
                },
                new SavedProperty
                {
                    UserId = users[2].UserId,
                    PropertyId = properties[1].PropertyId
                },
                new SavedProperty
                {
                    UserId = users[4].UserId,
                    PropertyId = properties[2].PropertyId
                },
                new SavedProperty
                {
                    UserId = users[6].UserId,
                    PropertyId = properties[3].PropertyId
                },
                new SavedProperty
                {
                    UserId = users[7].UserId,
                    PropertyId = properties[4].PropertyId
                },
                new SavedProperty
                {
                    UserId = users[9].UserId,
                    PropertyId = properties[5].PropertyId
                },
                new SavedProperty
                {
                    UserId = users[1].UserId,
                    PropertyId = properties[6].PropertyId
                },
                new SavedProperty
                {
                    UserId = users[3].UserId,
                    PropertyId = properties[7].PropertyId
                },
                new SavedProperty
                {
                    UserId = users[5].UserId,
                    PropertyId = properties[8].PropertyId
                },
                new SavedProperty
                {
                    UserId = users[8].UserId,
                    PropertyId = properties[9].PropertyId
                }
            };

            context.Users.AddRange(users);
            context.Properties.AddRange(properties);
            context.PropertyImages.AddRange(propertyImages);
            context.ViewRequests.AddRange(viewRequests);
            context.ContactMessages.AddRange(contactMessages);
            context.Reports.AddRange(reports);
            context.SavedProperties.AddRange(savedProperties);

            context.SaveChanges();


        }
    }
};


            