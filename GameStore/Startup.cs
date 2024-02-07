using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;

namespace GameStore
{
	public class Startup
	{
		public IConfiguration Configuration { get; set; }	
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc();
			services.AddSession();
		}
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();	
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				app.UseHsts();	
			}

			app.UseStaticFiles();	
			app.UseRouting();	
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute (
					name: "IndexHome",
					pattern: "{controller=Home}/{action=Index}/{id?}"
				);

				endpoints.MapControllerRoute (
					name: "DetailsHome",
					pattern: "{controller=Home}/{action=Details}/{id?}"
				);

			});
		}
	}
}