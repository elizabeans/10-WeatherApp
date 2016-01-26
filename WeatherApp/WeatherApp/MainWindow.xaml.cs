using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WeatherApp.Core;


namespace WeatherApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            var result = WeatherService.GetWeatherFor(searchBox.Text);

            weather.Content = result.weather;
            elevation.Content = result.elevation;
            latLong.Content = result.latitude + " / " + result.longitude;
            update.Content = result.observation_time;
            humidity.Content = result.relative_humidity;
            feelsLike.Content = result.feelslike_string;
            visibility.Content = result.visibility_mi;
            wind.Content = result.wind_string;
            windDirection.Content = result.wind_dir;
            uv.Content = result.uv;
            precipitation.Content = result.precip_today_in;
            temperature.Content = result.temp_f + "F ( " + result.temp_c + "C )";
            locationLabel.Content = result.display_location;

            if (!File.Exists(result.icon))
            {
                using (var webClient = new WebClient())
                {
                    byte[] bytes = webClient.DownloadData(result.icon_url);

                    File.WriteAllBytes(result.icon + ".gif", bytes);
                }
            }

            BitmapImage src = new BitmapImage();
            src.BeginInit();
            src.UriSource = new Uri(result.icon + ".gif", UriKind.Relative);
            src.EndInit();
            imageIcon.Source = src;
        }
    }
}
