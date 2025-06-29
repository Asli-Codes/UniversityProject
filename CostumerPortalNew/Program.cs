using DAL;
using DAL.DataServices;
using BLL.LogicServices;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IStudentsDataDAL, StudentsDataDAL>();
builder.Services.AddScoped<ICoursesDataDAL, CoursesDataDAL>();
builder.Services.AddScoped<IStudentsLogic, StudentsLogic>();
builder.Services.AddScoped<ICoursesLogic, CoursesLogic>();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.UseAuthorization();

app.MapControllers();

app.Run();
