using Microsoft.EntityFrameworkCore;
using System.Configuration;
using IRMS;
using IRMS.Repository;
using IRMS.IRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<IRMSContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("IRMSDBConnection")));
builder.Services.AddScoped<IEmployee, EmployeeRepository>();
builder.Services.AddScoped<IAddress, AddressRepository>();
builder.Services.AddScoped<IEducation, EducationRepository>();
builder.Services.AddScoped<IFamilyDetails, FamilyDetailsRepository>();
builder.Services.AddScoped<IAppointment, AppointmentRepository>();
builder.Services.AddScoped<IAttendence, AttendenceRepository>();
builder.Services.AddScoped<IEmailTemplates, EmailTemplatesRepository>();
builder.Services.AddScoped<IExpenses, ExpensesRepository>();
builder.Services.AddScoped<IExperience, ExperienceRepository>();
builder.Services.AddScoped<IIncome, IncomeRepository>();
builder.Services.AddScoped<IMenu, MenuRepository>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
