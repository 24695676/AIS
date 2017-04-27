using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class Class1:Form1
    {
        //存入AIS碼的所有字元
        public char[] cha2 = new char[69];

                //解出整數
                public int iconfig1(string total, int e, int i)
                {


                    con[y] = total.Substring(e, i);

                    inte[y] = Convert.ToInt32(con[y], 2);

                    return inte[y];
                }

                /*********************************************************************************/
              //解出文字
             public string i_function(int i)
             {

                 string s;
                 if (i >= 32)
                 {
                     s = Convert.ToString((char)i);
                 }

                 else
                 {
                     i += 64;
                     if (i > 96)
                     {
                         i -= 64;
                         s = Convert.ToString((char)i);
                     }
                     else
                         s = Convert.ToString((char)i);
                 }

                 return s;
             }


             /*********************************************************************************************/
               //解出經緯度
               public string lonlat(string total, int i, int j)
               {
                   float nu, nu1;
                   string jud = total.Substring(i, 1), pp = "", YU = "";

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
                           pp = nu.ToString();
                       }
                       else
                           pp = "-" + nu.ToString();
                   }
                   else
                   {
                       YU = total.Substring(i, (j - i));
                       nu1 = ((float)(Convert.ToInt32(YU, 2)) / 600000);
                       if (i == 61)
                       {
                           pp = "-" + nu1.ToString();
                       }
                       else
                           pp = nu1.ToString();
                   }

                   return pp;
               }
               /************************************************************************************************************/
             //將ASC碼化為二進位
                public string giveme(string id1)
              {
                  int i;
                  //char[] cha2 = new char[69];
                  cha2 = id1.ToCharArray();

                  int f, c1, c2;
                  string[] v = new string[70];
                  string[] b1 = new string[70];
                  for (i = 0; i < cha2.Length; ++i)
                  {
                      for (f = 0; f < 95; f++)                                  //找出與95個特殊字元相同的字元
                      {
                          if (f < 57)                                           //41個特殊字元以前-48讓數字為0
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
                  for (k = 0; k < 70; k++)
                      total += b1[k];
                  return total;




              }

                private void InitializeComponent()
                {
                    this.SuspendLayout();
                    // 
                    // Class1
                    // 
                    this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
                    this.ClientSize = new System.Drawing.Size(359, 244);
                    this.Name = "Class1";
                    this.ResumeLayout(false);

                }

                private void button1_Click_1(object sender, EventArgs e)
                {

                }








          }
    }

