using ScbReact;
using ScbReact.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ScbReact.Service;
using TodoList.Swagger;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("default")));

////TODO Fixa till så att adden görs på rätt ställe typ :D
//builder.Services.AddIdentityCore<User>()
//    .AddEntityFrameworkStores<ApplicationDbContext>();



builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(0, 2);
    options.AssumeDefaultVersionWhenUnspecified = true;

    options.ApiVersionReader = new QueryStringApiVersionReader("api-version");
});

builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
});

//TODO behövs en swagger?
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v0.1", new OpenApiInfo { Title = "versioning", Version = "0.1" });
    options.SwaggerDoc("v0.2", new OpenApiInfo { Title = "versioning", Version = "0.2" });
    options.OperationFilter<AddApiVersionExampleValueOperationFilter>();

});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint($"/swagger/v0.1/swagger.json", "v0.1");
        options.SwaggerEndpoint($"/swagger/v0.2/swagger.json", "v0.2");
    });
}

app.UseHttpsRedirection();


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider
        .GetRequiredService<ApplicationDbContext>();

    ctx.Database.EnsureDeleted();
    ctx.Database.EnsureCreated();
}
ApiHelper.InitializeClient();

app.Run();
