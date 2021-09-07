using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using Student_API_Xamarin_FrontEnd.Models;
using System.Collections.Generic;

namespace Student_API_Xamarin_FrontEnd
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        ListView StudentList;
        List<Student> myList = new List<Student>();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            StudentList = FindViewById<ListView>(Resource.Id.listView1);
            myList = DatabaseManager.GetStudentData();
            StudentList.Adapter = new DataAdapter(this, myList);
            StudentList.ItemClick += OnStudent_ListClick;
        }

        //Adds Add to the Menu in the top right of your screen.
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            menu.Add("Add Student");
            return base.OnPrepareOptionsMenu(menu);
        }

        //When you choose Add from the Menu run the Add Activity. Good to know to add more options
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            var itemTitle = item.TitleFormatted.ToString();

            switch (itemTitle)
            {
                case "Add Student":
                    StartActivity(typeof(AddStudent_Activity));
                    break;
            }
            return base.OnOptionsItemSelected(item);
        }

        void OnStudent_ListClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var Student_Item = myList[e.Position];

            var Edit_Student_item = new Intent(this, typeof(EditStudent_Activity));
            Edit_Student_item.PutExtra("Student_Name", Student_Item.Name);
            Edit_Student_item.PutExtra("Student_Email", Student_Item.email);
            Edit_Student_item.PutExtra("Student_Mobile", Student_Item.Mobile);
            Edit_Student_item.PutExtra("StudentId", Student_Item.Id);
            //Toast.MakeText(this, Tutor_Item.Id.ToString(), ToastLength.Long).Show();
           StartActivity(Edit_Student_item);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}