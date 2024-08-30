using Microsoft.AspNetCore.Identity;
using SAonlineMart.Data.Enum;
using SAonlineMart.Models;


namespace SAonlineMart.Data
{
    public class Seed
    {
              public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDBcontext>();

                context.Database.EnsureCreated();

                if (!context.product.Any())
                {
                    context.product.AddRange(new List<Product>()
                    {
                        new Product()
                        {
                            productPrice =219,
                            productCategory =ProductCategory.Fashion,
                            productDescription="A great dress",
                            productName = "Dress",
                            imageURL = "https://i0.wp.com/equilibrio.co.za/wp-content/uploads/2024/02/Erre-Fold-Wrap-Dress-Midi-Olive-8.webp?fit=1200%2C1800&ssl=1"
                        }, 
                        new Product()
                        {
                            productName="T-shirt",
                            productDescription="A great shirt",
                            productCategory=ProductCategory.Fashion,
                            productPrice=3900,
                            imageURL="https://bonblom.co.za/wp-content/uploads/2022/04/mens-tshirt-1.jpg"
                        },
                        new Product()
                        {
                            productName="Love South Africa - Mens - Hoodie - Grey",
                            productDescription="AdultsSlim Cuts - Recommended to take 1 size bigger than your T.Shirt SizeThin Fleece MaterialPolyester and Cotton BlendHooded JacketOpen front pocket pouchUnisex Cut Size Small-2Xl What's in the box 1 x Printed Hoodie",
                            productCategory=ProductCategory.Fashion,
                            productPrice=100,
                            imageURL="https://media.takealot.com/covers_tsins/59254985/59254985-1-list.jpeg"
                        },

                    });
                    context.SaveChanges();
                }           
            }
        }
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<Customer>>();
                string adminUserEmail = "amDEV@gmail.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new Customer()
                    {
                        FirstName = "AsiAdmin",
                        LaststName = "MockAdmin",
                        birthDay = new DateOnly(2002, 2, 1), //year, month, day,
                        UserName = "AMTestDEVdata",
                        Email = adminUserEmail,
                        EmailConfirmed = true,
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                string appUserEmail = "user@etickets.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new Customer()
                    {
                        FirstName = "AsiUser",
                        LaststName = "MockUser",
                        birthDay = new DateOnly(2005, 3, 10), //year, month, day,
                        UserName = "UserTestDEVdata",
                        Email = appUserEmail,
                        EmailConfirmed = true,
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}