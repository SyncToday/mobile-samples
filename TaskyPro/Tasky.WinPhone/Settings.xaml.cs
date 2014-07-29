using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace TaskyWinPhone
{
    public partial class Settings : PhoneApplicationPage
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void HandleSave(object sender, EventArgs e)
        {

            NavigationService.GoBack();
        }
    }
}