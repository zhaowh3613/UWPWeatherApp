using GalaSoft.MvvmLight;
using MvvmSampleWeatherApp.Model;
using System;
using System.Collections.Generic;
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


        public MainViewModel()
        {
            InitData();
        }

        public async Task InitData()
        {
           var collection = await WeatherApiBase.Current.GetWeatherCollection();
            if (collection != null)
            {
                Now = collection.results.FirstOrDefault().now;
            }
        }

    }
}
