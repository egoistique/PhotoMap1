using PhotoMap.Api;
using PhotoMap.Api.Configuration;
using PhotoMap.Services.Logger;
using PhotoMap.Services.Settings;
using PhotoMap.Settings;
using PhotoMap.Context;
using PhotoMap.Context.Seeder;

var mainSettings = Settings.Load<MainSettings>("Main");
var logSettings = Settings.Load<LogSettings>("Log");
var swaggerSettings = Settings.Load<SwaggerSettings>("Swagger");
var identitySettings = Settings.Load<IdentitySettings>("Identity");


var builder = WebApplication.CreateBuilder(args);

builder.AddAppLogger(mainSettings, logSettings);


var services = builder.Services;

services.AddHttpContextAccessor();

services.AddAppDbContext(builder.Configuration);

services.AddAppCors();

services.AddAppHealthChecks();

services.AddAppVersioning();

services.AddAppSwagger(mainSettings, swaggerSettings, identitySettings);

services.AddAppAutoMappers();

services.AddAppValidator();

services.AddAppAuth(identitySettings);

services.AddAppControllerAndViews();

services.RegisterServices(builder.Configuration);


var app = builder.Build();

var logger = app.Services.GetRequiredService<IAppLogger>();

app.UseHttpsRedirection();

app.UseAppCors();

app.UseAppHealthChecks();

app.UseAppSwagger();

app.UseAppAuth();

app.UseAppControllerAndViews();

DbInitializer.Execute(app.Services);

DbSeeder.Execute(app.Services);

logger.Information("The PhotoMap.API has started");

app.Run();

logger.Information("The PhotoMap.API has stopped");
