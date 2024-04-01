
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services.AddTransient<ITokenService, TokenService>();
builder.Services.AddAutoMapper(typeof(Program)); //AutoMapper'a GameWebApi programına tanıtma

builder.Services
    // oluşturulan interfaceleri ve model classlarını tanıtma işlemi yapılmalı IoC Container'a tanıtmış olduk. IAuthGroupRepository için AuthGroupRepository bu nesneyi bize verecek.
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



//// veritabanıyla baglantı oluşturma 
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

///


//Token ve authentication işlemleri için gerekli tanımlam ve atamalar
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["AppSettings:ValidIssuer"],
        ValidAudience = builder.Configuration["AppSettings:ValidAudience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["AppSettings:Secret"])),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true, //tokenen süresini doğrulayacak olan işlem
        ValidateIssuerSigningKey = true,
        ClockSkew = TimeSpan.Zero, //zaman farkını olmasının engellemek için
        //LifetimeValidator = () => true;
    };
});

builder.Services.AddAuthorization();

//


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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();