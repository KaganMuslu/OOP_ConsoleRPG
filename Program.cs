using ConsoleRPG.Enum;
using ConsoleRPG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Merhabalar, ConsoleRPG'ye hoşgeldiniz!");
            Thread.Sleep(1000);
            Console.WriteLine("Bir kullanıcı adı belirleyin: ");
            string username = Console.ReadLine();

            Console.WriteLine($"\nAnlaşıldı {username}. Şimdi de karakterinizin sınıfını seçin: ");
            Thread.Sleep(1000);

            string secilen;
            string savasKac;
            string dovusTuru;
            bool savasBitis;
            int hasar;

            string readSınıf;
            string readIrk;
            Sınıf secilenSınıf = Sınıf.Barbar;
            Irk secilenIrk = Irk.İnsan;

            #region Karakter Yaratma, Sınıf ve Irk Seçimi

            do
            {
                Console.WriteLine($"\n1- Barbar\n2- Druid\n3- Nişancı\n4- Büyücü\n5- Ninja\n");
                readSınıf = Console.ReadLine();

                switch (readSınıf)
                {
                    case "1":
                        secilenSınıf = Sınıf.Barbar;
                        break;
                    case "2":
                        secilenSınıf = Sınıf.Druid;
                        break;
                    case "3":
                        secilenSınıf = Sınıf.Nişancı;
                        break;
                    case "4":
                         secilenSınıf = Sınıf.Büyücü;
                        break;
                    case "5":
                        secilenSınıf = Sınıf.Ninja;
                        break;
                }

            } while (readSınıf != "1" && readSınıf != "2" && readSınıf != "3" && readSınıf != "4" && readSınıf != "5" );


            Console.WriteLine("\nTamamdır, şimdi de karakterinizin ırkını seçin: ");
            Thread.Sleep(1000);
            do
            {
                Console.WriteLine($"\n1- İnsan\n2- Cüce\n3- Elf\n4- Ork\n5- Gnome");
                readIrk = Console.ReadLine();

                switch (readIrk)
                {
                    case "1":
                        secilenIrk = Irk.İnsan;
                        break;
                    case "2":
                        secilenIrk = Irk.Cüce;
                        break;
                    case "3":
                        secilenIrk = Irk.Elf;
                        break;
                    case "4":
                        secilenIrk = Irk.Ork;
                        break;
                    case "5":
                        secilenIrk = Irk.Gnome;
                        break;
                }

            } while (readSınıf != "1" && readSınıf != "2" && readSınıf != "3" && readSınıf != "4" && readSınıf != "5");

            Console.WriteLine($"\nKarakterinizin adı {username}, sınıfı {secilenSınıf} ve ırkı {secilenIrk}\n");
            Thread.Sleep(1000);
            Karakter karakter = new Karakter(secilenSınıf, secilenIrk);

            #endregion


            Console.WriteLine("Şimdi ne yapmak istersiniz: ");
            Thread.Sleep(1000);
            do
            {
                Console.WriteLine("1- Maceraya Çık\n2- Dinlen\n3- Çıkış Yap");
                secilen = Console.ReadLine();

            } while (secilen != "1" && secilen != "2" && secilen != "3");

            switch (secilen)
            {
                case "1":
                    Yaratık yaratık = new Yaratık(karakter);
                    Thread.Sleep(1000);
                    Console.WriteLine("\nBir yaratıkla karşılaşıldı!");
                    Thread.Sleep(1000);
                    Console.WriteLine($"Yaratığın türü: {yaratık.YaratıkSınıf}, canı: {yaratık.MevcutCan} ve seviyesi: {yaratık.Seviye}");
                    Thread.Sleep(3000);
                    Console.WriteLine($"\nSizin Statlarınız: \nSeviye: {karakter.Seviye} \nMevcut Can: {karakter.MevcutCan} \nGüç:{karakter.Guc} \nÇeviklik: {karakter.Ceviklik} \nDayanıklılık: {karakter.Dayanıklılık} \nZeka: {karakter.Zeka} \nEnerji: {karakter.Enerji} ");
                    Thread.Sleep(3000);

                    do
                    {
                        Console.WriteLine("\nSavaşacak mısın kaçacak mısın? \n1- Savaş 2-Kaç\n");
                        savasKac = Console.ReadLine();

                    } while (savasKac != "1" && savasKac != "2");

                    switch (savasKac)
                    {
                        case "1":
                            savasBitis = false;
                            do
                            {
                                do
                                {
                                    Thread.Sleep(1000);
                                    Console.WriteLine("\nSaldırı Türü Seç: ");
                                    Thread.Sleep(1000);
                                    Console.WriteLine("1- Yakın Saldırı\n2- Uzak Saldırı\n3- Büyü Saldırısı\n");

                                    dovusTuru = Console.ReadLine();

                                } while (dovusTuru != "1" && dovusTuru != "2" && dovusTuru != "3");

                                switch (dovusTuru)
                                {
                                    default:
                                        hasar = karakter.YakinSaldiri(karakter);
                                        break;
                                    case "2":
                                        hasar = karakter.UzakSaldiri(karakter);
                                        break;
                                    case "3":
                                        hasar = karakter.BuyuSaldiri(karakter);
                                        break;
                                }

                                
                                yaratık.MevcutCan -= hasar;

                                Thread.Sleep(1000);
                                Console.WriteLine($"\nYaratığa {hasar} hasar vuruldu!\n");

                                if (yaratık.MevcutCan < 0)
                                {
                                    Console.WriteLine($"{yaratık.YaratıkSınıf} sizin tarafınızdan kesildi!");
                                    savasBitis = true;
                                }

                                hasar = yaratık.Saldır(yaratık);
                                karakter.MevcutCan -= hasar;
                                Thread.Sleep(3000);
                                Console.WriteLine($"{yaratık.YaratıkSınıf} karakterinize {hasar} hasar verdi!\n\n");

                                Thread.Sleep(3000);
                                Console.WriteLine($"Mevcut Canınız: {karakter.MevcutCan} | {yaratık.YaratıkSınıf} Canı: {yaratık.MevcutCan}\n");


                                Console.WriteLine("1- Savaş\n2- Kaç\n");
                                savasKac = Console.ReadLine();

                                switch (savasKac)
                                {
                                    case "2":
                                        Console.WriteLine("Kaçılıyor...");
                                        return;
                                }

                            } while (savasBitis != true);

                        case "2":
                            Console.WriteLine("Kaçılıyor...\n\n");
                            break;
                    }

                    break;
                case "2":
                    break;
                case "3":
                    break;

            }

            Console.WriteLine("\nGörüşmek üzere");
            Thread.Sleep(2000);

        }
    }
}
