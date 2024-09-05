
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using S4_HW3.Abstractions;
using S4_HW3.Context;
using S4_HW3.Mappers;
using S4_HW3.Services;
using S4_HW3.Models;

namespace S4_HW3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<StoreContext>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

            builder.Services.AddAutoMapper(typeof(MappingProfile));
            builder.Host.ConfigureContainer<ContainerBuilder>(c => c
            .RegisterType<ProductService>()
            .As<IProductService>());

            builder.Services.AddMemoryCache(m => m.TrackStatistics = true);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
