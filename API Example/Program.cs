using Microsoft.AspNetCore.Identity;
using SecuringWebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.ProjectConfiguration(builder.Configuration);    

var app = builder.Build();

app.MapIdentityApi<IdentityUser>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
