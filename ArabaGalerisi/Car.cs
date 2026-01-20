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
        public string Marka { get; set; }
        public string Model { get; set; }
        public int ModelYili { get { return ModelTarihi.Year;} }
        [Required]
        public DateTime ModelTarihi { get; set; }
        public string Renk { get; set; }
        public decimal Fiyat { get; set; }
        public void Print(int order)
        {
            Console.WriteLine("[{0}] {1} | {2} | {3} | {4} | {5} ₺", order, Marka, Model, Renk, ModelYili, Fiyat);
        }
    }
}
