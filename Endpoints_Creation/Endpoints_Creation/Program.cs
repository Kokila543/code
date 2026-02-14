//using Endpoints_Creation.Mapping;
using Endpoints_Creation.Services;
using Endpoints_Creation.Services.Implementations;
using Endpoints_Creation.Services.Interfaces;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



// Services
builder.Services.AddScoped<ITagMasterQueryService, TagMasterQueryService>();
builder.Services.AddScoped<ITagAssociationsValidationService, TagAssociationsValidationService>();
builder.Services.AddScoped<ITagAssociationCommandService, TagAssociationCommandService>();
builder.Services.AddScoped<ITagFrameworkService, TagFrameworkService>();
builder.Services.AddScoped<ITagMasterValidationService, TagMasterValidationService>();
builder.Services.AddScoped<ITagMasterCommandService, TagMasterCommandService>();

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddMaps(AppDomain.CurrentDomain.GetAssemblies());
});
builder.Services.AddDbContext<AppContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

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
