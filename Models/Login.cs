using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogMvcApp.Models
{
    public class Login
    {
        public int Id { get; set; }
        public String Isim { get; set; }
        public String SoyIsim { get; set; }
        public String Email { get; set; }
        public String Sifre { get; set; }
    }
    public class LoginInit
    {
        public static List<Login> Init()
        {
            return new List<Login>
            {
               new Login { Isim="Dilara", SoyIsim="Yılmaz", Email="dilara@gmail.com",Sifre="123"},
                new Login { Isim="suna", SoyIsim="cihan", Email="suna@gmail.com",Sifre="123"}
            };
        }
    }

   
}