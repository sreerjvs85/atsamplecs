using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atsamplecs.src
{
    public class Calculator{

        public int FirstNumber {get; set;}

        public int SecondNumber {get; set;}

        public int Add(){
               return FirstNumber + SecondNumber; 
        }

    }
}