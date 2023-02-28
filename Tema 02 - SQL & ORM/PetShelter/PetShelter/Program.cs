using PetShelter.DataAccessLayer;
using PetShelter.DataAccessLayer.Repository;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");


app.MapGet("/TotalAmount", async () => "Total: " + await new FundraiserRepository(new PetShelterContext()).CurrentRaisedAmount());


app.Run();
