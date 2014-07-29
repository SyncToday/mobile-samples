using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Tasky.BL;
using Android.Views;
using Tasky.BL.Managers;
using Android.Net;
using Android.Preferences;

namespace Tasky.Droid.Screens {
	[Activity (Label = "TaskyPro for Sync.Today Demo", MainLauncher = true)]			
	public class LoginScreen : Activity  {

		private Button loginButton;
		private Button registerButton;
		private EditText username;
		private EditText password;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Enable the ActionBar
			RequestWindowFeature(WindowFeatures.ActionBar);

			// set our layout to be the home screen
			SetContentView(Resource.Layout.LoginScreen);

			ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this); 

			//try login
			if (!Login (prefs.GetString ("username", ""), prefs.GetString ("password", ""), true)) {

				loginButton = FindViewById<Button> (Resource.Id.login_button);
				loginButton.Click += delegate {

					//Call Your Method When User Clicks The Button
					OnClickLoginButton ();
				};

				registerButton = FindViewById<Button> (Resource.Id.register_button);
				registerButton.Click += delegate {

					//Call Your Method When User Clicks The Button
					OnClickRegisterButton ();
				};
			}
		}

		protected override void OnResume ()
		{
			base.OnResume ();

			loginButton = FindViewById<Button> (Resource.Id.login_button);
			loginButton.Click += delegate {

				//Call Your Method When User Clicks The Button
				OnClickLoginButton ();
			};

			registerButton = FindViewById<Button> (Resource.Id.register_button);
			registerButton.Click += delegate {

				//Call Your Method When User Clicks The Button
				OnClickRegisterButton ();
			};
		}

		private bool Login(string username, string password, bool credential)
		{
			Tasky.BL.Managers.RemoteTaskManager.loggedUser = null;
			Tasky.BL.Managers.RemoteTaskManager.UserName = username;
			Tasky.BL.Managers.RemoteTaskManager.Password = password;

			Tasky.BL.Managers.RemoteTaskManager.GetUsers (null);

			if (Tasky.BL.Managers.RemoteTaskManager.loggedUser == null) {
				if(!credential) Toast.MakeText (this, "Bad username or password.", ToastLength.Long).Show ();
				Tasky.BL.Managers.RemoteTaskManager.UserName = "";
				Tasky.BL.Managers.RemoteTaskManager.Password = "Password123";
				return false;
			} else {
				ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this); 
				ISharedPreferencesEditor editor = prefs.Edit();
				editor.PutString ("username", username);
				editor.PutString ("password", password);
				editor.Apply();

				//if user hit back button he has got a value in login forms
				FindViewById<EditText>(Resource.Id.login_username).Text = prefs.GetString ("username", "");
				FindViewById<EditText>(Resource.Id.login_password).Text = prefs.GetString ("password", "");

				var homeScreen = new Intent (this, typeof (HomeScreen));
				StartActivity (homeScreen);
				return true;
			}
		}

		public void OnClickLoginButton()
		{
			Tasky.BL.Managers.RemoteTaskManager.loggedUser = null;

			username = FindViewById<EditText>(Resource.Id.login_username);
			password = FindViewById<EditText>(Resource.Id.login_password);
			Login (username.Text, password.Text, false);
		}

		public void OnClickRegisterButton()
		{
			Intent browserIntent = new Intent(Intent.ActionView, Uri.Parse("http://wsdl.sync.today/register"));
			StartActivity(browserIntent);
		}
	}
}