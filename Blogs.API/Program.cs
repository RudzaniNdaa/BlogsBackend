using Blogs.API.Brokers.DateTimes;
using Blogs.API.Brokers.Loggings;
using Blogs.API.Brokers.Storages;
using Blogs.API.Brokers.UserManagements;
using Blogs.API.Models.Users;
using Blogs.API.Services.Foundations.Authors;
using Blogs.API.Services.Foundations.Comments;
using Blogs.API.Services.Foundations.Likes;
using Blogs.API.Services.Foundations.PostAttachments;
using Blogs.API.Services.Foundations.Posts;
using Blogs.API.Services.Foundations.Replies;
using Blogs.API.Services.Processings.Authors;
using Blogs.API.Services.Processings.Comments;
using Blogs.API.Services.Processings.Likes;
using Blogs.API.Services.Processings.PostAttachments;
using Blogs.API.Services.Processings.Posts;
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
builder.Services.AddTransient<IAuthorProcessingService, AuthorProcessingService>();

builder.Services.AddTransient<ICommentService, CommentService>();
builder.Services.AddTransient<ICommentProcessingService, CommentProcessingService>();

builder.Services.AddTransient<ILikeService, LikeService>();
builder.Services.AddTransient<ILikeProcessingService, LikeProcessingService>();

builder.Services.AddTransient<IPostAttachmentService, PostAttachmentService>();
builder.Services.AddTransient<IPostAttachmentProcessingService, PostAttachmentProcessingService>();

builder.Services.AddTransient<IPostService, PostService>();
builder.Services.AddTransient<IPostProcessingService, PostProcessingService>();

builder.Services.AddTransient<IReplyService, ReplyService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.Run();
