public static class DependencyInjection
{
    public static IServiceCollection AddDataContext(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddDbContext<AppDbContext>(
            options => options.UseSqlite(configuration.GetConnectionString("Default"))
        );

        services.AddScoped<IAppDbContext>(provider => provider.GetRequiredService<AppDbContext>());

        services.AddScoped<IAppWriteDbConnection, ApplWriteDbConnection>();
        services.AddScoped<IAppReadDbConnection, AppReadDbConnection>();

        services.AddTransient(typeof(IRepository<>), typeof(BaseRepository<>));
        services.AddTransient(typeof(IReadRepository<>), typeof(BaseRepository<>));
        services.AddTransient<IActRepository, ActRepository>();

        return services;
    }
}
