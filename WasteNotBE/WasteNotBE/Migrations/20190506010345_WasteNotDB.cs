using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WasteNotBE.Migrations
{
    public partial class WasteNotDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Story = table.Column<string>(nullable: true),
                    PhotoURL = table.Column<string>(nullable: true),
                    isAdmin = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false),
                    SourceLink = table.Column<string>(nullable: true),
                    PhotoUrl = table.Column<string>(nullable: true),
                    ReplacementTag = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WishLists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WishLists_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WishListItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ItemId = table.Column<int>(nullable: false),
                    WishListId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishListItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WishListItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WishListItems_WishLists_WishListId",
                        column: x => x.WishListId,
                        principalTable: "WishLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "FirstName", "LastName", "PhotoURL", "Story", "isAdmin" },
                values: new object[] { "a89ce0a8-ac52-4454-b563-8f4b297784cd", 0, "c839ef80-43d6-40fc-a6c7-aa59b7377824", "ApplicationUser", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAEAACcQAAAAECN01AZdU/NniOzZ8cahH86/HrwnY4n4K9oYR4cd0u7FFo00Az9VPXxRMPaOxUn5Bg==", null, false, "93bf2895-d280-4946-971c-88675acae3ce", false, "admin", "admin", "admin", null, null, true });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 2, "Grocery" },
                    { 3, "Kitchen" },
                    { 4, "Travel" },
                    { 5, "Bath" },
                    { 6, "Beauty" },
                    { 7, "Apparel" },
                    { 8, "Cleaning" },
                    { 9, "Office" }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "Description", "PhotoUrl", "ReplacementTag", "SourceLink", "Title", "UserId" },
                values: new object[] { 1, 4, @"- Packaging: Comes in a paper sleeve without any plastic tape; can be recycled or added to your compost. 
                    - Use: I keep it tucked in a small napkin inside my purse or tote bag.It's great for traveling, or for keeping a utensil with me when I'm out and about, just in case.
                    -Care: Wash with dish soap and air dry.Bamboo can become moldy if not dried properly, so I wipe mine quickly with a dishtowel before letting it finish air drying in the dish rack.
                    - Disposal: The bamboo spork can be composted(you may want to very carefully break it up a bit first). If you cut the stitching and glue from the sides of the cork case, it can be composted as well", "https://static1.squarespace.com/static/55cfcd4ae4b0c17da812b28a/t/5a0a2a054192029150c743fb/1534804577577/Reusable+Bambu+travel+spork+and+utensil+%7C+Litterless?format=1000w", "fork utensil utensils spork", "https://earthhero.com/products/travel/bambu-spork-and-cork-set/", "Bambu Reusable Travel Fork", "a89ce0a8-ac52-4454-b563-8f4b297784cd" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "Description", "PhotoUrl", "ReplacementTag", "SourceLink", "Title", "UserId" },
                values: new object[] { 15, 9, "You live in the real world, and it's not always easy to stick to your high principles when you're on your grind from 9 to 5. As with everything, a little bit of planning and preparation go a long way.", "https://static1.squarespace.com/static/58ca692459cc682c73a99835/t/5a8700db71c10bc44db6570e/1518797029336/Minimal+office?format=2500w", "office tips desk work", "https://smallshop.co.uk/blog/2018/2/16/7-ways-to-go-zero-waste-at-work?utm_content=tribes&utm_term=316545498_9353590_257281", "Zero Waste Office", "a89ce0a8-ac52-4454-b563-8f4b297784cd" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "Description", "PhotoUrl", "ReplacementTag", "SourceLink", "Title", "UserId" },
                values: new object[] { 14, 9, "Ditch the plastic bottle and switch to a bar! It’s a *gasp* moment for hair care devotees, I know, but there are so many eco-friendly options out there that you’re sure to find a product you love. Not only is this a plastic-free bathroom essential they’re also known to outlast standard shampoos.", "https://i.pinimg.com/564x/37/cb/e8/37cbe859fc691c3d83abfe29afc560e3.jpg", "office desk", "google.com", "Desk Eco-Friendly Checklist", "a89ce0a8-ac52-4454-b563-8f4b297784cd" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "Description", "PhotoUrl", "ReplacementTag", "SourceLink", "Title", "UserId" },
                values: new object[] { 13, 8, @"-Packaging: This comes packaged in a clear plastic sleeve (if you buy it locally or from a zero waste store and it doesn't, it's likely that they just removed the packaging before displaying). Since the packaging is stretchy, it can likely be recycled with other plastic bags at a local drugstore or grocery.
                            -Use: Dish washing! I love this shape because the round head means that it makes washing pots and bottles and jars super easy and quick. Add a little dish soap to the bristles, run a bit of water on them, and go to town.
                            -Care: Store upright in a jar or container to let the handle and top dry out between uses. Especially if you cook with meat, take care to sterilize it every so often by boiling for at least five minutes.
                            -Disposal: It's all wood and natural bristles, so it's compostable at the end of its life. You can also give it a good clean and then repurpose it in the bathroom as a toilet brush..", "https://static1.squarespace.com/static/55cfcd4ae4b0c17da812b28a/t/5a592d994192027937a4ed63/1534804577612/Compostable+wooden+dish+brush+for+zero+waste+dishwashing+%7C+Litterless?format=1000w", "brush dishes kitchen bottle soap dish", "https://www.therefillrevolution.com/household/redecker-wooden-milk-bottle-brush?category=Kitchen&rfsn=1119018.bfaf1e", "Compostable Wooden Dish and Bottle Brush", "a89ce0a8-ac52-4454-b563-8f4b297784cd" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "Description", "PhotoUrl", "ReplacementTag", "SourceLink", "Title", "UserId" },
                values: new object[] { 12, 8, @"-Use: Great for drying clothing and linens. Be sure to hang small things, like handkerchiefs and socks, on the slanted portions to maximize your available space.
                            - Care: It folds up when not in use; store it somewhere dry, like an upstairs closet.Bamboo can get moldy when wet for extended periods of time, but that shouldn't happen with this since the clothes dry fairly quickly. If you're worried, you can always quickly wipe it down with a dry cloth before storing.
                            - Disposal: Unlike metal drying racks which will eventually need to be landfilled, this bamboo rack can eventually compost back down into nothing.But it should last for years and years first and, if possible, should be donated rather than composted if you decide you don't need it.", "https://static1.squarespace.com/static/55cfcd4ae4b0c17da812b28a/t/5a08f28a9140b7f3b7afa9f7/1510614942465/Screen+Shot+2017-11-12+at+7.16.11+PM.png?format=1000w", "dryer drying laundry", "https://www.amazon.com/Household-Essentials-6524-Folding-Clothes/dp/B003VYAGOC/ref=as_li_ss_tl?ie=UTF8&qid=1510535751&sr=8-4&keywords=bamboo+drying+rack&linkCode=sl1&tag=l0875-20&linkId=4cb236866ff58a11a6c410c505662976", "Bamboo Clothes Drying Rack", "a89ce0a8-ac52-4454-b563-8f4b297784cd" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "Description", "PhotoUrl", "ReplacementTag", "SourceLink", "Title", "UserId" },
                values: new object[] { 11, 0, "Transitioning and living a zero waste life means working with your closet in order to extend the life of your existing clothes or find ways to purchase clothing that is less harmful to the Earth.", "https://i.pinimg.com/564x/d8/43/29/d84329e35bc3536810ffb2999b59ee0a.jpg", "closet transition clothing wardrobe apparel", "http://www.thedosomethingproject.com/home/zero-waste-closet-transition", "Zero Waste: Closet Transition", "a89ce0a8-ac52-4454-b563-8f4b297784cd" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "Description", "PhotoUrl", "ReplacementTag", "SourceLink", "Title", "UserId" },
                values: new object[] { 10, 9, null, "https://i.pinimg.com/564x/aa/47/53/aa47539be1a44b76422539b28eb98aa5.jpg", "Zero Waste Designers, the best zero waste fashion collections, zero waste sustainable fashion, zero waste fashion techniques, what is zero waste fashion", "https://eluxemagazine.com/fashion/zero-waste-designers/", "6 Zero Waste Designers Who Are Just Killing It", "a89ce0a8-ac52-4454-b563-8f4b297784cd" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "Description", "PhotoUrl", "ReplacementTag", "SourceLink", "Title", "UserId" },
                values: new object[] { 9, 9, "Ditch the plastic bottle and switch to a bar! It’s a *gasp* moment for hair care devotees, I know, but there are so many eco-friendly options out there that you’re sure to find a product you love. Not only is this a plastic-free bathroom essential they’re also known to outlast standard shampoos.", "https://i.pinimg.com/564x/98/ce/ff/98ceffe3863fb31c49e4176e1b515442.jpg", "beauty sustainable shampoo hair", "https://www.amazon.com/dp/B07572ZHB9?ascsubtag=.Mjg3Mzg2LTA.056fb4ed-6b7f-11e9-941d-81adbcf9f5c1&tag=rewardstyle-20&th=1", "Shampoo Bar", "a89ce0a8-ac52-4454-b563-8f4b297784cd" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "Description", "PhotoUrl", "ReplacementTag", "SourceLink", "Title", "UserId" },
                values: new object[] { 7, 3, "A simple room by room guide to a zero waste home which should make transitioning to a plastic free lifestyle easy as pie!", "https://i.pinimg.com/564x/5c/b1/05/5cb105d9e78787ca1dbe6ceedeb9baf2.jpg", "kitchen zero waste checklist", "https://www.tinyyellowbungalow.com/room-by-room-zero-waste-guide/", "Zero Waste Kitchen Checklist", "a89ce0a8-ac52-4454-b563-8f4b297784cd" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "Description", "PhotoUrl", "ReplacementTag", "SourceLink", "Title", "UserId" },
                values: new object[] { 6, 2, "Leftover Espresso Grounds Brownies, a rich fudgy brownie recipe made with leftover espresso grounds. Reuse those coffee grounds for a deliciously moist chocolaty treat!", "https://www.forkintheroad.co/wp-content/uploads/2019/01/leftover-espresso-grounds-brownies-102.jpg", "coffee espresso leftovers brownie recipe market meal-planning grocery", "https://www.forkintheroad.co/leftover-espresso-grounds-brownies/", "Leftover Espresso Grounds Brownies", "a89ce0a8-ac52-4454-b563-8f4b297784cd" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "Description", "PhotoUrl", "ReplacementTag", "SourceLink", "Title", "UserId" },
                values: new object[] { 5, 2, "This step-by-step guide will help you learn to plan meals around farmers market trips so you can eat local, waste less food, and save money!", "https://i.pinimg.com/564x/72/0f/9f/720f9f2e9416acc0ab28d109f328e883.jpg", "market farmer's market meal-planning grocery", "https://www.forkintheroad.co/farmers-market-meal-planning/?utm_medium=social&utm_source=pinterest&utm_campaign=tailwind_tribes&utm_content=tribes&utm_term=555492632_20372870_160564", "Pan Your Meals Around The Farmer's Market", "a89ce0a8-ac52-4454-b563-8f4b297784cd" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "Description", "PhotoUrl", "ReplacementTag", "SourceLink", "Title", "UserId" },
                values: new object[] { 4, 5, null, "https://i.pinimg.com/564x/bd/5e/7b/bd5e7bba29d3d544034d2336f9f99911.jpg", "bath razor safety shave", "https://www.thezerowastecollective.com/blog/shaving-with-a-safety-razor-this-zero-waste-swap-is-easier-than-you-think", "How To Use a Safety Razor", "a89ce0a8-ac52-4454-b563-8f4b297784cd" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "Description", "PhotoUrl", "ReplacementTag", "SourceLink", "Title", "UserId" },
                values: new object[] { 3, 5, @"-Packaging: Packaged in paper with a compostable inner plant-based liner. You can recycle the paper, or tear it up into small pieces to compost. The inner liner can be commercially composted.
                      -Use: Brush teeth as normal :)
                      -Care: Dry your toothbrush after each use to prevent it from getting moldy, and store it upright in a glass or jar to help air circulate. You can find more of my tips on taking care of it to help it last here.
                      -Disposal: The bristles should be removed with pliers and added to the trash; the brush handle is entirely made of bamboo and can be composted. First, try upcycling your brush for cleaning, as a plant marker, and more. ", "https://s7d5.scene7.com/is/image/FreePeople/43335264_001_a?$a15-pdp-detail-shot$&hei=900&qlt=80&fit=constrain", "bag plastic grocery", "https://www.brushwithbamboo.com/shop/", "Bamboo Toothbrush", "a89ce0a8-ac52-4454-b563-8f4b297784cd" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "Description", "PhotoUrl", "ReplacementTag", "SourceLink", "Title", "UserId" },
                values: new object[] { 2, 4, @"-Packaging: May come in a small plastic bag, which you can take to a local drugstore or grocery store to recycle. Compost or recycle the paper 'Baggu' tag and throw away the plastic loop attaching it to the bag.
                    - Use: Carry with you everywhere!Perfect tucked in your bag or coat pocket.
                    - Care: Machine wash cold with your other garments or hand wash,
                    then hang to dry.Minimize washing when will keep the bag in better shape longer.
                    - Disposal: Baggu accepts their bags back for recycling; you can send it back to them by following the instructions on their website", "https://images-na.ssl-images-amazon.com/images/I/81EfOAma9QL._SX679_.jpg", "bag plastic grocery", "https://www.amazon.com/BAGGU-Standard-Reusable-Shopping-Bag/dp/B00CRPOUS4/ref=as_li_ss_tl?ie=UTF8&qid=1510679139&sr=8-1&keywords=baggu&linkCode=sl1&tag=l0875-20&linkId=c95ee97caddd67a873d0f14dc139ed4a", "Baggu Reusable Tote Bags", "a89ce0a8-ac52-4454-b563-8f4b297784cd" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "Description", "PhotoUrl", "ReplacementTag", "SourceLink", "Title", "UserId" },
                values: new object[] { 8, 6, "Plastic-encased makeup that gets tossed every few months isn’t exactly a sustainable approach to a conscious beauty routine. Use environmentally-safe products that come in a glass container (it can be recycled or repurposed) that are multipurpose for a one-two punch.", "https://mediacdn.espssl.com/9428/Popup%20Images/popup-image-2.jpg", "beauty sustainable lip cheek blush", "https://credobeauty.com/products/rms-beauty-lip2cheek-beloved?sscid=41k3_obmcm&utm_source=shareasale&utm_medium=referral&utm_campaign=shareasale", "RMS Lip2Cheek", "a89ce0a8-ac52-4454-b563-8f4b297784cd" });

            migrationBuilder.InsertData(
                table: "WishLists",
                columns: new[] { "Id", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, "Essentials", "a89ce0a8-ac52-4454-b563-8f4b297784cd" },
                    { 2, "WishList", "a89ce0a8-ac52-4454-b563-8f4b297784cd" }
                });

            migrationBuilder.InsertData(
                table: "WishListItems",
                columns: new[] { "Id", "ItemId", "WishListId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 1 },
                    { 4, 4, 1 },
                    { 5, 2, 2 },
                    { 6, 5, 2 },
                    { 7, 6, 2 },
                    { 8, 7, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Items_UserId",
                table: "Items",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WishListItems_ItemId",
                table: "WishListItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_WishListItems_WishListId",
                table: "WishListItems",
                column: "WishListId");

            migrationBuilder.CreateIndex(
                name: "IX_WishLists_UserId",
                table: "WishLists",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "WishListItems");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "WishLists");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
