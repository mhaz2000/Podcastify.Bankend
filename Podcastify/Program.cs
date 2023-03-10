using Microsoft.EntityFrameworkCore;
using Podcastify.Application.Services.PodcastServices;
using Podcastify.Core.Repositories.Base;
using Podcastify.Infrastructure.Data;
using Podcastify.Infrastructure.Repositories.Base;
using Podcastify.API.Helpers.ExceptionHandlers;
using Podcastify.Application.Services.FileServices;
using Podcastify.Application.Services.Review_Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("Main")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IPodcastService, PodcastService>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IReviewService, ReviewService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

app.UseCors(c =>
{
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
});

app.UseMiddleware<ExceptionMiddle>();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
