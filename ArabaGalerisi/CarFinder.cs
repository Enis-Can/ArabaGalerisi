using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ArabaGalerisi
{
    internal class CarFinder
    {
        public List<Car> FindCarWithBrand(List<Car> filteredCars)
        {
            string brand = Getter.GetString("Sorgulamak istediğiniz markayı giriniz: ");
            return filteredCars.Where(x=>x.Marka.ToLower() == brand.ToLower().Trim()).ToList();
        }

        internal List<Car> FindCarWithColor(List<Car> filteredCars)
        {
            string color = Getter.GetString("Sorgulamak istediğiniz rengi giriniz: ");
            return filteredCars.Where(x => x.Renk.ToLower() == color.ToLower().Trim()).ToList();
        }

        internal List<Car> FindCarWithModel(List<Car> filteredCars)
        {
            string model = Getter.GetString("Sorgulamak istediğiniz modeli giriniz: ");
            return filteredCars.Where(x => x.Model.ToLower() == model.ToLower().Trim()).ToList();
        }

        internal List<Car> FindCarWithPrice(List<Car> filteredCars)
        {
            decimal minPrice = Getter.GetDecimal("Sorgulama için en düşük fiyat değerini giriniz: ");
            decimal maxPrice = Getter.GetDecimal("Sorgulama için en yüksek fiyat değerini giriniz: ");
            return filteredCars.Where(x => x.Fiyat >= minPrice && x.Fiyat <= maxPrice).ToList();
        }

        internal List<Car> FindCarWithYear(List<Car> filteredCars)
        {
            DateTime date = DateTime.Now;
            int minYear = Getter.GetInt("Minimum model yılını giriniz: ",date.Year-25,date.Year);
            int maxYear = Getter.GetInt("Maksimum model yılını giriniz: ", minYear, date.Year);
            return filteredCars.Where(x => x.ModelYili >= minYear && x.ModelYili <= maxYear).ToList();
        }
    }
}
