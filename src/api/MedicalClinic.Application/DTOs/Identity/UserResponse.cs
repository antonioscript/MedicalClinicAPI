using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Application.DTOs.Identity
{
    public class UserResponse
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
