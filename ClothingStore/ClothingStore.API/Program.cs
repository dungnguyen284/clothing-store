
using ClothingStore.BLL.Services;
using ClothingStore.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Identity.UI.Services;
using ClothingStore.DAL.Repositories.Interfaces;
using ClothingStore.DAL.Repositories.Implementations;
using ClothingStore.DAL.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ClothingStore.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            // Add mail settings
            var mailSettings = builder.Configuration.GetSection("MailSettings");
            builder.Services.Configure<MailSettings>(mailSettings);

            // Add dependancy injection
            builder.Services.AddDbContext<ApplicationDBContext>(options =>
            {
                options.UseSqlServer("Server=LAPTOP-1O1FBHF3\\SQLEXPRESS01;uid=sa;pwd=123;Database=ClothingStoreDtb;Trusted_Connection=True;TrustServerCertificate=true;");
            });
            builder.Services.AddTransient<IAccountRepository, AccountRepository>();

            //builder.Services.AddScoped<IProductService, ProductService>();
            //builder.Services.AddScoped<ICustomerService, CustomerService>();
            //builder.Services.AddScoped<IBillService, BillService>();
            //builder.Services.AddScoped<IBillDetailService, BillDetailService>();
            //builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddTransient<IEmailSender, MailService>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
