using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabaGalerisi
{
    internal interface ICarService
    {
        void AddCar(Car car);
        void RemoveCar(Car car);
        List<Car> GetAllCars();
        bool HasCars();
        int GetCarCount();
        Car GetCar(int index);
        void AddInterestToAllCars(decimal percent);
        void AddDiscountToAllCars(decimal percent);
    }
}
