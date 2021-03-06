﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WasteNotBE.Data;

namespace WasteNotBE.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("WasteNotBE.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Title = "Grocery"
                        },
                        new
                        {
                            Id = 3,
                            Title = "Kitchen"
                        },
                        new
                        {
                            Id = 4,
                            Title = "Travel"
                        },
                        new
                        {
                            Id = 5,
                            Title = "Bath"
                        },
                        new
                        {
                            Id = 6,
                            Title = "Beauty"
                        },
                        new
                        {
                            Id = 7,
                            Title = "Apparel"
                        },
                        new
                        {
                            Id = 8,
                            Title = "Cleaning"
                        },
                        new
                        {
                            Id = 9,
                            Title = "Office"
                        });
                });

            modelBuilder.Entity("WasteNotBE.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId");

                    b.Property<DateTime?>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Description");

                    b.Property<string>("PhotoUrl");

                    b.Property<string>("ReplacementTag");

                    b.Property<string>("SourceLink");

                    b.Property<string>("Title");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 4,
                            Description = @"- Packaging: Comes in a paper sleeve without any plastic tape; can be recycled or added to your compost. 
                    - Use: I keep it tucked in a small napkin inside my purse or tote bag.It's great for traveling, or for keeping a utensil with me when I'm out and about, just in case.
                    -Care: Wash with dish soap and air dry.Bamboo can become moldy if not dried properly, so I wipe mine quickly with a dishtowel before letting it finish air drying in the dish rack.
                    - Disposal: The bamboo spork can be composted(you may want to very carefully break it up a bit first). If you cut the stitching and glue from the sides of the cork case, it can be composted as well",
                            PhotoUrl = "https://static1.squarespace.com/static/55cfcd4ae4b0c17da812b28a/t/5a0a2a054192029150c743fb/1534804577577/Reusable+Bambu+travel+spork+and+utensil+%7C+Litterless?format=1000w",
                            ReplacementTag = "fork utensil utensils spork",
                            SourceLink = "https://earthhero.com/products/travel/bambu-spork-and-cork-set/",
                            Title = "Bambu Reusable Travel Fork",
                            UserId = "a89ce0a8-ac52-4454-b563-8f4b297784cd"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 4,
                            Description = @"-Packaging: May come in a small plastic bag, which you can take to a local drugstore or grocery store to recycle. Compost or recycle the paper 'Baggu' tag and throw away the plastic loop attaching it to the bag.
                    - Use: Carry with you everywhere!Perfect tucked in your bag or coat pocket.
                    - Care: Machine wash cold with your other garments or hand wash,
                    then hang to dry.Minimize washing when will keep the bag in better shape longer.
                    - Disposal: Baggu accepts their bags back for recycling; you can send it back to them by following the instructions on their website",
                            PhotoUrl = "https://images-na.ssl-images-amazon.com/images/I/81EfOAma9QL._SX679_.jpg",
                            ReplacementTag = "bag plastic grocery",
                            SourceLink = "https://www.amazon.com/BAGGU-Standard-Reusable-Shopping-Bag/dp/B00CRPOUS4/ref=as_li_ss_tl?ie=UTF8&qid=1510679139&sr=8-1&keywords=baggu&linkCode=sl1&tag=l0875-20&linkId=c95ee97caddd67a873d0f14dc139ed4a",
                            Title = "Baggu Reusable Tote Bags",
                            UserId = "a89ce0a8-ac52-4454-b563-8f4b297784cd"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 5,
                            Description = @"-Packaging: Packaged in paper with a compostable inner plant-based liner. You can recycle the paper, or tear it up into small pieces to compost. The inner liner can be commercially composted.
                      -Use: Brush teeth as normal :)
                      -Care: Dry your toothbrush after each use to prevent it from getting moldy, and store it upright in a glass or jar to help air circulate. You can find more of my tips on taking care of it to help it last here.
                      -Disposal: The bristles should be removed with pliers and added to the trash; the brush handle is entirely made of bamboo and can be composted. First, try upcycling your brush for cleaning, as a plant marker, and more. ",
                            PhotoUrl = "https://s7d5.scene7.com/is/image/FreePeople/43335264_001_a?$a15-pdp-detail-shot$&hei=900&qlt=80&fit=constrain",
                            ReplacementTag = "bag plastic grocery",
                            SourceLink = "https://www.brushwithbamboo.com/shop/",
                            Title = "Bamboo Toothbrush",
                            UserId = "a89ce0a8-ac52-4454-b563-8f4b297784cd"
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 5,
                            PhotoUrl = "https://i.pinimg.com/564x/bd/5e/7b/bd5e7bba29d3d544034d2336f9f99911.jpg",
                            ReplacementTag = "bath razor safety shave",
                            SourceLink = "https://www.thezerowastecollective.com/blog/shaving-with-a-safety-razor-this-zero-waste-swap-is-easier-than-you-think",
                            Title = "How To Use a Safety Razor",
                            UserId = "a89ce0a8-ac52-4454-b563-8f4b297784cd"
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 2,
                            Description = "This step-by-step guide will help you learn to plan meals around farmers market trips so you can eat local, waste less food, and save money!",
                            PhotoUrl = "https://i.pinimg.com/564x/72/0f/9f/720f9f2e9416acc0ab28d109f328e883.jpg",
                            ReplacementTag = "market farmer's market meal-planning grocery",
                            SourceLink = "https://www.forkintheroad.co/farmers-market-meal-planning/?utm_medium=social&utm_source=pinterest&utm_campaign=tailwind_tribes&utm_content=tribes&utm_term=555492632_20372870_160564",
                            Title = "Pan Your Meals Around The Farmer's Market",
                            UserId = "a89ce0a8-ac52-4454-b563-8f4b297784cd"
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 2,
                            Description = "Leftover Espresso Grounds Brownies, a rich fudgy brownie recipe made with leftover espresso grounds. Reuse those coffee grounds for a deliciously moist chocolaty treat!",
                            PhotoUrl = "https://www.forkintheroad.co/wp-content/uploads/2019/01/leftover-espresso-grounds-brownies-102.jpg",
                            ReplacementTag = "coffee espresso leftovers brownie recipe market meal-planning grocery",
                            SourceLink = "https://www.forkintheroad.co/leftover-espresso-grounds-brownies/",
                            Title = "Leftover Espresso Grounds Brownies",
                            UserId = "a89ce0a8-ac52-4454-b563-8f4b297784cd"
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 3,
                            Description = "A simple room by room guide to a zero waste home which should make transitioning to a plastic free lifestyle easy as pie!",
                            PhotoUrl = "https://i.pinimg.com/564x/5c/b1/05/5cb105d9e78787ca1dbe6ceedeb9baf2.jpg",
                            ReplacementTag = "kitchen zero waste checklist",
                            SourceLink = "https://www.tinyyellowbungalow.com/room-by-room-zero-waste-guide/",
                            Title = "Zero Waste Kitchen Checklist",
                            UserId = "a89ce0a8-ac52-4454-b563-8f4b297784cd"
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 6,
                            Description = "Plastic-encased makeup that gets tossed every few months isn’t exactly a sustainable approach to a conscious beauty routine. Use environmentally-safe products that come in a glass container (it can be recycled or repurposed) that are multipurpose for a one-two punch.",
                            PhotoUrl = "https://mediacdn.espssl.com/9428/Popup%20Images/popup-image-2.jpg",
                            ReplacementTag = "beauty sustainable lip cheek blush",
                            SourceLink = "https://credobeauty.com/products/rms-beauty-lip2cheek-beloved?sscid=41k3_obmcm&utm_source=shareasale&utm_medium=referral&utm_campaign=shareasale",
                            Title = "RMS Lip2Cheek",
                            UserId = "a89ce0a8-ac52-4454-b563-8f4b297784cd"
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 9,
                            Description = "Ditch the plastic bottle and switch to a bar! It’s a *gasp* moment for hair care devotees, I know, but there are so many eco-friendly options out there that you’re sure to find a product you love. Not only is this a plastic-free bathroom essential they’re also known to outlast standard shampoos.",
                            PhotoUrl = "https://i.pinimg.com/564x/98/ce/ff/98ceffe3863fb31c49e4176e1b515442.jpg",
                            ReplacementTag = "beauty sustainable shampoo hair",
                            SourceLink = "https://www.amazon.com/dp/B07572ZHB9?ascsubtag=.Mjg3Mzg2LTA.056fb4ed-6b7f-11e9-941d-81adbcf9f5c1&tag=rewardstyle-20&th=1",
                            Title = "Shampoo Bar",
                            UserId = "a89ce0a8-ac52-4454-b563-8f4b297784cd"
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 9,
                            PhotoUrl = "https://i.pinimg.com/564x/aa/47/53/aa47539be1a44b76422539b28eb98aa5.jpg",
                            ReplacementTag = "Zero Waste Designers, the best zero waste fashion collections, zero waste sustainable fashion, zero waste fashion techniques, what is zero waste fashion",
                            SourceLink = "https://eluxemagazine.com/fashion/zero-waste-designers/",
                            Title = "6 Zero Waste Designers Who Are Just Killing It",
                            UserId = "a89ce0a8-ac52-4454-b563-8f4b297784cd"
                        },
                        new
                        {
                            Id = 11,
                            CategoryId = 0,
                            Description = "Transitioning and living a zero waste life means working with your closet in order to extend the life of your existing clothes or find ways to purchase clothing that is less harmful to the Earth.",
                            PhotoUrl = "https://i.pinimg.com/564x/d8/43/29/d84329e35bc3536810ffb2999b59ee0a.jpg",
                            ReplacementTag = "closet transition clothing wardrobe apparel",
                            SourceLink = "http://www.thedosomethingproject.com/home/zero-waste-closet-transition",
                            Title = "Zero Waste: Closet Transition",
                            UserId = "a89ce0a8-ac52-4454-b563-8f4b297784cd"
                        },
                        new
                        {
                            Id = 12,
                            CategoryId = 8,
                            Description = @"-Use: Great for drying clothing and linens. Be sure to hang small things, like handkerchiefs and socks, on the slanted portions to maximize your available space.
                            - Care: It folds up when not in use; store it somewhere dry, like an upstairs closet.Bamboo can get moldy when wet for extended periods of time, but that shouldn't happen with this since the clothes dry fairly quickly. If you're worried, you can always quickly wipe it down with a dry cloth before storing.
                            - Disposal: Unlike metal drying racks which will eventually need to be landfilled, this bamboo rack can eventually compost back down into nothing.But it should last for years and years first and, if possible, should be donated rather than composted if you decide you don't need it.",
                            PhotoUrl = "https://static1.squarespace.com/static/55cfcd4ae4b0c17da812b28a/t/5a08f28a9140b7f3b7afa9f7/1510614942465/Screen+Shot+2017-11-12+at+7.16.11+PM.png?format=1000w",
                            ReplacementTag = "dryer drying laundry",
                            SourceLink = "https://www.amazon.com/Household-Essentials-6524-Folding-Clothes/dp/B003VYAGOC/ref=as_li_ss_tl?ie=UTF8&qid=1510535751&sr=8-4&keywords=bamboo+drying+rack&linkCode=sl1&tag=l0875-20&linkId=4cb236866ff58a11a6c410c505662976",
                            Title = "Bamboo Clothes Drying Rack",
                            UserId = "a89ce0a8-ac52-4454-b563-8f4b297784cd"
                        },
                        new
                        {
                            Id = 13,
                            CategoryId = 8,
                            Description = @"-Packaging: This comes packaged in a clear plastic sleeve (if you buy it locally or from a zero waste store and it doesn't, it's likely that they just removed the packaging before displaying). Since the packaging is stretchy, it can likely be recycled with other plastic bags at a local drugstore or grocery.
                            -Use: Dish washing! I love this shape because the round head means that it makes washing pots and bottles and jars super easy and quick. Add a little dish soap to the bristles, run a bit of water on them, and go to town.
                            -Care: Store upright in a jar or container to let the handle and top dry out between uses. Especially if you cook with meat, take care to sterilize it every so often by boiling for at least five minutes.
                            -Disposal: It's all wood and natural bristles, so it's compostable at the end of its life. You can also give it a good clean and then repurpose it in the bathroom as a toilet brush..",
                            PhotoUrl = "https://static1.squarespace.com/static/55cfcd4ae4b0c17da812b28a/t/5a592d994192027937a4ed63/1534804577612/Compostable+wooden+dish+brush+for+zero+waste+dishwashing+%7C+Litterless?format=1000w",
                            ReplacementTag = "brush dishes kitchen bottle soap dish",
                            SourceLink = "https://www.therefillrevolution.com/household/redecker-wooden-milk-bottle-brush?category=Kitchen&rfsn=1119018.bfaf1e",
                            Title = "Compostable Wooden Dish and Bottle Brush",
                            UserId = "a89ce0a8-ac52-4454-b563-8f4b297784cd"
                        },
                        new
                        {
                            Id = 14,
                            CategoryId = 9,
                            Description = "Ditch the plastic bottle and switch to a bar! It’s a *gasp* moment for hair care devotees, I know, but there are so many eco-friendly options out there that you’re sure to find a product you love. Not only is this a plastic-free bathroom essential they’re also known to outlast standard shampoos.",
                            PhotoUrl = "https://i.pinimg.com/564x/37/cb/e8/37cbe859fc691c3d83abfe29afc560e3.jpg",
                            ReplacementTag = "office desk",
                            SourceLink = "google.com",
                            Title = "Desk Eco-Friendly Checklist",
                            UserId = "a89ce0a8-ac52-4454-b563-8f4b297784cd"
                        },
                        new
                        {
                            Id = 15,
                            CategoryId = 9,
                            Description = "You live in the real world, and it's not always easy to stick to your high principles when you're on your grind from 9 to 5. As with everything, a little bit of planning and preparation go a long way.",
                            PhotoUrl = "https://static1.squarespace.com/static/58ca692459cc682c73a99835/t/5a8700db71c10bc44db6570e/1518797029336/Minimal+office?format=2500w",
                            ReplacementTag = "office tips desk work",
                            SourceLink = "https://smallshop.co.uk/blog/2018/2/16/7-ways-to-go-zero-waste-at-work?utm_content=tribes&utm_term=316545498_9353590_257281",
                            Title = "Zero Waste Office",
                            UserId = "a89ce0a8-ac52-4454-b563-8f4b297784cd"
                        });
                });

            modelBuilder.Entity("WasteNotBE.Models.WishList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("WishLists");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "Essentials",
                            UserId = "a89ce0a8-ac52-4454-b563-8f4b297784cd"
                        },
                        new
                        {
                            Id = 2,
                            Title = "WishList",
                            UserId = "a89ce0a8-ac52-4454-b563-8f4b297784cd"
                        });
                });

            modelBuilder.Entity("WasteNotBE.Models.WishListItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ItemId");

                    b.Property<int>("WishListId");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("WishListId");

                    b.ToTable("WishListItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ItemId = 1,
                            WishListId = 1
                        },
                        new
                        {
                            Id = 2,
                            ItemId = 2,
                            WishListId = 1
                        },
                        new
                        {
                            Id = 3,
                            ItemId = 3,
                            WishListId = 1
                        },
                        new
                        {
                            Id = 4,
                            ItemId = 4,
                            WishListId = 1
                        },
                        new
                        {
                            Id = 5,
                            ItemId = 2,
                            WishListId = 2
                        },
                        new
                        {
                            Id = 6,
                            ItemId = 5,
                            WishListId = 2
                        },
                        new
                        {
                            Id = 7,
                            ItemId = 6,
                            WishListId = 2
                        },
                        new
                        {
                            Id = 8,
                            ItemId = 7,
                            WishListId = 2
                        });
                });

            modelBuilder.Entity("WasteNotBE.Models.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("PhotoURL");

                    b.Property<string>("Story");

                    b.Property<bool>("isAdmin");

                    b.HasDiscriminator().HasValue("ApplicationUser");

                    b.HasData(
                        new
                        {
                            Id = "a89ce0a8-ac52-4454-b563-8f4b297784cd",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "c839ef80-43d6-40fc-a6c7-aa59b7377824",
                            Email = "admin@admin.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@ADMIN.COM",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAECN01AZdU/NniOzZ8cahH86/HrwnY4n4K9oYR4cd0u7FFo00Az9VPXxRMPaOxUn5Bg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "93bf2895-d280-4946-971c-88675acae3ce",
                            TwoFactorEnabled = false,
                            UserName = "admin",
                            FirstName = "admin",
                            LastName = "admin",
                            isAdmin = true
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WasteNotBE.Models.Item", b =>
                {
                    b.HasOne("WasteNotBE.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("WasteNotBE.Models.WishList", b =>
                {
                    b.HasOne("WasteNotBE.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("WasteNotBE.Models.WishListItem", b =>
                {
                    b.HasOne("WasteNotBE.Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WasteNotBE.Models.WishList", "WishList")
                        .WithMany("WishListItems")
                        .HasForeignKey("WishListId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
