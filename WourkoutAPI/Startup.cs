using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Threading.Tasks;
using WourkoutAPI.Data;
using WourkoutAPI.Settings;

namespace WourkoutAPI
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			var config = Configuration.GetSection(nameof(JwtSettings)).Get<JwtSettings>();

			//services.AddSingleton(Configuration.GetSection(nameof(JwtSettings)).Get<JwtSettings>());

			services.AddDbContext<ApiDbContext>(options => options.UseSqlServer(
				Configuration.GetConnectionString("ApiWorkoutCS")
			));
			services.Configure<JwtSettings>(Configuration.GetSection(nameof(JwtSettings)));
			
			// Add Authentication Services
			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			.AddJwtBearer(options =>
			{
				options.RequireHttpsMetadata = config.RequireHttpsMetadata;
				options.IncludeErrorDetails = config.IncludeErrorDetails;
				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateAudience = config.ValidateAudience,
					ValidateIssuerSigningKey = config.ValidateIssuerSigningKey,
					ValidateIssuer = config.ValidateIssuer,
					ValidateLifetime = config.ValidateLifetime,
					ValidIssuer = config.AuthorityURL,
					ValidAudience = config.AuthorityURL,
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.SecretKey))
				};

				options.Events = new JwtBearerEvents
				{
					OnAuthenticationFailed = context =>
					{
						if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
						{
							context.Response.Headers.Add("Token-Expired", "true");
						}
						return Task.CompletedTask;
					}
				};
			});



			services.AddControllers();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			// Enable authentication middleware
			app.UseAuthentication();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
