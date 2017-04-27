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
                                                                                                      //string[] paths; 保存路徑
        //印出訊息內容
        string[] m24 = new string[50000];
        char[] id;
        //vn=Vessel Name
        string[] vn = new string[20];
        //vid=Vendor ID
        string[] vid = new string[7];
        //cs=Call Sign
        string[] cs = new string[7];
        //de=destination
        string[] de = new string[20];
        //cog=Course Over Ground
        float cog;
        public string[] con = new string[70];
        public int[] inte = new int[70];
        sbyte number;
        //Speed Over Ground
        double sog;
        //將所有2bit碼存入total
        public string total;
        public int y = 0;
        //Longitude,Latitude
        string lon, lat;
        //Navigation Status
        string ns = "";

        public char[] cha = new char[] {' ','!','"','#','$','%','&','\'','(',')','*','+',',','-','.','/','0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ':', ';', '<', '=', '>', '?', '@', 'A', 
            'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W','X','Y','Z','[','\\',']','^','_', '`', 'a',
            'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w','x','y','z','{','|','}','~'};

        /************************************************************************************************************/
        // 檔案路徑

        public void browse_button_Click(object sender, EventArgs e)
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

                                                                                                                  //paths = ofd.FileNames;

            for (int i = 0; i < ofd.SafeFileNames.Length; i++)
            {
                                                                                                                 //paths_comboBox.Items.Add(ofd.SafeFileNames[i]);
                paths_comboBox.Items.Add(ofd.FileNames[i]);

            }

            paths_comboBox.SelectedIndex = 0;

            MessageBox.Show("檔案路徑設定完成");
        }

        private void paths_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /************************************************************************************************************/


        public Form1()
       { 
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void button1_Click(object sender, EventArgs e)
        {

            /*********************************************************************************/
            //一份檔案最多讀50000筆訊息行數
            StreamReader sr = new StreamReader(paths_comboBox.Text);
            Class1 ob = new Class1();
            id = new char[200];
            string[] id1 = new string[10];
            string[] ji = new string[50000];
            string[] ymd = new string[50000];
            
         
            
            for (int rer = 0; rer < 50000; rer++)
            {
                if (!sr.EndOfStream)
                {
                    ji[rer] = sr.ReadLine();
                    ymd[rer] = ji[rer].Substring(0, 19);
                    id = ji[rer].ToCharArray();
                    for (int yi = 0; yi < id.Length; yi++)
                    {
                                                                                                    //id = (ji[rer].Substring(20, 1)).ToCharArray();
                        //判斷是否為AIS訊號
                        if (id[yi] == '!')
                        {
                            if (id[(yi + 1)] == 'A')
                            {
                                id1 = ji[rer].Split(',');
                                if (id1[5] != "")
                                {
                                    //呼叫ob物件的giveme()方法
                                    total = ob.giveme(id1[5]);


                                    /*********************************************************************************/
                                    //24type
                                    // 2. 修正
                                    if (ob.cha2[0] == 'H')
                                    {
                                        int[] u = new int[] { 0, 6, 8, 38, 66, 70, 132, 141, 150, 156, 132, 40 };
                                        int[] h = new int[] { 6, 2, 30, 2, 4, 20, 9, 9, 6, 6, 30, 8 };

                                        for (int g = 0; g < 12; g++)
                                        {
                                            //呼叫ob物件的iconfig1()方法
                                            inte[g] = ob.iconfig1(total, u[g], h[g]);
                                            y++;
                                        }
                                        y = 0;
                                        int m, m3, m2, t = 0;
                                        int n = 40, q = 48, r = 90;




                                        for (m = 12; m < 32; m++)                                           //vn=Vessel Name
                                        {

                                            con[m] = total.Substring(n, 6);
                                            inte[m] = Convert.ToInt32(con[m], 2);

                                            //呼叫ob物件的i_function()方法
                                            vn[t] = ob.i_function(inte[m]);
                                            t++;
                                            n += 6;

                                        }
                                        t = 0;

                                        for (m3 = 32; m3 < 39; m3++)                                        //vid=Vendor ID
                                        {
                                            con[m3] = total.Substring(q, 6);
                                            inte[m3] = Convert.ToInt32(con[m3], 2);
                                            vid[t] = ob.i_function(inte[m3]);
                                            t++;
                                            q += 6;

                                        }


                                        t = 0;
                                        for (m2 = 39; m2 < 46; m2++)                                        //cs=Call Sign
                                        {
                                            con[m2] = total.Substring(r, 6);
                                            inte[m2] = Convert.ToInt32(con[m2], 2);
                                            cs[t] = ob.i_function(inte[m2]);
                                            t++;
                                            r += 6;
                                        }


                                        m24[rer] = (" " + inte[0] + "," + inte[1] + "," + inte[2] + "," + inte[3] + "," + (vn[0] + vn[1] + vn[2] + vn[3] + vn[4] + vn[5] + vn[6] +
                                            vn[7] + vn[8] + vn[9] + vn[10] + vn[11] + vn[12] + vn[13] + vn[14] + vn[15] + vn[16] + vn[17] + vn[18] + vn[19]) + "," + inte[11] + ","
                                            + (vid[0] + vid[1] + vid[2] + vid[3] + vid[4] + vid[5] + vid[6]) + "," + inte[4] + "," + inte[5] + "," + (cs[0] +
                                        cs[1] + cs[2] + cs[3] + cs[4] + cs[5] + cs[6]) + "," + inte[6] + "," + inte[7] + "," + inte[8] + "," + inte[9] + "," + inte[10]);

                                        //前面的日期時間+解碼後的訊息碼
                                        ymd[rer] += m24[rer];



                                    }


                                    /********************************************************************************************/
                                    //5type 解

                                    else if (ob.cha2[0] == '5')
                                    {
                                        //呼叫第二行和第一行合併在一起
                                        string total1 = total;
                                        string[] t1 = new string[1];
                                        t1[0] = sr.ReadLine();
                                        string t2 = t1[0].Substring(0, 19);
                                        char[] t3 = new char[1];
                                        t3 = (t1[0].Substring(20, 1)).ToCharArray();
                                        string[] t4 = new string[10];
                                        t4 = t1[0].Split(',');
                                        string total2 = ob.giveme(t4[5]);
                                        total = total1 + total2;


                                        int[] u = new int[] { 0, 6, 8, 38, 40, 232, 240, 249, 258, 264, 270, 274, 278, 283, 288, 294, 422, 423 };
                                        int[] h = new int[] { 6, 2, 30, 2, 30, 8, 9, 9, 6, 6, 4, 4, 5, 5, 6, 8, 1, 1 };
                                        for (int g = 0; g < u.Length; g++)
                                        {
                                            inte[g] = ob.iconfig1(total, u[g], h[g]);
                                            y++;
                                        }
                                        y = 0;
                                        int m, m2, m3, t = 0;
                                        int n = 112, r = 70, q = 302;
                                        //Draught
                                        float dra = inte[15];
                                        dra /= 10;

                                        for (m = 22; m < 42; m++)                                           //vn=Vessel Name
                                        {

                                            con[m] = total.Substring(n, 6);
                                            inte[m] = Convert.ToInt32(con[m], 2);

                                            vn[t] = ob.i_function(inte[m]);
                                            t++;
                                            n += 6;

                                        }
                                        t = 0;
                                        for (m2 = 42; m2 < 49; m2++)                                        //cs=Call Sign
                                        {
                                            con[m2] = total.Substring(r, 6);
                                            inte[m2] = Convert.ToInt32(con[m2], 2);
                                            cs[t] = ob.i_function(inte[m2]);
                                            t++;
                                            r += 6;
                                        }
                                        t = 0;
                                        for (m3 = 49; m3 < 69; m3++)                                           //de=destination
                                        {

                                            con[m3] = total.Substring(q, 6);
                                            inte[m3] = Convert.ToInt32(con[m3], 2);

                                            de[t] = ob.i_function(inte[m3]);
                                            t++;
                                            q += 6;

                                        }
                                        m24[rer] = (" " + inte[0] + "," + inte[1] + "," + inte[2] + "," + inte[3] + "," + inte[4] + "," + (cs[0] + cs[1] + cs[2] + cs[3] + cs[4] +
                                        cs[5] + cs[6]) + "," + (vn[0] + vn[1] + vn[2] + vn[3] + vn[4] + vn[5] + vn[6] + vn[7] + vn[8] + vn[9] + vn[10] + vn[11]
                                        + vn[12] + vn[13] + vn[14] + vn[15] + vn[16] + vn[17] + vn[18] + vn[19]) + "," + inte[5] + "," + inte[6] + "," + inte[7] + "," + inte[8]
                                        + "," + inte[9] + "," + inte[10] + "," + inte[11] + "," + inte[12] + "," + inte[13] + "," + inte[14] + "," + dra + "," + (de[0] + de[1] +
                                        de[2] + de[3] + de[4] + de[5] + de[6] + de[7] + de[8] + de[9] + de[10] + de[11] + de[12] + de[13] + de[14] + de[15] + de[16] + de[17] +
                                        de[18] + de[19]) + "," + inte[16] + "," + inte[17]);
                                        ymd[rer] += m24[rer];
                                    }
                                    /********************************************************************************************/
                                    // 8type 解

                                    else if (ob.cha2[0] == '8')
                                    {
                                        int[] u = new int[] { 0, 6, 8, 38, 40, 50 };
                                        int[] h = new int[] { 6, 2, 30, 2, 10, 6 };
                                        for (int g = 0; g < 6; g++)
                                        {
                                            inte[g] = ob.iconfig1(total, u[g], h[g]);
                                            y++;
                                        }
                                        y = 0;
                                        m24[rer] = (" " + inte[0] + "," + inte[1] + "," + inte[2] + "," + inte[3] + "," + inte[4] + "," + inte[5]);

                                        ymd[rer] += m24[rer];

                                    }

                                    /********************************************************************************************/
                                    //18type解

                                    else if (ob.cha2[0] == 'B')
                                    {
                                        int[] u = new int[] { 0, 6, 8, 38, 46, 56, 57, 85, 112, 124, 133, 139, 141, 142, 143, 144, 145, 146, 147, 148 };
                                        int[] h = new int[] { 6, 2, 30, 8, 10, 1, 28, 27, 12, 9, 6, 2, 1, 1, 1, 1, 1, 1, 1, 20 };
                                        for (int g = 0; g < 20; g++)
                                        {
                                            inte[g] = ob.iconfig1(total, u[g], h[g]);
                                            y++;
                                        }
                                        y = 0;
                                        sog = inte[4];
                                        sog /= 10;
                                        lon = ob.lonlat(total, 57, 85);
                                        lat = ob.lonlat(total, 85, 112);
                                        cog = (float)inte[8] / 10;
                                        m24[rer] = (" " + inte[0] + "," + inte[1] + "," + inte[2] + "," + inte[3] + "," + sog+ "," + inte[5] + "," + lon + "," + lat + "," +
                                            cog + "," + inte[9] + "," + inte[10] + "," + inte[11] + "," + inte[12] + "," + inte[13] + "," + inte[14] + "," + inte[15] + "," + inte[16] + "," + inte[17]
                                            + "," + inte[18] + "," + inte[19]);

                                        ymd[rer] += m24[rer];
                                    }

                                    /********************************************************************************************/
                                    //19type解

                                    else if (ob.cha2[0] == 'C')
                                    {
                                        int m, t = 0, n = 143;

                                        int[] u = new int[] { 0, 6, 8, 38, 46, 56, 57, 85, 112, 124, 133, 139, 263, 271, 280, 289, 295, 301, 305, 306, 307, 308 };
                                        int[] h = new int[] { 6, 2, 30, 8, 10, 1, 28, 27, 12, 9, 6, 4, 8, 9, 9, 6, 6, 4, 1, 1, 1, 4 };
                                        for (int g = 0; g < u.Length; g++)
                                        {
                                            inte[g] = ob.iconfig1(total, u[g], h[g]);
                                            y++;
                                        }
                                        y = 0;
                                        sog = inte[4];
                                        sog /= 10;
                                        lon = ob.lonlat(total, 57, 85);
                                        lat = ob.lonlat(total, 85, 112);
                                        cog = (float)inte[8] / 10;
                                        for (m = 22; m < 42; m++)                                           //vn=Vessel Name
                                        {

                                            con[m] = total.Substring(n, 6);
                                            inte[m] = Convert.ToInt32(con[m], 2);

                                            vn[t] = ob.i_function(inte[m]);
                                            t++;
                                            n += 6;

                                        }
                                        t = 0;
                                        m24[rer] = (" " + inte[0] + "," + inte[1] + "," + inte[2] + "," + inte[3] + "," + sog + "," + inte[5] + "," + lon + "," + lat + "," +
                                            cog + "," + inte[9] + "," + inte[10] + "," + inte[11] + "," + (vn[0] + vn[1] + vn[2] + vn[3] + vn[4] + vn[5] + vn[6] + vn[7] + vn[8] + vn[9] + vn[10] + vn[11] + vn[12] + vn[13]
                                        + vn[14] + vn[15] + vn[16] + vn[17] + vn[18] + vn[19]) + "," + inte[12] + "," + inte[13] + "," + inte[14] + "," + inte[15] + "," + inte[16]
                                            + "," + inte[17] + "," + inte[18] + "," + inte[19] + "," + inte[20] + "," + inte[21]);

                                        ymd[rer] += m24[rer];
                                    }


                                     /************************************************************************************/
                                    //123type解

                                    else if (ob.cha2[0] == '1' | ob.cha2[0] == '2' | ob.cha2[0] == '3')
                                    {
                                        int[] u = new int[] { 0, 6, 8, 38, 50, 60, 61, 89, 116, 128, 137, 143, 145, 148, 149 };
                                        int[] h = new int[] { 6, 2, 30, 4, 10, 1, 28, 27, 12, 9, 6, 2, 3, 1, 19 };


                                        for (int g = 0; g < 14; g++)
                                        {
                                            inte[g] = ob.iconfig1(total, u[g], h[g]);
                                            y++;
                                        }
                                        sog = inte[4];
                                        sog /= 10;
                                        y = 0;



                                        string ss = total.Substring(42, 8);
                                        number = Convert.ToSByte(ss, 2);


                                        lon = ob.lonlat(total, 61, 89);
                                        lat = ob.lonlat(total, 89, 116);

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
                                        m24[rer] = (" " + inte[0] + "," + inte[1] + "," + inte[2] + "," + ns + "," + number + "," + sog + "," + inte[5] + "," + lon + "," + lat + ","
                                            + cog + "," + inte[9] + "," + inte[10] + "," + inte[11] + "," + inte[12] + "," + inte[13] + "," + inte[14]);
                                        ymd[rer] += m24[rer];

                                    }
                                    /********************************************************************************************/
                                    //4type解
                                    else if (ob.cha2[0] == '4')
                                    {
                                        int[] u = new int[] { 0, 6, 8, 38, 52, 56, 61, 66, 72, 78, 134, 138, 148, 149 };
                                        int[] h = new int[] { 6, 2, 30, 14, 4, 5, 5, 6, 6, 1, 4, 10, 1, 19 };
                                        for (int g = 0; g < u.Length; g++)
                                        {
                                            inte[g] = ob.iconfig1(total, u[g], h[g]);
                                            y++;
                                        }
                                        y = 0;
                                        lon = ob.lonlat(total, 79, 107);
                                        lat = ob.lonlat(total, 107, 134);
                                        m24[rer] = (" " + inte[0] + "," + inte[1] + "," + inte[2] + "," + inte[3] + "," + inte[4] + "," + inte[5] + "," + inte[6] + "," + inte[7] + "," + inte[8] + "," + inte[9]
                                        + "," + lon + "," + lat + "," + inte[10] + "," + inte[11] + "," + inte[12] + "," + inte[13]);

                                        ymd[rer] += m24[rer];
                                    }

                                    /********************************************************************************************/
                                    //無message(所有message以外)
                                    else
                                    { }
                                }
                            }
                        }
                    }
                }
            }
            /*********************************************************************************/
            //關閉檔案之後改寫
            sr.Close();
            StreamWriter sw = new StreamWriter(paths_comboBox.Text);
            for (int typ = 0; typ < 50000; typ++)
            {
                sw.WriteLine(ymd[typ]);

            }
            sw.Close();
            MessageBox.Show("改寫成功摟");
        }


    
    }
}
 


