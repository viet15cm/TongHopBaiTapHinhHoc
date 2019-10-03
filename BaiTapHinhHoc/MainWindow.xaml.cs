using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BaiTapHinhHoc;
using System.IO;
using Microsoft.Win32;

namespace BaiTapHinhHoc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HinhVuong[] hinhVuongs = null;
        List<HinhTron> hinhTrons = null;
        List<float> banKinhs = null;
        List<float> canhs = null;
       

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Windown_Loaded(object sender, RoutedEventArgs e)
        {

            /* hinhVuongs = new HinhVuong[5];
             int[] canh = { 3, 5, 6, 7, 8 };
             for (int i = 0; i < hinhVuongs.Length; i++)
             {
                 hinhVuongs[i] = new HinhVuong(canh[i]);
                 listDataHinhVuong.Items.Add((i + 1).ToString() + "\t\t" + hinhVuongs[i].Canh.ToString() + "\t\t" + hinhVuongs[i].CV().ToString() + "\t\t"
                    + hinhVuongs[i].DT().ToString());
             }


             hinhTrons = new List<HinhTron>();
             int[] banKinhs = { 2, 3, 4, 5, 6 };

             foreach(int banKinh in banKinhs)
                 hinhTrons.Add(new HinhTron(banKinh));

             int count = 0;

             foreach (HinhTron hinhTron in hinhTrons)
             {
                 listDataHinhTron.Items.Add((count +1).ToString() + "\t\t" + hinhTron.Canh.ToString() + "\t\t" + hinhTron.CV().ToString() + "\t\t"
                     + hinhTron.DT().ToString());
                 count+=1;
             }
             */

            lb1.Content = "STT" + "\t\t" + "Canh" + "\t\t" + "Chu Vi" + "\t\t" + "Dien Tich";
            lb2.Content = "STT" + "\t\t" + "Ban Kinh" + "\t\t" + "Chu Vi" + "\t\t" + "Dien Tich";

            /* List<Hinh> hinh = new List<Hinh>();

             for (int i=0; i< hinhVuongs.Length; i++)
             {
                 hinh.Add(new Hinh() {STT = i , Canh = hinhVuongs[i].Canh.ToString(), CV = hinhVuongs[i].CV().ToString(), DT = hinhVuongs[i].DT().ToString() });
             }

             livDisplay.ItemsSource = hinh;
            */
        }

        class Hinh
        {
            public int STT { get; set; }
            public string Canh { get; set; }
            public string CV { get; set; }
            public string DT { get; set; }
        }



        private void Button_ClickHinhTron(object sender, RoutedEventArgs e)
        {
            readLineFileHinhTron();

            if (banKinhs != null)
            {

                listDataHinhTron.Items.Clear();
                hinhTrons = new List<HinhTron>();
                foreach (float banKinh in banKinhs)
                {
                    hinhTrons.Add(new HinhTron(banKinh));
                }

                int count = 0;
                foreach (HinhTron hinhTron in hinhTrons)
                {
                    listDataHinhTron.Items.Add((count + 1).ToString() + "\t\t" + hinhTron.Bk.ToString() + "\t\t" + hinhTron.CV().ToString() + "\t\t"
                        + hinhTron.DT().ToString());
                    count += 1;
                }
            }
            else
            {
                MessageBox.Show("There is no printout");
            }


        }

        private void Button_ClickHinhVuong(object sender, RoutedEventArgs e)
        {
            readLineFileHinhVuong();
            if (canhs != null)
            {
                hinhVuongs = new HinhVuong[canhs.Count];
                listDataHinhVuong.Items.Clear();
                for (int i = 0; i < canhs.Count; i++)
                {
                    hinhVuongs[i] = new HinhVuong(canhs[i]);
                    listDataHinhVuong.Items.Add((i + 1).ToString() + "\t\t" + hinhVuongs[i].Canh.ToString() + "\t\t" + hinhVuongs[i].CV().ToString() + "\t\t"
                       + hinhVuongs[i].DT().ToString());
                }
            }
            else
            {
                MessageBox.Show("There is no radius to print");
            }
        }

        private void saveMember_Click(object sender, RoutedEventArgs e)
        {



            if (txbCanh.Text.Equals(""))
            {
                MessageBox.Show("There is no edge on the textBox bar");
            }
            else
            {

                using (StreamWriter streamWriter = new StreamWriter((@"Filec#\HinhVuong.txt"), true))
                    {

                        streamWriter.WriteLine(txbCanh.Text);
                    }

                    MessageBox.Show("Added edge to file");
                

            }


        }

        private void saveMember_Click_1(object sender, RoutedEventArgs e)
        {
            if (txbBanKinh.Text.Equals(""))
            {
                MessageBox.Show("There is no radius on the textBox bar");
            }
            else
            {
                using (StreamWriter streamWriter = new StreamWriter(@"Filec#\HinhTron.txt", true))
                {
                    streamWriter.WriteLine(txbBanKinh.Text);
                }

                MessageBox.Show("Added radius to file");
            }

        }

        private void readLineFileHinhVuong()
        {
            using (StreamReader streamReader = new StreamReader(@"Filec#\HinhVuong.txt"))
            {
                string temp = null;
                if ((temp = streamReader.ReadLine()) != null)
                {
                    canhs = new List<float>();
                    while (true)
                    {
                        canhs.Add(float.Parse(temp));
                        if ((temp = streamReader.ReadLine()) == null)
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Empty file has no data");
                }
            }
        }

        private void readLineFileHinhTron()
        {
            using (StreamReader streamReader = new StreamReader(@"Filec#\HinhTron.txt"))
            {
                string temp = null;
                if ((temp = streamReader.ReadLine()) != null)
                {
                    banKinhs = new List<float>();
                    while (true)
                    {
                        banKinhs.Add(float.Parse(temp));
                        if ((temp = streamReader.ReadLine()) == null)
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Empty file has no data");
                }
            }
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /*  private void Windown_Loaded(object sender , RoutedEventArgs e)
          {
              string whatever = "";
              hinhVuongs = new HinhVuong[10];
              int[] canh = { 3, 4, 2, 3, 5, 6, 7, 3, 2, 1 };

              for(int i=0; i<hinhVuongs.Length; i++)
              {
                  hinhVuongs[i] = new HinhVuong(canh[i]);
                  whatever += (i + 1).ToString();
                  whatever += string.Format("{0,20}", hinhVuongs[i].Canh.ToString());
                  whatever += string.Format("{0,20}", hinhVuongs[i].CV().ToString());
                  whatever += string.Format("{0,20}", hinhVuongs[i].DT().ToString());
                  listDataHinhVuong.Items.Add(whatever);
                  whatever = "";
              }


          }

      */
    }



}

