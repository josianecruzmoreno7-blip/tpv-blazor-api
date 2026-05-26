var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();

var app = builder.Build();

app.UseCors(policy =>
    policy.AllowAnyOrigin()
          .AllowAnyHeader()
          .AllowAnyMethod()
);

var corridas = new[]
{
    new {
        origen = "Tuxtla",
        destino = "CDMX",
        hora = "08:00 PM",
        precio = 950
    },

    new {
        origen = "Tuxtla",
        destino = "Puebla",
        hora = "10:00 PM",
        precio = 700
    }
};

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