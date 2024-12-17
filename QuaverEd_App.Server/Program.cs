var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();











// var builder = WebApplication.CreateBuilder(args);

// // Add services to the container.
// builder.Services.AddControllers();

// // Add CORS services
// builder.Services.AddCors(options =>
// {
//     options.AddDefaultPolicy(policy =>
//     {
//         policy.WithOrigins("http://localhost:8080") // Allow Vue.js development server
//               .AllowAnyHeader()
//               .AllowAnyMethod();
//     });
// });

// // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

// var app = builder.Build();

// app.UseDefaultFiles();
// app.UseStaticFiles();

// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

// app.UseHttpsRedirection();

// // Enable CORS middleware
// app.UseCors();

// app.UseAuthorization();

// app.MapControllers();

// app.MapFallbackToFile("/index.html");

// app.Run();








//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddControllers();

//// Add CORS services
//builder.Services.AddCors(options =>
//{
//    options.AddDefaultPolicy(policy =>
//    {
//        //policy.WithOrigins("http://localhost:8080") // Allow Vue.js development server // original
//        policy.WithOrigins("http://localhost:5278") // Allow Vue.js development server 
//        // policy.WithOrigins("http://localhost:5173") // Allow Vue.js development server
//              .AllowAnyHeader()
//              .AllowAnyMethod();
//    });
//});

//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//app.UseDefaultFiles();
//app.UseStaticFiles();

//// Add Content Security Policy middleware
//app.Use(async (context, next) =>
//{
//    // Allow scripts from the same origin ('self') and Vue.js development server
//    // context.Response.Headers.Add("Content-Security-Policy", "default-src 'self'; script-src 'self' http://localhost:8080;"); //original
//    context.Response.Headers.Add("Content-Security-Policy",
//        "default-src 'self'; script-src 'self' http://localhost:8080; script-src-elem 'self' http://localhost:8080;"); // original
//        // "default-src 'self'; script-src 'self' http://localhost:5173; script-src-elem 'self' http://localhost:5173;");
//    await next();
//});

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//// Enable CORS middleware
//app.UseCors();

//app.UseAuthorization();

//app.MapControllers();

//app.MapFallbackToFile("/index.html");

//app.Run();











//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddControllers();

//// Add CORS services
//builder.Services.AddCors(options =>
//{
//    options.AddDefaultPolicy(policy =>
//    {
//        //policy.WithOrigins("http://localhost:8080") // Vue.js dev server
//        policy.WithOrigins("http://localhost:5174") // Vue.js dev server
//              .AllowAnyHeader()
//              .AllowAnyMethod();
//    });

//    // Retain the existing configuration
//    options.AddPolicy("CustomPolicy", policy =>
//    {
//        policy.WithOrigins("http://localhost:5278")
//              .AllowAnyHeader()
//              .AllowAnyMethod();
//    });
//});

//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//app.UseDefaultFiles();
//app.UseStaticFiles();

//// Add Content Security Policy middleware
//app.Use(async (context, next) =>
//{
//    // Allow scripts from the same origin ('self') and Vue.js development server
//    context.Response.Headers.Add("Content-Security-Policy",
//      //  "default-src 'self'; script-src 'self' http://localhost:8080; script-src-elem 'self' http://localhost:8080;"); // Vue.js dev server
////"default-src 'self'; script-src 'self' http://localhost:5173; script-src-elem 'self' http://localhost:5173;"); // Vue.js dev server
//"default-src 'self'; script-src 'self' http://localhost:5174; script-src-elem 'self' http://localhost:5174;"); // Vue.js dev server
//await next();
//});

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//// Enable CORS middleware
//app.UseCors(); // Uses the default policy

//app.UseAuthorization();

//app.MapControllers();

//app.MapFallbackToFile("/index.html");

//app.Run();
