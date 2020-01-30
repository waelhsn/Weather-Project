using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using WeatherProject;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Weather_Project
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            ApplicationView appView = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView();
            appView.Title = "Gothenburg Weather";
            DegreeGetter();
            FeelsLike();
            CityName();
            MaxCelsius();
            MinCelsius();
            ShowWind();
            GetDescription();
        }
        private async void CityName()
        {
            RootObject gotWeather = await GothenburgWeather.GetWeather();
            cityResult.Text = gotWeather.name;
        }
        private async void DegreeGetter()
        {
            RootObject gotWeather = await GothenburgWeather.GetWeather();
            string icon = String.Format("ms-appx:///Assets/Weather/{0}.png", gotWeather.weather[0].icon);
            ResultImage.Source = new Windows.UI.Xaml.Media.Imaging.BitmapImage(new Uri(icon, UriKind.Absolute));
            celsius.Text = ((int)gotWeather.main.temp).ToString() + "°";
        }
        private async void GetDescription()
        {
            RootObject gotWeather = await GothenburgWeather.GetWeather();
            textDescription.Text = gotWeather.weather[0].description[0].ToString().ToUpper() +
              gotWeather.weather[0].description.Substring(1);
        }
        private async void FeelsLike()
        {
            RootObject gotWeather =
                await GothenburgWeather.GetWeather();
            TextFeelsLike.Text = "Känns: " + ((int)gotWeather.main.feels_like).ToString() + "°";
        }
        private async void MaxCelsius()
        {
            RootObject gotWeather = await GothenburgWeather.GetWeather();
            Max_Celsius.Text = "Max: " + ((int)gotWeather.main.temp_max).ToString() + "°";
        }
        private async void MinCelsius()
        {
            RootObject gotWeather = await GothenburgWeather.GetWeather();
            Min_Celsius.Text = "Min: " + ((int)gotWeather.main.temp_min).ToString() + "°";
        }
        private async void ShowWind()
        {
            RootObject gotWeather = await GothenburgWeather.GetWeather();
            WindSpeedText.Text = "Vind: " + ((int)gotWeather.wind.speed).ToString() + " m/s";
        }
    }


}


