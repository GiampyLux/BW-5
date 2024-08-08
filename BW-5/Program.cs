using BW5.DataContext;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

            // Aggiungi servizi al container.
            builder.Services.AddControllersWithViews();

            // Configurazione del DbContext
            var conn = builder.Configuration.GetConnectionString("DbBW");
            builder.Services.AddDbContext<ClinicaDbContext>(opt =>
                opt.UseSqlServer(conn));

            // Configura l'autenticazione e l'autorizzazione
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Account/Login";
                    options.AccessDeniedPath = "/Denied/Index";
                });

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
                options.AddPolicy("MedicoOnly", policy => policy.RequireRole("Medico"));
                options.AddPolicy("FarmacistaOnly", policy => policy.RequireRole("Farmacista"));                                                  
                options.AddPolicy("AdminOrMedico", policy => policy.RequireRole("Admin", "Medico"));
                options.AddPolicy("AdminOrFarmacista", policy => policy.RequireRole("Admin", "Farmacista"));


            });

var app = builder.Build();

            // Configurazione della pipeline di richieste HTTP
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

            // Aggiungi autenticazione e autorizzazione
            app.UseAuthentication();
            app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
