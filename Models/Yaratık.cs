using ConsoleRPG.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG.Models
{
    internal class Yaratık : KarakterYaratık
    {
        public YaratıkSınıf YaratıkSınıf { get; set; }


        public Yaratık(Karakter karakter)
        {
            int randomCan = rnd.Next(15, 30);
            int randomSeviye = rnd.Next((int)(karakter.Seviye+1 * 0.75), karakter.Seviye+2);

            // Genel Statlar
            MaksimumCan = randomCan * (int)((randomSeviye + 1) * 0.5);
            MevcutCan = randomCan * (int)((randomSeviye + 1) * 0.5);
            Seviye = randomSeviye;
            MevcutTecrube = (int)(MaksimumCan * 0.7); // Yaratık kesilince karakter tecrübesine ekelenecek

            // Random Sınıf Atama
            int randomSınıf = rnd.Next(1, 5);
            YaratıkSınıf = (YaratıkSınıf)randomSınıf;

            #region Yaratık Statlar

            // Stat atama
            Guc = rnd.Next((int)(karakter.Guc * 0.6), (int)(karakter.Guc * 0.9));
            Ceviklik = rnd.Next((int)(karakter.Ceviklik * 0.6), (int)(karakter.Ceviklik * 0.9));
            Dayanıklılık = rnd.Next((int)(karakter.Dayanıklılık * 0.6), (int)(karakter.Dayanıklılık * 0.9));
            Zeka = rnd.Next((int)(karakter.Zeka * 0.6), (int)(karakter.Zeka * 0.9));
            Enerji = rnd.Next((int)(karakter.Enerji * 0.6), (int)(karakter.Enerji * 0.9));

            // Yaratık Sınıf Modifikasyonu
            switch (YaratıkSınıf)
            {
                case YaratıkSınıf.İskelet:
                    Dayanıklılık = (int)(karakter.Dayanıklılık * 0.4);
                    break;
                case YaratıkSınıf.Zombi:
                    Zeka = (int)(karakter.Zeka * 0.4);
                    break;
                case YaratıkSınıf.Goblin:
                    Zeka = (int)(karakter.Zeka * 0.4);
                    break;
                case YaratıkSınıf.Slime:
                    Guc = (int)(karakter.Guc * 0.4);
                    break;
                case YaratıkSınıf.Sıçan:
                    Ceviklik = (int)(karakter.Ceviklik * 0.4);
                    break;
            }

            #endregion

        }

        #region Yaratık Saldırılar

        public int Saldır(Yaratık yaratık)
        {
            int randomSaldiriTuru = rnd.Next(1,3);

            switch (randomSaldiriTuru)
            {
                case 2:
                    Console.WriteLine($"{yaratık.YaratıkSınıf} yakın saldırı yapıyor!");
                    switch (yaratık.YaratıkSınıf)
                    {
                        case YaratıkSınıf.İskelet:
                            return (int)(((Ceviklik * 0.5) + (Guc * 0.2)) * (base.Saldir() / 10));
                        case YaratıkSınıf.Zombi:
                            return (int)(((Ceviklik * 2) + (Zeka * 0.5)) * (base.Saldir() / 10));
                        case YaratıkSınıf.Goblin:
                            return (int)((Ceviklik + (Zeka * 0.5)) * (base.Saldir() / 10));
                        case YaratıkSınıf.Slime:
                            return (int)((Ceviklik + (Zeka * 1.5)) * (base.Saldir() / 10));
                        case YaratıkSınıf.Sıçan:
                            return (int)(((Ceviklik * 2) + (Guc * 0.5)) * (base.Saldir() / 10));
                        default:
                            return 0;
                    }
                case 3:
                    Console.WriteLine($"{yaratık.YaratıkSınıf} uzak saldırı yapıyor!");
                    switch (yaratık.YaratıkSınıf)
                    {
                        case YaratıkSınıf.İskelet:
                            return (int)(((Zeka * 0.5) + (Enerji * 0.5)) * (base.Saldir() / 10));
                        case YaratıkSınıf.Zombi:
                            return (int)(((Zeka * 1.5) + Enerji) * (base.Saldir() / 10));
                        case YaratıkSınıf.Goblin:
                            return (int)(((Zeka * 2) + (Enerji * 1.5)) * (base.Saldir() / 10));
                        case YaratıkSınıf.Slime:
                            return (int)(((Zeka * 2) + (Enerji * 1.5)) * (base.Saldir() / 10));
                        case YaratıkSınıf.Sıçan:
                            return (int)(((Zeka * 1.5) + Enerji) * (base.Saldir() / 10));
                        default:
                            return 0;
                    }
                default:
                    Console.WriteLine($"{yaratık.YaratıkSınıf} büyü saldırısı yapıyor!");
                    switch (yaratık.YaratıkSınıf)
                    {
                        case YaratıkSınıf.İskelet:
                            return (int)(((Guc * 2) + (Dayanıklılık * 0.5)) * (base.Saldir() / 10));
                        case YaratıkSınıf.Zombi:
                            return (int)((Guc + (Dayanıklılık * 0.5)) * (base.Saldir() / 10));
                        case YaratıkSınıf.Goblin:
                            return (int)(((Guc * 0.5) + (Zeka * 0.2)) * (base.Saldir() / 10));
                        case YaratıkSınıf.Slime:
                            return (int)(((Guc * 0.5) + (Zeka * 0.5)) * (base.Saldir() / 10));
                        case YaratıkSınıf.Sıçan:
                            return (int)(((Guc * 1.5) + (Ceviklik * 1.5)) * (base.Saldir() / 10));
                        default:
                            return 0;
                    }
            }
        }

        #endregion


    }
}
