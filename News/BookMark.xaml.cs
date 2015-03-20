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
using Coding4Fun.Toolkit.Controls;

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
    }
}