using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabaGalerisi
{
    internal class Menu
    {
        List<Car> Cars = new();
        public static void MenuOptions(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    AddCar("ARAÇ EKLE");
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    ListCar("ARAÇLARI LİSTELE");
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    DeleteCar("ARAÇ SİL");
                    break;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    FindCar("ARAÇ ARAMA");
                    break;
                case ConsoleKey.D5:
                case ConsoleKey.NumPad5:
                    CountCar("TOPLAM ARAÇ SAYISI");
                    break;
                case ConsoleKey.D6:
                case ConsoleKey.NumPad6:
                    AddDiscount("İNDİRİM YAP");
                    break;
                case ConsoleKey.D7:
                case ConsoleKey.NumPad7:
                    AddInterest("ZAM YAP");
                    break;
            }
        }

        private static void AddInterest(string v)
        {
            MenuTitle(v);
            if (Cars.Any())
            {
                double interestRate = Getter.GetDouble("Araçlara yapılacak zam miktarını giriniz(%): ", 0, 20);
                foreach (var car in Cars)
                {
                    car.Fiyat *= (1 + (Decimal)interestRate/100);
                    car.Fiyat = Math.Round(car.Fiyat,2);
                }
                ToMenu(string.Format("Fiyatlara %{0} zam başarıyla yapıldı.",interestRate));
            }
            else ToMenu("Zam yapılabilecek bir araç bulunamadı.");
        }

        private static void AddDiscount(string v)
        {
            MenuTitle(v);
            if (Cars.Any())
            {
                double discountRate = Getter.GetDouble("Araçlara yapılacak indirim miktarını giriniz(%): ", 0, 20);
                foreach (var car in Cars)
                {
                    car.Fiyat *= (1 - (Decimal)discountRate/100);
                    car.Fiyat = Math.Round(car.Fiyat, 2);
                }
                ToMenu(string.Format("Fiyatlara %{0} indirim başarıyla yapıldı.", discountRate));
            }
            else ToMenu("İndirim yapılabilecek bir araç bulunamadı.");
        }

        private static void CountCar(string v)
        {
            MenuTitle(v);
            Console.WriteLine();
            ToMenu(string.Format("Sisteme kayıtlı {0} adet araç bulunmaktadır.",Cars.Count));
        }

        private static void FindCar(string v)
        {
            MenuTitle(v);

            if (Cars.Any())
            {
                CarFinder carFinder = new CarFinder();
                List<Car> filteredCars = Cars;
                ConsoleKey key;
                do
                {
                    
                    Console.WriteLine("1-) Markaya göre sorgula");
                    Console.WriteLine("2-) Modele göre sorgula");
                    Console.WriteLine("3-) Araç rengine göre sorgula");
                    Console.WriteLine("4-) Model yılına göre sorgula");
                    Console.WriteLine("5-) Fiyata göre sorgula");
                    Console.WriteLine("0-) Menüye dön");
                    Console.Write("Lütfen bir sorgulama yöntemi seçiniz: ");
                    key = Console.ReadKey().Key;
                    Console.WriteLine();
                    switch (key)
                    {
                        case ConsoleKey.NumPad1:
                        case ConsoleKey.D1:
                            filteredCars = carFinder.FindCarWithBrand(filteredCars);
                            break;
                        case ConsoleKey.NumPad2:
                        case ConsoleKey.D2:
                            filteredCars = carFinder.FindCarWithModel(filteredCars);
                            break;
                        case ConsoleKey.NumPad3:
                        case ConsoleKey.D3:
                            filteredCars = carFinder.FindCarWithColor(filteredCars);
                            break;
                        case ConsoleKey.NumPad4:
                        case ConsoleKey.D4:
                            filteredCars = carFinder.FindCarWithYear(filteredCars);
                            break;
                        case ConsoleKey.NumPad5:
                        case ConsoleKey.D5:
                            filteredCars = carFinder.FindCarWithPrice(filteredCars);
                            break;
                    }
                    Lister.ListCars(filteredCars);
                }
                while (key != ConsoleKey.D0 && key != ConsoleKey.NumPad0 && filteredCars.Any());
                if (!filteredCars.Any()) ToMenu("Bu kriterlere uygun araç bulunamadı");
                else ToMenu("Araç sorgulaması sonlandırıldı.");
            }
            else ToMenu("Sorgulanabilecek bir araç, listede bulunamadı.");
        }

        private static void DeleteCar(string v)
        {
            MenuTitle(v);
            
            if (Cars.Any())
            {
                int orderNu = -1;
                Lister.ListCars(Cars);
                Console.WriteLine();
                orderNu = Getter.GetInt("Silmek istediğiniz aracın sıra numarasını giriniz:", 1, Cars.Count);
                Console.WriteLine();
                Console.Write("Silmek istediğiniz araç: ");
                Cars[orderNu-1].Print(orderNu);
                Console.WriteLine("Silmek istediğinize emin misiniz?(e)");
                if (Console.ReadKey().Key == ConsoleKey.E)
                {
                    Cars.RemoveAt(orderNu-1);
                }
                else
                {
                    ToMenu("Silme işlemi iptal edildi.");
                }
            }
            else ToMenu("Silme işlemi uygulanabilecek bir araç bulunamadı.");
        }

        private static void ListCar(string v)
        {
            MenuTitle(v);
            if (Cars.Any())
            {
                Lister.ListCars(Cars);
                ToMenu(string.Format("{0} adet araç listelendi.", Cars.Count));
            }
            else ToMenu("Listelenebilecek bir araç bulunamadı.");
        }

        private static void AddCar(string v)
        {
            MenuTitle(v);
            Console.WriteLine("Aracın;");
            Car car = new Car()
            {
                Marka = Getter.GetString("Marka: ", 1, 20),
                Model = Getter.GetString("Model: ", 1, 25),
                ModelTarihi = Getter.GetDateTime("Araç Tarihi: ", new DateTime(DateTime.Now.Year - 25, 1, 1), DateTime.Now),
                Renk = Getter.GetString("Renk: ", 1, 20),
                Fiyat = Getter.GetDecimal("Fiyat: ", 1)
            };
            Cars.Add(car);
            ToMenu("Aracınız başarıyla sisteme eklendi.");
        }

        private static void MenuTitle(string v)
        {
            Console.Clear();
            Console.WriteLine(v);
            for (int i = 0; i < v.Length; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
        }

        private static void ToMenu(string v)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(v);
            Console.WriteLine("Menüye devam etmek için herhangi bir tuşa basınız.");
            Console.ReadKey();
        }
    }
}
