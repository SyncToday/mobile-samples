using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using Android.Graphics;
using Android.Views;

using Tasky.BL;
using Android.Util;
using Tasky.Droid.SyncTodayServiceReference;
using Tasky.BL.Managers;

namespace Tasky.Droid.Screens {
	//TODO: implement proper lifecycle methods
	[Activity (Label = "Task Details")]			
	public class TaskDetailsScreen : Activity {

		protected TaskDatabase wsdl;
		protected Task task = new Task();
		protected EditText notesTextEdit;
		protected EditText nameTextEdit;
		protected Spinner spinner;
		CheckBox doneCheckbox;
		private String[] array_spinner;
		private int spinnerPositionSelected;
		
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

            RequestWindowFeature(WindowFeatures.ActionBar);
            ActionBar.SetDisplayHomeAsUpEnabled(true);
            ActionBar.SetHomeButtonEnabled(true);
			
			int taskID = Intent.GetIntExtra("TaskID", 0);
			if(taskID > 0) {
				task = Tasky.BL.Managers.TaskManager.GetTask(taskID);
			}
			
			// set our layout to be the home screen
			SetContentView(Resource.Layout.TaskDetails);
			nameTextEdit = FindViewById<EditText>(Resource.Id.txtName);
			notesTextEdit = FindViewById<EditText>(Resource.Id.txtNotes);
			doneCheckbox = FindViewById<CheckBox>(Resource.Id.chkDone);
						
			// name
			if(nameTextEdit != null) { nameTextEdit.Text = task.Name; }
			
			// notes
			if(notesTextEdit != null) { notesTextEdit.Text = task.Notes; }
			
			if(doneCheckbox != null) { doneCheckbox.Checked = task.Done; }

			//setting spinner with users from Tasky.Core
			RemoteTaskManager.GetUsers(OnGetUsersCompleted);
		}

		public void OnGetUsersCompleted()
		{
			Toast.MakeText (this, string.Format("Logged user is '{0}'. Count of all users is '{1}'",Tasky.BL.Managers.RemoteTaskManager.UserName, Tasky.BL.Managers.RemoteTaskManager.Users.Length ), ToastLength.Long).Show ();

			var users = Tasky.BL.Managers.RemoteTaskManager.Users;
			List<string> items = new List<string> ();
			foreach (var item in users) {
				items.Add (item);
			}

			var adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, items);
			var spinner = FindViewById<Spinner>(Resource.Id.spinner);
			spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs> (spinner_ItemSelected);
			spinner.Adapter = adapter;

			spinner.SetSelection (GetPositionOfUsername(Tasky.BL.Managers.RemoteTaskManager.UserName, Tasky.BL.Managers.RemoteTaskManager.Users));
		}

		private int GetPositionOfUsername(string username, string[] users)
		{
			for (int i = 0; i < users.Length; i++) {
				if (username.Equals (users [i]))
					return i;
			}
			//select first position in spinner
			return 0;
		}
			
		private void spinner_ItemSelected (object sender, AdapterView.ItemSelectedEventArgs e)
		{
			Spinner spinner = (Spinner)sender;
			//Merchant merch = (Merchant)spinner.SelectedItem;
			spinnerPositionSelected = e.Position;
			string toast = string.Format ("Selected text is {0} on the position {1}.", spinner.GetItemAtPosition (e.Position), e.Position);
			Toast.MakeText (this, toast, ToastLength.Long).Show ();
		}

		protected void Save()
		{
			task.Name = nameTextEdit.Text;
			task.Notes = notesTextEdit.Text;
			task.Done = doneCheckbox.Checked;
			var spinner = FindViewById<Spinner>(Resource.Id.spinner);
			task.Owner = spinner.GetItemAtPosition(spinnerPositionSelected).ToString();
			Tasky.BL.Managers.TaskManager.SaveTask(task);
			Finish();
		}
		
		protected void CancelDelete()
		{
			if(task.ID != 0) {
				Tasky.BL.Managers.TaskManager.DeleteTask(task.ID);
			}
			Finish();
		}

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_detailsscreen, menu);

            IMenuItem menuItem = menu.FindItem(Resource.Id.menu_delete_task);
            menuItem.SetTitle(task.ID == 0 ? "Cancel" : "Delete");

            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.menu_save_task:
                    Save();
                    return true;

                case Resource.Id.menu_delete_task:
                    CancelDelete();
                    return true;

                default: 
                    Finish();
                    return base.OnOptionsItemSelected(item);
            }
        }

	}
}