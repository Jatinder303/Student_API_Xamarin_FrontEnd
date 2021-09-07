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
using System.Net.Http.Headers;
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

        public static void AddStudent(string Student_Name, string Student_Email, string Student_Mobile)
        {
            try
            {
                // Define the object of student class and pass the values of the parameters to object variables.
                /* Student student_Obj_2 = new Student();
                   student_Obj_2.Name = Student_Name;
                   student_Obj_2.email = Student_Email;
                   student_Obj_2.Mobile = Student_Mobile; */
                Student student_Obj = new Student
                {
                    Name = Student_Name,
                    Mobile = Student_Mobile,
                    email = Student_Email
                };
                var httpClient = new HttpClient();
                var Json = JsonConvert.SerializeObject(student_Obj);
                HttpContent httpContent = new StringContent(Json);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/Json");
                httpClient.PostAsync(string.Format("http://10.0.2.2:3492/api/Students"), httpContent);

            }
            catch (Exception e)
            {
                Console.WriteLine("Insert student Data Error " + e.Message);
            }
        }

        public static void EditStudent(string Stud_Name, string Stud_Email, string Stud_Mobile, int Stud_Id)
        {
            try
            {
                // Define the object of student class and pass the values of the parameters to object variables.
          
                Student student_Obj = new Student
                {
                    Name = Stud_Name,
                    Mobile = Stud_Mobile,
                    email = Stud_Email,
                    Id = Stud_Id
                };
                var httpClient = new HttpClient();
                var Json = JsonConvert.SerializeObject(student_Obj);
                HttpContent httpContent = new StringContent(Json);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/Json");
                httpClient.PutAsync(string.Format("http://10.0.2.2:3492/api/Students/{0}",Stud_Id), httpContent);

            }
            catch (Exception e)
            {
                Console.WriteLine("Update student Data Error " + e.Message);
            }
        }
    }
}