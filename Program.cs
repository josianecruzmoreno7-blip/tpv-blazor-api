var builder = WebApplication.CreateBuilder(args);

// ACTIVAR CORS
builder.Services.AddCors();

var app = builder.Build();

// USAR CORS
app.UseCors(policy =>
    policy
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod()
);

// DATOS DEMO
var corridas = new[]
{
    new
    {
        origen = "Tuxtla",
        destino = "CDMX",
        fecha = "01-06-2026",
        hora = "08:00 PM",
        precio = 950
    },
    new
    {
        origen = "Tuxtla",
        destino = "Puebla",
        fecha = "09-06-2026",
        hora = "10:00 PM",
        precio = 700
    },
    new
    {
        origen = "Campeche",
        destino = "Veracruz",
        fecha = "09-06-2026",
        hora = "10:00 PM",
        precio = 700
    }
    
};

// ENDPOINT
app.MapGet("/api/corridas", (string origen, string destino) =>
{
    var resultados = corridas.Where(c =>

        c.origen.ToLower() == origen.ToLower()

        &&

        c.destino.ToLower() == destino.ToLower()

    );

    return resultados;
});

app.Run();