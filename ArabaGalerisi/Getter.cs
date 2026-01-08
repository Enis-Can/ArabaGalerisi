using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ArabaGalerisi
{
    internal class Getter
    {
        public static string GetString(string msg, int min, int max)
        {
            string txt = string.Empty;
            bool err = false;
            do
            {
                Console.WriteLine(msg);
                txt = Console.ReadLine();
                try
                {
                    if (string.IsNullOrEmpty(txt)) throw new Exception("Boş değer girilemez");
                    else if (txt.Length > max) throw new Exception(string.Format("{0} karakterden fazla olamaz.",max));
                    else if (txt.Length < min) throw new Exception(string.Format("{0} karakterden az olamaz.", min));
                    else err = false;
                }
                catch(Exception e) 
                {
                    Console.WriteLine(e.Message);
                    err = true;
                }
            }
            while (err);
            return txt;
        }

        public static int GetInt(string msg, int min, int max)
        {
            int val = 0;
            bool err = false;
            do
            {
                Console.WriteLine(msg);
                try
                {
                    val = int.Parse(Console.ReadLine());
                    if (val > max) throw new Exception(string.Format("{0} değerinden fazla olamaz.", max));
                    else if (val < min) throw new Exception(string.Format("{0} değerinden az olamaz.", min));
                    err = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    err = true;
                }
            }
            while (err);
            return val;
        }

        public static double GetDouble(string msg, double min, double max)
        {
            double val = 0;
            bool err = false;
            do
            {
                Console.WriteLine(msg);
                try
                {
                    val = double.Parse(Console.ReadLine());
                    if (val > max) throw new Exception(string.Format("{0} değerinden fazla olamaz.", max));
                    else if (val < min) throw new Exception(string.Format("{0} değerinden az olamaz.", min));
                    err = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    err = true;
                }
            }
            while (err);
            return val;
        }

        public static DateTime GetDateTime(string msg, int min, int max)
        {
            DateTime date = DateTime.MinValue;
            bool err = false;
            do
            {
                Console.WriteLine(msg);
                try
                {
                    date = DateTime.Parse(Console.ReadLine());
                    if (date.Year > max) throw new Exception(string.Format("Girilen tarih yılı, {0} yılından büyük olamaz.", max));
                    else if (date.Year < min) throw new Exception(string.Format("Girilen tarih yılı, {0} yılından küçük olamaz", min));
                    err = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    err = true;
                }
            }
            while (err);
            return date;
        }
    }
}
