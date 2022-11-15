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
    /// Product Service to perform CRUD operations on the database
    /// </summary>
    public class JsonFileProductService
    {
        // Initializing up the host environment 
        public IWebHostEnvironment WebHostEnvironment 
        { 
            get; 
        }

        /// <summary>
        /// Default Constructor with IWebHostEnvironment dependency injection
        /// </summary>
        /// <param name="webHostEnvironment"></param>
        public JsonFileProductService(IWebHostEnvironment webHostEnvironment)
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
                return Path.Combine(WebHostEnvironment.WebRootPath, "data", "products.json"); 
            }
        }

        /// <summary>
        /// Method to get data for all the products and read the whole content of the data file
        /// </summary>
        /// <returns>List of ProductModel</returns>
        public IEnumerable<ProductModel> GetAllData()
        {
            using(var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<ProductModel[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }

        /// <summary>
        /// Update method to save the modified data for existing record
        /// Find the data record from the file
        /// Update the fields
        /// Save to the data file
        /// </summary>
        /// <param name="data">Product data to be saved</param>
        public ProductModel UpdateData(ProductModel data)
        {
            var products = GetAllData();
            var productData = products.FirstOrDefault(x => x.Id.Equals(data.Id));
            if (productData == null)
            {
                return null;
            }

            // Update the data to the new passed in values
            productData.SchoolName = data.SchoolName;
            productData.SchoolAddress = data.SchoolAddress.Trim();
            productData.SchoolEmail = data.SchoolEmail;
            productData.SchoolContactInfo = data.SchoolContactInfo;
            productData.LaptopQuantity = data.LaptopQuantity;
            productData.ProjectorsQuantity = data.ProjectorsQuantity;
            productData.SpeakersQuantity = data.SpeakersQuantity;
            productData.SmartBoardsQuantity = data.SmartBoardsQuantity;
            productData.TabletsQuantity = data.TabletsQuantity;
            productData.DigitalMarkersQuantity = data.DigitalMarkersQuantity;
            productData.action = "update";

            SaveData(products);

            return productData;
        }

        /// <summary>
        /// Retrive a single product in the data storage
        /// </summary>
        /// <param name="id">The id of the product to retrive</param>
        /// <returns>The product with the given id or null if not found</returns>
        public ProductModel GetProduct(string id)
        {
            return GetAllData().FirstOrDefault(m => m.Id.Equals(id));
        }

        /// <summary>
        /// Save All products data to database file
        /// </summary>
        private void SaveData(IEnumerable<ProductModel> products)
        {

            using (var outputStream = File.Create(JsonFileName))
            {
                JsonSerializer.Serialize<IEnumerable<ProductModel>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {
                        SkipValidation = true,
                        Indented = true
                    }),
                    products
                );
            }
        }

        /// <summary>
        /// Create a new product using default values
        /// After create the user can update to set values
        /// </summary>
        /// <returns></returns>
        public ProductModel CreateData()
        {
            var data = new ProductModel()
            {
                Id = System.Guid.NewGuid().ToString(),
                SchoolName = "",
                SchoolAddress = "",
                SchoolEmail = "",
                SchoolContactInfo = "",
                LaptopQuantity = 0,
                ProjectorsQuantity = 0,
                SpeakersQuantity = 0,
                SmartBoardsQuantity = 0,
                TabletsQuantity = 0,
                DigitalMarkersQuantity = 0,
                action = "create",
            };

            // Get the current set, and append the new record to it becuase IEnumerable does not have Add
            var dataSet = GetAllData();
            dataSet = dataSet.Append(data);

            SaveData(dataSet);

            return data;
        }

        /// <summary>
        /// Remove the item from the system
        /// </summary>
        /// <returns></returns>
        public ProductModel DeleteData(string id)
        {

            // Get the current set, and append the new record after removing the item to be deleted
            var dataSet = GetAllData();
            var data = dataSet.FirstOrDefault(m => m.Id.Equals(id));

            var newDataSet = GetAllData().Where(m => m.Id.Equals(id) == false);
            
            SaveData(newDataSet);

            return data;
        }

    }

}