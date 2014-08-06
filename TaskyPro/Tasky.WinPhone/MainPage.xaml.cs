using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Tasky.BL.Managers;

namespace TaskyWinPhone {
    public partial class MainPage : PhoneApplicationPage {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            DataContext = new TaskListViewModel();
            Loaded += new RoutedEventHandler(MainPage_Loaded);

            ApplicationTitle.Text = RemoteTaskManager.GetApplicationName();
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            ((TaskListViewModel)DataContext).BeginUpdate(Dispatcher);

            ApplicationTitle.Text = RemoteTaskManager.GetApplicationName();
        }

        private void HandleAdd(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/TaskDetailsPage.xaml?id=-1", UriKind.RelativeOrAbsolute));
        }

        private void HandleRefresh(object sender, EventArgs e)
        {
            ((TaskListViewModel)DataContext).BeginUpdate(Dispatcher);
        }

        private void HandleSettings(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Settings.xaml", UriKind.RelativeOrAbsolute));
        }

        private void HandleTaskTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var item = ((Grid)sender).DataContext as TaskViewModel;

            if (item != null) {
                NavigationService.Navigate(new Uri("/TaskDetailsPage.xaml?id=" + item.ID, UriKind.RelativeOrAbsolute));
            }
        }
    }
}