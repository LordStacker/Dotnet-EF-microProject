using Microsoft.EntityFrameworkCore;
using RoundTheCode.EFCore.Application.Context;
using RoundTheCode.EFCore.Application.Services;
using RoundTheCode.EFCore.Infrastructure;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddDbContext<IRoundTheCodeEfCoreDbContext, RoundTheCodeEfCoreDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("RoundTheCodeEfCoreDbContext"));
});

var app = builder.Build();

using (var scope = app.Services.CreateScope()) { 
    var dbContext = scope.ServiceProvider.GetRequiredService<IRoundTheCodeEfCoreDbContext>();

    if (!dbContext.Database.CanConnect()) {
        throw new NotImplementedException("Cant Connect to db");
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
