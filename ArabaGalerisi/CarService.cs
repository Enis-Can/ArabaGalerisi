using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabaGalerisi
{
    internal class CarService : ICarService
    {
        private readonly List<Car> Cars = new();
        public void AddCar(Car car)
        {
            Cars.Add(car);
        }
        public void RemoveCar(Car car)
        {
            Cars.Remove(car);
        }
        public List<Car> GetAllCars()
        {
            return Cars;
        }
        public bool HasCars()
        {
            return Cars.Any();
        }
        public int GetCarCount()
        {
            return Cars.Count;
        }
        public Car GetCar(int index)
        {
            return Cars[index];
        }
        public void AddInterestToAllCars(decimal percent)
        {
            foreach (var car in Cars)
            {
                car.IncreasePrice(percent);
            }
        }
        public void AddDiscountToAllCars(decimal percent)
        {
            foreach (var car in Cars)
            {
                car.DecreasePrice(percent);
            }
        }
    }
}
