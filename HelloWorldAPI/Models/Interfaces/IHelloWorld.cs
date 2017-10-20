using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldAPI.Models.Interfaces
{
    public interface IHelloWorld
    {
        string PrintHelloWorld();
        void WriteToSystem(string _text);
    }
}
