using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WasteNotBE.Models;
using WasteNotBE.Models.ApplicationUserViewModels;


namespace WasteNotBE.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<WishList> WishLists { get; set; }
        public DbSet<WishListItem> WishListItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            modelBuilder.Entity<Item>()
                .Property(b => b.DateCreated)
                .HasDefaultValueSql("GETDATE()");

            // Restrict deletion of related order when OrderProducts entry is removed
            //modelBuilder.Entity<Order>()
            //    .HasMany(o => o.OrderProducts)
            //    .WithOne(l => l.Order)
            //    .OnDelete(DeleteBehavior.Restrict);



            // Restrict deletion of related product when OrderProducts entry is removed
            //modelBuilder.Entity<Product>()
            //    .HasMany(o => o.OrderProducts)
            //    .WithOne(l => l.Product)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<PaymentType>()
            //    .Property(b => b.DateCreated)
            //    .HasDefaultValueSql("GETDATE()");

            ApplicationUser user = new ApplicationUser
            {
                FirstName = "admin",
                LastName = "admin",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString("D"),
                isAdmin = true
            };
            var passwordHash = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHash.HashPassword(user, "Admin8*");
            modelBuilder.Entity<ApplicationUser>().HasData(user);

            modelBuilder.Entity<WishList>().HasData(
                new WishList()
                {
                    Id = 1,
                    UserId = user.Id,
                    Title = "Essentials"
                },
                new WishList()
                {
                    Id = 2,
                    UserId = user.Id,
                    Title = "WishList"
                }
                
            );


            modelBuilder.Entity<WishListItem>().HasData(
                new WishListItem()
                {
                    Id = 1,
                    ItemId = 1,
                    WishListId= 1
                },
                new WishListItem()
                {
                    Id = 2,
                    ItemId = 2,
                    WishListId = 1
                },
                new WishListItem()
                {
                    Id = 3,
                    ItemId = 3,
                    WishListId = 1
                },
                new WishListItem()
                {
                    Id = 4,
                    ItemId = 4,
                    WishListId = 1
                },
                new WishListItem()
                {
                    Id = 5,
                    ItemId = 2,
                    WishListId = 2
                },
                 new WishListItem()
                 {
                     Id = 6,
                     ItemId = 5,
                     WishListId = 2
                 },
                  new WishListItem()
                  {
                      Id = 7,
                      ItemId = 6,
                      WishListId = 2
                  },
                   new WishListItem()
                   {
                       Id = 8,
                       ItemId = 7,
                       WishListId = 2
                   }
            );

            modelBuilder.Entity<Category>().HasData(
                 new Category()
                 {
                     Id = 2,
                     Title = "Grocery"
                 }, 
                 new Category()
                 {
                     Id = 3,
                     Title = "Kitchen"
                 },
                 new Category()
                 {
                     Id = 4,
                     Title = "Travel"
                 },
                 new Category()
                 {
                     Id = 5,
                     Title = "Bath"
                 },
                 new Category()
                 {
                     Id = 6,
                     Title = "Beauty"
                 },
                 new Category()
                 {
                     Id = 7,
                     Title = "Apparel"
                 },
                 new Category()
                 {
                     Id = 8,
                     Title = "Cleaning"
                 },
                    new Category()
                    {
                        Id = 9,
                        Title = "Office"
                    }
            );

            modelBuilder.Entity<Item>().HasData(
                new Item()
                {
                    Id = 1,
                    Title = "Bambu Reusable Travel Fork",
                    UserId = user.Id,
                    Description = $@"- Packaging: Comes in a paper sleeve without any plastic tape; can be recycled or added to your compost. 
                    - Use: I keep it tucked in a small napkin inside my purse or tote bag.It's great for traveling, or for keeping a utensil with me when I'm out and about, just in case.
                    -Care: Wash with dish soap and air dry.Bamboo can become moldy if not dried properly, so I wipe mine quickly with a dishtowel before letting it finish air drying in the dish rack.
                    - Disposal: The bamboo spork can be composted(you may want to very carefully break it up a bit first). If you cut the stitching and glue from the sides of the cork case, it can be composted as well",
                    CategoryId = 4,

                    SourceLink = "https://earthhero.com/products/travel/bambu-spork-and-cork-set/",
                    PhotoUrl = "https://static1.squarespace.com/static/55cfcd4ae4b0c17da812b28a/t/5a0a2a054192029150c743fb/1534804577577/Reusable+Bambu+travel+spork+and+utensil+%7C+Litterless?format=1000w",
                    ReplacementTag = "fork utensil utensils spork"
                    
                },
                new Item ()
                {
                    Id = 2,
                    Title = "Baggu Reusable Tote Bags",
                    UserId = user.Id,
                    Description = $@"-Packaging: May come in a small plastic bag, which you can take to a local drugstore or grocery store to recycle. Compost or recycle the paper 'Baggu' tag and throw away the plastic loop attaching it to the bag.
                    - Use: Carry with you everywhere!Perfect tucked in your bag or coat pocket.
                    - Care: Machine wash cold with your other garments or hand wash,
                    then hang to dry.Minimize washing when will keep the bag in better shape longer.
                    - Disposal: Baggu accepts their bags back for recycling; you can send it back to them by following the instructions on their website",
                    CategoryId = 4,

                    SourceLink = "https://www.amazon.com/BAGGU-Standard-Reusable-Shopping-Bag/dp/B00CRPOUS4/ref=as_li_ss_tl?ie=UTF8&qid=1510679139&sr=8-1&keywords=baggu&linkCode=sl1&tag=l0875-20&linkId=c95ee97caddd67a873d0f14dc139ed4a",
                    PhotoUrl = "https://images-na.ssl-images-amazon.com/images/I/81EfOAma9QL._SX679_.jpg",
                    ReplacementTag = "bag plastic grocery"
                  
                },
                new Item()
                {
                    Id = 3,
                    Title = "Bamboo Toothbrush",
                    UserId = user.Id,
                    Description = $@"-Packaging: Packaged in paper with a compostable inner plant-based liner. You can recycle the paper, or tear it up into small pieces to compost. The inner liner can be commercially composted.
                      -Use: Brush teeth as normal :)
                      -Care: Dry your toothbrush after each use to prevent it from getting moldy, and store it upright in a glass or jar to help air circulate. You can find more of my tips on taking care of it to help it last here.
                      -Disposal: The bristles should be removed with pliers and added to the trash; the brush handle is entirely made of bamboo and can be composted. First, try upcycling your brush for cleaning, as a plant marker, and more. ",
                    CategoryId = 5,

                    SourceLink = "https://www.brushwithbamboo.com/shop/",
                    PhotoUrl = "https://s7d5.scene7.com/is/image/FreePeople/43335264_001_a?$a15-pdp-detail-shot$&hei=900&qlt=80&fit=constrain",
                    ReplacementTag = "bag plastic grocery"
                   
                },
                new Item()
                {
                    Id = 4,
                    Title = "How To Use a Safety Razor",
                    UserId = user.Id,
                    CategoryId = 5,

                    SourceLink = "https://www.thezerowastecollective.com/blog/shaving-with-a-safety-razor-this-zero-waste-swap-is-easier-than-you-think",
                    PhotoUrl = "https://i.pinimg.com/564x/bd/5e/7b/bd5e7bba29d3d544034d2336f9f99911.jpg",
                    ReplacementTag = "bath razor safety shave"
                  
                },
                 new Item()
                 {
                     Id = 5,
                     Title = "Pan Your Meals Around The Farmer's Market",
                     UserId = user.Id,
                     Description = "This step-by-step guide will help you learn to plan meals around farmers market trips so you can eat local, waste less food, and save money!",
                     CategoryId = 2,

                     SourceLink = "https://www.forkintheroad.co/farmers-market-meal-planning/?utm_medium=social&utm_source=pinterest&utm_campaign=tailwind_tribes&utm_content=tribes&utm_term=555492632_20372870_160564",
                     PhotoUrl = "https://i.pinimg.com/564x/72/0f/9f/720f9f2e9416acc0ab28d109f328e883.jpg",
                     ReplacementTag = "market farmer's market meal-planning grocery"
                    
                 },
                  new Item()
                  {
                      Id = 6,
                      Title = "Leftover Espresso Grounds Brownies",
                      UserId = user.Id,
                      Description = "Leftover Espresso Grounds Brownies, a rich fudgy brownie recipe made with leftover espresso grounds. Reuse those coffee grounds for a deliciously moist chocolaty treat!",
                      CategoryId = 2,

                      SourceLink = "https://www.forkintheroad.co/leftover-espresso-grounds-brownies/",
                      PhotoUrl = "https://www.forkintheroad.co/wp-content/uploads/2019/01/leftover-espresso-grounds-brownies-102.jpg",
                      ReplacementTag = "coffee espresso leftovers brownie recipe market meal-planning grocery"
                    
                  },
                  new Item()
                  {
                      Id = 7,
                      Title = "Zero Waste Kitchen Checklist",
                      UserId = user.Id,
                      Description = "A simple room by room guide to a zero waste home which should make transitioning to a plastic free lifestyle easy as pie!",
                      CategoryId = 3,

                      SourceLink = "https://www.tinyyellowbungalow.com/room-by-room-zero-waste-guide/",
                      PhotoUrl = "https://i.pinimg.com/564x/5c/b1/05/5cb105d9e78787ca1dbe6ceedeb9baf2.jpg",
                      ReplacementTag = "kitchen zero waste checklist"
                      
                  },
                   new Item()
                   {
                       Id = 8,
                       Title = "RMS Lip2Cheek",
                       UserId = user.Id,
                       Description = "Plastic-encased makeup that gets tossed every few months isn’t exactly a sustainable approach to a conscious beauty routine. Use environmentally-safe products that come in a glass container (it can be recycled or repurposed) that are multipurpose for a one-two punch.",
                       CategoryId = 6,

                       SourceLink = "https://credobeauty.com/products/rms-beauty-lip2cheek-beloved?sscid=41k3_obmcm&utm_source=shareasale&utm_medium=referral&utm_campaign=shareasale",
                       PhotoUrl = "https://mediacdn.espssl.com/9428/Popup%20Images/popup-image-2.jpg",
                       ReplacementTag = "beauty sustainable lip cheek blush"
                      
                   },
                   new Item()
                   {
                       Id = 9,
                       Title = "Shampoo Bar",
                       UserId = user.Id,
                       Description = "Ditch the plastic bottle and switch to a bar! It’s a *gasp* moment for hair care devotees, I know, but there are so many eco-friendly options out there that you’re sure to find a product you love. Not only is this a plastic-free bathroom essential they’re also known to outlast standard shampoos.",
                       CategoryId = 9,


                       SourceLink = "https://www.amazon.com/dp/B07572ZHB9?ascsubtag=.Mjg3Mzg2LTA.056fb4ed-6b7f-11e9-941d-81adbcf9f5c1&tag=rewardstyle-20&th=1",
                       PhotoUrl = "https://i.pinimg.com/564x/98/ce/ff/98ceffe3863fb31c49e4176e1b515442.jpg",
                       ReplacementTag = "beauty sustainable shampoo hair"
                     
                   },
                    new Item()
                    {
                        Id = 10,
                        Title = "6 Zero Waste Designers Who Are Just Killing It",
                        UserId = user.Id,
                        CategoryId = 9,


                        SourceLink = "https://eluxemagazine.com/fashion/zero-waste-designers/",
                        PhotoUrl = "https://i.pinimg.com/564x/aa/47/53/aa47539be1a44b76422539b28eb98aa5.jpg",
                        ReplacementTag = "Zero Waste Designers, the best zero waste fashion collections, zero waste sustainable fashion, zero waste fashion techniques, what is zero waste fashion"
                      
                    },
                     new Item()
                     {
                         Id = 11,
                         Title = "Zero Waste: Closet Transition",
                         UserId = user.Id,
                         Description = "Transitioning and living a zero waste life means working with your closet in order to extend the life of your existing clothes or find ways to purchase clothing that is less harmful to the Earth.",
                
                       
                         SourceLink = "http://www.thedosomethingproject.com/home/zero-waste-closet-transition",
                         PhotoUrl = "https://i.pinimg.com/564x/d8/43/29/d84329e35bc3536810ffb2999b59ee0a.jpg",
                         ReplacementTag = "closet transition clothing wardrobe apparel"
                     },
                      new Item()
                      {
                          Id = 12,
                          Title = "Bamboo Clothes Drying Rack",
                          UserId = user.Id,
                          Description = $@"-Use: Great for drying clothing and linens. Be sure to hang small things, like handkerchiefs and socks, on the slanted portions to maximize your available space.
                            - Care: It folds up when not in use; store it somewhere dry, like an upstairs closet.Bamboo can get moldy when wet for extended periods of time, but that shouldn't happen with this since the clothes dry fairly quickly. If you're worried, you can always quickly wipe it down with a dry cloth before storing.
                            - Disposal: Unlike metal drying racks which will eventually need to be landfilled, this bamboo rack can eventually compost back down into nothing.But it should last for years and years first and, if possible, should be donated rather than composted if you decide you don't need it.",
                          CategoryId = 8,

                          SourceLink = "https://www.amazon.com/Household-Essentials-6524-Folding-Clothes/dp/B003VYAGOC/ref=as_li_ss_tl?ie=UTF8&qid=1510535751&sr=8-4&keywords=bamboo+drying+rack&linkCode=sl1&tag=l0875-20&linkId=4cb236866ff58a11a6c410c505662976",
                          PhotoUrl = "https://static1.squarespace.com/static/55cfcd4ae4b0c17da812b28a/t/5a08f28a9140b7f3b7afa9f7/1510614942465/Screen+Shot+2017-11-12+at+7.16.11+PM.png?format=1000w",
                          ReplacementTag = "dryer drying laundry"
                      },
                       new Item()
                       {
                           Id = 13,
                           Title = "Compostable Wooden Dish and Bottle Brush",
                           UserId = user.Id,
                           Description = $@"-Packaging: This comes packaged in a clear plastic sleeve (if you buy it locally or from a zero waste store and it doesn't, it's likely that they just removed the packaging before displaying). Since the packaging is stretchy, it can likely be recycled with other plastic bags at a local drugstore or grocery.
                            -Use: Dish washing! I love this shape because the round head means that it makes washing pots and bottles and jars super easy and quick. Add a little dish soap to the bristles, run a bit of water on them, and go to town.
                            -Care: Store upright in a jar or container to let the handle and top dry out between uses. Especially if you cook with meat, take care to sterilize it every so often by boiling for at least five minutes.
                            -Disposal: It's all wood and natural bristles, so it's compostable at the end of its life. You can also give it a good clean and then repurpose it in the bathroom as a toilet brush..",
                           CategoryId = 8,
                           SourceLink = "https://www.therefillrevolution.com/household/redecker-wooden-milk-bottle-brush?category=Kitchen&rfsn=1119018.bfaf1e",
                           PhotoUrl = "https://static1.squarespace.com/static/55cfcd4ae4b0c17da812b28a/t/5a592d994192027937a4ed63/1534804577612/Compostable+wooden+dish+brush+for+zero+waste+dishwashing+%7C+Litterless?format=1000w",
                           ReplacementTag = "brush dishes kitchen bottle soap dish"
                          
                       },
                        new Item()
                        {
                            Id = 14,
                            Title = "Desk Eco-Friendly Checklist",
                            UserId = user.Id,
                            Description = "Ditch the plastic bottle and switch to a bar! It’s a *gasp* moment for hair care devotees, I know, but there are so many eco-friendly options out there that you’re sure to find a product you love. Not only is this a plastic-free bathroom essential they’re also known to outlast standard shampoos.",
                            CategoryId = 9,

                            SourceLink = "google.com",
                            PhotoUrl = "https://i.pinimg.com/564x/37/cb/e8/37cbe859fc691c3d83abfe29afc560e3.jpg",
                            ReplacementTag = "office desk"
                           
                        },
                         new Item()
                         {
                             Id = 15,
                             Title = "Zero Waste Office",
                             UserId = user.Id,
                             Description = "You live in the real world, and it's not always easy to stick to your high principles when you're on your grind from 9 to 5. As with everything, a little bit of planning and preparation go a long way.",
                             CategoryId = 9,

                             SourceLink = "https://smallshop.co.uk/blog/2018/2/16/7-ways-to-go-zero-waste-at-work?utm_content=tribes&utm_term=316545498_9353590_257281",
                             PhotoUrl = "https://static1.squarespace.com/static/58ca692459cc682c73a99835/t/5a8700db71c10bc44db6570e/1518797029336/Minimal+office?format=2500w",
                             ReplacementTag = "office tips desk work"
                             
                             
                         }
            );
        }

        public DbSet<WasteNotBE.Models.ApplicationUserViewModels.ProfileViewModel> ProfileViewModel { get; set; }

    }
}
