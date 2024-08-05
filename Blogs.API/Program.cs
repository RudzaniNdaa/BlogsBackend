using Blogs.API.Brokers.DateTimes;
using Blogs.API.Brokers.Loggings;
using Blogs.API.Brokers.Storages;
using Blogs.API.Brokers.UserManagements;
using Blogs.API.Models.Users;
using Blogs.API.Services.Foundations.Authors;
using Blogs.API.Services.Foundations.Comments;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<StorageBroker>();

builder.Services.AddIdentityCore<User>()
                .AddRoles<Role>()
                .AddEntityFrameworkStores<StorageBroker>()
                .AddDefaultTokenProviders();

builder.Services.AddScoped<IUserManagementBroker, UserManagementBroker>();
builder.Services.AddScoped<IStorageBroker, StorageBroker>();
builder.Services.AddTransient<ILoggingBroker, LoggingBroker>();
builder.Services.AddTransient<IDateTimeBroker, DateTimeBroker>();

builder.Services.AddTransient<IAuthorService, AuthorService>();
builder.Services.AddTransient<ICommentService, CommentService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.Run();
