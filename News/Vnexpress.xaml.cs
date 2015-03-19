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

namespace News {
    public partial class Vnexpress : PhoneApplicationPage {
        private VnExpressList VnExpressIndex;
        private VnExpressList VnExpressCurrent;
        public Vnexpress() {
            InitializeComponent();
            VnExpressIndex = new VnExpressList();
            VnExpressCurrent = new VnExpressList();
            VnexpressViewIndex.ItemsSource = VnExpressIndex;
            VnexpressViewCurrent.ItemsSource = VnExpressCurrent;
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
                        }
                        break;
                    }
                case 1: {
                        if (!VnExpressCurrent.IsDataLoad) {
                            VnExpressCurrent.LoadData(Helper.VnExpressCurrent);
                        }
                        break;
                    }
            }
        }

        


    }
}