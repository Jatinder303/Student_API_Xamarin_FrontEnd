using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Student_API_Xamarin_FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Student_API_Xamarin_FrontEnd
{
    class DataAdapter : BaseAdapter<Student>
    {
        private readonly Activity context;
        private readonly List<Student> items;
        public DataAdapter(Activity context, List<Student> items)
        {
            this.context = context;
            this.items = items;
        }
        public override Student this[int position]
        {
            get { return items[position]; }
        }

        public override int Count
        {
            get
            {
                return items.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];
            var view = convertView;
            if (view == null) // no view to re-use, create new
                view = context.LayoutInflater.Inflate(Resource.Layout.DisplayStudentData, null);
            view.FindViewById<TextView>(Resource.Id.lblName).Text = item.Name;
            view.FindViewById<TextView>(Resource.Id.lblEmail).Text = item.email;
            view.FindViewById<TextView>(Resource.Id.lblMobile).Text = item.Mobile;
            return view;
        }
    }
}