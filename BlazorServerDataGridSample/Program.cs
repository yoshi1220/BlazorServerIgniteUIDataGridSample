using BlazorServerDataGridSample.Data;
using BlazorServerDataGridSample.Repositories;
using BlazorServerDataGridSample.Services;
using IgniteUI.Blazor.Controls;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();



//DBŠÖ˜A
builder.Services.AddDbContext<SampleDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//RepositoryŠÖ˜A
builder.Services.AddScoped<ISalesDetailRepository, SalesDetailRepository>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();

//ServiceŠÖ˜A            
builder.Services.AddScoped<ISalesDetailService, SalesDetailService>();
builder.Services.AddScoped<IItemService, ItemService>();


//Ignite UI for Blazor
builder.Services.AddIgniteUIBlazor(
                typeof(IgbPropertyEditorPanelModule),
                typeof(IgbGridModule),
                typeof(IgbCalloutLayerModule),
                typeof(IgbNumberAbbreviatorModule),
                typeof(IgbLegendModule),
                typeof(IgbButtonModule),
                typeof(IgbInputModule)
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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
