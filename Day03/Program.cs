using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        //Console.Write("Bir sayı girin: ");
        //int number = int.Parse(Console.ReadLine());
        //Console.WriteLine($"Rakamların toplamı: {RakamlarToplami(number)}");

        //Console.Write("10 ile 100 arasında bir sayı girin: ");
        //Console.WriteLine("Geçerli sayı girdiniz: " + KullaniciSayiAl());

        //YasKategorisi();
        //TekrarEdenElemanlar();
        //EnUzunVeEnKisaKelime();
        //CumleyiSirala();
        //ListeyiGenislet();
        //KelimeleriTersYazdir();
        //RastgeleSayilar();
        //ListedenKucukleriSil();
        //NotlariGuncelle();
    }

    static int RakamlarToplami(int number)
    {
        int sum = 0;
        while (number > 0)
        {
            sum += number % 10;
            number /= 10;
        }
        return sum;
    }

    static int KullaniciSayiAl()
    {
        int input;
        do
        {
            input = int.Parse(Console.ReadLine());
        } while (input < 10 || input > 100);
        return input;
    }

    static void YasKategorisi()
    {
        int[] yaslar = { 5, 15, 25, 70 };
        foreach (int yas in yaslar)
        {
            string kategori = "";
            if (yas <= 12) kategori = "Çocuk";
            else if (yas <= 19) kategori = "Genç";
            else if (yas <= 64) kategori = "Yetişkin";
            else kategori = "Yaşlı";
            Console.WriteLine($"Yaş: {yas}, Kategori: {kategori}");
        }
    }

    static void TekrarEdenElemanlar()
    {
        int[] numbers = { 1, 2, 3, 4, 2, 5, 3, 6 };
        List<int> checkedNumbers = new List<int>();
        List<int> duplicates = new List<int>();

        foreach (int num in numbers)
        {
            if (checkedNumbers.Contains(num) && !duplicates.Contains(num))
            {
                duplicates.Add(num);
            }
            else
            {
                checkedNumbers.Add(num);
            }
        }

        Console.Write("Tekrar eden sayılar: ");
        foreach (var num in duplicates)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
    }

    static void EnUzunVeEnKisaKelime()
    {
        string[] words = { "elma", "armut", "çilek", "karpuz" };
        string enUzun = words[0], enKisa = words[0];

        foreach (string word in words)
        {
            if (word.Length > enUzun.Length) enUzun = word;
            if (word.Length < enKisa.Length) enKisa = word;
        }

        Console.WriteLine($"En uzun: {enUzun}, En kısa: {enKisa}");
    }

    static void CumleyiSirala()
    {
        Console.Write("Bir cümle girin: ");
        string cumle = Console.ReadLine();
        string[] kelimeler = cumle.Split(' ');
        Array.Sort(kelimeler);
        Console.WriteLine("Alfabetik sıralı: " + string.Join(" ", kelimeler));
    }

    static void ListeyiGenislet()
    {
        List<string> liste = new List<string> { "elma", "armut" };
        liste.Add("çilek");
        liste.Add("muz");
        Console.WriteLine("Genişletilmiş liste: " + string.Join(", ", liste));
    }

    static void KelimeleriTersYazdir()
    {
        Console.Write("Bir cümle girin: ");
        string cumle = Console.ReadLine();  // Read input from user
        string[] kelimeler = cumle.Split(' ');  // Split sentence into words
        Array.Reverse(kelimeler);  // Reverse the array of words
        Console.WriteLine("Ters sıralı cümle: " + string.Join(" ", kelimeler));  // Join words back and print
    }


    static void RastgeleSayilar()
    {
        List<int> sayilar = new List<int>();
        Random rnd = new Random();
        for (int i = 0; i < 5; i++)
        {
            sayilar.Add(rnd.Next(1, 100));
        }
        sayilar.Sort();
        double ortalama = sayilar.Average();
        Console.WriteLine("Sıralı sayılar: " + string.Join(", ", sayilar) + $" Ortalama: {ortalama}");
    }

    static void ListedenKucukleriSil()
    {
        List<int> sayilar = new List<int> { 5, 15, 3, 20, 8, 25 };
        sayilar.RemoveAll(sayi => sayi < 10);
        Console.WriteLine("Güncellenmiş liste: " + string.Join(", ", sayilar));
    }

    static void NotlariGuncelle()
    {
        List<int> notlar = new List<int> { 45, 60, 30, 90, 75 };
        for (int i = 0; i < notlar.Count; i++)
        {
            if (notlar[i] < 50)
            {
                notlar[i] = 50;
            }
        }
        Console.Write("Güncellenmiş notlar: ");
        foreach (var not in notlar)
        {
            Console.Write(not + " ");
        }
        Console.WriteLine();
    }
}