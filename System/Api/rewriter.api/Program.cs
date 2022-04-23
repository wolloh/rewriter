using rewriter.api.Configuration;
using Serilog;
var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((host,cfg)=>
{
    cfg.ReadFrom.Configuration(host.Configuration);
});
// Add services to the container.
builder.Services.AddAppHealthCheck()
                .AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAppHealthCheck();
app.UseAuthorization();

app.MapControllers();

app.Run();
