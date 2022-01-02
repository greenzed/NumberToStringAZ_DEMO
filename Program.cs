using System;
using System.Numerics;
using System.Text;
using System.Collections.Generic;

namespace NumberToStringDEMO
{
    class Program
    {
        struct num_group
        {
            public int num3;
            public int gr_id;

        };

        static void Main(string[] args)
        {
            decimal a =10000.44M;
            String r = NumberToAzeri(a);

            Console.WriteLine(r);
        }



        public static String NumberToAzeri(decimal num)
        {
            String result = "";
            //int gr4, gr3, gr2, gr1;



            Stack<num_group> my_stack = new Stack<num_group>();

            int num1 = (int)Math.Truncate(num);
            decimal diff = num - num1;
            int _2digitafterpoint = (int)Math.Truncate(diff * 100);

            num_group t;
            int r1 = num1 / 1000;
            int r2 = num1 % 1000;
            int gr_id = 0;

            do
            {
                t.num3 = r2;
                t.gr_id = gr_id++;

                my_stack.Push(t);

                r2 = r1 % 1000;
                r1 /= 1000;
            }

            while (r2 != 0);


            while (my_stack.Count > 0)
            {
                int a, b, c;
                t = my_stack.Pop();
                a = t.num3 / 100;
                b = t.num3 / 10 % 10;
                c = t.num3 % 10;
                if ( a > 1) { result += DigitToAZ1(a, "yuz ") ; } else if (a == 1 ) { result += "yuz "; }; 
                if (b >= 1) { result += DigitToAZ10(b, ""); }; 
                if (c >= 1) { result += DigitToAZ1(c, ""); };
                result += getSuffixByGroup(t.gr_id);

                System.Console.WriteLine(t.num3);
            }

            System.Console.WriteLine(result);

            //if (num == 0) result = DigitToAZ1(0, "");
            //if (num>=0 & num <= 100) result = DigitToAZ1(num1, "");
            //if (num > 100) result = DigitToAZ1(num1, "");
            return "";
        }

        static String getSuffixByGroup(int group)
        {
            String result = "";
            if (group == 0) { result = ""; };
            if (group == 1) { result = "min "; };
            if (group == 2) { result = "milyon "; };
            if (group == 3) { result = "milyard"; };

            return result;
        }
        static String DigitToAZ1(int p1, String suffix)
        {
            String result = "";
            switch (p1)
            {

                case 0: result = "sıfır"; break;
                case 1: result = "bir"; break;
                case 2: result = "iki"; break;
                case 3: result = "üç"; break;
                case 4: result = "dörd"; break;
                case 5: result = "beş"; break;
                case 6: result = "altı"; break;
                case 7: result = "yeddi"; break;
                case 8: result = "səkkiz"; break;
                case 9: result = "doguz"; break;



            }

            return (result + " " + suffix);

        }


        static String DigitToAZ10(int p1, String suffix)
        {
            String result = "";
            switch (p1)
            {

                case 1: result = "on"; break;
                case 2: result = "iyirmi"; break;
                case 3: result = "otuz"; break;
                case 4: result = "qirx"; break;
                case 5: result = "əlli"; break;
                case 6: result = "altmış"; break;
                case 7: result = "yetmiş"; break;
                case 8: result = "səksən"; break;
                case 9: result = "doxsan"; break;



            }

            return (result + " " + suffix);

        }




    }
}

