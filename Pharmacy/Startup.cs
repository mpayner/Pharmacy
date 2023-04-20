using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pharmacy.Data.Database;
using Pharmacy.Data.Interfaces;
using Pharmacy.Data.Mocks;
using Pharmacy.Data.Models;
using Pharmacy.Data.Repository;
using IHostingEnvironment = Microsoft.Extensions.Hosting.IHostingEnvironment;

namespace Pharmacy
{
    public class Startup
    {
/*        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }*/

        public IConfigurationRoot _confString;
        public Startup(IHostingEnvironment hostEnv)
        {
            //отримання файлу зі строкою підключення БД
            _confString = new ConfigurationBuilder().SetBasePath(hostEnv.
           ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }



        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<AppDBContent>(options => options.UseSqlServer(
_confString.GetConnectionString("DefaultConnection")));

            services.AddScoped<ISubstance, SubstanceRepository>();
            services.AddScoped<IDrug, DrugRepository>();
            services.AddScoped<IDrugSubstance, DrugSubstanceRepository>();
            services.AddScoped<IDrugPackaging, DrugPackagingRepository>();
            services.AddScoped<IGood, GoodRepository>();
            services.AddScoped<IManufacturer, ManufacturerRepository>();
            services.AddScoped<IMedicalForm, MedicalFormRepository>();
            services.AddScoped<IOrder, OrderRepository>();
            services.AddScoped<IOrderStatus, OrderStatusRepository>();
            services.AddScoped<IUser, UserRepository>();
            services.AddScoped<IUserType, UserTypeRepository>();
            services.AddScoped<IDeliveryCompany, DeliveryCompanyRepository>();
            services.AddScoped<ICategory, CategoryRepository>();


            services.AddRazorPages().AddRazorRuntimeCompilation();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShopCart.GetCart(sp));
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.Cookie.Name = "PharmaSession";
                options.Cookie.IsEssential = true;
            });


          
            // Регистрируем сервис UserManager<IdentityUser>

            services.AddControllersWithViews();



            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options => //CookieAuthenticationOptions
            {
                options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Login");
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();  
            app.UseAuthorization();
            app.UseSession(); 

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=General}/{id?}");
            });

            using (var scope = app.ApplicationServices.CreateScope())
            {
                AppDBContent content = scope.ServiceProvider.
                    GetRequiredService<AppDBContent>();
                DBObjects.Initial(content);
            }

        }
    }
}
