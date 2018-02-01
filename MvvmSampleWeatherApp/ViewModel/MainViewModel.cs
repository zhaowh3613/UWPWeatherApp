using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MvvmSampleWeatherApp.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace MvvmSampleWeatherApp.ViewModel
{
    public class MainViewModel:ViewModelBase
    {
        private WeatherCollection mWeatherCollection;

        public WeatherCollection WeatherCollection
        {
            get { return mWeatherCollection; }
            set
            {
                mWeatherCollection = value;
                RaisePropertyChanged(() => WeatherCollection);
            }
        }

        private ImageBrush mBGImage = new ImageBrush();

        public ImageBrush BGImage
        {
            get
            {
                return mBGImage;
            }
            set
            {
                mBGImage = value;
                RaisePropertyChanged(() => BGImage);
            }
        }

        private Uri mIcon;

        public Uri Icon
        {
            get
            {
                return mIcon;
            }
            set
            {
                mIcon = value;
                RaisePropertyChanged(() => Icon);
            }
        }

        private Now mNow;

        public Now Now
        {
            get { return mNow; }
            set
            {
                mNow = value;
                RaisePropertyChanged(() => Now);
            }
        }

        private Suggestion mSuggestion;

        public Suggestion Suggestion
        {
            get { return mSuggestion; }
            set
            {
                mSuggestion = value;
                RaisePropertyChanged(() => Suggestion);
            }
        }


        private Location mLocation;

        public Location Location
        {
            get { return mLocation; }
            set
            {
                mLocation = value;
                RaisePropertyChanged(() => Location);
            }
        }

        private String mLastUpdateTime;

        public String LastUpdateTime
        {
            get { return mLastUpdateTime; }
            set
            {
                mLastUpdateTime = value;
                RaisePropertyChanged(() => LastUpdateTime);
            }
        }

        private String mSearchText = "beijing";

        public String SearchText
        {
            get { return mSearchText; }
            set
            {
                mSearchText = value;
            }
        }

        private RelayCommand mSearchCommand;

        public RelayCommand SearchCommand
        {
            get { return mSearchCommand ?? (mSearchCommand = new RelayCommand(Search, CanSearchExcute)); }
        }


        public MainViewModel()
        {
            InitData();
        }

        public void InitData()
        {
            try
            {
                Search();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"InitData Error: {ex.Message}");
            }
         
        }
        public void Search()
        {
            if (string.IsNullOrWhiteSpace(mSearchText))
            {
                return;
            }
            UpdateWeatherNow();
            UpdateWeatherSuggestion();
        }

        public async void UpdateWeatherNow()
        {
            try
            {
                var collection = await WeatherApiBase.Instance.GetWeatherNow(mSearchText);
                if (collection != null)
                {
                    Now = collection.results?.FirstOrDefault().Now;
                    UpdateSharedInfo(collection);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"UpdateWeatherNow Error: {ex.Message}");
            }
        }

        public async void UpdateWeatherSuggestion()
        {
            try
            {
                var collection = await WeatherApiBase.Instance.GetWeatherSuggestion(mSearchText);
                if (collection != null)
                {
                    Suggestion = collection.results?.FirstOrDefault().Suggestion;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"UpdateWeatherNow Error: {ex.Message}");
            }
        }
     
        private void UpdateSharedInfo(WeatherCollection collection)
        {
            if (collection == null && collection.results == null)
            {
                return;
            }
            try
            {
                string code = collection.results.FirstOrDefault().Now?.Code;
                Location = collection.results?.FirstOrDefault().Location;
                var lastUpdate = DateTime.Now;
                DateTime.TryParse(collection.results?.FirstOrDefault().LastUpdate, out lastUpdate);
                LastUpdateTime = lastUpdate.ToString("hh:mm");
                BGImage.ImageSource = GetBGImage(code);
                Icon = GetIcon(code);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"UpdateSharedInfo Error:{ex.Message}");
            }
            
        }

        private bool CanSearchExcute()
        {
            if (String.IsNullOrWhiteSpace(mSearchText))
            {
                return false;
            }
            return true;
        }

        private BitmapImage GetBGImage(string conditionCode = "0")
        {
            
            switch (conditionCode)
            {
                //sunny
                case "0":
                case "1":
                case "2":
                case "3":
                    return new BitmapImage(new Uri("ms-appx:///Assets/BGa1920x1080.jpg", UriKind.Absolute));
                //cloudy
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                    return new BitmapImage(new Uri("ms-appx:///Assets/BG_cloudy2.jpg", UriKind.Absolute));
                //overcast
                case "9":
                    return new BitmapImage(new Uri("ms-appx:///Assets/BG_overcast.jpg", UriKind.Absolute));
                //rain
                case "10":
                case "11":
                case "12":
                case "13":
                case "14":
                case "15":
                case "16":
                case "17":
                case "18":
                case "19":
                    return new BitmapImage(new Uri("ms-appx:///Assets/BG_rain2.jpg", UriKind.Absolute));
                //snow
                case "20":
                case "21":
                case "22":
                case "23":
                case "24":
                case "25":
                    return new BitmapImage(new Uri("ms-appx:///Assets/BG_snow.jpg", UriKind.Absolute));
                case "30":
                case "31":
                    return new BitmapImage(new Uri("ms-appx:///Assets/BG_foggy.jpg", UriKind.Absolute));
                case "32":
                case "33":
                case "34":
                case "35":
                case "36":
                    return new BitmapImage(new Uri("ms-appx:///Assets/BG_windy.jpg", UriKind.Absolute));
                    //cold
                case "37":
                    return new BitmapImage(new Uri("ms-appx:///Assets/BG_snow.jpg", UriKind.Absolute));
                case "38":
                    return new BitmapImage(new Uri("ms-appx:///Assets/BGa1920x1080.jpg", UriKind.Absolute));
                default:
                    return new BitmapImage(new Uri("ms-appx:///Assets/BGa1920x1080.jpg", UriKind.Absolute));
            }
        }

        private Uri GetIcon(string conditionCode= "0")
        {
            return new Uri($"ms-appx:///Assets/icon/{conditionCode}.png", UriKind.Absolute);
        }
    }
}
