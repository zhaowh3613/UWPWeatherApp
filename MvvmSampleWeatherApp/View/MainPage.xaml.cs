﻿using GalaSoft.MvvmLight.Messaging;
using MvvmSampleWeatherApp.Model;
using MvvmSampleWeatherApp.ViewModel;
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
        MainViewModel vm = ViewModelLocator.Instance.Main;
        public MainPage()
        {
            this.InitializeComponent();
            //var imageBrush = new ImageBrush();
            //imageBrush.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/BGa1920x1080.jpg", UriKind.Absolute));
            //MainGrid.Background = imageBrush;
            Messenger.Default.Register<bool>(this, "ProgressState", UpdateProgressState);
        }

        private void TextBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                vm.Search();
            }
        }

        private void UpdateProgressState(bool state)
        {
            this.ProgressRing.IsActive = state;
        }
    }
}