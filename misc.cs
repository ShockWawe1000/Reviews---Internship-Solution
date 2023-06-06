using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using static Reviews.reviewsjson;

namespace Reviews
{
    internal class misc
    {
        List<reviewsjson> reviews = new List<reviewsjson>();
        public List<reviewsjson> getReviews ()
        {
            string filePath = @"reviews.json";


            string jsonData = File.ReadAllText(filePath);

            reviews = Newtonsoft.Json.JsonConvert.DeserializeObject<List<reviewsjson>>(jsonData);
            return reviews;

        }

        public void setReviews(List<reviewsjson> set)
        {
            reviews = set;
        }
    }
}
