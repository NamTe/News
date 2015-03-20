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
using System.Collections.ObjectModel;
using Microsoft.Phone.Tasks;
using System.Windows.Media.Imaging;
namespace News {
    public partial class page24h : PhoneApplicationPage {
        private Model24hList Index24h;
        private Model24hList Soccer24h;
        private LongListMultiSelector SelectedList;
        public page24h() {
            InitializeComponent();
            Index24h = new Model24hList();
            Soccer24h  = new Model24hList();
            IndexView24h.ItemsSource = Index24h;
            SoccerView24h.ItemsSource = Soccer24h;
            BuildLocalizedApplicationBar();
        }

        private void appbarBookMark_Click(object sender, EventArgs e) {
            ObservableCollection<NewsItem> bookMarkList = new ObservableCollection<NewsItem>();
            foreach (object obj in SelectedList.SelectedItems) {
                NewsItem item = obj as NewsItem;
                if (item != null)
                    bookMarkList.Add(item);
            }

            Helper.SaveList(bookMarkList);
            MessageBox.Show("Saved");
        }

        private void BuildLocalizedApplicationBar() {
            ApplicationBar = new ApplicationBar();
            ApplicationBar.Mode = ApplicationBarMode.Minimized;
            ApplicationBarMenuItem menu = new ApplicationBarMenuItem("About");
            menu.Click += menu_Click;
            ApplicationBar.MenuItems.Add(menu);
        }

        private void NewsItemList_IsSelectionEnable(object sender, DependencyPropertyChangedEventArgs e) {
            ApplicationBar = new ApplicationBar();
            ApplicationBar.Mode = ApplicationBarMode.Minimized;
            if (((LongListMultiSelector)sender).SelectedItems.Count != 0) {
                ApplicationBar.Mode = ApplicationBarMode.Default;
                ApplicationBarIconButton appbarShare = new ApplicationBarIconButton(new Uri("/Assets/share.png", UriKind.Relative));
                appbarShare.Text = "Share";
                ApplicationBar.Buttons.Add(appbarShare);
                appbarShare.Click += appbarShare_Click;
                ApplicationBarIconButton appbarBookMark = new ApplicationBarIconButton(new Uri("/Assets/Bookmark-Up.png", UriKind.Relative));
                appbarBookMark.Text = "Book Mark";
                ApplicationBar.Buttons.Add(appbarBookMark);
                appbarBookMark.Click += appbarBookMark_Click;
            }
            ApplicationBarMenuItem menu = new ApplicationBarMenuItem("About");
            menu.Click += menu_Click;
            ApplicationBar.MenuItems.Add(menu);
        }

        private void menu_Click(object sender, EventArgs e) {
            NavigationService.Navigate(new Uri("/AboutPage.xaml", UriKind.Relative));
        }


        private void appbarShare_Click(object sender, EventArgs e) {
            EmailComposeTask emailComposeTask = new EmailComposeTask();
            emailComposeTask.Subject = "Let read these aticles together";
            foreach (object obj in SelectedList.SelectedItems) {
                NewsItem item = obj as NewsItem;
                if (item != null)
                    emailComposeTask.Body += item.ToString();
            }
            emailComposeTask.Show();
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
                            SelectedList = IndexView24h;
                        }
                        break;
                    }
                case 1: {
                        if (!Soccer24h.IsDataLoad) {
                            Soccer24h.LoadData(Helper.Soccer24h);
                            SelectedList = SoccerView24h;
                        }
                        break;
                    }
                case 2: {

                        break;
                    }
            }
        }

        private void OnImageFailed(object sender, ExceptionRoutedEventArgs e) {
            ((Image)sender).Source = new BitmapImage(new Uri("/Assets/News.png", UriKind.Relative));
        }
    }
}