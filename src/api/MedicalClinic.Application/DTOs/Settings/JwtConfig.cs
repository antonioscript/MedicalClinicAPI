using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Application.DTOs.Settings
{
    public class JwtConfig
    {
        public string Secret { get; set; }
        public int DurationInMinutes { get; set; }
        public int RefreshTokenExpireInMinutes { get; set; }
    }
}
