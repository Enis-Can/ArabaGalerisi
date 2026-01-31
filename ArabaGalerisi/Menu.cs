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
        private readonly IMenuService _menuService;
        public Menu(IMenuService menuService)
        {
            _menuService = menuService;
        }
        public void MenuOptions(ConsoleKey key)
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

        private void AddInterest(string v)
        {
            MenuTitle(v);
            ToMenu(_menuService.AddInterest());
        }

        private void AddDiscount(string v)
        {
            MenuTitle(v);
            ToMenu(_menuService.AddDiscount());
        }

        private void CountCar(string v)
        {
            MenuTitle(v);
            Console.WriteLine();
            ToMenu(_menuService.CountCar());
        }

        private void FindCar(string v)
        {
            MenuTitle(v);
            ToMenu(_menuService.FindCar());
        }

        private void DeleteCar(string v)
        {
            MenuTitle(v);
            ToMenu(_menuService.DeleteCar());
        }

        private void ListCar(string v)
        {
            MenuTitle(v);
            ToMenu(_menuService.ListCar());
        }

        private void AddCar(string v)
        {
            MenuTitle(v);
            ToMenu(_menuService.AddCar());
        }

        private void MenuTitle(string v)
        {
            Console.Clear();
            Console.WriteLine(v);
            for (int i = 0; i < v.Length; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
        }

        private void ToMenu(string v)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(v);
            Console.WriteLine("Menüye devam etmek için herhangi bir tuşa basınız.");
            Console.ReadKey();
        }
    }
}
