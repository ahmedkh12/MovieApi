using Microsoft.EntityFrameworkCore;
using MovieApi.Data;
using MovieApi.Repositers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MovieApi") ?? throw new InvalidOperationException("Connection string 'identity' not found.")));

builder.Services.AddCors();  //for external communication
builder.Services.AddSwaggerGen(options => 
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "MovieApi Documentation",
        Description = "MovieApi Description",
        TermsOfService = new Uri("https://www.google.com"),
        Contact = new Microsoft.OpenApi.Models.OpenApiContact 
        {
        Name = "Ahmed",
       Email = "akh52888@gmail.com",
       
        },
        Version = "v1"
    });

    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme { 
    Name = "Authrization",
    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
    Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
    BearerFormat="JWT",
    Description = "Enter Token",
    });
}
);


builder.Services.AddScoped<IGenresRepositery, GenresRepositery>();
builder.Services.AddScoped<IMoviesRepositery, MoviesRepositery>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(c=>c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()); //for external communication
app.UseAuthorization();

app.MapControllers();

app.Run();
