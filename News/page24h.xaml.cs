using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using News.Model.News24h;
using News.Model;
namespace News {
    public partial class page24h : PhoneApplicationPage {
        private Model24hList Index24h;
        private Model24hList Soccer24h;
        public page24h() {
            InitializeComponent();
            Index24h = new Model24hList();
            Soccer24h  = new Model24hList();
            IndexView24h.ItemsSource = Index24h;
            SoccerView24h.ItemsSource = Soccer24h;
        }

        private void NewsItemList_IsSelectionEnable(object sender, DependencyPropertyChangedEventArgs e) {

        }

        private void OnItemTap(object sender, System.Windows.Input.GestureEventArgs e) {
            NewsItem SelectedItem = ((FrameworkElement)sender).DataContext as NewsItem;
            if (SelectedItem != null) {
                NavigationService.Navigate(new Uri("/DetailPage.xaml?link=" + SelectedItem.link, UriKind.RelativeOrAbsolute));
            }
        }

        private void PivotSelectionChanged(object sender, SelectionChangedEventArgs e) {
            Pivot pivot = sender as Pivot;

            if (pivot == null) {
                return;
            }

            switch (pivot.SelectedIndex) {
                case 0: {
                        if (!Index24h.IsDataLoad) {
                            Index24h.LoadData(Helper.Index24h);
                        }
                        break;
                    }
                case 1: {
                        if (!Soccer24h.IsDataLoad) {
                            Soccer24h.LoadData(Helper.Soccer24h);
                        }
                        break;
                    }
                case 2: {

                        break;
                    }
            }
        }
    }
}