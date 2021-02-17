using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Siemens.Helper;
using Siemens.Service;

namespace Siemens
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>();
            services.AddControllers();

            // configure DI for application services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IDiscountService, DiscountService>();
            services.AddScoped<IPrintFactory, PrintFactory>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            using(var serviceScope = app.ApplicationServices.CreateScope()){
                var service=serviceScope.ServiceProvider.GetService<DataContext>();
                AddTestData(service);
            }
            //var context = app.ApplicationServices.GetService<DataContext>();
            //AddTestData(context);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void AddTestData(DataContext context)
        {
            context.Users.Add(new Entity.User
            {
                id = 1,
                username = "Luke",
                password = "Skywalker",
                userType=Entity.UserType.Normal
            });
            context.Users.Add(new Entity.User
            {
                id = 2,
                username = "Luke2",
                password = "Skywalker2",
                userType=Entity.UserType.Priviledge
            });

            context.Prices.Add(new Entity.Discount
            {
                id=1,
                userType=Entity.UserType.Normal,
                discount=0
            });

            context.Prices.Add(new Entity.Discount
            {
                id=2,
                userType=Entity.UserType.Priviledge,
                discount=2
            });

            context.SaveChanges();
        }
    }
}
