using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloWorldAPI.Models.Implementations
{
    public class HelloWorld : Interfaces.IHelloWorld
    {
        public string PrintHelloWorld()
        {
            //We will write Hello World to the screen for console.
            return "Hello World";
        }

        public void WriteToSystem(string _text)
        {
            //We will write to the screen based on text passed from the console.
        }
    }
}