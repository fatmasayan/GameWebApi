namespace GameWebApi2.Data;

public class DataContext :DbContext 
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    } 
    
    //(11-37 kodlar )Bu özellik, api_x türünden nesneleri temsil eden bir DbSet'i belirtir. Bu, X adı altında bir veritabanı tablosuna erişimi sağlar.
    public DbSet<Achievement> api_achievement { get; set; }
    public DbSet<BikeParts> api_bikeparts { get; set; }
    public DbSet<CharItems> api_charitems { get; set; }
    public DbSet<Garage> api_garage { get; set; }
    public DbSet<Map> api_map { get; set; }
    public DbSet<Prices> api_prices { get; set; }
    public DbSet<Purchase> api_purchase { get; set; }
    public DbSet<UserBikes> api_userbikes { get; set; }
    public DbSet<UserBodyType> api_userbodytype { get; set; }
    public DbSet<UserChar> api_userchar { get; set; }
    public DbSet<UserInventory> api_userinventory { get; set; }
    public DbSet<UserOwendGarage> api_userowendgarage { get; set; }
    public DbSet<UserOwendMap> api_userowendmap { get; set; }
    public DbSet<UserOwnedAchievement> api_userownedachievement { get; set; }
    public DbSet<UserProfile> api_userprofile { get; set; }
    public DbSet<AuthGroup> auth_group { get; set; }
    public DbSet<AuthGroupPermissions> auth_group_permissions { get; set; }
    public DbSet<AuthPermission> auth_permission { get; set; }
    public DbSet<AuthUser> auth_user { get; set; }
    public DbSet<AuthUserGroups> auth_user_groups { get; set; }
    public DbSet<AuthUserAndUserPermissions> auth_user_user_permissions { get; set; }
    public DbSet<AuthtokenToken> authtoken_token { get; set; }
    public DbSet<DjangoAdminLog> django_admin_log { get; set; }
    public DbSet<DjangoContentType> django_content_type { get; set; }
    public DbSet<DjangoMigrations> django_migrations { get; set; }
    public DbSet<DjangoSession> django_session { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<UserBodyType>()
        .HasOne(u => u.loginUser)
        .WithMany()
        .HasForeignKey(u => u.loginUser_id)
        .HasPrincipalKey(u => u.id);

    //-----------------------------------------------

        modelBuilder.Entity<AuthUserGroups>()
        .HasOne(u => u.group)
        .WithMany()
        .HasForeignKey(u => u.group_id)
        .HasPrincipalKey(u => u.id);

        modelBuilder.Entity<AuthUserGroups>() // AuthUserGroups modelinin tablosuna git
        .HasOne(u => u.user) // tablonun user tablosu ile 1'e
        .WithMany() // n ilişkide
        .HasForeignKey(u => u.user_id) // bu bağlantı user_id sütunu ile bağlanmıştır
        .HasPrincipalKey(u => u.id); // AuthUser tablosun id'si ile eşleştir

        //--------------------------------------------------

        modelBuilder.Entity<UserProfile>()
        .HasOne(u => u.user)
        .WithMany()
        .HasForeignKey(u => u.user_id)
        .HasPrincipalKey(u => u.id);

        //---------------------------
        modelBuilder.Entity<AuthGroupPermissions>()
        .HasOne(u => u.group)
        .WithMany()
        .HasForeignKey(u => u.group_id)
        .HasPrincipalKey(u => u.id);
        
        modelBuilder.Entity<AuthGroupPermissions>()
        .HasOne(u => u.permission)
        .WithMany()
        .HasForeignKey(u => u.permission_id)
        .HasPrincipalKey(u => u.id);
        //--------------------------------

        modelBuilder.Entity<UserOwnedAchievement>()
        .HasOne(u => u.achievement)
        .WithMany()
        .HasForeignKey(u => u.achievement_id)
        .HasPrincipalKey(u => u.id);

        modelBuilder.Entity<UserOwnedAchievement>()
        .HasOne(u => u.loginUser)
        .WithMany()
        .HasForeignKey(u => u.loginUser_id)
        .HasPrincipalKey(u => u.id);

        //--------------------------------------

        modelBuilder.Entity<UserOwendMap>()
        .HasOne(u => u.loginUser)
        .WithMany()
        .HasForeignKey(u => u.loginUser_id)
        .HasPrincipalKey(u => u.id);

        modelBuilder.Entity<UserOwendMap>()
        .HasOne(u => u.map)
        .WithMany()
        .HasForeignKey(u => u.map_id)
        .HasPrincipalKey(u => u.id);

        //--------------------------------------

        modelBuilder.Entity<AuthtokenToken>()
        .HasOne(u => u.user)
        .WithMany()
        .HasForeignKey(u => u.user_id)
        .HasPrincipalKey(u => u.id);

        //--------------------------------------
        modelBuilder.Entity<AuthUserAndUserPermissions>()
        .HasOne(u => u.user)
        .WithMany()
        .HasForeignKey(u => u.user_id)
        .HasPrincipalKey(u => u.id);

        modelBuilder.Entity<AuthUserAndUserPermissions>()
        .HasOne(u => u.permission)
        .WithMany()
        .HasForeignKey(u => u.permission_id)
        .HasPrincipalKey(u => u.id);

        //--------------------------------------
        modelBuilder.Entity<DjangoAdminLog>()
        .HasOne(u => u.content_type)
        .WithMany()
        .HasForeignKey(u => u.content_type_id)
        .HasPrincipalKey(u => u.id);

        modelBuilder.Entity<DjangoAdminLog>()
        .HasOne(u => u.user)
        .WithMany()
        .HasForeignKey(u => u.user_id)
        .HasPrincipalKey(u => u.id);

        //--------------------------------------

        modelBuilder.Entity<Purchase>()
        .HasOne(u => u.loginUser)
        .WithMany()
        .HasForeignKey(u => u.loginUser_id)
        .HasPrincipalKey(u => u.id);

        //--------------------------------------


        modelBuilder.Entity<UserBikes>()
        .HasOne(u => u.body)
        .WithMany()
        .HasForeignKey(u => u.body_id)
        .HasPrincipalKey(u => u.id);

        modelBuilder.Entity<UserBikes>()
        .HasOne(u => u.handlebar)
        .WithMany()
        .HasForeignKey(u => u.handlebar_id)
        .HasPrincipalKey(u => u.id);

        modelBuilder.Entity<UserBikes>()
        .HasOne(u => u.indicator)
        .WithMany()
        .HasForeignKey(u => u.indicator_id)
        .HasPrincipalKey(u => u.id);

        modelBuilder.Entity<UserBikes>()
        .HasOne(u => u.loginUser)
        .WithMany()
        .HasForeignKey(u => u.loginUser_id)
        .HasPrincipalKey(u => u.id);

        modelBuilder.Entity<UserBikes>()
        .HasOne(u => u.saddle)
        .WithMany()
        .HasForeignKey(u => u.saddle_id)
        .HasPrincipalKey(u => u.id);

        modelBuilder.Entity<UserBikes>()
        .HasOne(u => u.wheel)
        .WithMany()
        .HasForeignKey(u => u.wheel_id)
        .HasPrincipalKey(u => u.id);

        //--------------------------------------

        modelBuilder.Entity<UserChar>()
        .HasOne(u => u.body)
        .WithMany()
        .HasForeignKey(u => u.body_id)
        .HasPrincipalKey(u => u.id);

        modelBuilder.Entity<UserChar>()
        .HasOne(u => u.foot)
        .WithMany()
        .HasForeignKey(u => u.foot_id)
        .HasPrincipalKey(u => u.id);

        modelBuilder.Entity<UserChar>()
        .HasOne(u => u.glove)
        .WithMany()
        .HasForeignKey(u => u.glove_id)
        .HasPrincipalKey(u => u.id);

        modelBuilder.Entity<UserChar>()
        .HasOne(u => u.head)
        .WithMany()
        .HasForeignKey(u => u.head_id)
        .HasPrincipalKey(u => u.id);

        modelBuilder.Entity<UserChar>()
        .HasOne(u => u.leg)
        .WithMany()
        .HasForeignKey(u => u.leg_id)
        .HasPrincipalKey(u => u.id);

        modelBuilder.Entity<UserChar>()
        .HasOne(u => u.loginUser)
        .WithMany()
        .HasForeignKey(u => u.loginUser_id)
        .HasPrincipalKey(u => u.id);

        //--------------------------------------
        modelBuilder.Entity<UserInventory>()
        .HasOne(u => u.loginUser)
        .WithMany()
        .HasForeignKey(u => u.loginUser_id)
        .HasPrincipalKey(u => u.id);

        //--------------------------------------

        modelBuilder.Entity<UserOwendGarage>()
        .HasOne(u => u.garage)
        .WithMany()
        .HasForeignKey(u => u.garage_id)
        .HasPrincipalKey(u => u.id);

        modelBuilder.Entity<UserOwendGarage>()
        .HasOne(u => u.loginUser)
        .WithMany()
        .HasForeignKey(u => u.loginUser_id)
        .HasPrincipalKey(u => u.id);

        //--------------------------------------
    }
}
