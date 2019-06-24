using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Test("42*47=1?74", 9);
            Test("4?*47=1974", 2);
            Test("42*?7=1974", 4);
            Test("42*?47=1974", -1);
            Test("2*12?=247", -1);
            Console.ReadKey(true);
        }

        private static void Test(string args, int expected)
        {
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }

        private static int FindDigit(string equation)
        {
            double[] integer_equation = new double[3];
            double res_int;
            int missing = 0,ind = 0,pass=0;
            string unknown="", res_string;
            string[] splitted_equation = equation.Split(new Char[] { '*', '=' });
            for (int i = 0; i < 3; i++)
            {
                if (splitted_equation[i].IndexOf('?') < 0)
                {
                    string a = splitted_equation[i];
                    integer_equation[i] = Int32.Parse(a);
                }
                else
                {
                    unknown = splitted_equation[i];
                    ind = splitted_equation[i].IndexOf('?');
                    missing = i;
                }
            }
            if (missing == 0)
            {
                res_int = integer_equation[2] / integer_equation[1];
                pass = CheckDecimal(res_int);
            }
            else if (missing == 1)
            {
                res_int = integer_equation[2] / integer_equation[0];
                pass = CheckDecimal(res_int);
            }
            else
            {
                res_int = integer_equation[0] * integer_equation[1];
                pass = CheckDecimal(res_int);
            }
            res_string = res_int.ToString();

            if(res_string.Length==unknown.Length && pass==1)
            {
                return (int)Char.GetNumericValue(res_string, ind);
            }
            else
            {
                return -1;
            }
        }

        private static int CheckDecimal(double d)
        {
            if ((d % 1) > 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}
