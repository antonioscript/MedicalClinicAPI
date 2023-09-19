using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marko.Api.Mercury.Application.Exceptions
{
    public interface IThrow
    {
    }

    public class Throw : IThrow
    {
        public static IThrow Exception { get; } = new Throw();

        private Throw()
        {
        }
    }
}
