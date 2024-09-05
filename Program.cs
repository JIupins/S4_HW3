using Autofac;
using Autofac.Extensions.DependencyInjection;
using S4_HW3.Abstractions;
using S4_HW3.Context;
using S4_HW3.Mappers;
using S4_HW3.Services;

namespace S4_HW3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<StoreContext>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

            builder.Services.AddAutoMapper(typeof(MappingProfile));
            builder.Host.ConfigureContainer<ContainerBuilder>(c => c
            .RegisterType<ProductService>()
            .As<IProductService>());

            builder.Services.AddMemoryCache(m => m.TrackStatistics = true);

            var app = builder.Build();

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