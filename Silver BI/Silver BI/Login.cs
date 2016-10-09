
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

namespace Silver_BI
{
    [Activity (Label = "Silver BI", MainLauncher = true)]
    public class Login : Activity
    {
        protected override void OnCreate (Bundle savedInstanceState)
        {
            base.OnCreate (savedInstanceState);

            // Create your application here
            SetContentView (Resource.Layout.Login);
            EditText txtCpf = (EditText)FindViewById (Resource.Id.txtCpf);
            EditText txtPassword = (EditText)FindViewById (Resource.Id.txtPassword);
            Button btnLogin = (Button)FindViewById (Resource.Id.btnLogin);

            btnLogin.Click += delegate {
                StartActivity (typeof (MainActivity));
             };
        }
    }
}
