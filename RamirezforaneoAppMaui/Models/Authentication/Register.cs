using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RamirezforaneoAppMaui.Models.Authentication
{
    public class Register
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string CedulaUser { get; set; }
        public string StateName { get; set; }
        public string StudyProgram { get; set; }
        public int SessionNumber { get; set; }
        public DateTime UserCreationDate { get; set; } = DateTime.Now;
    }
}
