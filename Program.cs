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

            bool savasBitis = false;
            bool dinlen = false;

            string secilen;
            string savasKac;
            string dovusTuru;
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


            do
            {
                // Macera Tamam - Devam
                if (savasBitis == true)
                {
                    savasBitis = false;
                    if (dinlen == false)
                    {
                        do
                        {
                            Console.WriteLine("1- Maceraya Devam\n2- Dinlen\n3- Çıkış Yap");
                            secilen = Console.ReadLine();

                        } while (secilen != "1" && secilen != "2" && secilen != "3");
                    }
                    else
                    {
                        do
                        {
                            Console.WriteLine("1- Maceraya Devam\n2- Dinlen (Yakın zamanda dinlendiniz!)\n3- Çıkış Yap");
                            secilen = Console.ReadLine();

                        } while (secilen != "1" && secilen != "3");
                    }

                }

                // Maceraya Çıkma Seçimi
                switch (secilen)
                {
                    // Savaş seçimi
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
                            // Savaşılıyor
                            case "1":
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
                                    Thread.Sleep(2000);

                                    // Eğer yaratığın canı -'ye düşerse savaşı bitir
                                    if (yaratık.MevcutCan <= 0)
                                    {
                                        Console.WriteLine($"{yaratık.YaratıkSınıf} sizin tarafınızdan kesildi!");
                                        Thread.Sleep(2000);
                                        savasBitis = true;
                                        dinlen = false;

                                        // Karakter tecrübe kazanacak
                                        karakter.MevcutTecrube += yaratık.MevcutTecrube;
                                        Console.WriteLine($"Karakteriniz {username}, {yaratık.MevcutTecrube} tecrübe puanı kazandı.");
                                        Console.WriteLine($"Canınız: {karakter.MevcutCan}, Tecrübe puanınız: {karakter.MevcutTecrube}, Seviyeniz: {karakter.Seviye}");
                                        Thread.Sleep(2000);
                                    }
                                    else
                                    {
                                        hasar = yaratık.Saldır(yaratık);
                                        karakter.MevcutCan -= hasar;
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
                                    }

                                } while (savasBitis != true);
                                break;

                            // Kaçıyor
                            case "2":
                                Console.WriteLine("Kaçılıyor...\n\n");
                                savasBitis = true;
                                break;
                        }

                        break;

                    // Dinlenme ve can doldurma
                    case "2":
                        Console.WriteLine("\nBiraz dinleniyorsun...");
                        Thread.Sleep(1000);
                        Console.WriteLine("...");
                        Thread.Sleep(1000);
                        Console.WriteLine("..");
                        Thread.Sleep(1000);
                        Console.WriteLine(".\n");

                        // Karakter canını dolduruyor
                        int canDoldur = karakter.CanDoldur(karakter);
                        if ((canDoldur + karakter.MevcutCan) > karakter.MaksimumCan)
                        {
                            karakter.MevcutCan = karakter.MaksimumCan;
                        }
                        else
                        {
                            karakter.MevcutCan += canDoldur;
                        }
                        Console.WriteLine($"{username}, {canDoldur} can puanını tekrar doldurdu..");
                        Thread.Sleep(2000);
                        Console.WriteLine($"Yeni can miktarı: {karakter.MevcutCan} | Maksimum can miktarı: {karakter.MaksimumCan}\n");
                        Thread.Sleep(3000);

                        dinlen = true;
                        savasBitis = true;
                        break;

                    // Çıkış Yap
                    case "3":
                        Console.WriteLine("\nÇıkış  Yapılıyor...");
                        Thread.Sleep(1000);
                        Console.WriteLine("Görüşmek üzere");
                        Thread.Sleep(2000);
                        break;

                }
            } while (savasBitis == true);

            //Todo: 1- Savaş 2- Kaç seçeneğinde 3 seçilebiliyor
            //Todo: Karakterin ölmesini ekle
            //Todo: Tecrübe ile seviye atlama ve stat verme

        }
    }
}
