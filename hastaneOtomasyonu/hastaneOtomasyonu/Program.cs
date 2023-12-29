using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace hastaneOtomasyonu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Hastane Otomasyonu");
            Console.WriteLine("______________________________");
            Console.WriteLine("[1] Hasta"); // hasta , hastane
            Console.WriteLine("[2] Doktor"); // doktor, hastanecalisanlari, hastane
            Console.WriteLine("[3] Hastane"); // hastane
            Console.WriteLine("[4] Hastane Çalışanları"); //hastanecalisanlari, hastane
            Console.WriteLine("[5] Çıkış");
            Console.WriteLine("Hangi işlemi gerçekleştireceksiniz?");
            try
            {
                uint islem = Convert.ToUInt16(Console.ReadLine());
                if (islem == 1)
                {
                    Console.Clear();
                    Console.WriteLine("Hasta Ekleme");
                    Console.WriteLine("______________________________");
                    Hastane hastane = new Hastane();
                    Hasta hasta = new Hasta();
                    hastane.Ekle();
                    hasta.Ekle();
                    Console.WriteLine("Hasta ekleme işlemi gerçekleşti. Yazdırmak için bir tuşa basın.");
                    string cevap = Console.ReadLine();
                    if (cevap != null)
                    {
                        Console.Clear();
                        Console.WriteLine("Hasta Bilgileri");
                        Console.WriteLine("______________________________");
                        hastane.Yazdir();
                        hasta.Yazdir();
                        Console.WriteLine("Hasta bilgileri görüntülendi. [A] Ana menüye dönün / [Ç] Çıkış yapın.");
                        string cevap2 = Console.ReadLine().ToUpper();
                        if (cevap2[0] == 'A')
                        {
                            Main(args);
                        }
                        else if (cevap[0] == 'Ç')
                        {
                            Environment.Exit(0);
                        }
                    }
                }
                else if (islem == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Doktor Ekleme");
                    Console.WriteLine("______________________________");
                    Hastane hastane = new Hastane();
                    HastaneCalisanlari hastaneCalisanlari = new HastaneCalisanlari();
                    Doktor doktor = new Doktor();
                    hastane.Ekle();
                    hastaneCalisanlari.Ekle();
                    doktor.Ekle();
                    Console.WriteLine("Doktor ekleme işlemi gerçekleşti. Yazdırmak için bir tuşa basın.");
                    string cevap = Console.ReadLine();
                    if (cevap != null)
                    {
                        Console.Clear();
                        Console.WriteLine("Doktor Bilgileri");
                        Console.WriteLine("______________________________");
                        hastane.Yazdir();
                        hastaneCalisanlari.Yazdir();
                        doktor.Yazdir();
                        Console.WriteLine("Maaş: "+doktor.maasHesapla(Convert.ToUInt16(doktor.EkGosterge)));
                        Console.WriteLine("Doktor bilgileri görüntülendi. [A] Ana menüye dönün / [Ç] Çıkış yapın.");
                        string cevap2 = Console.ReadLine().ToUpper();
                        if (cevap2[0] == 'A')
                        {
                            Main(args);
                        }
                        else if (cevap[0] == 'Ç')
                        {
                            Environment.Exit(0);
                        }
                    }

                }
                else if (islem == 3)
                {
                    Console.Clear();
                    Console.WriteLine("Hastane Ekleme");
                    Console.WriteLine("______________________________");
                    Hastane hastane = new Hastane();
                    hastane.Ekle();
                    Console.WriteLine("Hastane ekleme işlemi gerçekleşti. Yazdırmak için bir tuşa basın.");
                    string cevap = Console.ReadLine();
                    if (cevap != null)
                    {
                        Console.Clear();
                        Console.WriteLine("Hastane Bilgileri");
                        Console.WriteLine("______________________________");
                        hastane.Yazdir();
                        Console.WriteLine("Hastane bilgileri görüntülendi. [A] Ana menüye dönün / [Ç] Çıkış yapın.");
                        string cevap2 = Console.ReadLine().ToUpper();
                        if (cevap2[0] == 'A')
                        {
                            Main(args);
                        }
                        else if (cevap[0] == 'Ç')
                        {
                            Environment.Exit(0);
                        }
                    }
                }
                else if (islem == 4)
                {
                    Console.Clear();
                    Console.WriteLine("Hastane Çalışanları Ekleme");
                    Console.WriteLine("______________________________");
                    Hastane hastane = new Hastane();
                    HastaneCalisanlari hastaneCalisanlari = new HastaneCalisanlari();
                    hastane.Ekle();
                    hastaneCalisanlari.Ekle();
                    Console.WriteLine("Hastane çalışanları ekleme işlemi gerçekleşti. Yazdırmak için bir tuşa basın.");
                    string cevap = Console.ReadLine();
                    if (cevap != null)
                    {
                        Console.Clear();
                        Console.WriteLine("Hastane Çalışan Bilgileri");
                        Console.WriteLine("______________________________");
                        hastane.Yazdir();
                        hastaneCalisanlari.Yazdir();
                        Console.WriteLine("Hastane çalışan bilgileri görüntülendi. [A] Ana menüye dönün / [Ç] Çıkış yapın.");
                        string cevap2 = Console.ReadLine().ToUpper();
                        if (cevap2[0] == 'A')
                        {
                            Main(args);
                        }
                        else if (cevap[0] == 'Ç')
                        {
                            Environment.Exit(0);
                        }
                    }
                }
                else if (islem == 5)
                {
                    Environment.Exit(0);
                }
            }
            catch
            {
                Console.Write("Girilen bilgilerde tutarsızlık algılandı.");
                string unnamed = Console.ReadLine();
                if (unnamed != null)
                {
                    Environment.Exit(0);
                    //Main(args);
                }
            }

        }
    }
    class Hastane
    {
        public int Tc { get; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Cinsiyet { get; set; }

        public ArrayList hastaneList = new ArrayList();

        public Hastane() { }
        public Hastane(int tc, string ad, string soyad, string cinsiyet)
        {
            Tc = tc;
            Ad = ad;
            Soyad = soyad;
            Cinsiyet = cinsiyet;
        }
        public virtual void Ekle()
        {
            try
            {
                Console.Write("Ad: ");
                Ad = Console.ReadLine();
                Console.Write("Soyad: ");
                Soyad = Console.ReadLine();
                Console.Write("Cinsiyet: ");
                Cinsiyet = Console.ReadLine();
                hastaneList.Add(this);
            }
            catch
            {
                /* Veri uyuşmazlığında gerçekleşmesi planan kodlar */
                Console.Clear();
                Hastane h = new Hastane();
                h.Ekle();
            }
        }
        public virtual void Yazdir()
        {
            Console.WriteLine($"Ad: {Ad}");
            Console.WriteLine($"Soyad: {Soyad}");
            Console.WriteLine($"Cinsiyet: {Cinsiyet}");
        }
    }
    class Hasta : Hastane
    {
        public DateTime YatisTarih { get; set; }
        public string Polikinlik { get; set; }
        public Hasta() { }
        public Hasta(DateTime yatisTarih, string polikinlik)
        {
            YatisTarih = yatisTarih;
            Polikinlik = polikinlik;
        }
        public override void Ekle()
        {
            Console.Write("Yatış Tarihi[YYYY-MM-DD]: ");
            YatisTarih = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Polikinlik: ");
            Polikinlik = Console.ReadLine();
            hastaneList.Add(this);
        }
        public override void Yazdir()
        {
            Console.WriteLine($"Yatış Tarihi: {YatisTarih}");
            Console.WriteLine($"Polikinlik: {Polikinlik}");
        }
    }
    class HastaneCalisanlari : Hastane
    {
        public int SicilNo { get; }
        public int EkGosterge { get; set; }
        public string Departman { get; set; }
        public HastaneCalisanlari() { }
        public HastaneCalisanlari(int sicilNo, int ekGosterge, string departman)
        {
            SicilNo = sicilNo;
            EkGosterge = ekGosterge;
            Departman = departman;
        }
        public override void Ekle()
        {
            Console.Write("Ek Gösterge: ");
            EkGosterge = Convert.ToInt16(Console.ReadLine());
            Console.Write("Departman: ");
            Departman = Console.ReadLine();
            hastaneList.Add(this);
        }
        public override void Yazdir()
        {
            Console.WriteLine($"Ek Gösterge: {EkGosterge}");
            Console.WriteLine($"Departman: {Departman}");
        }
    }
    class Doktor:HastaneCalisanlari
    {
        public double DiplomaNot { get; }
        public string Brans { get; set; }
        public Doktor() { }
        public Doktor(double diplomaNot, string brans)
        {
            DiplomaNot = diplomaNot;
            Brans = brans;
        }
        public override void Ekle()
        {
            Console.Write("Branş: ");
            Brans = Console.ReadLine();
            hastaneList.Add(this);
        }
        public uint maasHesapla(uint ekgosterge)
        {
            uint maas = 0;
            if (ekgosterge <= 1500) { maas = 15000; }
            else if (ekgosterge > 1500 && ekgosterge <= 2200) { maas = 20000; }
            else if (ekgosterge > 2200 && ekgosterge <= 3000) { maas = 30000; }
            else if (ekgosterge > 3000 && ekgosterge <= 3600) { maas = 40000; }
            else maas = 50000;
            return maas;
        }
    }
}
