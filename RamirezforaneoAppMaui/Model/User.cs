using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RamirezforaneoAppMaui.Model
{
    class User
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Enter your cedula")]
        public string CedulaUser { get; set; }
        [Required(ErrorMessage = "Select a program study")]
        public string StudyProgram { get; set; }
        [Required(ErrorMessage = "Select the session you are currently")]
        public int SessionNumber { get; set; }
        [Required(ErrorMessage = "Select the state you are from")]
        public string StateName { get; set; }
        public DateTime UserCreationDate { get; set; } = DateTime.Now;
    }
}
