using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

using ContosoCrafts.WebSite.Models;

using Microsoft.AspNetCore.Hosting;

namespace ContosoCrafts.WebSite.Services
{

    /// <summary>
    /// Items Service to perform CRUD operations on the database
    /// </summary>
    public class JsonFileItemsService
    {

        // Initializing up the host environment 
        public IWebHostEnvironment WebHostEnvironment { get; }

        /// <summary>
        /// Default Constructor with IWebHostEnvironment dependency injection
        /// </summary>
        /// <param name="webHostEnvironment"></param>
        public JsonFileItemsService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        /// <summary>
        /// Getting the JSON database file name
        /// </summary>
        private string JsonFileName
        {
            get 
            { 
                return Path.Combine(WebHostEnvironment.WebRootPath, "data", "items.json"); 
            }
        }

        /// <summary>
        /// Method to get data for all the items and read the whole content of the data file
        /// </summary>
        /// <returns>List of ItemsModel</returns>
        public IEnumerable<ItemsModel> GetAllData()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<ItemsModel[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }

        /// <summary>
        /// Add Rating
        /// 
        /// Take in the product ID and the rating
        /// If the rating does not exist, add it
        /// Save the updated rating
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="rating"></param>
        public bool AddRating(string productId, int rating)
        {

            // If the ProductID is invalid, return
            if (string.IsNullOrEmpty(productId))
            {
                return false;
            }

            var items = GetAllData();

            // Look up the product, if it does not exist, return
            var data = items.FirstOrDefault(x => x.Id.Equals(productId));

            if (data == null)
            {
                return false;
            }

            // Check Rating for boundries, do not allow ratings below 0
            if (rating < 0)
            {
                return false;
            }

            // Check Rating for boundries, do not allow ratings above 5
            if (rating > 5)
            {
                return false;
            }

            // Check to see if the rating exist, if there are none, then create the array
            if (data.Ratings == null)
            {
                data.Ratings = new int[] { };
            }

            // Add the Rating to the Array
            var ratings = data.Ratings.ToList();
            ratings.Add(rating);
            data.Ratings = ratings.ToArray();

            // Save the data back to the data store
            SaveData(items);

            return true;
        }

        /// <summary>
        /// Save All items data to storage
        /// </summary>
        private void SaveData(IEnumerable<ItemsModel> items)
        {

            using (var outputStream = File.Create(JsonFileName))
            {
                JsonSerializer.Serialize<IEnumerable<ItemsModel>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {
                        SkipValidation = true,
                        Indented = true
                    }),
                    items
                );
            }

        }

    }

}