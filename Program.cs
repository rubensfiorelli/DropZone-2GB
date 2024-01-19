using Microsoft.AspNetCore.Http.Features;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.Limits.MaxRequestBodySize = 2028 * 1024 * 1024;
});

builder.Services.Configure<FormOptions>(options =>
{
    options.ValueLengthLimit = int.MaxValue;
    options.MultipartBodyLengthLimit = int.MaxValue;

});

builder.Services.Configure<IISServerOptions>(opts =>
{
    opts.MaxRequestBodySize = 2028 * 1024 * 1024;

});

builder.Services.Configure<IISServerOptions>(opts =>
{
    opts.MaxRequestBodySize = 2028 * 1024 * 1024;

});

//builder.WebHost.ConfigureKestrel((context, serverOptions) =>
//{
//    serverOptions.ListenAnyIP(7252, listenOptions =>
//    {
//        listenOptions.Protocols = HttpProtocols.Http1AndHttp2AndHttp3;
//    });
//});


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
