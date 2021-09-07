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
    [Activity(Label = "EditStudent_Activity")]
    public class EditStudent_Activity : Activity
    {
        int Student_Id;
        TextView txt_Student_Name;
        TextView txt_Student_Email;
        TextView txt_Student_Mobile;

        Button btn_Edit;
        Button btn_Delete;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.EditStudent_Layout);

            txt_Student_Name = FindViewById<TextView>(Resource.Id.txtEditStudentName);
            txt_Student_Email = FindViewById<TextView>(Resource.Id.txtEditEmail);
            txt_Student_Mobile = FindViewById<TextView>(Resource.Id.txtEditMobile);
       
            btn_Edit = FindViewById<Button>(Resource.Id.btnEdit);
            btn_Delete = FindViewById<Button>(Resource.Id.btnDelete);

            Student_Id = Intent.GetIntExtra("StudentId", -1); //-1 is default 
            txt_Student_Name.Text = Intent.GetStringExtra("Student_Name");
            txt_Student_Email.Text = Intent.GetStringExtra("Student_Email");
            txt_Student_Mobile.Text = Intent.GetStringExtra("Student_Mobile");
            
            btn_Edit.Click += OnEdit_Click;
            btn_Delete.Click += OnDelete_Click;
       }

        public void OnEdit_Click(object sender, EventArgs e)
        {
            if (txt_Student_Name.Text != "" && txt_Student_Email.Text != "" && txt_Student_Mobile.Text != "")
            {
              
                DatabaseManager.EditStudent(txt_Student_Name.Text, txt_Student_Email.Text, txt_Student_Mobile.Text, Student_Id);
               Toast.MakeText(this, "Student data Updated", ToastLength.Long).Show();
                this.Finish();
                StartActivity(typeof(MainActivity));
            }
            else
            {
                Toast.MakeText(this, "Please fill data in all fields", ToastLength.Long).Show();
            }
        }

        public void OnDelete_Click(object sender, EventArgs e)
        {
                DatabaseManager.DeleteStudent(Student_Id);
                Toast.MakeText(this, "Student data is Deleted", ToastLength.Long).Show();
                this.Finish();
                StartActivity(typeof(MainActivity));
           
        }
    }
}