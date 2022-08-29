using MessagesAPI.Repository;
using MessagesAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationContext>();
builder.Services.AddScoped(typeof(IUserService), typeof(UserService));
builder.Services.AddScoped(typeof(IMessagesService), typeof(MessagesService));
builder.Services.AddScoped(typeof(IMessagesRepository), typeof(MessagesRepository));
builder.Services.AddScoped(typeof(IUsersRepository), typeof(UsersRepository));


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "origins",
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000").AllowAnyHeader()
                                                  .AllowAnyMethod();
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("origins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
