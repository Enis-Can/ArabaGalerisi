using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabaGalerisi
{
    internal class Car
    {
        // -- Arabaların (Marka, Model, Model Yılı, Renk, Fiyat) özellikleri olacak.
        public string Marka { get; }
        public string Model { get; }
        public int ModelYili { get { return ModelTarihi.Year;} }
        public DateTime ModelTarihi { get; }
        public string Renk { get; }
        public decimal Fiyat { get; private set; }
        public string PrintFormat()
        {
            return $"{Marka} | {Model} | {Renk} | {ModelYili} | {Fiyat:C2} ";
        }
        public Car(string marka, string model, DateTime modelTarihi, string renk, decimal fiyat)
        {
            Marka = marka;
            Model = model;
            ModelTarihi = modelTarihi;
            Renk = renk;
            Fiyat = fiyat;
        }
        public void IncreasePrice(decimal percent)
        {
            Fiyat += Math.Round(Fiyat * percent / 100, 2);
        }
        public void DecreasePrice(decimal percent)
        {
            Fiyat -= Math.Round(Fiyat * percent / 100, 2);
        }
    }
}
