
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Tasky.Droid.Screens;

namespace Tasky.Droid
{
	[Activity (Label = "RegisterScreen")]			
	public class RegisterScreen : Activity
	{
		private Button registerButton;
		private EditText username;
		private EditText password;
		private EditText passwordAgain;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Enable the ActionBar
			RequestWindowFeature(WindowFeatures.ActionBar);

			// set our layout to be the home screen
			SetContentView(Resource.Layout.RegisterScreen);

			registerButton = FindViewById<Button>(Resource.Id.register_button);
			registerButton.Click += delegate {

				//Call Your Method When User Clicks The Button
				OnClickRegisterButton();
			};
		}

		public void OnClickRegisterButton()
		{
			Tasky.BL.Managers.RemoteTaskManager.loggedUser = null;

			username = FindViewById<EditText>(Resource.Id.register_username);
			password = FindViewById<EditText>(Resource.Id.register_password);
			passwordAgain = FindViewById<EditText>(Resource.Id.register_password_again);

			string passwordAgain = passwordAgain.Text;
			string password = password.Text;
			if (!passwordAgain.Equals (password)) {
				Toast.MakeText (this, "Passwords not match.", ToastLength.Long).Show ();
				this.password.Text = "";
				this.passwordAgain.Text = "";
			}
			else {
				LoginScreen.OnClickLoginButton ();
			}
		}
	}
}

