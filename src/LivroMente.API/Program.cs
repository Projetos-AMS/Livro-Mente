using System.Reflection;
using Azure.Storage.Blobs;
using LivroMente.API.Handlers.CategoryBookHandler;
using LivroMente.Data.Context;
using LivroMente.Service.Interfaces;
using LivroMente.Service.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();

builder.Services.AddMediatR(add => add.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultContext")));

builder.Services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
builder.Services.AddScoped<CategoryBookService>();
builder.Services.AddScoped<PaymentService>();
builder.Services.AddScoped<BookService>();
builder.Services.AddScoped<BlobService>();


builder.Services.AddSingleton(x => new BlobServiceClient(builder.Configuration.GetValue<string>("AzureBlobStorage")));
builder.Services.AddScoped<IBlobService,BlobService>();

builder.Services.AddAutoMapper(typeof(DataContext));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();
app.MapControllers();

app.Run();

