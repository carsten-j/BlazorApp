﻿using BellyBox.Client;
using BellyBox.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<MealsListState>();
builder.Services.AddScoped<IBellyBoxDataService, BellyBoxDataService>();
builder.Services.AddScoped<ICartDataService, CartDataService>();
builder.Services.AddScoped<ILocalStorageService, LocalStorageService>();

builder.Services.AddApiAuthorization();

await builder.Build().RunAsync();