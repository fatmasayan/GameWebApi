using GameWebApi2.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    //options.AddSecurityDefinition("Basic", new Microsoft.OpenApi.Models.OpenApiSecurityScheme()
    //{
    //    Name = "Authorization",
    //    Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
    //    Scheme = "Basic",
    //    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
    //    Description = "Basic Authorization Header"
    //});

    //options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    //{
    //    {
    //        new OpenApiSecurityScheme
    //        {
    //            Reference = new OpenApiReference
    //            {
    //                Type = ReferenceType.SecurityScheme,
    //                Id = "Basic"
    //            }
    //        },
    //        new string[]{"Basic "} 
    //    }
    //});
});
builder.Services.AddAutoMapper(typeof(Program)); //AutoMapper'a programımızı tanıtma 

builder.Services.AddAuthentication()
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>(
        "Basic", null
    );

builder.Services
    // oluşturlan interfaceleri ve model classlarını tanıtma işlemi yapılmalı IoC Container'a tanıtmış olduk. IAuthGroupRepository için AuthGroupRepository bu nesneyi bize verecek.
    .AddScoped<IAchievementRepository, AchievementRepository>() // dependencies injections DI 
    .AddScoped<IAuthGroupRepository, AuthGroupRepository>()
    .AddScoped<IAuthGroupPermissionsRepository, AuthGroupPermissionsRepository>()
    .AddScoped<IAuthPermissionRepository, AuthPermissionRepository>()
    .AddScoped<IAuthtokenTokenRepository, AuthtokenTokenRepository>()
    .AddScoped<IAuthUserRepository, AuthUserRepository>()
    .AddScoped<IAuthUserAndUserPermissionsRepository, AuthUserAndUserPermissionsRepository>()
    .AddScoped<IAuthUserGroupsRepository, AuthUserGroupsRepository>()
    .AddScoped<IBikePartsRepository, BikePartsRepository>()
    .AddScoped<ICharItemsRepository, CharItemsRepository>()
    .AddScoped<IDjangoAdminLogRepository, DjangoAdminLogRepository>()
    .AddScoped<IDjangoContentTypeRepository, DjangoContentTypeRepository>()
    .AddScoped<IDjangoMigrationsRepository, DjangoMigrationsRepository>()
    .AddScoped<IDjangoSessionRepository, DjangoSessionRepository>()
    .AddScoped<IGarageRepository, GarageRepository>()
    .AddScoped<IMapRepository, MapRepository>()
    .AddScoped<IPricesRepository, PricesRepository>()
    .AddScoped<IPurchaseRepository, PurchaseRepository>()
    .AddScoped<IUserBikesRepository, UserBikesRepository>()
    .AddScoped<IUserBodyTypeRepository, UserBodyTypeRepository>()
    .AddScoped<IUserCharRepository, UserCharRepository>()
    .AddScoped<IUserInventoryRepository, UserInventoryRepository>()
    .AddScoped<IUserOwendGarageRepository, UserOwendGarageRepository>()
    .AddScoped<IUserOwendMapRepository, UserOwendMapRepository>()
    .AddScoped<IUserOwnedAchievementRepository, UserOwnedAchievementRepository>()
    .AddScoped<IUserProfileRepository, UserProfileRepository>();



//// baglantı oluşturma
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

///


var app = builder.Build();  

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(x =>
    {
        x.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None); //metodların kapalı gelmesi icin ayar
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();