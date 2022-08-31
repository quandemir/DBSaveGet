using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Data;
namespace DBSaveGet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DB x = new DB();

        bas:
            Console.WriteLine("-------------------");
            Console.WriteLine("NE YAPMAK İSTİYORSUN");
            Console.WriteLine("1--veri girmek");
            Console.WriteLine("2--isim,soyisime göre veri görmek");
            Console.WriteLine("3--veri görmek");
            Console.WriteLine("4--çıkış yapmak");
            Console.WriteLine("-------------------");
            string aa = Console.ReadLine();
            Console.WriteLine("-------------------");
            ArrayList al = new ArrayList();
            if (aa == "1")
            {
                
                try
                {
                    MySqlConnection con = new MySqlConnection("Server = localhost; Database = ogrenci; Uid = root; Pwd = 'Usmanım'; ");
                    Console.WriteLine("kaç veri girmek istiyorsunuz");
                    int deger = Convert.ToInt32(Console.ReadLine());
                    for (int i = 1; i < deger + 1; i++)
                    {
                        Ogrenci ogr = new Ogrenci();
                    b:
                        try
                        {
                            Console.WriteLine(i + ". numarasını griiniz");
                            ogr.Numara = Convert.ToInt32(Console.ReadLine());
                            con.Open();
                            string sql = "select numara  from ogrenci where numara=@x";
                            MySqlCommand cm = new MySqlCommand(sql, con);
                            cm.Parameters.AddWithValue("@x", ogr.Numara);
                            MySqlDataReader dr = cm.ExecuteReader();

                            if (dr.Read() == true)
                            {

                                Console.WriteLine(ogr.Numara + "'ya sahip öğrenci var");
                                con.Close();
                            lkl:
                                Console.WriteLine("NE YAPMAK İSTİYORSUNUZ");
                                Console.WriteLine("1--TEKRAR NUMARA GİRMEK İSTİYORUM");
                                Console.WriteLine("2--ÇIKIŞ YAPMAK İSTİYORUM ");
                                string kjk = Console.ReadLine();
                                if (kjk == "1") { goto b; }
                                else if (kjk == "2") { Environment.Exit(0); }
                                else
                                {
                                    Console.WriteLine("hatalı tuşlama");
                                    goto lkl;
                                }
                            }
                            con.Close();
                        }
                        catch (FormatException err)
                        {
                            Console.WriteLine("!!!!!!!!!!!!!!!");
                            Console.WriteLine(err.Message);
                            Console.WriteLine("!!!!!!!!!!!!!!!");
                        ssss:
                            Console.WriteLine("--------------------------");
                            Console.WriteLine("NE YAPMAK İSTİYORSUN");
                            Console.WriteLine("1--VERİLERİ TEKRAR GİRMEK");
                            Console.WriteLine("2--ÇIKIŞ YAPMAK");
                            Console.WriteLine("--------------------------");
                            string xx = Console.ReadLine();
                            if (xx == "1") { goto b; }
                            else if (xx == "2") { Environment.Exit(0); }
                            else
                            {
                                Console.WriteLine("Hatalı bir veri girdiniz...");
                                goto ssss;
                            }

                        }



                    vvv:
                        Console.WriteLine(i + ". ad griiniz");
                        ogr.Ad = Convert.ToString(Console.ReadLine());
                        if (String.IsNullOrEmpty(ogr.Ad))
                        {
                        sss:
                            Console.WriteLine("Hatalı bir veri girdiniz...");
                            Console.WriteLine("--------------------------");
                            Console.WriteLine("NE YAPMAK İSTİYORSUN");
                            Console.WriteLine("1--VERİYİ TEKRAR GİRMEK");
                            Console.WriteLine("2--ÇIKIŞ YAPMAK");
                            Console.WriteLine("--------------------------");
                            string xx = Console.ReadLine();
                            if (xx == "1") { goto vvv; }
                            else if (xx == "2") { Environment.Exit(0); }
                            else
                            {
                                Console.WriteLine("Hatalı bir veri girdiniz...");
                                goto sss;
                            }
                        }

                    vv:
                        Console.WriteLine(i + ". soyad griiniz");
                        ogr.Soyad = Convert.ToString(Console.ReadLine());
                        if (String.IsNullOrEmpty(ogr.Soyad))
                        {
                        ss:
                            Console.WriteLine("Hatalı bir veri girdiniz...");
                            Console.WriteLine("--------------------------");
                            Console.WriteLine("NE YAPMAK İSTİYORSUN");
                            Console.WriteLine("1--VERİYİ TEKRAR GİRMEK");
                            Console.WriteLine("2--ÇIKIŞ YAPMAK");
                            Console.WriteLine("--------------------------");
                            string xx = Console.ReadLine();
                            if (xx == "1") { goto vv; }
                            else if (xx == "2") { Environment.Exit(0); }
                            else
                            {
                                Console.WriteLine("Hatalı bir veri girdiniz...");
                                goto ss;
                            }
                        }
                    v:
                        Console.WriteLine(i + ". tel griiniz");
                        ogr.Telefon = Convert.ToString(Console.ReadLine());
                        if (String.IsNullOrEmpty(ogr.Telefon))
                        {
                        s:
                            Console.WriteLine("Hatalı bir veri girdiniz...");
                            Console.WriteLine("--------------------------");
                            Console.WriteLine("NE YAPMAK İSTİYORSUN");
                            Console.WriteLine("1--VERİYİ TEKRAR GİRMEK");
                            Console.WriteLine("2--ÇIKIŞ YAPMAK");
                            Console.WriteLine("--------------------------");
                            string xx = Console.ReadLine();
                            if (xx == "1") { goto v; }
                            else if (xx == "2") { Environment.Exit(0); }
                            else
                            {
                                Console.WriteLine("Hatalı bir veri girdiniz...");
                                goto s;
                            }
                        }
                        al.Add(ogr.Numara);
                        al.Add(ogr.Ad);
                        al.Add(ogr.Soyad);
                        al.Add(ogr.Telefon);
                    }
                    Console.Clear();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("bir sorun var" + ex.Message);
                }
                string sqll = "insert into ogrenci(numara,ad,soyad,telefon) values(@0,@1,@2,@3)";
                x.Save(sqll, al);
                Console.WriteLine("kayıt başarılı..");
                goto bas;
            }
            else if (aa == "2")
            {       
                string query = "select  * from ogrenci where ad=@0 and soyad=@1 limit 1";
                ArrayList ok = new ArrayList();
                ok.Clear();
                v:
                Console.Write("aranılan isimi gir:");
                string secadsoy=Console.ReadLine();
                if (String.IsNullOrEmpty(secadsoy))
                {
                s:
                    Console.WriteLine("Hatalı bir veri girdiniz...");
                    Console.WriteLine("--------------------------");
                    Console.WriteLine("NE YAPMAK İSTİYORSUN");
                    Console.WriteLine("1--VERİYİ TEKRAR GİRMEK");
                    Console.WriteLine("2--ÇIKIŞ YAPMAK");
                    Console.WriteLine("--------------------------");
                    string xx = Console.ReadLine();
                    if (xx == "1") { goto v; }
                    else if (xx == "2") { Environment.Exit(0); }
                    else
                    {
                        Console.WriteLine("Hatalı bir veri girdiniz...");
                        goto s;
                    }
                }
                ok.Add(secadsoy);
                ç:
                Console.Write("aranılan soyisimi gir:");
                secadsoy = Console.ReadLine();
                if (String.IsNullOrEmpty(secadsoy))
                {
                i:
                    Console.WriteLine("Hatalı bir veri girdiniz...");
                    Console.WriteLine("--------------------------");
                    Console.WriteLine("NE YAPMAK İSTİYORSUN");
                    Console.WriteLine("1--VERİYİ TEKRAR GİRMEK");
                    Console.WriteLine("2--ÇIKIŞ YAPMAK");
                    Console.WriteLine("--------------------------");
                    string xx = Console.ReadLine();
                    if (xx == "1") { goto ç; }
                    else if (xx == "2") { Environment.Exit(0); }
                    else
                    {
                        Console.WriteLine("Hatalı bir veri girdiniz...");
                        goto i;
                    }
                }
                ok.Add(secadsoy);
                Console.WriteLine("-----------");
                DataTable dt = new DataTable();

                dt=DB.GetDataTableWithParams(query, ok);
                Console.WriteLine("id: "+dt.Rows[0][0]);
                Console.WriteLine("numara: "+dt.Rows[0][1]);
                Console.WriteLine("ad: "+dt.Rows[0][2]);
                Console.WriteLine("soyad: "+dt.Rows[0][3]);
                Console.WriteLine("telefon numara "+dt.Rows[0][4]);
                goto bas;
            }
            else if (aa == "3") 
            {
                string queery = "select * from ogrenci";

                ArrayList alx = new ArrayList();
                
                alx=DB.GetClassWithNoParam(queery);
                    Console.WriteLine("ID ---- NUMARA ---- AD ---- SOYAD ---- TELNUMARA ----");
                for (int i=0;i<alx.Count; i+=5)
                {
                    Console.WriteLine(alx[i].ToString()+" "+ alx[i + 1].ToString() + " " + alx[i + 2].ToString() + " " + alx[i + 3].ToString() + " " + alx[i + 4].ToString());
                }
                Console.ReadLine();
                goto bas;
            }
            else if (aa == "4") { Environment.Exit(0); }
            else
            {
                Console.WriteLine("hatalı giriş yaptınız");
                goto bas;
            }

            





        } 
    }
}
