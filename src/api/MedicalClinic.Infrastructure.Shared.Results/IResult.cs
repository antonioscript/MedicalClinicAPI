using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Infrastructure.Shared.Results
{
    public interface IResult
    {
        public string Message { get; set; }
        public bool Succeeded { get; set; }
    }

    public interface IResult<out T> : IResult
    {
        T Data { get; }
    }
}
