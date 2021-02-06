using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using PikTok.Components;
using PikTok.Models;
using PikTok.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PikTok.Controllers;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Net.WebSockets;

namespace PikTok.WebSite {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddHttpClient();
            services.AddControllers();
            services.AddSingleton<AuthService>();
            services.AddSingleton<MediaService>();
            services.AddSingleton<DatabaseService>();
            services.AddSingleton<PostService>();
            services.AddSingleton<WebSocketServerService>();
            services.AddMvc(options => options.EnableEndpointRouting = false);

            var key = Encoding.ASCII.GetBytes("qqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqq");
            services.AddAuthentication(x => {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x => {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });            
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            else {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles(new StaticFileOptions() {
                OnPrepareResponse = context =>
                {
                    context.Context.Response.Headers.Add("Cache-Control", "no-cache, no-store");
                    context.Context.Response.Headers.Add("Expires", "-1");
                }
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseMvc(routes => {
                routes.MapRoute("Profile", "{UserName}", new { controller = "Profile", action = "LoadProfile" });
                routes.MapRoute("ProfileMedia", "{UserName}/Media", new { controller = "Profile", action = "LoadProfileMedia" });
                routes.MapRoute("ProfilePhotos", "{UserName}/Photos", new { controller = "Profile", action = "LoadProfilePhotos" });
                routes.MapRoute("ProfileVideos", "{UserName}/Videos", new { controller = "Profile", action = "LoadProfileVideos" });
                routes.MapRoute("ProfileMediaByID", "{UserName}/Media/{MediaID}", new { controller = "Profile", action = "LoadProfileMediaByID" });
            });
            app.UseEndpoints(endpoints => {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
            });
            WebSocketServerService webSocketServerService = app.ApplicationServices.GetService<WebSocketServerService>();
            webSocketServerService.Start();
        }
    }
}
