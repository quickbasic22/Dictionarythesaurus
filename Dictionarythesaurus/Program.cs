using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Dictionarythesaurus.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<DictionarythesaurusContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DictionarythesaurusContext") ?? throw new InvalidOperationException("Connection string 'DictionarythesaurusContext' not found.")));

builder.Services.AddRazorPages().AddRazorPagesOptions(options =>
{
    options.Conventions.AddPageRoute("/WordDictionary/Index", "");
}
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
