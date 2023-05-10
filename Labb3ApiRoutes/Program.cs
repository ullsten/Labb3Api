
using Labb3ApiRoutes.Data;
using Microsoft.EntityFrameworkCore;
using Labb3ApiRoutes.Repository.IRepository;
using Labb3ApiRoutes.Repository;
using Labb3ApiRoutes.Models;
using Labb3ApiRoutes.Models.DTO;

namespace Labb3ApiRoutes
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<Labb3ApiRouteDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddScoped<IRepository<Person>, Repository<Person>>();
            builder.Services.AddScoped<IRepository<Interest>, Repository<Interest>>();
            builder.Services.AddScoped<IRepository<Link>, Repository<Link>>();

            builder.Services.AddControllers();
            builder.Services.AddControllersWithViews().AddNewtonsoftJson();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(typeof(MappingConfig)); // Kallar på filen MappingConfig som ligger i rooten.
                                                                   // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            // Add error handling middleware.
            app.UseExceptionHandler("/error");
            app.UseStatusCodePagesWithReExecute("/error/{0}");

            app.MapControllers();

            app.Run();
        }
    }
}