using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Tasky.BL.Managers;
using System.Text;
using System.Security.Cryptography;
using System.IO.IsolatedStorage;
using System.IO;

namespace TaskyWinPhone
{
    public partial class Settings : PhoneApplicationPage
    {
        public Settings()
        {
            InitializeComponent();

            App.GetLoginInformation();

            UsernameText.Text = RemoteTaskManager.UserName;
            PasswordText.Password = RemoteTaskManager.Password;
        }

        private void HandleSave(object sender, EventArgs e)
        {
            RemoteTaskManager.UserName = UsernameText.Text;
            RemoteTaskManager.Password = PasswordText.Password;
            string pin = RemoteTaskManager.UserName + "|" + RemoteTaskManager.Password;

            // Convert the PIN to a byte[].
            byte[] PinByte = Encoding.UTF8.GetBytes(pin);

            // Encrypt the PIN by using the Protect() method.
            byte[] ProtectedPinByte = ProtectedData.Protect(PinByte, null);

            // Store the encrypted PIN in isolated storage.
            this.WritePinToFile(ProtectedPinByte);

            NavigationService.GoBack();
        }

        private void WritePinToFile(byte[] pinData)
        {
            // Create a file in the application's isolated storage.
            IsolatedStorageFile file = IsolatedStorageFile.GetUserStoreForApplication();
            IsolatedStorageFileStream writestream = new IsolatedStorageFileStream(App.FilePath, System.IO.FileMode.Create, System.IO.FileAccess.Write, file);

            // Write pinData to the file.
            Stream writer = new StreamWriter(writestream).BaseStream;
            writer.Write(pinData, 0, pinData.Length);
            writer.Close();
            writestream.Close();
        }
    }
}
