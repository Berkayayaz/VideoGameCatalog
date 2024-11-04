using Microsoft.EntityFrameworkCore;
using VideoGameCatalog.Entity;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddEntityFrameworkSqlServer();

var connString = builder.Configuration.GetConnectionString("VideoGameCatalogContext");
builder.Services.AddDbContext<VideoGameCatalogDbContext>(opt => { opt.UseSqlServer(connString); });

builder.Services.AddCors(options => {
	options.AddPolicy("AllowAngular",
		builder => builder
			.WithOrigins("http://localhost:4200")
			.AllowAnyMethod()
			.AllowAnyHeader());
});

var app = builder.Build();

using (var scope = app.Services.CreateScope()) {
	var services = scope.ServiceProvider;
	var context = services.GetRequiredService<VideoGameCatalogDbContext>();
	DatabaseSeeder.SeedData(context);
}



app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
	app.UseSwagger();
	app.UseSwaggerUI();
}
app.UseRouting();
app.UseCors("AllowAngular");

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
