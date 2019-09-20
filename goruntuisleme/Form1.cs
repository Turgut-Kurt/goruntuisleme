using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace goruntuisleme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OpenFileDialog dosyaAc = new OpenFileDialog();
        Bitmap GirisResmi;
        Bitmap CikisResmi;
        private void BtnMenuDosyaAc_Click(object sender, EventArgs e)
        {
            yeniDosyaAc();
            BtnTB2Negatif.Enabled = true;
            BtnTB2GriTon.Enabled = true;
            BtnTB2Aynalama.Enabled = true;
            BtnTB2TersCevirme.Enabled = true;
            BtnTB2SepyaDonusumu.Enabled = true;
            BtnTB2Esikleme.Enabled = true;
            BtnTB2Parlaklik50.Enabled = true;
            BtnTB2KarsitlikEksi.Enabled = true;
            BtnTB2KarsitlikArti.Enabled = true;
            BtnTBKaydet.Enabled = true;
            BtnTBEkraniTemizle.Enabled = true;
            filtrelerToolStripMenuItem.Enabled = true;
            döndürmeToolStripMenuItem.Enabled = true;
        }

        private void BtnTBDosyaAC_Click(object sender, EventArgs e)
        {
            yeniDosyaAc();
            BtnTB2Negatif.Enabled = true;
            BtnTB2GriTon.Enabled = true;
            BtnTB2Aynalama.Enabled = true;
            BtnTB2TersCevirme.Enabled = true;
            BtnTB2SepyaDonusumu.Enabled = true;
            BtnTB2Esikleme.Enabled = true;
            BtnTB2Parlaklik50.Enabled = true;
            BtnTB2KarsitlikEksi.Enabled = true;
            BtnTB2KarsitlikArti.Enabled = true;
            BtnTBKaydet.Enabled = true;
            BtnTBEkraniTemizle.Enabled = true;
            filtrelerToolStripMenuItem.Enabled = true;
            BtnTBDondurme15.Enabled = true;
            döndürmeToolStripMenuItem.Enabled = true;
        }
        public void yeniDosyaAc()
        {
            try
            {

                dosyaAc.DefaultExt = ".jpg";
                dosyaAc.Filter = "Image Files(*.BMP;*.JPG;*.Png)|*.BMP;*.JPG;*.Png|All files (*.*)|*.*";
                dosyaAc.ShowDialog();
                String ResimYolu = dosyaAc.FileName;
                PctrBxSol.Image = Image.FromFile(ResimYolu);
                GirisResmi = new Bitmap(ResimYolu);
            }
            catch { }
        }
        public void ResmiKaydet()
        {
            SaveFileDialog dosyaKaydet = new SaveFileDialog();
            dosyaKaydet.Filter = "Jpeg Resmi|*.jpg|Bitmap Resmi|*.bmp|Gif Resmi|*.gif";
            dosyaKaydet.Title = "Resmi Kaydet";
            dosyaKaydet.ShowDialog();
            if (dosyaKaydet.FileName != "") //Dosya adı boş değilse kaydedecek.
            {
                // FileStream nesnesi ile kayıtı gerçekleştirecek.
                FileStream DosyaAkisi = (FileStream)dosyaKaydet.OpenFile();
                switch (dosyaKaydet.FilterIndex)
                {
                    case 1:
                        PctrBxSag.Image.Save(DosyaAkisi, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    case 2:
                        PctrBxSag.Image.Save(DosyaAkisi, System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                    case 3:
                        PctrBxSag.Image.Save(DosyaAkisi, System.Drawing.Imaging.ImageFormat.Png);
                        break;
                }
                DosyaAkisi.Close();
            }
        }

        private void BtnTBKaydet_Click(object sender, EventArgs e)
        {
            ResmiKaydet();
        }

        private void BtnMenuKaydet_Click(object sender, EventArgs e)
        {
            ResmiKaydet();
        }

        private void BtnMenuCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public Bitmap ResminNegatifiniAl()
        {
            Color OkunanRenk, DonusenRenk;
            int yeniR = 0, yeniG = 0, yeniB = 0;
            int ResimGenisligi = GirisResmi.Width; //GirisResmi global tanımlandı. İçerisine görüntü yüklendi.
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi); //Cikis resmini oluşturuyor. Boyutları giriş resmi ile aynı olur.Tanımlaması globalde yapıldı.
            int yeniX = 0, yeniY = 0; //Çıkış resminin x ve y si olacak.
            for (int x = 0; x < ResimGenisligi; x++)
            {
                yeniY = 0;
                for (int y = 0; y < ResimYuksekligi; y++, yeniY++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x, y);
                    yeniR = 255 - OkunanRenk.R;
                    yeniG = 255 - OkunanRenk.G;
                    yeniB = 255 - OkunanRenk.B;
                    DonusenRenk = Color.FromArgb(yeniR, yeniG, yeniB);
                    CikisResmi.SetPixel(yeniX, yeniY, DonusenRenk);
                }
                yeniX++;
            }
            return CikisResmi;
        }

        private void BtnTB2Negatif_Click(object sender, EventArgs e)
        {
            PctrBxSag.Image = ResminNegatifiniAl();
        }

        private void BtnMenuNegatif_Click(object sender, EventArgs e)
        {
            PctrBxSag.Image = ResminNegatifiniAl();
        }

        private void filtrelerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void BtnTB2GriTon_Click(object sender, EventArgs e)
        {
            PctrBxSag.Image = ResmiGriTonaDonustur();
        }
        public Bitmap ResmiGriTonaDonustur()
        {
            Color OkunanRenk, DonusenRenk;
            int yeniR = 0, yeniG = 0, yeniB = 0;
            int ResimGenisligi = GirisResmi.Width; 
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
            int yeniX = 0, yeniY = 0;
            for (int x = 0; x < ResimGenisligi; x++)
            {
                yeniY = 0;
                for (int y = 0; y < ResimYuksekligi; y++, yeniY++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x, y);
                    int GriDegeri = Convert.ToInt16(OkunanRenk.R * 0.299 + OkunanRenk.G * 0.587 + OkunanRenk.B * 0.114);
                    //Gri-ton formülü
                    yeniR = GriDegeri;
                    yeniG = GriDegeri;
                    yeniB = GriDegeri;
                    DonusenRenk = Color.FromArgb(yeniR, yeniG, yeniB);
                    CikisResmi.SetPixel(yeniX, yeniY, DonusenRenk);
                }
                yeniX++;
            }
            return CikisResmi;
        }

        private void BtnMenuGriTon_Click(object sender, EventArgs e)
        {
            PctrBxSag.Image = ResmiGriTonaDonustur();
        }
        public Bitmap Aynalama()
        {
            Color OkunanRenk;
            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
            int yeniX = 0, yeniY = 0;
            /*for (int y = 0; y < ResimYuksekligi; y++)
            {
                for (int x = 0, rx = ResimGenisligi - 1; x < ResimGenisligi; x++, rx--)
                {
                    Color c1 = GirisResmi.GetPixel(x, y);
                    CikisResmi.SetPixel(rx, y, c1);
                }
            }*/
            yeniX = ResimGenisligi - 1;
            for (int x = 0; x < ResimGenisligi; x++)
            {
                yeniY = 0;
                for (int y = 0; y < ResimYuksekligi; y++, yeniY++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x, y);
                    CikisResmi.SetPixel(yeniX, yeniY, OkunanRenk);
                }
                yeniX--;
            }
            return CikisResmi;
        }

        private void BtnMenuAynalama_Click(object sender, EventArgs e)
        {
            PctrBxSag.Image = Aynalama();
        }

        private void BtnTB2Aynalama_Click(object sender, EventArgs e)
        {
            PctrBxSag.Image = Aynalama();
        }
        public Bitmap TersCevirme()
        {
            Color OkunanRenk;
            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
            int yeniX = 0, yeniY = 0;
            for (int x = 0; x < ResimGenisligi; x++)
            {
                yeniY = ResimYuksekligi - 1;
                for (int y = 0; y < ResimYuksekligi; y++, yeniY--)
                {
                    OkunanRenk = GirisResmi.GetPixel(x, y);
                    CikisResmi.SetPixel(yeniX, yeniY, OkunanRenk);
                }
                yeniX++;
            }
            return CikisResmi;
        }

        private void BtnTB2TersCevirme_Click(object sender, EventArgs e)
        {
            PctrBxSag.Image = TersCevirme();
        }

        private void BtnMenuTersCevirme_Click(object sender, EventArgs e)
        {
            PctrBxSag.Image = TersCevirme();
        }
        public Bitmap SepyaDonusumu()
        {
            Color OkunanRenk;
            int yeniR = 0, yeniG = 0, yeniB = 0;
            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
            for (int x = 0; x < ResimGenisligi; x++)
            {
                for (int y = 0; y < ResimYuksekligi; y++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x, y);
                    yeniR = OkunanRenk.R;
                    yeniG = OkunanRenk.G;
                    yeniB = OkunanRenk.B;
                    int sepyaRed = (byte)(.393 * yeniR + .769 * yeniG + .189 * yeniB);
                    int sepyaGreen = (byte)(.349 * yeniR + .686 * yeniG + .168 * yeniB);
                    int sepyaBlue = (byte)(.272 * yeniR + .534 * yeniG + .131 * yeniB);
                    if (yeniR > 200 || yeniR == 255)
                    {
                        yeniR = 254;
                    }
                    else { yeniR = sepyaRed; }
                    if (yeniG > 200 || yeniR == 255)
                    {
                        yeniG = 254;
                    }
                    else { yeniG = sepyaGreen; }
                    if (yeniB > 200 || yeniR == 255)
                    {
                        yeniB = 254;
                    }
                    else { yeniB = sepyaBlue; }
                    CikisResmi.SetPixel(x, y, Color.FromArgb(yeniR, yeniG, yeniB));
                }
            }
            return CikisResmi;
        }

        private void BtnTB2SepyaDonusumu_Click(object sender, EventArgs e)
        {
            PctrBxSag.Image = SepyaDonusumu();
        }

        private void BtnMenuSepyaDonusumu_Click(object sender, EventArgs e)
        {
            PctrBxSag.Image = SepyaDonusumu();
        }
        public Bitmap EsiklemeYap()
        {
            Color OkunanRenk, DonusenRenk;
            int yeniR = 0, yeniG = 0, yeniB = 0;
            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
            int yeniX = 0, yeniY = 0; 
            for (int x = 0; x < ResimGenisligi; x++)
            {
                yeniY = 0;
                for (int y = 0; y < ResimYuksekligi; y++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x, y);
                    if (OkunanRenk.R >= 128)
                        yeniR = 255;
                    else
                        yeniR = 0;
                    if (OkunanRenk.G >= 128)
                        yeniG = 255;
                    else
                        yeniG = 0;
                    if (OkunanRenk.B >= 128)
                        yeniB = 255;
                    else
                        yeniB = 0;
                    DonusenRenk = Color.FromArgb(yeniR, yeniG, yeniB);
                    CikisResmi.SetPixel(yeniX, yeniY, DonusenRenk);
                    yeniY++;
                }
                yeniX++;
            }
            return CikisResmi;
        }
        private void BtnTB2Esikleme_Click(object sender, EventArgs e)
        {
            PctrBxSag.Image = EsiklemeYap();
        }

        private void BtnMenuEsikleme_Click(object sender, EventArgs e)
        {
            PctrBxSag.Image = EsiklemeYap();
        }
        public Bitmap ResminParlakliginiDegistir()
        {
            int yeniR = 0, yeniG = 0, yeniB = 0;
            Color OkunanRenk, DonusenRenk;
            int ResimGenisligi = GirisResmi.Width; 
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi); 
            int yeniX = 0, yeniY = 0; 
            for (int x = 0; x < ResimGenisligi; x++)
            {
                yeniY = 0;
                for (int y = 0; y < ResimYuksekligi; y++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x, y);
                    //Rengini 50 değeri ile açacak.
                    yeniR = OkunanRenk.R + 50;
                    yeniG = OkunanRenk.G + 50;
                    yeniB = OkunanRenk.B + 50;
                    //Renkler 255 geçtiyse son sınır olan 255 alınacak.
                    if (yeniR > 255) yeniR = 255;
                    if (yeniG > 255) yeniG = 255;
                    if (yeniB > 255) yeniB = 255;
                    DonusenRenk = Color.FromArgb(yeniR, yeniG, yeniB);
                    CikisResmi.SetPixel(yeniX, yeniY, DonusenRenk);
                    yeniY++;
                }
                yeniX++;
            }
            return CikisResmi;
        }

        private void BtnTB2Parlaklik50_Click(object sender, EventArgs e)
        {
            PctrBxSag.Image = ResminParlakliginiDegistir();
        }

        private void BtnMenuParlaklik50_Click(object sender, EventArgs e)
        {
            PctrBxSag.Image = ResminParlakliginiDegistir();
        }
        public Bitmap Karsitlik(int g)
        {
            int yeniR = 0, yeniG = 0, yeniB = 0;
            Color OkunanRenk, DonusenRenk;
            int ResimGenisligi = GirisResmi.Width; 
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi); 
            double KontrastSeviyesi = g;
            double KontrastFaktoru = (259 * (KontrastSeviyesi + 255)) / (255 * (259 - KontrastSeviyesi));
            int yeniX = 0, yeniY = 0; 
            for (int x = 0; x < ResimGenisligi; x++)
            {
                yeniY = 0;
                for (int y = 0; y < ResimYuksekligi; y++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x, y);
                    yeniR = OkunanRenk.R;
                    yeniG = OkunanRenk.G;
                    yeniB = OkunanRenk.B;
                    yeniR = (int)((KontrastFaktoru * (yeniR - 128)) + 128);
                    yeniG = (int)((KontrastFaktoru * (yeniG - 128)) + 128);
                    yeniB = (int)((KontrastFaktoru * (yeniB - 128)) + 128);
                    //Renkler sınırların dışına çıktıysa, sınır değer alınacak.
                    if (yeniR > 255) yeniR = 255;
                    if (yeniG > 255) yeniG = 255;
                    if (yeniB > 255) yeniB = 255;
                    if (yeniR < 0) yeniR = 0;
                    if (yeniG < 0) yeniG = 0;
                    if (yeniB < 0) yeniB = 0;
                    DonusenRenk = Color.FromArgb(yeniR, yeniG, yeniB);
                    CikisResmi.SetPixel(yeniX, yeniY, DonusenRenk);
                    yeniY++;
                }
                yeniX++;
            }
            return CikisResmi;
        }

        private void BtnTB2Karsitlik_Click(object sender, EventArgs e)
        {
            int a = -128;
            PctrBxSag.Image =Karsitlik(a);
        }

        private void BtnMenuKarsitlikEksi128_Click(object sender, EventArgs e)
        {
            int a = -128;
            PctrBxSag.Image = Karsitlik(a);
        }

        private void BtnTB2KarsitlikArti_Click(object sender, EventArgs e)
        {
            int a = +128;
            PctrBxSag.Image = Karsitlik(a);
        }

        private void BtnMenuKarsitlikArti128_Click(object sender, EventArgs e)
        {
            int a = +128;
            PctrBxSag.Image = Karsitlik(a);
        }

        private void BtnTBCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnTBEkraniTemizle_Click(object sender, EventArgs e)
        {
            Bitmap varsayilan= new Bitmap(700, 600);
            PctrBxSol.Image = varsayilan;
            PctrBxSag.Image = varsayilan;
            BtnTB2Negatif.Enabled = false;
            BtnTB2GriTon.Enabled = false;
            BtnTB2Aynalama.Enabled = false;
            BtnTB2TersCevirme.Enabled = false;
            BtnTB2SepyaDonusumu.Enabled = false;
            BtnTB2Esikleme.Enabled = false;
            BtnTB2Parlaklik50.Enabled = false;
            BtnTB2KarsitlikEksi.Enabled = false;
            BtnTB2KarsitlikArti.Enabled = false;
            BtnTBKaydet.Enabled = false;
            BtnTBEkraniTemizle.Enabled = false;
            filtrelerToolStripMenuItem.Enabled = false;
            döndürmeToolStripMenuItem.Enabled = false;
        }
               public Bitmap Dondurme_Alias(int q)
        {
            Color OkunanRenk;
            Bitmap GirisResmi, CikisResmi;
            GirisResmi = new Bitmap(PctrBxSol.Image);
            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
            int Aci = q;
            double RadyanAci = Aci * 2 * Math.PI / 360;
            double x2 = 0, y2 = 0;
            //Resim merkezini buluyor. Resim merkezi etrafında döndürecek.
            int x0 = ResimGenisligi / 2;
            int y0 = ResimYuksekligi / 2;
            for (int x1 = 0; x1 < (ResimGenisligi); x1++)
            {
                for (int y1 = 0; y1 < (ResimYuksekligi); y1++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x1, y1);
                    //Aliaslı Döndürme -Sağa Kaydırma
                    x2 = (x1 - x0) - Math.Tan(RadyanAci / 2) * (y1 - y0) + x0;
                    y2 = (y1 - y0) + y0;
                    x2 = Convert.ToInt16(x2);
                    y2 = Convert.ToInt16(y2);
                    //Aliaslı Döndürme -Aşağı kaydırma
                    x2 = (x2 - x0) + x0;
                    y2 = Math.Sin(RadyanAci) * (x2 - x0) + (y2 - y0) + y0;
                    x2 = Convert.ToInt16(x2);
                    y2 = Convert.ToInt16(y2);
                    //Aliaslı Döndürme -Sağa Kaydırma
                    x2 = (x2 - x0) - Math.Tan(RadyanAci / 2) * (y2 - y0) + x0;
                    y2 = (y2 - y0) + y0;
                    x2 = Convert.ToInt16(x2);
                    y2 = Convert.ToInt16(y2);
                    if (x2 > 0 && x2 < ResimGenisligi && y2 > 0 && y2 < ResimYuksekligi)
                        CikisResmi.SetPixel((int)x2, (int)y2, OkunanRenk);
                }
            }
            return CikisResmi;
        }
        private void BtnTBDondurme15_Click(object sender, EventArgs e)
        {
            int a = 135;
            PctrBxSag.Image = Dondurme_Alias(a);
        }

        private void BtnMenuDondurmea30_Click(object sender, EventArgs e)
        {
            int a = 30;
            PctrBxSag.Image = Dondurme_Alias(a);
        }

        private void BtnMenuDondurmea60_Click(object sender, EventArgs e)
        {
            int a = 60;
            PctrBxSag.Image = Dondurme_Alias(a);
        }

        private void BtnMenuDondurmea90_Click(object sender, EventArgs e)
        {
            int a = 90;
            PctrBxSag.Image = Dondurme_Alias(a);
        }

        private void BtnMenuDondurmea120_Click(object sender, EventArgs e)
        {
            int a = 120;
            PctrBxSag.Image = Dondurme_Alias(a);
        }

        private void yönde30DereceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int a = -30;
            PctrBxSag.Image = Dondurme_Alias(a);
        }

        private void dosyaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void yönde60DereceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int a = -60;
            PctrBxSag.Image = Dondurme_Alias(a);
        }

        private void yönde90DereceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int a = -90;
            PctrBxSag.Image = Dondurme_Alias(a);
        }

        private void yönde120DereceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int a = -120;
            PctrBxSag.Image = Dondurme_Alias(a);
        }

        private void tersDöndürmeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PctrBxSag.Image = TersCevirme();
        }

        private void BtnTBTemizle_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
