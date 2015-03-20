using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using News.Resources;
using Microsoft.Phone.Net.NetworkInformation;
using Coding4Fun.Toolkit;
using Coding4Fun.Toolkit.Controls;
namespace News {
    public partial class MainPage : PhoneApplicationPage {
        // Constructor
        public MainPage() {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            BuildLocalizedApplicationBar();
        }

        private void On24hClik(object sender, System.Windows.Input.GestureEventArgs e) {
            Progressbar.Visibility = System.Windows.Visibility.Visible;
            if (checkNetworkConnection()) {
                Progressbar.Visibility = System.Windows.Visibility.Collapsed;
                NavigationService.Navigate(new Uri("/page24h.xaml", UriKind.RelativeOrAbsolute));
            }
            else {
                MessageBox.Show("Network not available");
            }
            Progressbar.Visibility = System.Windows.Visibility.Collapsed;
        }


        private void BuildLocalizedApplicationBar() {
            ApplicationBar = new ApplicationBar();
            ApplicationBar.Mode = ApplicationBarMode.Minimized;
            ApplicationBarMenuItem menu = new ApplicationBarMenuItem("About");
            menu.Click += menu_Click;
            ApplicationBar.MenuItems.Add(menu);
        }

        private void menu_Click(object sender, EventArgs e) {
            AboutPrompt aboutMe = new AboutPrompt();
            aboutMe.Title = "About";
            aboutMe.Show("NamTe", "@Tintac_Tk3", "tintac_tk3@yahoo.com", null);
        }


        private void OnVnExpressClick(object sender, System.Windows.Input.GestureEventArgs e) {
            Progressbar.Visibility = System.Windows.Visibility.Visible;
            if (checkNetworkConnection()) {
                Progressbar.Visibility = System.Windows.Visibility.Collapsed;
                NavigationService.Navigate(new Uri("/Vnexpress.xaml", UriKind.RelativeOrAbsolute));
            }
            else {
                MessageBox.Show("Network not available");
            }
            Progressbar.Visibility = System.Windows.Visibility.Collapsed;
        }

        public static bool checkNetworkConnection() {
            var ni = NetworkInterface.NetworkInterfaceType;

            bool IsConnected = false;
            if ((ni == NetworkInterfaceType.Wireless80211) || (ni == NetworkInterfaceType.MobileBroadbandCdma) || (ni == NetworkInterfaceType.MobileBroadbandGsm))
                IsConnected = true;
            else if (ni == NetworkInterfaceType.None)
                IsConnected = false;
            return IsConnected;
        }

        private void OnBookMarkClick(object sender, System.Windows.Input.GestureEventArgs e) {
            NavigationService.Navigate(new Uri("/BookMark.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}