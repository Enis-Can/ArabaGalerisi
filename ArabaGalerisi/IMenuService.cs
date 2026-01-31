using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabaGalerisi
{
    internal interface IMenuService
    {
        public string AddInterest();
        public string AddDiscount();
        public string CountCar();
        public string FindCar();
        public string DeleteCar();
        public string ListCar();
        public string AddCar();
        public int ListCars(IEnumerable<Car> cars);
    }
}
