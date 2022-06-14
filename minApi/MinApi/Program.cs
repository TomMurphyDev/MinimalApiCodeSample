using Microsoft.OpenApi.Models;
using ItemStore; 


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
  {
      c.SwaggerDoc("v1", new OpenApiInfo { Title = "Todo API", Description = "Keep track of your tasks", Version = "v1" });
  });
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
  {
      c.SwaggerEndpoint("/swagger/v1/swagger.json", "Todo API V1");
  });
app.MapGet("/", () => "Hello World!");
app.MapGet("/items/{id}", (int id) => ItemDB.GetItem(id));
app.MapGet("/items", () => ItemDB.GetItems());
app.MapPost("/items", (Item item) => ItemDB.CreateItem(item));
app.MapPut("/items", (Item item) => ItemDB.UpdateItem(item));
app.MapDelete("/items/{id}", (int id) => ItemDB.RemoveItem(id));
app.Run();
