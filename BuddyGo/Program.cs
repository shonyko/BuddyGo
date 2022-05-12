using BuddyGo.Data;
using BuddyGo.Repositories;
using BuddyGo.Repositories.Impl;
using BuddyGo.Services;
using BuddyGo.Services.Impl;
using BuddyGo.Utils;
using BuddyGo.Utils.Impl;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddDbContext<ApplicationDbContext>(options => {
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IPasswordEncryptor, PasswordEncryptor>();
builder.Services.AddScoped<IPetRepository, MySqlPetRepository>();
builder.Services.AddScoped<IPetService, PetService>();

builder.Services.AddScoped<IAnnouncementRepository, AnnouncementRepository>();
builder.Services.AddScoped<IAnnouncementService, AnnouncementService>();

builder.Services.AddScoped<IOfferRepository, OfferRepository>();
builder.Services.AddScoped<IOfferService, OfferService>();

builder.Services.AddScoped<IIncompleteUserRepository, MySqlIncompleteUserRepository>();
builder.Services.AddScoped<IIncompleteUserService, IncompleteUserService>();
builder.Services.AddScoped<IOwnerRepository, MySqlOwnerRepository>();
builder.Services.AddScoped<IOwnerService, OwnerService>();
builder.Services.AddScoped<ISitterRepository, MySqlSitterRepository>();
builder.Services.AddScoped<ISitterService, SitterService>();

builder.Services.AddScoped<IAccountFacade, AccountFacade>();
//builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => {
    options.AddDefaultPolicy(
        builder => {
            builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
        }
    );
});

var app = builder.Build();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    c.RoutePrefix = "";
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseMigrationsEndPoint();
    app.UseSwagger();
    app.UseSwaggerUI();
} else {
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseCors();
//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();


//app.UseAuthentication();
//app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.MapRazorPages();

app.Run();
