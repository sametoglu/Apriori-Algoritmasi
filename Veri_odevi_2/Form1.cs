using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Veri_odevi_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //string elma, yumurta, simit, muz,  erik;
        double sayacelma, sayacyumurta, sayacsimit, sayacmuz,  sayacerik;
        double elmadestek, simitdestek, muzdestek, erikdestek, yumurtadestek;
        int islemsayac=1;
        double toplam_fis_sayisi;
        //int toplam_nesne_sayisi = 5;
        string [] nesneler;

        double min_destek;
        double min_guven;

        Dictionary<string, double> nesneler1 = new Dictionary<string, double>();
        Dictionary<string, double> nesneler2 = new Dictionary<string, double>();
        Dictionary<string, double> nesneler3 = new Dictionary<string, double>();
        Dictionary<string, double> nesneler4 = new Dictionary<string, double>();
        Dictionary<string, double> nesneler6 = new Dictionary<string, double>();


        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-C97083V;Initial Catalog=dbproje;Integrated Security=True");

        public void fonk_ilktarama()
        {
            baglan.Open();

            SqlDataAdapter data_tablo = new SqlDataAdapter("SELECT * from veri_odevi_apriori ", baglan);
            DataTable tbl_tablo = new DataTable();
            data_tablo.Fill(tbl_tablo);

            SqlDataAdapter data_tablogetir = new SqlDataAdapter("SELECT count(*) from veri_odevi_apriori ", baglan);
            DataTable tbl_tablogetir = new DataTable();
            data_tablogetir.Fill(tbl_tablogetir);

            toplam_fis_sayisi = Convert.ToInt32(tbl_tablogetir.Rows[0][0]);

            //data_tablo.Fill(tbl_tablo);

            string nesnesayisi = "";

            for (int i = 0; i < toplam_fis_sayisi; i++)
            {
                //MessageBox.Show(toplam_fis_sayisi.ToString());

                nesnesayisi = tbl_tablo.Rows[i][1].ToString();

                //MessageBox.Show(nesnesayisi);

                nesneler = nesnesayisi.Split(',');

                for (int j = 0; j < nesneler.Length; j++)
                {
                    switch (nesneler[j])
                    {
                        case "elma":
                            sayacelma++;
                            elmadestek = Math.Round((sayacelma / toplam_fis_sayisi), 2);
                            break;
                        case "yumurta":
                            sayacyumurta++;
                            yumurtadestek = Math.Round((sayacyumurta / toplam_fis_sayisi), 2);
                            break;
                        case "simit":
                            sayacsimit++;
                            simitdestek = Math.Round((sayacsimit / toplam_fis_sayisi), 2);
                            break;
                        case "erik":
                            sayacerik++;
                            erikdestek = Math.Round((sayacerik / toplam_fis_sayisi), 2);
                            break;
                        case "muz":
                            sayacmuz++;
                            muzdestek = Math.Round((sayacmuz / toplam_fis_sayisi), 2);
                            break;
                    }


                }

            }

            lb1.Items.Add("elma " + elmadestek);
            lb1.Items.Add("muz " + muzdestek);
            lb1.Items.Add("simit " + simitdestek);
            lb1.Items.Add("yumurta " + yumurtadestek);
            lb1.Items.Add("erik " + erikdestek);



            baglan.Close();


        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            min_destek = Convert.ToDouble(nud_destek.Value) / 100;
            min_guven = Convert.ToDouble(nud_guven.Value) / 100;

            sayacelma=0;
            sayacyumurta = 0; 
            sayacsimit=0;
            sayacmuz=0;
            sayacerik = 0;
            elmadestek = 0;
            simitdestek = 0; 
            muzdestek = 0 ;
            erikdestek = 0;
            yumurtadestek = 0;
            islemsayac = 1;
            nesneler=null;

            nesneler1.Clear();
            nesneler2.Clear();
            nesneler3.Clear();
            nesneler4.Clear();
            nesneler6.Clear();

            lb1.Items.Clear();
            lb2.Items.Clear();
            lb3.Items.Clear();
            lb4.Items.Clear();
            lb5.Items.Clear();
            lb_yorum.Items.Clear();


            fonk_ilktarama();



            if (elmadestek >= min_destek)
            {
                nesneler1.Add("elma", elmadestek);
                //lb2.Items.Add("elma "+nesneler1.ElementAt(0).Value.ToString());
            }
            if (muzdestek >= min_destek)
            {
                nesneler1.Add("muz", muzdestek);
                //lb2.Items.Add("muz " + nesneler1.ElementAt(1).Value.ToString());
            }
            if (simitdestek >= min_destek)
            {
                nesneler1.Add("simit", simitdestek);
                //lb2.Items.Add("simit " + nesneler1.ElementAt(2).Value.ToString());
            }
            if (yumurtadestek >= min_destek)
            {
                nesneler1.Add("yumurta", yumurtadestek);
                //lb2.Items.Add("yumurta " + nesneler1.ElementAt(3).Value.ToString());
            }
            if (erikdestek >= min_destek)
            {
                nesneler1.Add("erik", erikdestek);
                //lb2.Items.Add("erik " + nesneler1.ElementAt(4).Value.ToString());
            }
            islemsayac++;

            fonk_nesnesay(nesneler1);


        }

        public void fonk_nesnesay(Dictionary<string, double> nesneler1)
        {
            if (nesneler1.Count == 1)
            {
                MessageBox.Show("işlem bitti");
                fonk_yorumla(nesneler1);
            }
            else
            {
                if (islemsayac == 2)
                {
                    int sayi = (fakt(nesneler1.Count) / (fakt(islemsayac) * fakt(nesneler1.Count - islemsayac)));
                    if (sayi == 1)
                    {
                        SqlDataAdapter data_getir = new SqlDataAdapter("select count(*) from veri_odevi_apriori where sepet like '%" +
                                                                                       nesneler1.ElementAt(0).Key.ToString() + "%' and sepet like '%" +
                                                                                       nesneler1.ElementAt(1).Key.ToString() + "%'", baglan);
                        DataTable tbl_getir = new DataTable();
                        data_getir.Fill(tbl_getir);
                        if ((Convert.ToDouble(tbl_getir.Rows[0][0]) / toplam_fis_sayisi) < min_destek)
                        {
                            MessageBox.Show("cevap destek yuzdesi min.destekten dusuk cıkacaktır.");
                        }

                        nesneler2.Add((nesneler1.ElementAt(0).Key.ToString() + "," + nesneler1.ElementAt(1).Key.ToString()), Math.Round((Convert.ToDouble(tbl_getir.Rows[0][0]) / toplam_fis_sayisi),2));

                        lb2.Items.Add(nesneler1.ElementAt(0).Key.ToString() + "," + nesneler1.ElementAt(1).Key.ToString() +  Math.Round((Convert.ToDouble(tbl_getir.Rows[0][0]) / toplam_fis_sayisi),2));

                        tbl_getir.Clear();

                        baglan.Close();
                        fonk_yorumla(nesneler2);//fonk_nesnesay(nesneler2, islemsayac);//islemsayac gitmesine gerek yok
                    }
                    else
                    {
                        if (sayi % 2 == 0)
                        {
                            for (int i = 0; i < sayi / 2; i++)
                            {
                                for (int j = 1; j < sayi / 2; j++)
                                {

                                    if (i == j || i > j)
                                    {
                                        continue;
                                    }
                                    

                                    else
                                    {

                                        try
                                        {
                                            SqlDataAdapter data_getir = new SqlDataAdapter("select count(*) from veri_odevi_apriori where sepet like '%" +
                                                                                       nesneler1.ElementAt(i).Key.ToString() + "%' and sepet like '%" +
                                                                                       nesneler1.ElementAt(j + i).Key.ToString() + "%'", baglan);
                                            DataTable tbl_getir = new DataTable();
                                            data_getir.Fill(tbl_getir);

                                            if ((Convert.ToDouble(tbl_getir.Rows[0][0]) / toplam_fis_sayisi) >= min_destek)
                                            {
                                                nesneler2.Add((nesneler1.ElementAt(i).Key.ToString() + "," + nesneler1.ElementAt(j + i).Key.ToString()), Math.Round((Convert.ToDouble(tbl_getir.Rows[0][0]) / toplam_fis_sayisi), 2));

                                                lb2.Items.Add(nesneler1.ElementAt(i).Key.ToString() + "," + nesneler1.ElementAt(j + i).Key.ToString() + Math.Round((Convert.ToDouble(tbl_getir.Rows[0][0]) / toplam_fis_sayisi), 2));

                                            }
                                            tbl_getir.Clear();

                                        }
                                        catch (Exception)
                                        {
                                        }

                                    }
                                }
                            }
                            baglan.Close();
                            islemsayac++;
                            fonk_nesnesay(nesneler2);//fonk_nesnesay(nesneler2, islemsayac);//islemsayac gitmesine gerek yok
                        }

                        else
                        {
                            for (int i = 0; i <= sayi / 2; i++)
                            {

                                for (int j = 1; j < sayi; j++)
                                {

                                    //if (i == 1 && j == 2)
                                    //{
                                    //    continue;
                                    //}

                                    //else
                                    //{


                                    try 
	                                    {	        
		                                    SqlDataAdapter data_getir = new SqlDataAdapter("select count(*) from veri_odevi_apriori where sepet like '%" +
                                                                                        nesneler1.ElementAt(i).Key.ToString() + "%' and sepet like '%" +
                                                                                        nesneler1.ElementAt(j + i).Key.ToString() + "%'", baglan);
                                            DataTable tbl_getir = new DataTable();
                                            data_getir.Fill(tbl_getir);

                                            if ((Convert.ToDouble(tbl_getir.Rows[0][0]) / toplam_fis_sayisi) >= min_destek)
                                            {
                                                nesneler2.Add((nesneler1.ElementAt(i).Key.ToString() + "," + nesneler1.ElementAt(j).Key.ToString()),  Math.Round((Convert.ToDouble(tbl_getir.Rows[0][0]) / toplam_fis_sayisi),2));

                                                lb2.Items.Add(nesneler1.ElementAt(i).Key.ToString() + "," + nesneler1.ElementAt(j + i).Key.ToString() +  Math.Round((Convert.ToDouble(tbl_getir.Rows[0][0]) / toplam_fis_sayisi),2));

                                            }

                                            tbl_getir.Clear();

	                                    }
	                                    catch (Exception)
	                                    {

                                            
	                                    }
                                        
                                    //}
                                }
                            }
                            baglan.Close();
                            islemsayac++;
                            fonk_nesnesay(nesneler2);
                        }
                    }
                }
                else if (islemsayac == 3)
                {

                    tarama(nesneler1);

                    int sayi = (fakt(nesneler6.Count) / (fakt(islemsayac) * fakt(nesneler6.Count - islemsayac)));

                    if (sayi == 1)
                    {


                        SqlDataAdapter data_getir = new SqlDataAdapter("select count(*) from veri_odevi_apriori where sepet like '%" +
                                                                        nesneler6.ElementAt(0).Key.ToString() + "%' and sepet like '%" +
                                                                        nesneler6.ElementAt(1).Key.ToString() + "%'and sepet like '%" +
                                                                        nesneler6.ElementAt(2).Key.ToString() + "%'", baglan);
                        DataTable tbl_getir = new DataTable();
                        data_getir.Fill(tbl_getir);
                        if ((Convert.ToDouble(tbl_getir.Rows[0][0]) / toplam_fis_sayisi) < min_destek)
                        {
                            MessageBox.Show("cevap destek yuzdesi min.destekten dusuk cıkacaktır.");
                        }
                        nesneler3.Add((nesneler6.ElementAt(0).Key.ToString() + "," +
                                       nesneler6.ElementAt(1).Key.ToString() + "," +
                                       nesneler6.ElementAt(2).Key.ToString()), Math.Round((Convert.ToDouble(tbl_getir.Rows[0][0]) / toplam_fis_sayisi), 2));

                        lb3.Items.Add(nesneler6.ElementAt(0).Key.ToString() + "," +
                                       nesneler6.ElementAt(1).Key.ToString() + "," +
                                       nesneler6.ElementAt(2).Key.ToString() + Math.Round((Convert.ToDouble(tbl_getir.Rows[0][0]) / toplam_fis_sayisi), 2));


                        tbl_getir.Clear();

                        baglan.Close();
                        fonk_yorumla(nesneler3);//fonk_nesnesay(nesneler2, islemsayac);//islemsayac gitmesine gerek yok
                    }
                    else
                    {

                        tarama(nesneler1);
                        sayi = (fakt(nesneler6.Count) / (fakt(islemsayac) * fakt(nesneler6.Count - islemsayac)));

                        for (int i = 0; i < sayi / nesneler6.Count; i++)
                            {
                                for (int j = 1; j <= sayi / nesneler6.Count; j++)
                                {
                                    for (int k = 2; k < 4; k++)
                                    {
                                        if (i ==  j || j==k )
                                        {
                                            continue;
                                        }
                                        

                                        else
                                        {
                                            try
                                            {
                                                SqlDataAdapter data_getir = new SqlDataAdapter("select count(*) from veri_odevi_apriori where sepet like '%" +
                                                                                            nesneler6.ElementAt(i).Key.ToString() + "%' and sepet like '%" +
                                                                                            nesneler6.ElementAt(j).Key.ToString() + "%' and sepet like '%" +
                                                                                            nesneler6.ElementAt(k).Key.ToString() + "%'", baglan);
                                                DataTable tbl_getir = new DataTable();
                                                data_getir.Fill(tbl_getir);

                                                if ((Convert.ToDouble(tbl_getir.Rows[0][0]) / toplam_fis_sayisi) >= min_destek)
                                                {
                                                    nesneler3.Add((nesneler6.ElementAt(i).Key.ToString() + "," + nesneler6.ElementAt(j).Key.ToString() + "," + nesneler6.ElementAt(k).Key.ToString()), Math.Round((Convert.ToDouble(tbl_getir.Rows[0][0]) / toplam_fis_sayisi), 2));

                                                    lb3.Items.Add(nesneler6.ElementAt(i).Key.ToString() + "," + nesneler6.ElementAt(j).Key.ToString() + "," + nesneler6.ElementAt(k).Key.ToString() + Math.Round((Convert.ToDouble(tbl_getir.Rows[0][0]) / toplam_fis_sayisi), 2));
                                                }
                                                tbl_getir.Clear();
                                            }
                                            catch (Exception)
                                            {
                                            }
                                                
                                        }
                                    }
                                }
                            }

                            baglan.Close();
                            islemsayac++;
                            fonk_nesnesay(nesneler3);//fonk_nesnesay(nesneler2, islemsayac);//islemsayac gitmesine gerek yok
                        }
                }
                else if (islemsayac == 4)
                {
                    tarama(nesneler1);

                    int sayi = (fakt(nesneler6.Count) / (fakt(islemsayac) * fakt(nesneler6.Count - islemsayac)));

                    if (sayi == 1)
                    {
                        
                        SqlDataAdapter data_getir = new SqlDataAdapter("select count(*) from veri_odevi_apriori where sepet like '%" +
                                                                        nesneler6.ElementAt(0).Key.ToString() + "%' and sepet like '%" +
                                                                        nesneler6.ElementAt(1).Key.ToString() + "%' and sepet like '%" +
                                                                        nesneler6.ElementAt(2).Key.ToString() + "%' and sepet like '%" +
                                                                        nesneler6.ElementAt(3).Key.ToString() + "%'", baglan);
                        DataTable tbl_getir = new DataTable();
                        data_getir.Fill(tbl_getir);



                        if ((Convert.ToDouble(tbl_getir.Rows[0][0]) / toplam_fis_sayisi) < min_destek)
                        {
                            MessageBox.Show("cevap destek yuzdesi min.destekten dusuk cıkacaktır.");
                        }
                        nesneler4.Add((nesneler6.ElementAt(0).Key.ToString() + "," +
                                       nesneler6.ElementAt(1).Key.ToString() + "," +
                                       nesneler6.ElementAt(2).Key.ToString() + "," +
                                       nesneler6.ElementAt(3).Key.ToString()), Math.Round((Convert.ToDouble(tbl_getir.Rows[0][0]) / toplam_fis_sayisi), 2));

                        lb4.Items.Add((nesneler6.ElementAt(0).Key.ToString() + "," +
                                       nesneler6.ElementAt(1).Key.ToString() + "," +
                                       nesneler6.ElementAt(2).Key.ToString() + "," +
                                       nesneler6.ElementAt(3).Key.ToString() + Math.Round((Convert.ToDouble(tbl_getir.Rows[0][0]) / toplam_fis_sayisi), 2)));

                        tbl_getir.Clear();

                        baglan.Close();
                        fonk_yorumla(nesneler4);//fonk_nesnesay(nesneler2, islemsayac);//islemsayac gitmesine gerek yok
                    }
                    else
                    {


                        tarama(nesneler1);

                        sayi = (fakt(nesneler6.Count) / (fakt(islemsayac) * fakt(nesneler6.Count - islemsayac)));


                        for (int i = 0; i < sayi; i++)
                        {
                            for (int j = 0; j < sayi; j++)
                            {
                                for (int k = 0; k < sayi; k++)
                                {
                                    for (int t = 0; t < sayi; t++)
                                    {


                                        if (i == j || j == k || k==t || t==i)
                                        {
                                            continue;
                                        }


                                        else
                                        {
                                            try
                                            {
                                                SqlDataAdapter data_getir = new SqlDataAdapter("select count(*) from veri_odevi_apriori where sepet like '%" +
                                                                                            nesneler6.ElementAt(i).Key.ToString() + "%' and sepet like '%" +
                                                                                            nesneler6.ElementAt(j).Key.ToString() + "%' and sepet like '%" +
                                                                                            nesneler6.ElementAt(k).Key.ToString() + "%' and sepet like '%" +
                                                                                            nesneler6.ElementAt(t).Key.ToString() + "%'", baglan);
                                                DataTable tbl_getir = new DataTable();
                                                data_getir.Fill(tbl_getir);

                                                if ((Convert.ToDouble(tbl_getir.Rows[0][0]) / toplam_fis_sayisi) >= min_destek)
                                                {
                                                    nesneler4.Add((nesneler6.ElementAt(i).Key.ToString() + "," + nesneler6.ElementAt(j).Key.ToString() + "," + nesneler6.ElementAt(k).Key.ToString() + "," +nesneler6.ElementAt(t).Key.ToString()), Math.Round((Convert.ToDouble(tbl_getir.Rows[0][0]) / toplam_fis_sayisi), 2));

                                                    lb4.Items.Add(( nesneler6.ElementAt(i).Key.ToString() + "," + 
                                                                    nesneler6.ElementAt(j).Key.ToString() + "," + 
                                                                    nesneler6.ElementAt(k).Key.ToString() + "," + 
                                                                    nesneler6.ElementAt(t).Key.ToString() + Math.Round((Convert.ToDouble(tbl_getir.Rows[0][0]) / toplam_fis_sayisi), 2)));
                                                }
                                                tbl_getir.Clear();
                                            }
                                            catch (Exception)
                                            {
                                            }

                                        }
                                    }

                                }
                            }
                        }
                        baglan.Close();
                        fonk_yorumla(nesneler4);//fonk_nesnesay(nesneler2, islemsayac);//islemsayac gitmesine gerek yok
                    }
                }
            }
        }


        public void fonk_yorumla(Dictionary<string, double> nesneler5)
        {
                string eleman = nesneler5.ElementAt(0).Key.ToString();
                string[] elemanlar = eleman.Split(',');



                MessageBox.Show("yorumlanıyor");
            
                if (elemanlar.Length == 2)
                {
                                    try
                                    {
                                        if (Math.Round((nesneler2.ElementAt(0).Value / nesneler1[elemanlar[0]]), 2) >= min_guven)
                                        {
                                            lb_yorum.Items.Add(elemanlar[0].ToString() + " alanlar , " +
                                                               elemanlar[1].ToString() + "alır.  " + " destek = " +
                                                               nesneler5.ElementAt(0).Value + ", guven = " + Math.Round((nesneler2.ElementAt(0).Value / nesneler1[elemanlar[0]]), 2));
                                        }
                                        
                                        if (Math.Round((nesneler2.ElementAt(0).Value / nesneler1[elemanlar[1]]), 2) >= min_guven)
                                        {
                                            lb_yorum.Items.Add(elemanlar[1].ToString() + " alanlar , " +
                                                               elemanlar[0].ToString() + "alır.  " + " destek = " +
                                                               nesneler5.ElementAt(0).Value + ", guven = " + Math.Round((nesneler2.ElementAt(0).Value / nesneler1[elemanlar[1]]), 2));
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        MessageBox.Show("min.guvenden dusuk");
                                    }
                        
                    
                }
                else if (elemanlar.Length == 3)
                {

                                    try
                                    {
                                        if (Math.Round((nesneler5.ElementAt(0).Value / nesneler1[elemanlar[0]]), 2) >= min_guven)
                                        {
                                            lb_yorum.Items.Add(elemanlar[0].ToString() + " alanlar , " +
                                                                   elemanlar[1].ToString() + " ve " + elemanlar[2].ToString() + " alır.  " + " destek = " +
                                                                   nesneler5.ElementAt(0).Value + ", guven = " + Math.Round((nesneler5.ElementAt(0).Value / nesneler1[elemanlar[0]]), 2));
                                        }
                                        if (Math.Round((nesneler5.ElementAt(0).Value / nesneler1[elemanlar[1]]), 2) >= min_guven)
                                        {

                                            lb_yorum.Items.Add(elemanlar[1].ToString() + " alanlar , " +
                                                               elemanlar[0].ToString() + " ve " + elemanlar[2].ToString() + " alır.  " + " destek = " +
                                                               nesneler5.ElementAt(0).Value + ", guven = " + Math.Round((nesneler5.ElementAt(0).Value / nesneler1[elemanlar[1]]), 2));
                                        }
                                        if (Math.Round((nesneler5.ElementAt(0).Value / nesneler1[elemanlar[2]]), 2) >= min_guven)
                                        {

                                            lb_yorum.Items.Add(elemanlar[2].ToString() + " alanlar , " +
                                                               elemanlar[0].ToString() + " ve " + elemanlar[1].ToString() + " alır.  " + " destek = " +
                                                               nesneler5.ElementAt(0).Value + ", guven = " + Math.Round((nesneler5.ElementAt(0).Value / nesneler1[elemanlar[2]]), 2));
                                        }
                                        if (Math.Round((nesneler5.ElementAt(0).Value / nesneler2[elemanlar[1] + "," + elemanlar[2]]), 2) >= min_guven)
                                        {
                                            lb_yorum.Items.Add(elemanlar[1].ToString() + " ve  " +
                                                               elemanlar[2].ToString() + " alanlar , " + elemanlar[0].ToString() + " alır.  " + " destek = " +
                                                               nesneler5.ElementAt(0).Value + ", guven = " + Math.Round((nesneler5.ElementAt(0).Value / nesneler2[elemanlar[1] + "," + elemanlar[2]]), 2));
                                        }
                                        if (Math.Round((nesneler5.ElementAt(0).Value / nesneler2[elemanlar[0] + "," + elemanlar[1]]), 2) >= min_guven)
                                        {
                                            lb_yorum.Items.Add(elemanlar[0].ToString() + " ve  " +
                                                               elemanlar[1].ToString() + " alanlar , " + elemanlar[2].ToString() + " alır.  " + " destek = " +
                                                               nesneler5.ElementAt(0).Value + ", guven = " + Math.Round((nesneler5.ElementAt(0).Value / nesneler2[elemanlar[0] + "," + elemanlar[1]]), 2));
                                        }
                                        if (Math.Round((nesneler5.ElementAt(0).Value / nesneler2[elemanlar[0] + "," + elemanlar[2]]), 2) >= min_guven)
                                        {
                                            lb_yorum.Items.Add(elemanlar[0].ToString() + " ve  " +
                                                               elemanlar[2].ToString() + " alanlar , " + elemanlar[1].ToString() + " alır.  " + " destek = " +
                                                               nesneler5.ElementAt(0).Value + ", guven = " + Math.Round((nesneler5.ElementAt(0).Value / nesneler2[elemanlar[0] + "," + elemanlar[2]]), 2));
                                        }

                                    }
                                    catch (Exception)
                                    {
                                        MessageBox.Show("min.guvenden dusuk");
                                    }
                    
                        
                }
                else if (elemanlar.Length == 4)
                {
                    /*1 yorumlar*/

                                    try
                                    {
                                        if (Math.Round((nesneler5.ElementAt(0).Value / nesneler1[elemanlar[0]]), 2) >= min_guven)
                                        {
                                            lb_yorum.Items.Add(elemanlar[0].ToString() + " alanlar , " +
                                                                   elemanlar[1].ToString() + " ve " + elemanlar[2].ToString() + " ve " + elemanlar[3].ToString() + " alır.  " + " destek = " +
                                                                   nesneler5.ElementAt(0).Value + ", guven = " + Math.Round((nesneler5.ElementAt(0).Value / nesneler1[elemanlar[0]]), 2));
                                        }
                                        if (Math.Round((nesneler5.ElementAt(0).Value / nesneler1[elemanlar[1]]), 2) >= min_guven)
                                        {

                                            lb_yorum.Items.Add(elemanlar[1].ToString() + " alanlar , " +
                                                               elemanlar[0].ToString() + " ve " + elemanlar[2].ToString() + " ve " + elemanlar[3].ToString() + " alır.  " + " destek = " +
                                                               nesneler5.ElementAt(0).Value + ", guven = " + Math.Round((nesneler5.ElementAt(0).Value / nesneler1[elemanlar[1]]), 2));
                                        }
                                        if (Math.Round((nesneler5.ElementAt(0).Value / nesneler1[elemanlar[2]]), 2) >= min_guven)
                                        {

                                            lb_yorum.Items.Add(elemanlar[2].ToString() + " alanlar , " +
                                                               elemanlar[0].ToString() + " ve " + elemanlar[1].ToString() + " ve " + elemanlar[3].ToString() + " alır.  " + " destek = " +
                                                               nesneler5.ElementAt(0).Value + ", guven = " + Math.Round((nesneler5.ElementAt(0).Value / nesneler1[elemanlar[2]]), 2));
                                        }
                                        if (Math.Round((nesneler5.ElementAt(0).Value / nesneler1[elemanlar[3]]), 2) >= min_guven)
                                        {
                                            lb_yorum.Items.Add(elemanlar[3].ToString() + " alanlar , " +
                                                               elemanlar[0].ToString() + " ve " + elemanlar[1].ToString() + " ve " + elemanlar[2].ToString() + " alır.  " + " destek = " +
                                                               nesneler5.ElementAt(0).Value + ", guven = " + Math.Round((nesneler5.ElementAt(0).Value / nesneler1[elemanlar[3]]), 2));
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        MessageBox.Show("min.guvenden dusuk");
                                    }
                                    
                    /*3 yorumlar*/

                                    try
                                    {
                                        try
                                        {
                                        if (Math.Round((nesneler5.ElementAt(0).Value / nesneler3[elemanlar[1] + "," + elemanlar[2] + "," + elemanlar[3]]), 2) >= min_guven)
                                        {
                                            lb_yorum.Items.Add(elemanlar[1].ToString() + " ve  " + elemanlar[2].ToString() + " ve " + elemanlar[3].ToString() + " alanlar , " +
                                                                   elemanlar[0].ToString() + " alır.  " + " destek = " +
                                                                   nesneler5.ElementAt(0).Value + ", guven = " + Math.Round((nesneler5.ElementAt(0).Value / nesneler3[elemanlar[1] + "," + elemanlar[2] + "," + elemanlar[3]]), 2));
                                        }
                                        }
                                        catch (Exception)
                                        {
                                        }
                                      
                                        try 
	                                    {	        
		                                    if (Math.Round((nesneler5.ElementAt(0).Value / nesneler3[elemanlar[0] + "," + elemanlar[1] + "," + elemanlar[2]]), 2) >= min_guven)
                                            {
                                               lb_yorum.Items.Add(elemanlar[0].ToString() + " ve  " + elemanlar[1].ToString() + " ve " + elemanlar[2].ToString() + " alanlar , " +
                                                                    elemanlar[3].ToString() + " alır.  " + " destek = " +
                                                                    nesneler5.ElementAt(0).Value + ", guven = " + Math.Round((nesneler5.ElementAt(0).Value / nesneler3[elemanlar[0] + "," + elemanlar[1] + "," + elemanlar[2]]), 2));
                                        }
	                                    }
	                                    catch (Exception)
	                                    {
	                                    }
                                        try 
	                                    {	        
		                                    if (Math.Round((nesneler5.ElementAt(0).Value / nesneler3[elemanlar[0] + "," + elemanlar[1] + "," + elemanlar[3]]), 2) >= min_guven)
                                        {
                                            lb_yorum.Items.Add(elemanlar[0].ToString() + " ve  " + elemanlar[1].ToString() + " ve " + elemanlar[3].ToString() + " alanlar , " +
                                                                   elemanlar[2].ToString() + " alır.  " + " destek = " +
                                                                   nesneler5.ElementAt(0).Value + ", guven = " + Math.Round((nesneler5.ElementAt(0).Value / nesneler3[elemanlar[0] + "," + elemanlar[1] + "," + elemanlar[3]]), 2));
                                        }
	                                    }
	                                    catch (Exception)
	                                    {
	                                    }
                                        try 
	                                    {	        
		                                    if (Math.Round((nesneler5.ElementAt(0).Value / nesneler3[elemanlar[0] + "," + elemanlar[2] + "," + elemanlar[3]]), 2) >= min_guven)
                                        {
                                            lb_yorum.Items.Add(elemanlar[0].ToString() + " ve  " + elemanlar[2].ToString() + " ve " + elemanlar[3].ToString() + " alanlar , " +
                                                                   elemanlar[1].ToString() + " alır.  " + " destek = " +
                                                                   nesneler5.ElementAt(0).Value + ", guven = " + Math.Round((nesneler5.ElementAt(0).Value / nesneler3[elemanlar[0] + "," + elemanlar[2] + "," + elemanlar[3]]), 2));
                                        }
	                                    }
	                                    catch (Exception)
	                                    {
	                                    }
                                    }
                                    catch (Exception)
                                    {
                                        MessageBox.Show("min.guvenden dusuk");
                                    }


                    /*2x2 yorumlar*/

                                    try
                                    {
                                        try
                                        {
                                            if (Math.Round((nesneler5.ElementAt(0).Value / nesneler2[elemanlar[0] + "," + elemanlar[1]]), 2) >= min_guven)
                                            {
                                                lb_yorum.Items.Add(elemanlar[0].ToString() + " ve  " + elemanlar[1].ToString() + " alanlar , " +
                                                                       elemanlar[2].ToString() + " ve " + elemanlar[3].ToString() + " alır.  " + " destek = " +
                                                                       nesneler5.ElementAt(0).Value + ", guven = " + Math.Round((nesneler5.ElementAt(0).Value / nesneler2[elemanlar[0] + "," + elemanlar[1]]), 2));
                                            }
                                        }
                                        catch (Exception)
                                        {
                                        }
                                        try
                                        {
                                            if (Math.Round((nesneler5.ElementAt(0).Value / nesneler2[elemanlar[0] + "," + elemanlar[2]]), 2) >= min_guven)
                                            {
                                                lb_yorum.Items.Add(elemanlar[0].ToString() + " ve  " + elemanlar[2].ToString() + " alanlar , " +
                                                                       elemanlar[1].ToString() + " ve " + elemanlar[3].ToString() + " alır.  " + " destek = " +
                                                                       nesneler5.ElementAt(0).Value + ", guven = " + Math.Round((nesneler5.ElementAt(0).Value / nesneler2[elemanlar[0] + "," + elemanlar[2]]), 2));
                                            }
                                        }
                                        catch (Exception)
                                        {
                                        } try
                                        {
                                            if (Math.Round((nesneler5.ElementAt(0).Value / nesneler2[elemanlar[0] + "," + elemanlar[3]]), 2) >= min_guven)
                                            {
                                                lb_yorum.Items.Add(elemanlar[0].ToString() + " ve  " + elemanlar[3].ToString() + " alanlar , " +
                                                                       elemanlar[1].ToString() + " ve " + elemanlar[2].ToString() + " alır.  " + " destek = " +
                                                                       nesneler5.ElementAt(0).Value + ", guven = " + Math.Round((nesneler5.ElementAt(0).Value / nesneler2[elemanlar[0] + "," + elemanlar[3]]), 2));
                                            }
                                        }
                                        catch (Exception)
                                        {
                                        } try
                                        {
                                            if (Math.Round((nesneler5.ElementAt(0).Value / nesneler2[elemanlar[1] + "," + elemanlar[2]]), 2) >= min_guven)
                                            {
                                                lb_yorum.Items.Add(elemanlar[1].ToString() + " ve  " + elemanlar[2].ToString() + " alanlar , " +
                                                                       elemanlar[0].ToString() + " ve " + elemanlar[3].ToString() + " alır.  " + " destek = " +
                                                                       nesneler5.ElementAt(0).Value + ", guven = " + Math.Round((nesneler5.ElementAt(0).Value / nesneler2[elemanlar[1] + "," + elemanlar[2]]), 2));
                                            }
                                        }
                                        catch (Exception)
                                        {
                                        } try
                                        {
                                            if (Math.Round((nesneler5.ElementAt(0).Value / nesneler2[elemanlar[1] + "," + elemanlar[3]]), 2) >= min_guven)
                                            {
                                                lb_yorum.Items.Add(elemanlar[1].ToString() + " ve  " + elemanlar[3].ToString() + " alanlar , " +
                                                                       elemanlar[0].ToString() + " ve " + elemanlar[2].ToString() + " alır.  " + " destek = " +
                                                                       nesneler5.ElementAt(0).Value + ", guven = " + Math.Round((nesneler5.ElementAt(0).Value / nesneler2[elemanlar[1] + "," + elemanlar[3]]), 2));
                                            }
                                        }
                                        catch (Exception)
                                        {
                                        } try
                                        {
                                            if (Math.Round((nesneler5.ElementAt(0).Value / nesneler2[elemanlar[2] + "," + elemanlar[3]]), 2) >= min_guven)
                                            {
                                                lb_yorum.Items.Add(elemanlar[2].ToString() + " ve  " + elemanlar[3].ToString() + " alanlar , " +
                                                                       elemanlar[0].ToString() + " ve " + elemanlar[2].ToString() + " alır.  " + " destek = " +
                                                                       nesneler5.ElementAt(0).Value + ", guven = " + Math.Round((nesneler5.ElementAt(0).Value / nesneler2[elemanlar[2] + "," + elemanlar[3]]), 2));
                                            }
                                        }
                                        catch (Exception)
                                        {
                                        }
                                       }
                                        catch (Exception)
                                        {
                                            MessageBox.Show("min.guvenden dusuk");
                                        }
                                    
                                    
                                    
                                
                }
                else { MessageBox.Show("hatalı"); }
            
                
        }

        public int fakt(int sayi)
        {
            int fak = 1;
            for (int i = 1; i <= sayi; i++)
			{
			    fak=fak*i;
			}
            return fak;
        }


        public void tarama(Dictionary<string, double> nesneler1)
        {
            nesneler6.Clear();
            sayacelma = 0;
            sayacmuz = 0;
            sayacsimit = 0;
            sayacyumurta = 0;
            sayacerik = 0;

            string nesnesayisi = "";
            for (int i = 0; i < nesneler1.Count; i++)
            {
                nesnesayisi = nesneler1.ElementAt(i).Key.ToString();
                nesneler = nesnesayisi.Split(',');

                for (int j = 0; j < nesneler.Length; j++)
                {
                    switch (nesneler[j])
                    {
                        case "elma":
                            sayacelma++;
                            break;
                        case "muz":
                            sayacmuz++;
                            break;
                        case "simit":
                            sayacsimit++;
                            break;
                        case "yumurta":
                            sayacyumurta++;
                            break;
                        case "erik":
                            sayacerik++;
                            break;
                    }
                }
            }
            if (sayacelma > 0) { nesneler6.Add("elma", sayacelma); }
            if (sayacmuz > 0) { nesneler6.Add("muz", sayacmuz); }
            if (sayacsimit > 0) { nesneler6.Add("simit", sayacsimit); }
            if (sayacyumurta > 0) { nesneler6.Add("yumurta", sayacyumurta); }
            if (sayacerik > 0) { nesneler6.Add("erik", sayacerik); }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            baglan.Open();

            SqlDataAdapter data_tablo = new SqlDataAdapter("SELECT * from veri_odevi_apriori ", baglan);
            DataTable tbl_tablo = new DataTable();
            data_tablo.Fill(tbl_tablo);

            dgv_tablo.DataSource = tbl_tablo;



            baglan.Close();

        }
    } 
}
