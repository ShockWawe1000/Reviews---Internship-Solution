using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using static Reviews.reviewsjson;


namespace Reviews
{
  
    public partial class MainWindow : Window
    {
        List<reviewsjson> reviews = new List<reviewsjson>();

        public MainWindow()
        {
            InitializeComponent();
            try
            {

              misc misc = new misc();
                List <reviewsjson> reviews = misc.getReviews();

                DataGridReviews.ItemsSource = reviews;

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }


        }

       
        private void SearchButton_Click(object sender, RoutedEventArgs e) 
        {
            int rating = select_order_rating_prioritise.SelectedIndex;
            int min_rating = select_minimum_rating_prioritise.SelectedIndex;
            int date = select_date_prioritise.SelectedIndex;
            int text = select_txt_prioritise.SelectedIndex;
           
          // MessageBox.Show($"{rating} {min_rating} {date}  {text}   ");
           
            misc misc = new misc();
            List<reviewsjson> reviews = misc.getReviews();
            List<reviewsjson> SortedList = reviews;

            //text yes
            if (rating == 0 && date == 0 && text== 0)
            {
                SortedList.Sort((x, y) => {

                    var ret = y.ReviewFullText.Length.CompareTo(x.ReviewFullText.Length);
                     if (ret == 0) ret = y.Rating.CompareTo(x.Rating);
                    if (ret == 0) ret = y.ReviewCreatedOnDate.CompareTo(x.ReviewCreatedOnDate);
                   
                    return ret;
                });
            }
            else if (rating == 1 && date == 1 && text == 0)
            {
                SortedList.Sort((x, y) => {
                    var ret = y.ReviewFullText.Length.CompareTo(x.ReviewFullText.Length);
                     if (ret == 0) ret = x.Rating.CompareTo(y.Rating);
                    if (ret == 0) ret = x.ReviewCreatedOnDate.CompareTo(y.ReviewCreatedOnDate);
                    
                    return ret;
                });
            }
            if (rating == 0 && date == 1 && text == 0)
            {
                SortedList.Sort((x, y) => {
                    var ret = y.ReviewFullText.Length.CompareTo(x.ReviewFullText.Length);
                     if (ret == 0) ret = y.Rating.CompareTo(x.Rating);
                    if (ret == 0) ret = x.ReviewCreatedOnDate.CompareTo(y.ReviewCreatedOnDate);
                   
                    return ret;
                });
            }
            else if (rating == 1 && date == 0 && text == 0)
            {
                SortedList.Sort((x, y) => {
                    var ret = y.ReviewFullText.Length.CompareTo(x.ReviewFullText.Length);
                    if (ret == 0) ret = x.Rating.CompareTo(y.Rating);
                    if (ret == 0) ret = y.ReviewCreatedOnDate.CompareTo(x.ReviewCreatedOnDate);
                    
                    return ret;
                });
            }

            //text no
            else if (rating == 0 && date == 0 && text == 1)
            {
                SortedList.Sort((x, y) => {
                    var ret = y.Rating.CompareTo(x.Rating);
                    if (ret == 0) ret = y.ReviewCreatedOnDate.CompareTo(x.ReviewCreatedOnDate);
                    
                    return ret;
                });
            }
          
          
            else if (rating == 1 && date == 0 && text == 1)
            {
                SortedList.Sort((x, y) => {
                    var ret = x.Rating.CompareTo(y.Rating);
                    if (ret == 0) ret = y.ReviewCreatedOnDate.CompareTo(x.ReviewCreatedOnDate);
                    
                    return ret;
                });
            }

           
            else if (rating == 0 && date == 1 && text == 1)
            {
                SortedList.Sort((x, y) => {
                    var ret = y.Rating.CompareTo(x.Rating);
                    if (ret == 0) ret = x.ReviewCreatedOnDate.CompareTo(y.ReviewCreatedOnDate);

                    return ret;
                });
            }


            
            else if (rating == 1 && date == 1 && text == 1)
            {
                SortedList.Sort((x, y) => {
                    var ret = x.Rating.CompareTo(y.Rating);
                    if (ret == 0) ret = x.ReviewCreatedOnDate.CompareTo(y.ReviewCreatedOnDate);

                    return ret;
                });
            }


            switch (min_rating)
                {
                case 4:
                    for (int i = SortedList.Count - 1; i >= 0; i--)
                    {
                        if (SortedList[i].Rating == 2)
                        {
                            SortedList.RemoveAt(i);
                        }
                    }
                    goto case 3;
                case 3:
                    for (int i = SortedList.Count - 1; i >= 0; i--)
                    {
                        if (SortedList[i].Rating == 3)
                        {
                            SortedList.RemoveAt(i);
                        }
                    }
                    goto case 2;
                case 2:
                    for (int i = SortedList.Count - 1; i >= 0; i--)
                    {
                        if (SortedList[i].Rating == 4)
                        {
                            SortedList.RemoveAt(i);
                        }
                    }
                    goto case 1;
                case 1:
                    for (int i = SortedList.Count - 1; i >= 0; i--)
                    {
                        if (SortedList[i].Rating == 5)
                        {
                            SortedList.RemoveAt(i);
                        }
                    }
                    goto case 0;
                case 0:
                    break;
                default:
                    break;

            }
                
            DataGridReviews.ItemsSource = SortedList;
            
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string filePath;
                if ( txt_json_filepath.Text==string.Empty )
                {
                    filePath = @"reviews.json";
                }
                else
                {
                     filePath = txt_json_filepath.Text;
                }
                
                string jsonData = File.ReadAllText(filePath);

                List<reviewsjson> reviews = Newtonsoft.Json.JsonConvert.DeserializeObject<List<reviewsjson>>(jsonData);

                List<reviewsjson> list_review = new List<reviewsjson>();

                DataGridReviews.ItemsSource = reviews;
                misc misc = new misc();
                misc.setReviews(reviews);


            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
       


    }
}
