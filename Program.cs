using Microsoft.EntityFrameworkCore;
using StudentCrudApiDto.Data;

var builder = WebApplication.CreateBuilder(args);

// --- Entity Framework Core (DB-First) ---
builder.Services.AddDbContext<StudentDbBasicContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

// --- AutoMapper (registers the MappingProfile above) ---
builder.Services.AddAutoMapper(typeof(StudentCrudApiDto.Mappings.DtoMapper));

// --- Controllers + Swagger/OpenAPI ---
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// --- HTTP pipeline ---
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();