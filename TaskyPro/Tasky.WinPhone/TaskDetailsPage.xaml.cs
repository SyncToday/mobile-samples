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
using Tasky.BL;

namespace TaskyWinPhone
{
    public partial class TaskDetailsPage : PhoneApplicationPage
    {

        public TaskDetailsPage()
        {
            InitializeComponent();
            RemoteTaskManager.GetUsers(LoadOwners);
        }

        private void SetDefaultOwner()
        {
            string val = string.IsNullOrEmpty((DataContext as TaskViewModel).Owner) ? RemoteTaskManager.loggedUser.Email : (DataContext as TaskViewModel).Owner;

            for (int i = 0; i < OwnerListPicker.Items.Count; i++)
            {
                if (OwnerListPicker.Items[i].Equals(val))
                {
                    OwnerListPicker.SelectedIndex = i;
                    return;
                }
            }
        }

        private void LoadOwners()
        {
            foreach (var user in RemoteTaskManager.Users)
            {
                OwnerListPicker.Items.Add(user);
            }
            SetDefaultOwner();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.NavigationMode == System.Windows.Navigation.NavigationMode.New)
            {
                var vm = new TaskViewModel();
                var task = default(Task);

                if (NavigationContext.QueryString.ContainsKey("id"))
                {
                    var id = int.Parse(NavigationContext.QueryString["id"]);
                    task = TaskManager.GetTask(id);
                }

                if (task != null)
                {
                    vm.Update(task);
                }

                DataContext = vm;
            }
        }

        private void HandleSave(object sender, EventArgs e)
        {
            var taskvm = (TaskViewModel)DataContext;
            var task = taskvm.GetTask();
            task.Owner = (string)OwnerListPicker.SelectedItem;
            TaskManager.SaveTask(task);

            NavigationService.GoBack();
        }

        private void HandleDelete(object sender, EventArgs e)
        {
            var taskvm = (TaskViewModel)DataContext;
            if (taskvm.ID >= 0)
                TaskManager.DeleteTask(taskvm.ID);

            NavigationService.GoBack();
        }

        private void ListPickerSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                var s = e.AddedItems[0];
            }
        }
    }
}