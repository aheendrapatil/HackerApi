using HackerNewsApi2.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<IStoryRepositories,StoryRepositories>();
builder.Services.AddCors(p => p.AddPolicy("corspolicy", build => {
    build.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");   
    app.UseHsts();
}

app.UseCors("corspolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
