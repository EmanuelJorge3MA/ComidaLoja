using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using ComidaLoja.Model;
using Firebase.Database;

namespace ComidaLoja.Services
{
    public class FoodItemServices
    {
        FirebaseClient client;
        public FoodItemServices()
        {
            client = new FirebaseClient("https://comidaloja-default-rtdb.firebaseio.com/");
        }

        public async Task<List<FoodItem>> GetFoodItemsAsync()
        {
            var products = (await client.Child("FoodItems")
                .OnceAsync<FoodItem>())
                .Select(f => new FoodItem
                 {
                     CategoryID = f.Object.CategoryID,
                     Description = f.Object.Description,
                     HomeSelected = f.Object.HomeSelected,
                     ImageUrl = f.Object.ImageUrl,
                     Name = f.Object.Name,
                     Price = f.Object.Price,
                     ProductID = f.Object.ProductID,
                     Rating = f.Object.Rating,
                     RatingDetail = f.Object.RatingDetail
                 }).ToList();
            return products;
        }

        public async Task<ObservableCollection<FoodItem>> GetFoodItemsByCategoryAsync(int categoryID)
        {
            var foodItemsByCategory = new ObservableCollection<FoodItem>();
            var items = (await GetFoodItemsAsync()).Where(p => p.CategoryID == categoryID).ToList();
            foreach (var item in items)
            {
                foodItemsByCategory.Add(item);
            }
            return foodItemsByCategory;
        }

        public async Task<ObservableCollection<FoodItem>> GetLatestFoodItemsAsync()
        {
            var latestFoodItems = new ObservableCollection<FoodItem>();
            var items = (await GetFoodItemsAsync()).OrderByDescending(f => f.ProductID).Take(3);
            foreach (var item in items)
            {
                latestFoodItems.Add(item);
            }
            return latestFoodItems;
        }
    }
}
