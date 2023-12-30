using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Application.Exceptions
{
    public class MdException : Exception
    {
        public MdException() : base() 
        { 
        }

        public MdException(string message) : base(message) 
        { 
        
        }

        public MdException(string message, params object[] args)
            : base(String.Format(message, args)) 
        { 
            
        }
    }
}
