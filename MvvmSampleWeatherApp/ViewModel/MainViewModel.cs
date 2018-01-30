using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MvvmSampleWeatherApp.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private String mSearchText = "shanghai";

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

        public async Task InitData()
        {
            try
            {
                var collection = await WeatherApiBase.Instance.GetWeatherNow();
                if (collection != null)
                {
                    Now = collection.results?.FirstOrDefault().now;
                    Location = collection.results?.FirstOrDefault().location;
                    var lastUpdate = DateTime.Now;
                    DateTime.TryParse(collection.results?.FirstOrDefault().last_update, out lastUpdate);
                    LastUpdateTime = lastUpdate.ToString("hh:mm");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"InitData Error: {ex.Message}");
            }
         
        }

        public async void Search()
        {
            var collection = await WeatherApiBase.Instance.GetWeatherNow(SearchText);
            if (collection != null)
            {
                Now = collection.results?.FirstOrDefault().now;
                Location = collection.results?.FirstOrDefault().location;
                var lastUpdate = DateTime.Now;
                DateTime.TryParse(collection.results?.FirstOrDefault().last_update, out lastUpdate);
                LastUpdateTime = lastUpdate.ToString("hh:mm");
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
    }
}
