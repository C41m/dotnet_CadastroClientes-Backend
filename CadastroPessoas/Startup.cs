using CadastroPessoas.DataContext;
using CadastroPessoas.Service.CidadeService;
using CadastroPessoas.Service.CidadesService;
using CadastroPessoas.Service.ClienteService;
using Microsoft.EntityFrameworkCore;

namespace CadastroPessoas
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddScoped<IClienteInterface, ClienteService>();
            services.AddScoped<ICidadeInterface, CidadeService>();
            services.AddCors(options =>
            {
                options.AddPolicy("MyCorsPolicy", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "CadastroClientesApi",
                    Version = "v1"
                });
            });

            services.AddControllers();

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "CadastroClientesApi v1");
                options.RoutePrefix = String.Empty;


            });

            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();


            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseCors("MyCorsPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
