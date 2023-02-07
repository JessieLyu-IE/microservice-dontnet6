using GraphQL.MicrosoftDI;
using GraphQL.Server;
using GraphQL.Types;
using MyMicroservice.Notes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//add notes schema
builder.Services.AddSingleton<ISchema, NotesSchema>(services => new NotesSchema(new SelfActivatingServiceProvider(services)));
builder.Services.AddGraphQL(options =>
{
    options.EnableMetrics = true;
}).AddSystemTextJson();

//default setup
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(s =>
{
    s.SwaggerDoc("v1", new()
    {
        Version = "v1",
        Title = "MyServiceWithGraphQL"
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseGraphQLAltair();
}

app.UseAuthorization();

app.MapControllers();

app.UseGraphQL<ISchema>();

app.Run();
