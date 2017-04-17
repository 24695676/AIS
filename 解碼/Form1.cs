using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        float cog;
        string[] con = new string[47];
            int[] inte = new int[47];
            sbyte number;
            double sog;
         string total;
         int y =0;
         string lon, lat;
         string ns="";
         string str3;
        public char[] cha = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ':', ';', '<', '=', '>', '?', '@', 'A', 
            'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', '\'', 'a',
            'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w' };
        
        public Form1()
        {
            InitializeComponent();
        }

        #region qwe

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            str3 = textBox1.Text;
            string[] strArray = str3.Split(',');
           int i;
           // str3 = textBox1.Text.Substring(14, 28);
            char[] cha2 = new char[28];
           // cha2 = str3.ToCharArray();
            cha2 = strArray[5].ToCharArray();

            /*********************************************************************************/
            // 1. 修正
            int f, c1, c2;
            string[] v = new string[28];
            string[] b1 = new string[28];
            for (i = 0; i < cha2.Length - 1; ++i)
            {
                for (f = 0; f < 64; f++)                                  //找出與64個特殊字元相同的字元
                {
                    if (f < 41)                                           //41個特殊字元以前-48讓數字為0
                    {
                        if (cha2[i] == cha[f])
                        {
                            c1 = (int)cha2[i] - 48;
                            v[i] = Convert.ToString(c1, 2);
                            b1[i] = v[i].PadLeft(6, '0');

                        }
                    }

                    else                                                  //41個特殊字元以後-56
                    {
                        if (cha2[i] == cha[f])
                        {
                            c2 = (int)cha2[i] - 56;
                            v[i] = Convert.ToString(c2, 2);
                            b1[i] = v[i].PadLeft(6, '0');
                        }
                    }
                }
            }
            int k;
            total = "";
            for (k = 0; k < 28; k++)
                total += b1[k];
            
            
             /*********************************************************************************/
             // 2. 修正
            if (cha2[0] == 'H')
            {
                int[] u = new int[] { 0, 6, 8, 38, 66, 70, 132, 141, 150, 156, 132, 40 };
                int[] h = new int[] { 6, 2, 30, 2, 4, 20, 9, 9, 6, 6, 30, 8 };

                for (int g = 0; g < 12; g++)
                {
                    inte[g] = iconfig1(total, u[g], h[g]);
                    y++;
                }
            }               
         
               /********************************************************************************************/       //5type 解

            else if (cha[0] == '5')
            {
                int[] u = new int[] { 0, 6, 8, 38, 40, 70, 112, 232, 240, 249, 258, 264, 270, 274, 278,283,288,294,302,422,423 };
                int[] h = new int[] { 6, 2, 30, 2, 30, 42, 120, 8, 9, 9, 6, 6, 4, 4, 5,5,6,8,120,1,1};
                for (int g = 0; g < 20; g++)
                {
                    inte[g] = iconfig1(total, u[g], h[g]);
                    y++;
                }




            }
            /************************************************************************************/       //123type解
                else
            {
                int[] u = new int[] { 0, 6, 8, 38, 50, 60, 61, 89, 116, 128, 137, 143, 145, 148, 149 };
                int[] h = new int[] { 6, 2, 30, 4, 10, 1, 28, 27, 12, 9, 6, 2, 3, 1, 19 };


                for (int g = 0; g < 14; g++)
                {
                    inte[g] = iconfig1(total, u[g], h[g]);
                    y++;
                }
                sog = inte[4];
                sog /= 10;




                string ss = total.Substring(42, 8);
                number = Convert.ToSByte(ss, 2);


                lon = lonlat(total, 61, 89);
                lat = lonlat(total, 89, 116);

                cog = (float)inte[8] / 10;



                switch (inte[3])
                {
                    case 0:
                        ns = "Under way using engine";
                        break;
                    case 1:
                        ns = "At anchor";
                        break;
                    case 2:
                        ns = "Not under command";
                        break;
                    case 3:
                        ns = "Restricted manoeuverability";
                        break;
                    case 4:
                        ns = "Constrained by her draught";
                        break;
                    case 5:
                        ns = "Moored";
                        break;
                    case 6:
                        ns = "Aground";
                        break;
                    case 7:
                        ns = "Engaged in Fishing";
                        break;
                    case 8:
                        ns = "Under way sailing";
                        break;
                    case 9:
                        ns = "Reserved for future amendment of Navigational Status for HSC";
                        break;
                    case 10:
                        ns = "Reserved for future amendment of Navigational Status for WIG";
                        break;
                    case 11:
                        ns = "Reserved for future use";
                        break;
                    case 12:
                        ns = "Reserved for future use";
                        break;
                    case 13:
                        ns = "Reserved for future use";
                        break;
                    case 14:
                        ns = "AIS-SART is active";
                        break;
                    case 15:
                        ns = "Not defined (default)";
                        break;

                }

            }

                /*********************************************************************************/
                // 3. 修正
                int m, m3, m2, t = 0;
                int n = 40, q = 48, r = 90;
                string[] s1 =new string[20];
                string[] s2 =new string[7];
                string[] s3 =new string[7];
                


                for (m = 12; m < 32; m++)                                           //s1=Vessel Name
                {
                  
                    con[m] = total.Substring(n, 6);      
                    inte[m] = Convert.ToInt32(con[m],2);
              
                    s1[t] = i_function(inte[m]);
                    t++;
                    n += 6;
                    
                }
                t = 0;

                for (m3 = 32; m3 < 39; m3++)                                        //s2=Vendor ID
                {
                    con[m3] = total.Substring(q, 6);
                    inte[m3] =Convert.ToInt32(con[m3],2);
                    s2[t] = i_function(inte[m3]);
                    t++;
                    q += 6;

                }


                t = 0;
                for (m2 = 39; m2 < 46; m2++)                                        //s3=Call Sign
                {
                    con[m2] = total.Substring(r, 6);
                    inte[m2] = Convert.ToInt32(con[m2],2);
                    s3[t] = i_function(inte[m2]);
                    t++;
                     r += 6;
                }
                 int kr=24;
                string vl = Convert.ToString((char)kr);
                dataGridView1.Rows.Add(textBox1.Text, inte[0], inte[1], inte[2], inte[3], (s1[0] + s1[1] + s1[2] + s1[3] + s1[4] + s1[5] + s1[6] + s1[7] + s1[8] + s1[9] + s1[10] + s1[11] + s1[12] + s1[13]
                    + s1[14] + s1[15] + s1[16] + s1[17] + s1[18] + s1[19]),"", inte[11], (s2[0] + s2[1] + s2[2] + s2[3] + s2[4] + s2[5] + s2[6]), inte[4], inte[5], (s3[0] + s3[1] + s3[2] + s3[3]
                        + s3[4] + s3[5] + s3[6]), inte[6], inte[7], inte[8], inte[9], inte[10], "");
                dataGridView2.Rows.Add(textBox1.Text, inte[0], inte[1], inte[2], ns, number, sog, inte[5], lon, lat, cog, inte[9], inte[10],inte[11], inte[12], inte[13], inte[14]);
                textBox1.Text = "";

            }
                
                /*以下為涵式*/ //(s1[0]+ s1[1] + s1[2] + s1[3] + s1[4] + s1[5] + s1[6] + s1[7] + s1[8] + s1[9] + s1[10] + s1[11] + s1[12] + s1[13]
                        //+ s1[14] + s1[15] + s1[16] + s1[17] + s1[18] + s1[19])
               /*********************************************************************************/
                 
                 private int iconfig1(string total,int e,int i){    
                     
                
                     con[y] = total.Substring(e, i);

                     inte[y] = Convert.ToInt32(con[y],2);
                  
                 return inte[y];
             }
                 /*inte[1]=Message Type,inte[2]=Repeat Indicator,inte[3]=MMSI,inte[4]=Part Number,inte[5]=Unit Mode Code,
                   inte[6]=Serial Number,inte[7]=Dimension to Bow,inte[8]=Dimension to Stern,inte[9]=Dimension to Port,
                  inte[10]=Dimension to Starboard,inte[11]=Mothership MMSI*/
              /*********************************************************************************/
                        public string i_function(int i){

                                string s;
                                if (i>=48)
                                {
                                 s = Convert.ToString((char)i);}
                                
                                else
                                {
                                    i += 64;
                                    if(i>96)
                                    {
                                        i -= 64;
                                        s = Convert.ToString((char)i); }
                                    else
                                    s = Convert.ToString((char)i);
                        }

                                return s;
                        }
        /*********************************************************************************************/
                        public string lonlat(string total,int i,int j)
                        {
                            float nu,nu1;
                            string jud=total.Substring(i,1),pp = "",YU="";

                            if (jud == "1")
                            {
                                string te = "";
                                int tes = 0;
                                string[] test = new string[28];
                                for (int u = i; u < j; u++)
                                {
                                    test[tes] = total.Substring(u, 1);

                                    if (test[tes] == "0")
                                    { test[tes] = "1"; }
                                    else
                                    { test[tes] = "0"; }
                                    te += test[tes];
                                    tes++;
                                }
                                nu = ((float)(Convert.ToInt32(te, 2) + 1) / 600000);
                                if (i == 61)
                                {
                                    pp = "EAST    " + nu.ToString();
                                }
                                else
                                    pp = "NORTH   " + nu.ToString();
                            }
                            else
                            {
                                YU = total.Substring(i, (j - i));
                                nu1 = ((float)(Convert.ToInt32(YU, 2)) / 600000);
                                if (i == 61)
                                {
                                    pp = "WEST    " + nu1.ToString();
                                }
                                else
                                    pp = "SOUTH   " + nu1.ToString();
                            }
                          
                            return pp;   
                        }

                        // 檔案路徑
                        string[] paths;
                        private void browse_button_Click(object sender, EventArgs e)
                        {
                            OpenFileDialog ofd = new OpenFileDialog();
                            ofd.Multiselect = true;

                            ofd.ShowDialog();
                            for (int i = 0; i < ofd.FileNames.Length; i++)
                            {
                                if (!File.Exists(ofd.FileNames[i]))
                                {
                                    MessageBox.Show("檔案設定有誤");
                                    break;
                                }
                            }

                            paths = ofd.FileNames;

                            for (int i = 0; i < ofd.SafeFileNames.Length; i++)
                            {
                                paths_comboBox.Items.Add(ofd.SafeFileNames[i]);
                            }

                            paths_comboBox.SelectedIndex = 0;

                            MessageBox.Show("檔案路徑設定完成");
                        }

                        private void paths_comboBox_SelectedIndexChanged(object sender, EventArgs e)
                        {

                        }


        /************************************************************************************************************/


        #endregion


    }
  
}
 


