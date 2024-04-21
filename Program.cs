using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ERP_SalonNamestaja.Models;
using ERP_SalonNamestaja.Services;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme {
        Description = """Standard Authorization header using the Bearer scheme. Example: "bearer {token}" """,
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    c.OperationFilter<SecurityRequirementsOperationFilter>();
});
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<IProstorijaService, ProstorijaService>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddDbContext<SalonTestContext>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => 
    {
        options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value!)),
                ValidateIssuer = false,
                ValidateAudience = false
            };
    });
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(opt => {
    opt.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000");
    });
app.UseHttpsRedirection();

app.UseAuthentication();


app.UseAuthorization();

app.MapControllers();

app.Run();
