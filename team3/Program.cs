using Microsoft.EntityFrameworkCore;
using team3.DAL;
using team3.DAL.Repositories.Category;
using team3.DAL.Repositories.Product;
using FluentValidation;
using team3.BLL.Validators.Product;
using team3.BLL.Validators.Category;
using FluentValidation.AspNetCore;
using Serilog;
using Serilog.Events;
using team3.Middleware;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .WriteTo.Console(outputTemplate: "{Timestamp:HH:mm:ss} [{Level}] {Message}{NewLine}{Exception}")
    .WriteTo.File(
        path: "Logs/log-.txt",
        rollingInterval: RollingInterval.Hour,
        retainedFileCountLimit: 24 * 7,
        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level}] {Message}{NewLine}{Exception}")
    .CreateLogger();
try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog();

    builder.Services.AddFluentValidationAutoValidation();
    builder.Services.AddValidatorsFromAssemblyContaining<CreateProductDtoValidator>();
    builder.Services.AddValidatorsFromAssemblyContaining<CategoryDtoValidator>();
    builder.Services.AddValidatorsFromAssemblyContaining<ProductDtoValidator>();


    // Add repositories
    builder.Services.AddScoped<IProductRepository, ProductRepository>();
    builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

    builder.Services.AddControllers();
    // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
    builder.Services.AddOpenApi();

    builder.Services.AddDbContext<AppDbContext>(options =>
    {
        options.UseNpgsql("name=PostgresLocal");
    });

    //Add automapper
    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    builder.Services.AddCors(opt =>
    {
        opt.AddPolicy("react_cors", opt =>
        {
            opt
            .WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
        });
    });

    var app = builder.Build();

    // Configure the HTTP request pipeline..
    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
    }


    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Застосунок завершився неочікувано");
}
finally
{
    Log.CloseAndFlush();
}