using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Motok_Andreea_Proiect.Data;

namespace Motok_Andreea_Proiect.Models
{
    public class MovieCategoriesPageModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(Motok_Andreea_ProiectContext context, Movie Movie)
        {
            var allCategories = context.Category;
            var MovieCategories = new HashSet<int>(
            Movie.MovieCategories.Select(c => c.MovieID));
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = MovieCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateMovieCategories(Motok_Andreea_ProiectContext context,
 string[] selectedCategories, Movie MovieToUpdate)
        {
            if (selectedCategories == null)
            {
                MovieToUpdate.MovieCategories = new List<MovieCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var MovieCategories = new HashSet<int>
            (MovieToUpdate.MovieCategories.Select(c => c.Category.ID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!MovieCategories.Contains(cat.ID))
                    {
                        MovieToUpdate.MovieCategories.Add(
                        new MovieCategory
                        {
                            MovieID = MovieToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (MovieCategories.Contains(cat.ID))
                    {
                        MovieCategory courseToRemove
                        = MovieToUpdate
                        .MovieCategories
                        .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
