using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoCrafts.WebSite.Models
{
    public enum ProductTypeEnum
    {
        Undefined = 0,
        Laptops = 1,
        Projectors = 2,
        Speakers = 3,
        SmartBoards = 4,
        Tablets = 5,
        DigitalMarkers = 6,
    }

    public static class ProductTypeEnumExtensions
    {
        public static string DisplayName(this ProductTypeEnum data)
        {
            return data switch
            {
                ProductTypeEnum.Laptops => "Electronic Items",
                ProductTypeEnum.Projectors => "Electronic Items",
                ProductTypeEnum.Speakers => "Electronic Items",
                ProductTypeEnum.SmartBoards => "Electronic Items",
                ProductTypeEnum.Tablets => "Electronic Items",
                ProductTypeEnum.DigitalMarkers => "Electronic Items",

                // Default, Unknown
                _ => "",
            };
        }
    }
}