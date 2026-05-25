using GameLibrary.Api.Data;

var builder = WebApplication.CreateBuilder(args);

//* Add services to the container.
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.AddLibraryGame();

var app = builder.Build();

//* Migrate the database
app.MigrateDb();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
    
}

//* Configure the HTTP request pipeline.
app.UseHttpsRedirection();

//* Map controllers
app.MapControllers();

app.Run();

