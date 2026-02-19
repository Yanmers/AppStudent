using AppStudent.Configuration;
using AppStudent.Data;
using AppStudent.Data.Repository;
using AppStudent.MyLogger;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AppStudent
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers().AddNewtonsoftJson();
            //builder.Services.AddControllers(opt => opt.ReturnHttpNotAcceptable = true).AddNewtonsoftJson().AddXmlDataContractSerializerFormatters();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAutoMapper(typeof(AutoMapperConfig));

            builder.Services.AddDbContext<CollegeDBContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("CollegeDB"));
            });

            //Any Injection dependeci...
            //builder.Services.AddScoped<IMyLogger, LogToDB>();
            //builder.Services.AddSingleton<IMyLogger, LogToFile>();
            //builder.Services.AddTransient<IMyLogger, LogToServerMemory>();
            builder.Services.AddTransient<IStudentRepository, StudentRepository>();

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
