using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using RamirezforaneoApp.Data;
using RamirezforaneoApp.Models;
namespace RamirezforaneoAppAPI.Controllers.Admin;

public static class CategoryAPIEndpoints
{
    public static void MapCategoryEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Category").WithTags(nameof(Category));

        group.MapGet("/", async (ApplicationDbContext db) =>
        {
            return await db.Category.ToListAsync();
        })
        .WithName("GetAllCategories")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Category>, NotFound>> (int categoryid, ApplicationDbContext db) =>
        {
            return await db.Category.AsNoTracking()
                .FirstOrDefaultAsync(model => model.CategoryId == categoryid)
                is Category model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetCategoryById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int categoryid, Category category, ApplicationDbContext db) =>
        {
            var affected = await db.Category
                .Where(model => model.CategoryId == categoryid)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.CategoryId, category.CategoryId)
                    .SetProperty(m => m.CategoryName, category.CategoryName)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateCategory")
        .WithOpenApi();

        group.MapPost("/", async (Category category, ApplicationDbContext db) =>
        {
            db.Category.Add(category);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Category/{category.CategoryId}",category);
        })
        .WithName("CreateCategory")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int categoryid, ApplicationDbContext db) =>
        {
            var affected = await db.Category
                .Where(model => model.CategoryId == categoryid)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteCategory")
        .WithOpenApi();
    }
}
