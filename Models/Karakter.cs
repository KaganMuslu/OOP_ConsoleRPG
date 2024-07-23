using ConsoleRPG.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG.Models
{
    internal class Karakter : KarakterYaratık
    {
        public Sınıf Sınıf { get; set; }
        public Irk Irk { get; set; }

        public Karakter(Sınıf sinif, Irk irk)
        {
            // Genel Statlar
            MaksimumCan = 40;
            MevcutCan = 40;
            Seviye = 1;
            MevcutTecrube = 0;

            #region Karakter Statlar

            // Sınıf statları belirleme
            switch (sinif)
            {
                case Sınıf.Barbar:
                    Guc = 4;
                    Ceviklik = 2;
                    Dayanıklılık = 2;
                    Zeka = 1;
                    Enerji = 2;
                    break;
                case Sınıf.Druid:
                    Guc = 2;
                    Ceviklik = 2;
                    Dayanıklılık = 2;
                    Zeka = 3;
                    Enerji = 2;
                    break;
                case Sınıf.Nişancı:
                    Guc = 3;
                    Ceviklik = 3;
                    Dayanıklılık = 1;
                    Zeka = 2;
                    Enerji = 2;
                    break;
                case Sınıf.Büyücü:
                    Guc = 1;
                    Ceviklik = 2;
                    Dayanıklılık = 2;
                    Zeka = 4;
                    Enerji = 3;
                    break;
                case Sınıf.Ninja:
                    Guc = 2;
                    Ceviklik = 4;
                    Dayanıklılık = 1;
                    Zeka = 2;
                    Enerji = 2;
                    break;
            }

            // Irk statları belirleme
            switch (irk)
            {
                case Irk.İnsan:
                    Enerji += 1;
                    break;
                case Irk.Cüce:
                    Dayanıklılık += 2;
                    Enerji -= 1;
                    break;
                case Irk.Elf:
                    Ceviklik += 2;
                    Dayanıklılık -= 1;
                    break;
                case Irk.Ork:
                    Guc += 2;
                    Zeka -= 1;
                    break;
                case Irk.Gnome:
                    Dayanıklılık += 2;
                    Guc -= 1;
                    break;

            }

            #endregion
        }

        #region Karakter Saldırı

        public int YakinSaldiri(Karakter karakter)
        {
            switch (karakter.Sınıf)
            {
                case Sınıf.Barbar:
                    return (int)(((Guc * 2) + (Dayanıklılık * 0.5)) * (base.Saldir() / 5));
                case Sınıf.Nişancı:
                    return (int)((Guc + (Dayanıklılık * 0.5)) * (base.Saldir() / 5));
                case Sınıf.Büyücü:
                    return (int)(((Guc * 0.5) + (Zeka * 0.2)) * (base.Saldir() / 5));
                case Sınıf.Druid:
                    return (int)(((Guc * 0.5) + (Zeka * 0.5)) * (base.Saldir() / 5));
                case Sınıf.Ninja:
                    return (int)(((Guc * 1.5) + (Ceviklik * 1.5)) * (base.Saldir() / 5));
                default:
                    return 0;
            }
        }

        public int UzakSaldiri(Karakter karakter)
        {
            switch (karakter.Sınıf)
            {
                case Sınıf.Barbar:
                    return (int)(((Ceviklik * 0.5) + (Guc * 0.2)) * (base.Saldir() / 5));
                case Sınıf.Nişancı:
                    return (int)(((Ceviklik * 2) + (Zeka * 0.5)) * (base.Saldir() / 5));
                case Sınıf.Büyücü:
                    return (int)((Ceviklik + (Zeka * 0.5)) * (base.Saldir() / 5));
                case Sınıf.Druid:
                    return (int)((Ceviklik + (Zeka * 1.5)) * (base.Saldir() / 5));
                case Sınıf.Ninja:
                    return (int)(((Ceviklik * 2) + (Guc * 0.5)) * (base.Saldir() / 5));
                default:
                    return 0;
            }
        }

        public int BuyuSaldiri(Karakter karakter)
        {
            switch (karakter.Sınıf)
            {
                case Sınıf.Barbar:
                    return (int)(((Zeka * 0.5) + (Enerji * 0.5)) * (base.Saldir() / 5));
                case Sınıf.Nişancı:
                    return (int)(((Zeka * 1.5) + Enerji) * (base.Saldir() / 5));
                case Sınıf.Büyücü:
                    return (int)(((Zeka * 2) + (Enerji * 1.5)) * (base.Saldir() / 5));
                case Sınıf.Druid:
                    return (int)(((Zeka * 2) + (Enerji * 1.5)) * (base.Saldir() / 5));
                case Sınıf.Ninja:
                    return (int)(((Zeka * 1.5) + Enerji) * (base.Saldir() / 5));
                default:
                    return 0;
            }
        }

        #endregion

        #region Karakter Can Doldur

        public int CanDoldur(Karakter karakter)
        {
            return rnd.Next(karakter.MaksimumCan / 4, karakter.MaksimumCan / 2);
        }

        #endregion

    }
}
