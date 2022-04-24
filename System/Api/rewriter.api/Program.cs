using rewriter.api.Configuration;
using rewriter.Settings;
using rewriter.Settings.Settings;
using rewriter.Settings.Source;
using Serilog;
var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((hostBuilderContext,loggerConfiguration)=>
{
    loggerConfiguration
     .Enrich.WithCorrelationId()
     .ReadFrom.Configuration(hostBuilderContext.Configuration);
});
var settings = new ApiSettings(new SettingsSource());
builder.Services.AddHttpContextAccessor();
builder.Services.AddCors();
builder.Services.AddAppDbContext(settings);
// Add services to the container.
builder.Services.AddAppHealthCheck()
                .AddControllers();
builder.Services.AddAppVersions();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRazorPages();
builder.Services.AddSettings();
builder.Services.AddAppSwagger(settings);
var app = builder.Build();

// Configure the HTTP request pipeline.
/*if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}*/
app.UseAppSwagger();
app.UseStaticFiles(); 
app.UseAppHealthCheck();
app.UseAuthorization();
app.UseCors(); 
app.UseSerilogRequestLogging();
app.MapControllers(); 
app.MapRazorPages();
app.UseAppDbContext();
app.Run();
