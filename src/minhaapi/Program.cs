using Microsoft.AspNetCore.Mvc;
using minhaapi.infraestrutura;
using minhaapi.modul;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<iemployeeRepository, employeeRepository>();



var key = Encoding.ASCII.GetBytes(minhaapi.Key.Secret);

builder.Services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJWTBearer(x =>
    {
        x.RequireHttspsMetadata = false;
        x.SvaeToken = true;
        x.TokenvaliidationParameters = new TokenvaliidationParameters
        {
            validateIssuerSigningKey = true;
        IssuerSingningkey - new SymmetricSecuritykey(key);
        validateIssuer = false;
        ValidateAudience = false;

    

    });



var app = builder.Build();


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
