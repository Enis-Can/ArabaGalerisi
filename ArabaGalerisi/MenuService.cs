using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabaGalerisi
{
    internal class MenuService : IMenuService
    {
        private readonly ICarService _carService;
        public MenuService(ICarService carService) 
        { 
            _carService = carService;
        }
        public bool HasMoreThanOne(int count) => count > 1;
        public string AddInterest()
        {
            if (_carService.HasCars())
            {
                decimal interestRate = Getter.GetDecimal("Araçlara yapılacak zam miktarını giriniz(%): ", 0, 20);
                _carService.AddInterestToAllCars(interestRate);
                return $"Fiyatlara %{interestRate} zam başarıyla yapıldı.";
            }
            else return "Zam yapılabilecek bir araç bulunamadı.";
        }
        public string AddDiscount()
        {
            if (_carService.HasCars())
            {
                decimal discountRate = Getter.GetDecimal("Araçlara yapılacak indirim miktarını giriniz(%): ", 0, 20);
                _carService.AddDiscountToAllCars(discountRate);
                return $"Fiyatlara %{discountRate} indirim başarıyla yapıldı.";
            }
            return "İndirim yapılabilecek bir araç bulunamadı.";
        }

        public string CountCar()
        {
            return $"Sisteme kayıtlı {_carService.GetCarCount()} adet araç bulunmaktadır.";
        }

        public string FindCar()
        {
            if (_carService.HasCars())
            {
                CarFinder carFinder = new CarFinder();
                IEnumerable<Car> filteredCars = _carService.GetAllCars();
                int filteredCount = _carService.GetCarCount();
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
                    Console.Clear();
                    Console.WriteLine("Filtrelenen araçlar:");
                    filteredCount = ListCars(filteredCars.Take(20));
                }
                while (key != ConsoleKey.D0 && key != ConsoleKey.NumPad0 && HasMoreThanOne(filteredCount));
                if (!filteredCars.Any()) return "Bu kriterlere uygun araç bulunamadı";
                else return $"Tercihlerinize göre {filteredCount} adet araç bulundu.";
            }
            return "Sorgulanabilecek bir araç, listede bulunamadı.";
        }

        public string DeleteCar()
        {
            if (_carService.HasCars())
            {
                int orderNu = -1;
                ListCars(_carService.GetAllCars());
                Console.WriteLine();
                orderNu = Getter.GetInt("Silmek istediğiniz aracın sıra numarasını giriniz:", 1, _carService.GetCarCount());
                Console.WriteLine();
                Car carToBeRemoved = _carService.GetCar(orderNu - 1);
                Console.Write("Silmek istediğiniz araç: ");
                Console.WriteLine(carToBeRemoved.PrintFormat());
                ConsoleKey validation = Getter.GetConsoleKey("Silmek istediğinize emin misiniz?(e/h)",ConsoleKey.E,ConsoleKey.H);
                if ( validation == ConsoleKey.E)
                {
                    _carService.RemoveCar(carToBeRemoved);
                    return $"Aracınız başarıyla sistemden silindi. Sistemdeki güncel araç sayısı: {_carService.GetCarCount()}";
                }
                else
                {
                    return "Silme işlemi iptal edildi.";
                }
            }
            else return "Silme işlemi uygulanabilecek bir araç bulunamadı.";
        }

        public string ListCar()
        {
            if (_carService.HasCars())
            {
                ListCars(_carService.GetAllCars());
                return $"{_carService.GetCarCount()} adet araç listelendi.";
            }
            else return "Listelenebilecek bir araç bulunamadı.";
        }

        public string AddCar()
        {
            Console.WriteLine("Aracın;");
            Car car = new Car(
                Getter.GetString("Marka: ", 1, 20),
                Getter.GetString("Model: ", 1, 25),
                Getter.GetDateTime("Araç Tarihi: ", new DateTime(DateTime.Now.Year - 25, 1, 1), DateTime.Now),
                Getter.GetString("Renk: ", 1, 20),
                Getter.GetDecimal("Fiyat: ", 1));
            _carService.AddCar(car);
            return $"Aracınız başarıyla sisteme eklendi. Sistemdeki güncel araç sayısı: {_carService.GetCarCount()}";
        }
        public int ListCars(IEnumerable<Car> cars)
        {
            int i = 0;
            foreach (var car in cars)
            {
                i++;
                Console.WriteLine($"[{i}] {car.PrintFormat()} TL");
            }
            return i;
        }
    }
}
