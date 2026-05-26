var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

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