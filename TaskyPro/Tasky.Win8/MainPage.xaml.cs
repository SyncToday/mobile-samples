using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Tasky.BL;
using Tasky.BL.Managers;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Diagnostics;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace TaskyWin8
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            DataContext = new TaskListViewModel();

            GetLoginInformation();
            RemoteTaskManager.GetUsers(OnGetUsersCompleted);
        }

        public void OnGetUsersCompleted()
        {
            foreach (var userName in RemoteTaskManager.Users)
                OwnerComboBox.Items.Add(userName);

            OwnerComboBox.SelectedItem = RemoteTaskManager.UserName;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ((TaskListViewModel)DataContext).BeginUpdate();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var task = new Task();
            task.Name = "<new task>";
            task.Notes = "";
            TaskManager.SaveTask(task);
            ((TaskListViewModel)DataContext).BeginUpdate();
        }

        private void Task_Tap(object sender, TappedRoutedEventArgs e)
        {
            var lb = sender as ListBox;
            var tvm = lb.SelectedItem as TaskViewModel;
            ((TaskListViewModel)DataContext).PopulateTaskViewModel(tvm);
            OwnerComboBox.SelectedValue = string.IsNullOrWhiteSpace(tvm.Owner) ? RemoteTaskManager.UserName : tvm.Owner;
        }

        private void Save_Tap(object sender, TappedRoutedEventArgs e)
        {
            var t = ((TaskListViewModel)DataContext).GetTask();
            if (t != null) {
                t.Owner = OwnerComboBox.SelectedValue.ToString();
                TaskManager.SaveTask(t);
                ((TaskListViewModel)DataContext).BeginUpdate();
            }
        }

        private void Delete_Tap(object sender, TappedRoutedEventArgs e)
        {
            var t = ((TaskListViewModel)DataContext).GetTask();
            if (t != null)
            {
                TaskManager.DeleteTask(t.ID);
                ((TaskListViewModel)DataContext).BeginUpdate();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ((TaskListViewModel)DataContext).BeginUpdate();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var t = ((TaskListViewModel)DataContext).GetTask();
            if (t != null && OwnerComboBox.SelectedValue != null)
            {
                t.Owner = OwnerComboBox.SelectedValue.ToString();
                TaskManager.SaveTask(t);
                ((TaskListViewModel)DataContext).BeginUpdate();
            }
        }

        // http://msdn.microsoft.com/en-us/library/windows/apps/br241801.aspx?cs-save-lang=1&cs-lang=csharp#code-snippet-3
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // The URI to launch
            string uriToLaunch = @"http://sync.today";

            // Create a Uri object from a URI string 
            var uri = new Uri(uriToLaunch);

           // Launch the URI
            Windows.System.Launcher.LaunchUriAsync(uri);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            // The URI to launch
            string uriToLaunch = @"http://wsdl.sync.today/register";

            // Create a Uri object from a URI string 
            var uri = new Uri(uriToLaunch);

            // Launch the URI
            Windows.System.Launcher.LaunchUriAsync(uri);
        }

        private async void Button_Click_3(object sender, RoutedEventArgs e)
        {
            RemoteTaskManager.UserName = UserNameText.Text;
            RemoteTaskManager.Password = PasswordText.Password;

            var vault = new Windows.Security.Credentials.PasswordVault();
            vault.Add(new Windows.Security.Credentials.PasswordCredential(
                resourceName, RemoteTaskManager.UserName, RemoteTaskManager.Password));

            await RemoteTaskManager.Login();
            ((TaskListViewModel)DataContext).BeginUpdate();
        }

        // http://msdn.microsoft.com/en-us/library/windows/apps/xaml/hh465069.aspx
        private string resourceName = "TaskyPro/Windows 8 for Sync.Today Demo";

        private void GetLoginInformation()
        {
            var loginCredential = GetCredentialFromLocker();

            if (loginCredential != null)
            {
                // There is a credential stored in the locker.
                // Populate the Password property of the credential
                // for automatic login.
                loginCredential.RetrievePassword();
            }

            if (loginCredential != null)
            {
                // Log the user in.
                RemoteTaskManager.UserName = loginCredential.UserName;
                RemoteTaskManager.Password = loginCredential.Password;
                UserNameText.Text = loginCredential.UserName;
                PasswordText.Password = loginCredential.Password;
            }
        }

        private Windows.Security.Credentials.PasswordCredential GetCredentialFromLocker()
        {
            try
            {
                Windows.Security.Credentials.PasswordCredential credential = null;

                var vault = new Windows.Security.Credentials.PasswordVault();
                var credentialList = vault.FindAllByResource(resourceName);
                if (credentialList.Count > 0)
                {
                    if (credentialList.Count == 1)
                    {
                        credential = credentialList[0];
                    }
                }

                return credential;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            var vault = new Windows.Security.Credentials.PasswordVault();
            vault.Remove(new Windows.Security.Credentials.PasswordCredential(
                resourceName, RemoteTaskManager.UserName, RemoteTaskManager.Password));
        }
    }
}
