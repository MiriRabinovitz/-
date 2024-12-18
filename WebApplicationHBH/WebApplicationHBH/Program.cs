using System.Text.Json.Serialization;
using WebApplicationHBH.Contracts;
using WebApplicationHBH.DataContext;
using WebApplicationHBH.Routes;
using WebApplicationHBH.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;


var builder = WebApplication.CreateSlimBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<ContacFormDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("ContactFormDb")));
builder.Services.AddScoped<IContractFormRepository, ContactFormRepository>();


//builder.Services.ConfigureHttpJsonOptions(options =>
//{
//    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
//});



// ����� ������ �����
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        // ��� ����� �� ������� ���
    };
});

builder.Services.AddAuthorization();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("http://example.com")
        .AllowAnyMethod()
        .AllowAnyHeader());
});

builder.Services.AddControllers();


var app = builder.Build();


app.UseHttpsRedirection();// ������ ������ ����� 
app.UseExceptionHandler("/error");//����� ������
app.UseStatusCodePages();//����� ��� ����� �� ����
app.Services.CreateScope().ServiceProvider.GetRequiredService<ContacFormDbContext>().Database.EnsureCreated();

app.UseHttpsRedirection();

app.MapContactForm();

app.Run();


