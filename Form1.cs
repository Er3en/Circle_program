using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ZALICZENIE_10
{
    public partial class Form1 : Form
    {
        List<kolo> lista_figur = null;
        public Form1()
        {
            
            InitializeComponent();
            lista_figur = new List<kolo>();
            this.Text = "Jakub Rybski - program zaliczeniowy - Informatyka II 2020";
            

        }

        public int MAX=100;
        public int X = 1;
        Random generator = new Random();
        
        public int isNumeric = 0;
        bool czy = false;
        public Color wypelnienie_kolor=Color.Empty;
        public Color losowowanykolor = Color.Empty;

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
          

            if (int.TryParse(textBox2.Text, out int n) == false)
            {
                textBox1.Text = "1";
                isNumeric = 1;
            }
            else
            {
                isNumeric = int.Parse(textBox2.Text);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            int MAX = int.Parse(textBox3.Text);
            toolStripProgressBar1.Maximum = MAX;
            toolStripProgressBar1.Increment(MAX);

            if (lista_figur.Count+isNumeric>= MAX)
            {
               for(int i =0;i<lista_figur.Count;i++)
                {
                    lista_figur.Clear();
                    myPanel1.Refresh();
                }
                toolStripStatusLabel1.Text = "Liczba kół w zbiorze: " + lista_figur.Count;
                toolStripProgressBar1.Value = lista_figur.Count;
            }
            else
            {
                isNumeric = int.Parse(textBox2.Text);
                for (int i = 0; i < isNumeric; i++)
                {
                    kolo z = new kolo();
                

                    if (checkBox2.Checked == true)
                    { 
                        z.wypelnione = 1;
                        z.x = generator.Next(5, myPanel1.Size.Width - z.srednica);
                        z.y = generator.Next(5, myPanel1.Size.Height - z.srednica);
                        Color losowowanykolor = Color.FromArgb(generator.Next(256), generator.Next(256), generator.Next(256));
                        z.kolor = losowowanykolor;
                        z.wypelnienie = losowowanykolor;
                    }
                    else if (checkBox3.Checked == true)
                    {
                        //generator = new Random();
                        int v = generator.Next(1, 1000);
                        if (v > 500)
                        {
                            z.wypelnione = 0;
                            z.x = generator.Next(5, myPanel1.Size.Width - z.srednica);
                            z.y = generator.Next(5, myPanel1.Size.Height - z.srednica);
                            Color losowowanykolor = Color.FromArgb(generator.Next(256), generator.Next(256), generator.Next(256));
                            z.kolor = losowowanykolor;
                            z.wypelnienie = losowowanykolor;
                        }
                        else
                        {
                            z.wypelnione = 1;
                            z.x = generator.Next(5, myPanel1.Size.Width - z.srednica);
                            z.y = generator.Next(5, myPanel1.Size.Height - z.srednica);
                            Color losowowanykolor = Color.FromArgb(generator.Next(256), generator.Next(256), generator.Next(256));
                            z.kolor = losowowanykolor;
                            z.wypelnienie = losowowanykolor;
                        }
                    }
                        else if (checkBox2.Checked==false )
                    {
                        z.wypelnione = 0;
                        z.x = generator.Next(5, myPanel1.Size.Width - z.srednica);
                        z.y = generator.Next(5, myPanel1.Size.Height - z.srednica);
                        Color losowowanykolor = Color.FromArgb(generator.Next(256), generator.Next(256), generator.Next(256));
                        z.kolor = losowowanykolor;
                        z.wypelnienie = losowowanykolor;
                    }
       
                   
                
                    lista_figur.Add(z);
                }
                myPanel1.Refresh();
                toolStripStatusLabel1.Text = "Liczba kół w zbiorze: " + lista_figur.Count;
                toolStripProgressBar1.Value = lista_figur.Count;
                
            }
        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void myPanel1_Paint(object sender, PaintEventArgs e)
        {
            
                if (checkBox3.Checked == true)
                {
                    for (int i = 0; i < lista_figur.Count; i++)
                    {
                       
                        if (lista_figur[i].wypelnione == 1)
                        {

                            SolidBrush b = new SolidBrush(lista_figur[i].kolor);
                            e.Graphics.FillEllipse(b, lista_figur[i].x, lista_figur[i].y, lista_figur[i].srednica, lista_figur[i].srednica);
                        }
                        else
                        {
                            Pen pen = new Pen(lista_figur[i].kolor, 3);
                            e.Graphics.DrawEllipse(pen, lista_figur[i].x, lista_figur[i].y, lista_figur[i].srednica, lista_figur[i].srednica);
                        }

                    }
                }
                else
                {
                    for (int i = 0; i < lista_figur.Count; i++)
                    {
                        if (lista_figur[i].wypelnione == 1)
                        {

                            SolidBrush b = new SolidBrush(lista_figur[i].kolor);
                            e.Graphics.FillEllipse(b, lista_figur[i].x, lista_figur[i].y, lista_figur[i].srednica, lista_figur[i].srednica);
                        }
                        else
                        {
                            Pen pen = new Pen(lista_figur[i].kolor, 3);
                            e.Graphics.DrawEllipse(pen, lista_figur[i].x, lista_figur[i].y, lista_figur[i].srednica, lista_figur[i].srednica);
                        }
                    }
                }

                statusStrip1.Refresh();
            
        }
        

        private void toolStripStatusLabel1_Click_1(object sender, EventArgs e)
        {
            
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lista_figur.Count; i++)
            {
                lista_figur.Clear();
                myPanel1.Refresh();
            }
            toolStripStatusLabel1.Text = "Liczba kół w zbiorze: " + lista_figur.Count;
            toolStripProgressBar1.Value = lista_figur.Count;
        }

        private void myPanel1_Resize(object sender, EventArgs e)
        {
        
        }

        private void plikiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dodajToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }
        public async Task DoSomethingEveryTenSeconds()
        {
            int MAX = int.Parse(textBox3.Text);
            toolStripProgressBar1.Maximum = MAX;
            toolStripProgressBar1.Increment(MAX);
            while (czy==true)
            {
                var delayTask = Task.Delay(5000);
                if (lista_figur.Count + 10 >= MAX)
                {
                    for (int i = 0; i < lista_figur.Count; i++)
                    {
                        lista_figur.Clear();
                        myPanel1.Refresh();
                    }
                    toolStripStatusLabel1.Text = "Liczba kół w zbiorze: " + lista_figur.Count;
                    toolStripProgressBar1.Value = lista_figur.Count;
                }
                else
                {

                    if (checkBox2.Checked == true)
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            kolo z = new kolo();
                            z.x = generator.Next(5, myPanel1.Size.Width - z.srednica);
                            z.y = generator.Next(5, myPanel1.Size.Height - z.srednica);
                            Color losowowanykolor = Color.FromArgb(generator.Next(256), generator.Next(256), generator.Next(256));
                            z.kolor = losowowanykolor;
                            z.wypelnienie = losowowanykolor;
                            z.wypelnione = 1;
                            lista_figur.Add(z);
                        }
                    }
                    else
                    {

                        for (int i = 0; i < 10; i++)
                        {
                            kolo z = new kolo();
                            z.x = generator.Next(5, myPanel1.Size.Width - z.srednica);
                            z.y = generator.Next(5, myPanel1.Size.Height - z.srednica);
                            Color losowowanykolor = Color.FromArgb(generator.Next(256), generator.Next(256), generator.Next(256));
                            z.kolor = losowowanykolor;
                            z.wypelnienie = losowowanykolor;
                            z.wypelnione = 0;
                            lista_figur.Add(z);
                        }

                    }

                    myPanel1.Refresh();
                    toolStripStatusLabel1.Text = "Liczba kół w zbiorze: " + lista_figur.Count;
                    toolStripProgressBar1.Value = lista_figur.Count;
                }

                await delayTask; 
            }
        }

        private void dodajKołaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int MAX = int.Parse(textBox3.Text);
            toolStripProgressBar1.Maximum = MAX;
            toolStripProgressBar1.Increment(MAX);

            if (lista_figur.Count + isNumeric >= MAX)
            {
                for (int i = 0; i < lista_figur.Count; i++)
                {
                    lista_figur.Clear();
                    myPanel1.Refresh();
                }
                toolStripStatusLabel1.Text = "Liczba kół w zbiorze: " + lista_figur.Count;
                toolStripProgressBar1.Value = lista_figur.Count;
            }
            else
            {
                isNumeric = int.Parse(textBox2.Text);
                for (int i = 0; i < isNumeric; i++)
                {
                    kolo z = new kolo();
                    z.x = generator.Next(5, myPanel1.Size.Width - z.srednica);
                    z.y = generator.Next(5, myPanel1.Size.Height - z.srednica);
                    Color losowowanykolor = Color.FromArgb(generator.Next(256), generator.Next(256), generator.Next(256));
                    z.kolor = losowowanykolor;
                    z.wypelnienie = losowowanykolor;
                    lista_figur.Add(z);
                }
                myPanel1.Refresh();
                toolStripStatusLabel1.Text = "Liczba kół w zbiorze: " + lista_figur.Count;
                toolStripProgressBar1.Value = lista_figur.Count;
            }
            myPanel1.Refresh();
        }

        private void usuńWszytkieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lista_figur.Count; i++)
            {
                lista_figur.Clear();
                myPanel1.Refresh();
            }
            toolStripStatusLabel1.Text = "Liczba kół w zbiorze: " + lista_figur.Count;
            toolStripProgressBar1.Value = lista_figur.Count;
        }

    
        

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        { 
           if(checkBox1.Checked==true)
            {
                czy = true;
                DoSomethingEveryTenSeconds();
            }
           else
            {
                czy = false;
                DoSomethingEveryTenSeconds();
            }
            
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                //for (int i = 0; i < lista_figur.Count; i++)
                   // wypelnienie_kolor = lista_figur[i].kolor;
                myPanel1.Refresh();
            }
            else
            {
                myPanel1.Refresh();
            }

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            
            if (checkBox3.Checked == true)
            {
                for (int i = 0; i < lista_figur.Count; i++)
                    wypelnienie_kolor = lista_figur[i].kolor;
                myPanel1.Refresh();
            }
            else
            {
                myPanel1.Refresh();
            }
            
        }

        private void toolStripProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox3.Text, out int n) == false)
            {
                textBox3.Text = "100";

            }
            else
            {
                int MAX = int.Parse(textBox3.Text);
                toolStripProgressBar1.Maximum = MAX;
            }
        }

        public class kolo
        {
            public kolo()
            {
                Random generator = new Random();
                srednica = generator.Next(50, 100);
                
            }
            public int srednica;
            public Color kolor;
            public Color wypelnienie;
            public int wypelnione;
            public int x, y;
        }
    }
    public class myPanel : Panel
    {
        protected override void OnCreateControl()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.AutoScrollMinSize = new System.Drawing.Size(100, 100);
            base.OnCreateControl();
        }
    }
}
