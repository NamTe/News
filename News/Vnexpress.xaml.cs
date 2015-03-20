using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using News.Model;
using System.Collections.ObjectModel;
using Microsoft.Phone.Tasks;
using System.Windows.Media.Imaging;

namespace News {
    public partial class Vnexpress : PhoneApplicationPage {
        private VnExpressList VnExpressIndex;
        private VnExpressList VnExpressCurrent;
        private VnExpressList VnExpressWorld;
        private LongListMultiSelector SelectedList;
        public Vnexpress() {
            InitializeComponent();
            VnExpressIndex = new VnExpressList();
            VnExpressCurrent = new VnExpressList();
            VnExpressWorld = new VnExpressList();
            VnexpressViewIndex.ItemsSource = VnExpressIndex;
            VnexpressViewCurrent.ItemsSource = VnExpressCurrent;
            VnexpressViewWorld.ItemsSource = VnExpressWorld;
            BuildLocalizedApplicationBar();
        }

        private void BuildLocalizedApplicationBar() {
            ApplicationBar = new ApplicationBar();
            ApplicationBar.Mode = ApplicationBarMode.Minimized;
            ApplicationBarMenuItem menu = new ApplicationBarMenuItem("About");
            menu.Click += menu_Click;
            ApplicationBar.MenuItems.Add(menu);
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

        protected override void OnNavigatedTo(NavigationEventArgs e) {
            base.OnNavigatedTo(e);

        }

        private void pivotSelectionChange(object sender, SelectionChangedEventArgs e) {
            Pivot pivot = sender as Pivot;

            if (pivot == null) {
                return;
            }

            switch (pivot.SelectedIndex) {
                case 0: {
                        if (!VnExpressIndex.IsDataLoad) {
                            VnExpressIndex.LoadData(Helper.VnExpressIndex);
                            SelectedList = VnexpressViewIndex;
                        }
                        break;
                    }
                case 1: {
                        if (!VnExpressCurrent.IsDataLoad) {
                            VnExpressCurrent.LoadData(Helper.VnExpressCurrent);
                            SelectedList = VnexpressViewCurrent;
                        }
                        break;
                    }
                case 2: {
                        if (!VnExpressWorld.IsDataLoad) {
                            VnExpressWorld.LoadData(Helper.VnExpressWorld);
                            SelectedList = VnexpressViewWorld;
                        }
                        break;
                    }
            }
        }

        private void OnItemTap(object sender, System.Windows.Input.GestureEventArgs e) {
            NewsItem SelectedNewItem = ((FrameworkElement)sender).DataContext as NewsItem;
            if (SelectedNewItem != null)
                NavigationService.Navigate(new Uri("/DetailPage.xaml?link=" + SelectedNewItem.link, UriKind.RelativeOrAbsolute));
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

        private void OnImageFailed(object sender, ExceptionRoutedEventArgs e) {
            ((Image)sender).Source = new BitmapImage(new Uri("/Assets/News.png", UriKind.Relative));
        }

    }
}