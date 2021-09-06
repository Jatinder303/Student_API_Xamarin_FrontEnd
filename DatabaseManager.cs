using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using Student_API_Xamarin_FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace Student_API_Xamarin_FrontEnd
{
   public class DatabaseManager
    {
        public static List<Student> GetStudentData()
        {
            var httpClient = new HttpClient();
            var response = httpClient.GetStringAsync("http://10.0.2.2:3492/api/Students");
            var Student_Obj = JsonConvert.DeserializeObject<List<Student>>(response.Result);
            return Student_Obj.ToList();
        }
    }
}