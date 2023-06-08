var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDataContext(builder.Configuration);

var app = builder.Build();

if (app.Configuration.GetValue<bool>("UseInMemoryDatabase"))
{
    using (var scope = app.Services.CreateScope())
    {
        var scopeProvider = scope.ServiceProvider;
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        await AppDbContextSeed.SeedSampleDataAsync(dbContext);
    }
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
