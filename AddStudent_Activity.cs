using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Student_API_Xamarin_FrontEnd
{
    [Activity(Label = "AddStudent_Activity")]
    public class AddStudent_Activity : Activity
    {
        Button btn_Add;
        EditText txtItem_StudentName;
        EditText txtItem_Email;
        EditText txtItem_Mobile;
   
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.AddStudent_Layout);
          
            txtItem_StudentName = FindViewById<EditText>(Resource.Id.txtItemStudentName);
            txtItem_Email = FindViewById<EditText>(Resource.Id.txtItemEmail);
            txtItem_Mobile = FindViewById<EditText>(Resource.Id.txtItemMobile);

            btn_Add = FindViewById<Button>(Resource.Id.btnAdd);
            btn_Add.Click += OnBtnAddClick;
        }

        private void OnBtnAddClick(object sender, EventArgs e)
        {
            if(txtItem_StudentName.Text !="" && txtItem_Email.Text != "" && txtItem_Mobile.Text != "")
            {
                DatabaseManager.AddStudent(txtItem_StudentName.Text, txtItem_Email.Text, txtItem_Mobile.Text);
                Toast.MakeText(this, "New Student data Added", ToastLength.Long).Show();
                this.Finish();
                StartActivity(typeof(MainActivity));
            }
            else
            {
                Toast.MakeText(this, "Please fill data in all fields", ToastLength.Long).Show();
            }
        }

    }
}