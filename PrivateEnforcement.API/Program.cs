
using KIT.Logger;
using Serilog;

namespace PrivateEnforcement.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Adding custom services to container

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .CreateLogger();

            // Logging configs:
            builder.Host.UseSerilog();
            builder.Services.AddSingleton<Serilog.ILogger>(Log.Logger);

            //builder.Services.AddSerilog(config=>
            //    config.ReadFrom.Configuration(builder.Configuration.GetSection("Serilog")));

            builder.Services.AddScoped<ILoggerContainer, SerilogContainer>();
            // Add services to the container.

            builder.Services.AddControllers();
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
