using BlazorServerDataGridSample.Data;
using BlazorServerDataGridSample.Repositories;
using BlazorServerDataGridSample.Services;
using IgniteUI.Blazor.Controls;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor()
    .AddHubOptions(options =>
    {
        // IgbGrid で BodyTemplate を使用する場合に、Blazor Server の SignalR 通信サイズが
        // 既定の上限値を超える場合があるので、通信サイズ上限を緩和
        options.MaximumReceiveMessageSize = 102400000;
    });

//DB関連
builder.Services.AddDbContextFactory<SampleDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//Repository関連
builder.Services.AddScoped<ISalesDetailRepository, SalesDetailRepository>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();

//Service関連            
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
