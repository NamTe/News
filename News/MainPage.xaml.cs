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

namespace News {
    public partial class MainPage : PhoneApplicationPage {
        // Constructor
        public MainPage() {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void On24hClik(object sender, System.Windows.Input.GestureEventArgs e) {
            if (checkNetworkConnection()) {
                NavigationService.Navigate(new Uri("/page24h.xaml", UriKind.RelativeOrAbsolute));
            }
            else {
                MessageBox.Show("Network not available");
            }
        }

        private void OnVnExpressClick(object sender, System.Windows.Input.GestureEventArgs e) {
            if (checkNetworkConnection()) {
                NavigationService.Navigate(new Uri("/Vnexpress.xaml", UriKind.RelativeOrAbsolute));
            }
            else {
                MessageBox.Show("Network not available");
            }
            
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
    }
}