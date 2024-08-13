using EventApi.Context;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // Este método se llama en tiempo de ejecución. Use este método para agregar servicios al contenedor.
    public void ConfigureServices(IServiceCollection services)
    {
        //services.AddDbContext<ConnectionSQL>(options=>options.UseSqlServer(Configuration.GetConnectionString("conexionSQLServer")));
        services.Configure<DatabaseSettings>(Configuration.GetSection("DatabaseSettings"));
        services.AddTransient<MyService>();
        services.AddControllers();
    }

    // Este método se llama en tiempo de ejecución. Use este método para configurar el pipeline de solicitudes HTTP.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
