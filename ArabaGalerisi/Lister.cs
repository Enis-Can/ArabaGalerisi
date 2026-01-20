using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabaGalerisi
{
    internal class Lister
    {
        internal static void ListCars(List<Car> cars)
        {
            for (int i = 0; i < cars.Count; i++)
            {
                cars[i].Print(i + 1);
            }
        }
    }
}
