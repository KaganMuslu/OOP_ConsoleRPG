using ConsoleRPG.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG.Models
{
    internal abstract class KarakterYaratık : BaseEntity
    {
        // SOLID | Liskov Substitution Principle (LSP) - Liskov Yerine Geçme Prensibine uygun alt ve base classlar
        // Alt sınıflar, temel sınıfın sözleşmesini bozmadan temel sınıfın tüm işlevselliğini sunuyoor

        protected Random rnd;

        #region Karakter Özellikler

        // Genel Özellikler
        public int MaksimumCan { get; set; }
        public int MevcutCan { get; set; }
        public int Seviye { get; set; }
        public int MevcutTecrube { get; set; }

        // Statlar
        public int Guc { get; set; }
        public int Ceviklik { get; set; }
        public int Dayanıklılık { get; set; }
        public int Zeka { get; set; }
        public int Enerji { get; set; }

        #endregion


        // Bu class'ı miras alan her class random nesnesini buradan kullanabilir (Constructor Inheritance - Shared Resource Pattern)
        protected KarakterYaratık()
        {
            rnd = new Random();
        }


        #region Temel Saldırı

        public int Saldir()
        {
            int BaseAtk = rnd.Next(1, 21);
            Console.WriteLine("Zar Atılıyor (1-20), base saldırınız: " + BaseAtk);

            return BaseAtk;
        }

        #endregion


    }
}
