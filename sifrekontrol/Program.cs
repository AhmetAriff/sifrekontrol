

using System;


namespace NDP_ODEV1
{
    class Program
    {
        class Sifre
        {

            public static string sifre;
            public static int KucukHarf()//kucuk harf sayisini hesaplayan fonksiyon
            {
                int kucukHarfSayisi = 0;

                for (int i = 0; i < sifre.Length; i++)//sifrenin boyutu kadar dönüyor
                {
                    if (char.IsLower(sifre[i]))//sifrenin icinde kucuk harf varsa kucuk harf sayisini bir arttir
                    {
                        kucukHarfSayisi++;
                    }
                }

                return kucukHarfSayisi;
            }

            public static int BuyukHarf()//buyuk harf sayisini hesaplayan fonskiyon
            {
                int buyukHarfSayisi = 0;


                for (int i = 0; i < sifre.Length; i++)//sifrenin boyutu kadar dönüyor
                {
                    if (char.IsUpper(sifre[i]))//sifrenin icinde buyuk harf varsa kucuk harf sayisini bir arttir
                    {
                        buyukHarfSayisi++;
                    }
                }

                return buyukHarfSayisi;
            }

            public static int Rakam()//rakam sayisini hesaplıyor
            {
                int rakamSayisi = 0;

                for (int i = 0; i < sifre.Length; i++)//sifrenin boyutu kadar dönüyor
                {
                    if (char.IsDigit(sifre[i]))//sifrenin icinde rakam varsa kucuk harf sayisini bir arttır
                    {
                        rakamSayisi++;
                    }
                }

                return rakamSayisi;
            }

            public static int Sembol()//sembol sayisini hesaplıyor
            {
                int sembolSayisi = 0;

                for (int i = 0; i < sifre.Length; i++)//rakam sayisini hesaplıyor
                {
                    if (!(char.IsDigit(sifre[i]) || char.IsLower(sifre[i]) || char.IsUpper(sifre[i])))////sifrenin icinde buyuk kucuk harf rakam harici bir sey varsa (Sembol) sembol sayisini bir arttir
                    {
                        sembolSayisi++;
                    }
                }

                return sembolSayisi;
            }

            public static bool Bosluk()//sifrede bosluk olup olamdigini kontrol eden fonksiyon
            {
                bool boslukKontrol = true;

                for (int i = 0; i < sifre.Length; i++)//sifrenin boyutu kadar donuyor
                {
                    if (char.IsWhiteSpace(sifre[i]))//sifrenin icinde bosluk varsa boslukkontrol degiskenine false degerini atiyor
                    {
                        boslukKontrol = false;
                    }
                }

                if (boslukKontrol == true)
                { return true; }

                else
                { return false; }
            }

            public static int KucukBuyukHarfRakamPuanHesaplayici(int kucukbuyukharfrakamsayisi)//parametre olarak kucukharf buyukharf ve rakam aliyor ve puan hesabi yapiyor 
            {
                if (kucukbuyukharfrakamsayisi == 0)
                { return 0; }

                else if (kucukbuyukharfrakamsayisi == 1)
                { return 10; }

                else
                { return 20; }
            }
        }


