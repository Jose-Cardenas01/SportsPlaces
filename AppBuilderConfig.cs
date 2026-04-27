using Microsoft.EntityFrameworkCore;
using SportsPlacesWeb.Data;

namespace SportsPlacesWeb
{
    public static class AppBuilderConfig
    {
        public static WebApplicationBuilder AddAppBuilderConfig(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<AppDbContext>(option =>
                option.UseSqlServer(builder.Configuration.GetConnectionString("MyConnectionString"))
            );

            //AutoMapper
            builder.Services.AddAutoMapper(typeof(Program).Assembly);

            return builder;
        }
    }
}
