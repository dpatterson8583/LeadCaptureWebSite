using Microsoft.AspNetCore.Builder;

namespace LeadGeneration
{
    public class Startup
    {


        public void Configure(IApplicationBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapFallbackToPage("/index.html");

                endpoints.MapRazorPages();

            });


        }
    }
}
