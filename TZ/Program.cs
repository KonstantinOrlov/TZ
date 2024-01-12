using TZ.WebApi.Services;
using AutoMapper;
using TZ.WebApi.Mapping;
using TZ.Data;
using TZ.WebApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using TZ.WebApi.Helpers;

namespace TZ
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddDbContext<TZContext>();
            builder.Services.AddScoped<IRatingService, RatingService>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(cfg =>
            {
                cfg.AddProfiles(new List<Profile>()
                {
                    new MappingProfile()
                });
            });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("CustomPolicy", 
                    policy =>
                    {
                        policy.WithOrigins(builder.Configuration.GetSection("AllowedOrigins").Get<string[]>() ?? new string[] { })
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors("CustomPolicy");

            app.MapControllers();


            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<TZContext>();
                db.Database.Migrate();
                DbHelper.SetDataIfEmpty(db);
            }
            
            app.Run();
        }
    }
}