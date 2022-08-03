using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TestProgram
{
    public class Program
    {
        // Add two numbers – Method under test
        public object[] AddNumbers(int a, int b, int c)
        {
            
            double Delta = Math.Pow(b, 2) - 4 * a * c;
            double x1, x2;
            object[] Arr = new object[] {0,0};
            if (a == 0)
            {
                Arr[0] = -c / b;
                Arr[1] = "NULL";
                return Arr;
            }
            else
            {
                if (Delta > 0) {

                    x1 = (double)(-b + Math.Sqrt(Delta)) / (2 * a);
                    Arr[0] = x1;
                    x2 = (double)(-b - Math.Sqrt(Delta)) / (2 * a);
                    Arr[1] = x2;
                    return Arr;
                } 
                else if (Delta == 0)
                {
                    x1 =(double) -b / (2 * a);
                    Arr[0] = x1;
                    Arr[1] = x1;
                    return Arr;
                    
                }

                else
                {
                    Arr[0] = "NULL";
                    Arr[1] = "NULL";
                    return Arr;
                }

                    
            }
        }
            
        static void Main(string[] args)
        {
        }
    }
}