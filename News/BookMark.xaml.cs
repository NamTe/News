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
using Microsoft.Phone.Tasks;
using System.Collections.ObjectModel;


namespace News {
    public partial class BookMark : PhoneApplicationPage {
        public BookMarkModel BookMarkList = new BookMarkModel();
        public BookMark() {
            InitializeComponent();
            BuildLocalizedApplicationBar();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e) {
            base.OnNavigatedTo(e);
            if (!BookMarkList.IsLoadData) {
                BookMarkList.LoadData();
                BookMarkView.ItemsSource = BookMarkList.bookMarkList;
            }
            if (BookMarkList.bookMarkList.Count == 0) {
                OverLay.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void OnItemTap(object sender, System.Windows.Input.GestureEventArgs e) {
            NewsItem SelectedItem = ((FrameworkElement)sender).DataContext as NewsItem;
            if (SelectedItem != null) {
                NavigationService.Navigate(new Uri("/DetailPage.xaml?link=" + SelectedItem.link, UriKind.RelativeOrAbsolute));
            }
        }

        private void BuildLocalizedApplicationBar() {
            ApplicationBar = new ApplicationBar();
            ApplicationBar.Mode = ApplicationBarMode.Minimized;
            ApplicationBarMenuItem menu = new ApplicationBarMenuItem("About");
            menu.Click += menu_Click;
            ApplicationBar.MenuItems.Add(menu);
        }

        private void menu_Click(object sender, EventArgs e) {
            NavigationService.Navigate(new Uri("/AboutPage.xaml", UriKind.Relative));
        }

        private void delete() {
            ObservableCollection<NewsItem> delete = new ObservableCollection<NewsItem>();
            if (BookMarkView.SelectedItems.Count > 0) {
                foreach (NewsItem item in BookMarkView.SelectedItems) {
                    if (BookMarkList.bookMarkList.Contains(item)) {
                        delete.Add(item);
                    }
                }
                foreach (var item in delete) {
                    BookMarkList.bookMarkList.Remove(item);
                }
                Helper.DeleteItem(BookMarkList.bookMarkList);
            }
        }

        private void OnSelectionEnableChanged(object sender, DependencyPropertyChangedEventArgs e) {
            ApplicationBar = new ApplicationBar();
            ApplicationBar.Mode = ApplicationBarMode.Minimized;
            if (((LongListMultiSelector)sender).SelectedItems.Count != 0) {
                ApplicationBar.Mode = ApplicationBarMode.Default;
                ApplicationBarIconButton appbarShare = new ApplicationBarIconButton(new Uri("/Assets/share.png", UriKind.Relative));
                appbarShare.Text = "Share";
                ApplicationBar.Buttons.Add(appbarShare);
                appbarShare.Click += appbarShare_Click;
                ApplicationBarIconButton appbarDeleteBookMark = new ApplicationBarIconButton(new Uri("/Toolkit.Content/ApplicationBar.Delete.png", UriKind.Relative));
                appbarDeleteBookMark.Text = "Delete";
                ApplicationBar.Buttons.Add(appbarDeleteBookMark);
                appbarDeleteBookMark.Click += appbarDeleteBookMark_Click;
            }
            ApplicationBarMenuItem menu = new ApplicationBarMenuItem("About");
            menu.Click += menu_Click;
            ApplicationBar.MenuItems.Add(menu);
        }

        private void appbarDeleteBookMark_Click(object sender, EventArgs e) {
            delete();
            if (BookMarkList.bookMarkList.Count == 0) {
                OverLay.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void appbarShare_Click(object sender, EventArgs e) {
            EmailComposeTask emailComposeTask = new EmailComposeTask();
            emailComposeTask.Subject = "Let read these aticles together";
            foreach (object obj in BookMarkView.SelectedItems) {
                NewsItem item = obj as NewsItem;
                if (item != null)
                    emailComposeTask.Body += item.ToString();
            }
            emailComposeTask.Show();
        }
    }
}