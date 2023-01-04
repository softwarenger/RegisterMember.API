using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RegisterMember.API.Models;
using RegisterMember.API.Repositories;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(options => 
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        
});

builder.Services.AddCors((options) =>
{
    options.AddPolicy("angularApplication", (builder) =>
    {
        builder.WithOrigins("http://localhost:4200")
                      .AllowAnyHeader()
                      .WithMethods("GET", "POST", "PUT", "DELETE")
                      .WithExposedHeaders("*");
    });
});




builder.Services.AddScoped<IUserRepository,UserRepository>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "RegisterMember.API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("angularApplication");

app.UseAuthorization();

app.MapControllers();

app.Run();