        static void Main(string[] args)
        {
            char secim;

            do
            {

                Console.WriteLine("LÜTFEN OLUŞTURMAK İSTEDİĞİNİZ ŞİFREYİ GİRİNİZ :");

                Sifre.sifre = Console.ReadLine();
                int kucukHarfSayisi = Sifre.KucukHarf();
                int buyukHarfSayisi = Sifre.BuyukHarf();
                int rakamSayisi = Sifre.Rakam();
                int sembolSayisi = Sifre.Sembol();
                bool boslukVarmi = Sifre.Bosluk();
                int kucukHarfPuani = Sifre.KucukBuyukHarfRakamPuanHesaplayici(kucukHarfSayisi);
                int buyukHarfPuani = Sifre.KucukBuyukHarfRakamPuanHesaplayici(buyukHarfSayisi);
                int rakamPuani = Sifre.KucukBuyukHarfRakamPuanHesaplayici(rakamSayisi);
                int sembolPuani = sembolSayisi * 10;//kullanilan her sembol icin 10 puan
                int genelPuan = kucukHarfPuani + buyukHarfPuani + rakamPuani + sembolPuani;

                if (boslukVarmi)
                {

                    if (Sifre.sifre.Length >= 9)//sifrenin boyutu eger 9 veya 9tan buyukse
                    {
                        if (Sifre.sifre.Length == 9)//sifernin boyutu 9 a esitse 10 puan ekle
                        {
                            genelPuan += 10;
                        }

                        if (kucukHarfSayisi > 0 && buyukHarfSayisi > 0 && rakamSayisi > 0 && sembolSayisi > 0)//sifrede buyuk kucuk harf rakam ve sembol kullanildiysa
                        {

                            if (genelPuan < 70)//genel puan 70den kucukse
                            {
                                Console.WriteLine("ŞİFRENİZ KABUL EDİLMEDİ.ŞİFRENİZ GÜVENLİ DEĞİL YENİ BİR ŞİFRE OLUŞTURNUZ.");
                                Console.WriteLine("KULLANILAN KUCUKHARF SAYISI {0}", kucukHarfSayisi);
                                Console.WriteLine("KULLANILAN BUYUKHARF SAYISI {0}", buyukHarfSayisi);
                                Console.WriteLine("KULLANILAN RAKAM SAYISI {0}", rakamSayisi);
                                Console.WriteLine("KULLANILAN SEMBOL SAYISI {0}", sembolSayisi);
                            }

                            else if (genelPuan >= 70 && genelPuan <= 90)//genel puan 70 ile 90 arasındaysa
                            {
                                Console.WriteLine("ŞİFRENİZ KABUL EDİLDİ.ŞİFRENİZ GÜVENLİ FAKAT ÇOK GÜÇLÜ DEĞİL.");
                                Console.WriteLine("KULLANILAN KUCUKHARF SAYISI {0}", kucukHarfSayisi);
                                Console.WriteLine("KULLANILAN BUYUKHARF SAYISI {0}", buyukHarfSayisi);
                                Console.WriteLine("KULLANILAN RAKAM SAYISI {0}", rakamSayisi);
                                Console.WriteLine("KULLANILAN SEMBOL SAYISI {0}", sembolSayisi);
                            }

                            else//genel puan 90 ve uzeri ise
                            {
                                Console.WriteLine("ŞİFRENİZ KABUL EDİLDİ.ŞİFRENİZ ÇOK GÜÇLÜ.TEBRİKLER.");
                                Console.WriteLine("KULLANILAN KUCUKHARF SAYISI {0}", kucukHarfSayisi);
                                Console.WriteLine("KULLANILAN BUYUKHARF SAYISI {0}", buyukHarfSayisi);
                                Console.WriteLine("KULLANILAN RAKAM SAYISI {0}", rakamSayisi);
                                Console.WriteLine("KULLANILAN SEMBOL SAYISI {0}", sembolSayisi);
                            }

                        }
                        else//eger sifrede en az 1 adet buyuk kucuk harf rakam ve sembol kullanilmazsa
                        {
                            Console.WriteLine("ŞİFRENİZ KABUL EDİLMEDİ.OLUŞTURULAN ŞİFREDE EN AZ 1 ADET KUCUKHARF,BUYUKHARF,RAKAM,SEMBOL BULUNMALI");
                        }

                    }
                    else//sifre 9 karakterden az ize
                    {
                        Console.WriteLine("ŞİFRENİZ KABUL EDİLMEDİ.OLUŞTURULAN ŞİFRE EN AZ 9 KARAKTER OLMALI");
                    }

                }
                else//sifrede eger bosluk bulunuyorsa
                {
                    Console.WriteLine("ŞİFRENİZ KABUL EDİLMEDİ.OLUŞTURULAN ŞİFREDE BOŞLUK BULUNAMAZ");
                }

                do//bize e veya h a basmamizi zorlayan dongu
                {
                    Console.WriteLine("YENİ BİR ŞİFRE OLUŞTURMAK İÇİN 'e' ÇIKIŞ YAPMAK İÇİN 'h' YE BASINIZ");
                    secim = Convert.ToChar(Console.ReadLine());

                } while (secim != 'e' && secim != 'h');

            } while (secim == 'e');//Secim e ise yeniden bir sifre olustur 

            {
                Console.WriteLine("PROGRAMDAN BAŞARIYLA ÇIKIŞ YAPTINIZ");
            }
        }
    }
}
