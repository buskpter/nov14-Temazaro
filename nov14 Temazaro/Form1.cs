using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nov14_Temazaro
{
    public partial class Form1 : Form
    {
        Timer almaTicker = new Timer();
        Timer ember = new Timer();
        Timer keze = new Timer();
        bool almaEsik = false;
        bool utoKez = false;
        bool iranybal = true;
        int num = 0;
        int num2 = 0;
        int num3 = 10;
        int num4 = 20;
        int num5 = 30;
        
        public Form1()
        {
            InitializeComponent();
            Start();
        }

        void Start()
        {
            Label fateteje = new Label();
            fateteje.Height = 150;
            fateteje.Width = 200;
            fateteje.Top = 20;
            fateteje.Left = 30;
            fateteje.BackColor = Color.Green;
            this.Controls.Add(fateteje);

            Label torzs = new Label();
            torzs.Height = 230;
            torzs.Width = 30;
            torzs.BackColor = Color.SaddleBrown;
            torzs.Top = (fateteje.Bottom - 1);
            torzs.Left = (fateteje.Width + torzs.Width ) / 2;
            this.Controls.Add(torzs);


            Panel fej = new Panel();
            fej.BorderStyle = BorderStyle.FixedSingle;
            fej.Width = 30;
            fej.Height = 40;
            fej.Top = (torzs.Top + 40);
            fej.Left = (torzs.Right + 270);
            this.Controls.Add(fej);


            Panel test = new Panel();
            test.BorderStyle = BorderStyle.FixedSingle;
            test.Top = 248;
            test.Left = 420;
            test.Height = 150;
            test.Width = 20;
            this.Controls.Add(test);

            Panel kez = new Panel();
            kez.BorderStyle = BorderStyle.FixedSingle;
            kez.Width = 40;
            kez.Height = 20;
            kez.Top = (fej.Bottom + 30);
            kez.Left = (test.Left - 25);
            this.Controls.Add(kez);

            Label kosar = new Label();
            kosar.Width = 100;
            kosar.Height = 70;
            kosar.Left = (test.Right + 40);
            kosar.Top = (fej.Bottom + 80);
            kosar.BackColor = Color.Brown;
            this.Controls.Add(kosar);


            Label kosar2 = new Label();
            kosar2.Width = 15;
            kosar2.Height = 50;
            kosar2.Top = 280;
            kosar2.Left = 520;
            kosar2.BackColor = Color.Brown;
            this.Controls.Add(kosar2);

            Label alma = new Label();
            alma.Width = 10;
            alma.Height = 10;
            alma.BackColor = Color.Red;
            alma.Left = (fateteje.Width - 50);
            alma.Top = 125;
            this.Controls.Add(alma);

            Label pontszam = new Label();
            pontszam.Top = fateteje.Top + 100;
            pontszam.Left = 500;
            pontszam.Text = "Gyűjtött almák száma:";
            pontszam.Width = 300;

            Label teher = new Label();
            teher.Text = "Kosar teherbirasa: 20 alma";
            teher.Top = (pontszam.Top + 30);
            teher.Width = 200;
            teher.Left = pontszam.Left;
            this.Controls.Add(teher);

            this.Controls.Add(pontszam);

            Label nagyobbKosar = new Label();
            nagyobbKosar.Top = (pontszam.Top + 80);
            nagyobbKosar.Text = "Nagyobb kosar:";
            nagyobbKosar.Left = pontszam.Left;
            this.Controls.Add(nagyobbKosar);


            Button almapont = new Button();
            almapont.Text = "10 alma";
            almapont.Width = 100;
            almapont.Height = 30;
            almapont.Top = (pontszam.Top + 80);
            almapont.Left = (pontszam.Left + 100);
            almapont.BackColor = Color.Gray;
            this.Controls.Add(almapont);

            Label szedes = new Label();
            szedes.Text = "Gyorsabb szedes:";
            szedes.Top = (nagyobbKosar.Top + 50);
            szedes.Left = nagyobbKosar.Left;
            szedes.Width = 100;
            this.Controls.Add(szedes);

            Button almapont2 = new Button();
            almapont2.Text = "30 alma";
            almapont2.Width = 100;
            almapont2.Height = 30;
            almapont2.Top = (pontszam.Top + 130);
            almapont2.Left = (pontszam.Left + 100);
            almapont2.BackColor = Color.Gray;
            this.Controls.Add(almapont2);

            Label utes = new Label();
            utes.Top = (fateteje.Top);
            utes.Left = (fateteje.Left + 200);
            utes.Text = "utesek:";
            utes.Width = 100;
            this.Controls.Add(utes);

            

           




            int index = this.Controls.GetChildIndex(kez);
            this.Controls.SetChildIndex(test, index);


            almaTicker = new Timer();
            almaTicker.Interval = 10;
            almaTicker.Tick += (s, e) =>
            {
                if (almaEsik)
                {
                    alma.Top += 1;

                }
                if(alma.Bottom >= kez.Top && iranybal)
                {

                    
                    keze.Stop();
                    kez.Left = (test.Right - 10);
                    alma.Left = (test.Right + 10);
                    alma.Top = kez.Top - 10;
                    iranybal = false;
                    almaEsik = false;
                }

            };
            almaTicker.Start();

            
            
                almapont.Click += (ssss, eeee) =>
                {
                    if(num >= 10)
                    {
                        num -= num3;
                        pontszam.Text = "Gyűjtött almák száma:" + num.ToString();
                        num3 += 2;
                        num4 += 5;
                        teher.Text = $"Kosar teherbirasa: {num4.ToString()} alma";

                        almapont.Text = num3.ToString() + " alma ";
                    }
                    
                };
            
           
            
            

                almapont2.Click += (s, e) =>
                {
                    if (num >= 30)
                    {
                        num -= num5;
                        num5 += 30;
                        almapont2.Text = num5.ToString() + " alma ";
                    }
                       
                };
            

            

            ember = new Timer();
            ember.Interval = 1;
            ember.Tick += (ss, ee) =>
            {
                if(iranybal && kez.Left >= torzs.Right)
                {
                    if(kez.Left > torzs.Right && !utoKez)
                    {
                        fej.Left -= 1;
                        test.Left -= 1;
                        kez.Left -= 1;
                    }
                    else if(kez.Left == torzs.Right)
                    {
                        utoKez = true;
                        keze.Start();
                        almaEsik = true;

                    }
                }
                else if (!iranybal)
                {
                    if(kosar.Left != kez.Left - 5)
                    {
                        fej.Left += 1;
                        test.Left += 1;
                        kez.Left += 1;
                        alma.Left += 1;
                    }
                    else
                    {
                        if(alma.Top != kosar.Top)
                        {
                            alma.Top += 1;
                        }
                        else if(alma.Top == kosar.Top)
                        {
                            iranybal = true;
                            utoKez = false;
                            almaEsik = false;
                            num++;
                            pontszam.Text = "Gyűjtött almák száma:" + num.ToString();
                           

                           




                            alma.Left = (fateteje.Width - 50);
                            alma.Top = 125;

                            fej.Top = (torzs.Top + 40);
                            fej.Left = (torzs.Right + 270);

                            test.Top = 248;
                            test.Left = 420;

                            kez.Top = (fej.Bottom + 30);
                            kez.Left = (test.Left - 25);
                            
                        }
                        /*if(num == 1)
                       {
                           teher.Text = "Kosar teherbirasa: 25 alma";
                       }*/

                       

                    

                      
                    }
                }
            };
            ember.Start();

          

            keze = new Timer();
            keze.Interval = 100;
            keze.Tick += (sss, eee) =>
             {
                 if(kez.Left == torzs.Right )
                 {
                     num2++;
                     kez.Left += 15;
                     utes.Text = "utesek" + num2.ToString();
                 }

                 else 
                 {
                     kez.Left -= 15;
                    
                 }

                
             };





        }

        
    }
}
