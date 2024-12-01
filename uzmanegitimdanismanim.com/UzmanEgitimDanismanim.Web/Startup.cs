using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using UzmanEgitimDanismanim.Data;
using UzmanEgitimDanismanim.Web.Extensions;
using UzmanEgitimDanismanim.Web.Filters;

namespace UzmanEgitimDanismanim.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }



        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddRazorPages();

            services.AddAutoMapper(typeof(Startup));

            services.AddDi();

            services.AddDbContext<SqlDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SqlConnectionString"))
            );

            services.AddControllers(o =>
            {
                o.Filters.Add(new ValidationFilter());
            });

            services.Configure<ApiBehaviorOptions>(options =>
                options.SuppressModelStateInvalidFilter = true
            );

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            var loginAdress = new PathString("/Login");

            var logoutAdress = new PathString("/Login/CikisYap");

            services.AddDistributedMemoryCache(); // Oturum verilerinin bellekte depolanması için
            services.AddSession(opt =>
            {
                // Oturum zaman aşımını belirleme (dakika cinsinden)
                opt.IdleTimeout = TimeSpan.FromHours(5);
                opt.Cookie.HttpOnly = true;
                opt.Cookie.IsEssential = true;
            });

            services.AddHttpContextAccessor(); // HttpContext'e erişim için

            services.AddControllersWithViews(); // veya başka bir MVC framework'ü

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.MinimumSameSitePolicy = SameSiteMode.None;
                options.HttpOnly = HttpOnlyPolicy.Always;
                options.Secure = CookieSecurePolicy.Always;
            });

            services.ConfigureApplicationCookie(opt =>
            {
                opt.Cookie.Name = "UzmanEgitimDanismani";
                opt.ExpireTimeSpan = TimeSpan.FromHours(5);
                opt.SlidingExpiration = true;

            });


            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(opts =>
            {

                opts.LoginPath = loginAdress;
                opts.LogoutPath = logoutAdress;
                opts.ReturnUrlParameter = "ReturnUrl";
                opts.AccessDeniedPath = new PathString("/AccessDenied");
                
                
                opts.ExpireTimeSpan = TimeSpan.FromHours(8);
                //opts.Cookie.MaxAge = opts.ExpireTimeSpan;
                opts.SlidingExpiration = true; // Kullanıcı etkinse süre uzar
                opts.Cookie.HttpOnly = true; // Cookie'ye sadece HTTP üzerinden erişim
                opts.Cookie.SecurePolicy = CookieSecurePolicy.Always; // HTTPS üzerinde çalışacak
   



                //opts.Cookie.HttpOnly = true;
                //opts.Cookie.MaxAge = opts.ExpireTimeSpan;
                //opts.SlidingExpiration = true;
                ////opts.Cookie.Expiration = TimeSpan.FromHours(5);

                //opts.Cookie.IsEssential = true;
                //opts.Cookie.Name = "UzmanEgitimDanismani";
                //opts.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                //opts.Cookie.SameSite = SameSiteMode.Lax;
                //opts.Events = new CookieAuthenticationEvents()
                //{
                //    //    OnRedirectToAccessDenied = OnRedirectToAccessDenied,
                //    //    OnRedirectToLogin = OnRedirectToLogin,
                //    //    OnRedirectToLogout = OnRedirectToLogout
                //    //    OnRedirectToReturnUrl = OnRedirectToReturnUrl,
                //    //    OnSignedIn = OnSignedIn,
                //    //    OnSigningIn = OnSigningIn,
                //    //    OnSigningOut = OnSigningOut,
                //    //    OnValidatePrincipal = OnValidatePrincipal,

                //};

                //opts.SlidingExpiration = true;

            });

            services.AddAuthorization();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSession();

            app.UseCustomException();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapRazorPages();
            //});

            app.UseStatusCodePages();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{area:exists}/{controller=Anasayfa}/{action=Index}/{url?}",
                    new { area = "Akademi" }
                );
                endpoints.MapControllerRoute(
                    name: "login",
                    pattern: "{controller=Login}/{action=Index}/{id?}",
                    new { area = "" });
            });
        }
    }
}
