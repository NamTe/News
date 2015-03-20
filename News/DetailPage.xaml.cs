using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace News {
    public partial class DetailPage : PhoneApplicationPage {
        private string link = "";
        public DetailPage() {
            InitializeComponent();
            ProgressBar.Visibility = System.Windows.Visibility.Visible;
            OverLay.Visibility = System.Windows.Visibility.Visible;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e) {
            base.OnNavigatedTo(e);
            ProgressBar.Visibility = System.Windows.Visibility.Visible;
            NavigationContext.QueryString.TryGetValue("link", out link);
            Wb.Source = new Uri(link);
            Wb.LoadCompleted += Wb_LoadCompleted;
        }

        void Wb_LoadCompleted(object sender, NavigationEventArgs e) {
            ProgressBar.Visibility = System.Windows.Visibility.Collapsed;
            OverLay.Visibility = System.Windows.Visibility.Collapsed;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e) {
            base.OnNavigatedFrom(e);
            ProgressBar.Visibility = System.Windows.Visibility.Collapsed;
            OverLay.Visibility = System.Windows.Visibility.Visible;
            Wb.NavigateToString("Hello");
        }
    }
}