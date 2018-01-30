using MvvmSampleWeatherApp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MvvmSampleWeatherApp.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            var imageBrush = new ImageBrush();
            imageBrush.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/BGa1920x1080.jpg", UriKind.Absolute));
            MainGrid.Background = imageBrush;
        }

        private const string TOKENKEY = "hwgl4pd1vl4qrkka";
        private const string UID = "UE5A5FDF53";
        private string NowUrl = $"https://api.seniverse.com/v3/weather/now.json?key={TOKENKEY}&location=beijing&language=zh-Hans&unit=c";
        private string DailyUrl = $" https://api.seniverse.com/v3/weather/daily.json?key={TOKENKEY}&location=beijing&language=zh-Hans&unit=c&start=0&days=5";

        public async Task<string> SendHttpRequest(string url)
        {
            try
            {
                var uri = new Uri(DailyUrl);
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(UID, TOKENKEY);
                var respStr = await client.GetStringAsync(uri);
                var jsonObject = JsonConvert.DeserializeObject<WeatherCollection>(respStr);

                return respStr;
            }
            catch (Exception ex)
            {
                return "";
            }
           
        }
    }
}