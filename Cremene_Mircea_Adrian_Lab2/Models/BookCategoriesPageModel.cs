using Cremene_Mircea_Adrian_Lab2.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cremene_Mircea_Adrian_Lab2.Models;

public class BookCategoriesPageModel : PageModel
{
    public List<AssignedCategoryData>? AssignedCategoryDataList;

    public void PopulateAssignedCategoryData(Cremene_Mircea_Adrian_Lab2Context context, Book book)
    {
        var allCategories = context.Category;
        var bookCategories = new HashSet<int>(book.BookCategories!.Select(c =>
            c.CategoryId));

        AssignedCategoryDataList = new List<AssignedCategoryData>();

        foreach (var category in allCategories)
        {
            AssignedCategoryDataList.Add(new AssignedCategoryData
            {
                CategoryId = category.Id,
                Name = category.CategoryName,
                Assigned = bookCategories.Contains(category.Id)
            });
        }
    }

    public void UpdateBookCategories(Cremene_Mircea_Adrian_Lab2Context context, string[]? selectedCategories,
        Book bookToUpdate)
    {
        if (selectedCategories is null)
        {
            bookToUpdate.BookCategories = new List<BookCategory>();
            return;
        }

        var selectedCategoriesHashSet = new HashSet<string>(selectedCategories);
        var bookCategories = new HashSet<int>(bookToUpdate.BookCategories!.Select(c => c.CategoryId));

        foreach (var category in context.Category)
        {
            if (selectedCategoriesHashSet.Contains(category.Id.ToString()))
            {
                if (!bookCategories.Contains(category.Id))
                {
                    bookToUpdate.BookCategories!.Add(new BookCategory
                    {
                        BookId = bookToUpdate.Id,
                        CategoryId = category.Id
                    });
                }
            }
            else
            {
                if (bookCategories.Contains(category.Id))
                {
                    var bookToRemove = bookToUpdate.BookCategories!.SingleOrDefault(i => i.CategoryId == category.Id);
                    context.Remove(bookToRemove);
                }
            }
        }
    }
}