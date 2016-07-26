using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MouseRec
{
    public partial class Form1 : Form
    {
        ListViewItem lv;
        int a, b;

        public Form1()
        {
            InitializeComponent();
        } 


        /**
        * Auto Playing the recorded coordinates
        */
        private void timer2_Tick(object sender, EventArgs e)
        {
            if(a!=b)
            {  
                Cursor.Position = new Point(
                    int.Parse(listView1.Items[a].SubItems[0].Text), 
                    int.Parse(listView1.Items[a].SubItems[1].Text)
                );
                a++; 
            }
            else
            {
                // if cursor playing is done then
                // cursor should start back to zero so that when user play again 
                // it should work and start playing from the start
                //a = 0; 
            }
        }
             
       /**
       * Recording mouse coordinates
       */
        private void timer1_Tick(object sender, EventArgs e)
        { 
            lv = new ListViewItem(Cursor.Position.X.ToString());
            lv.SubItems.Add(Cursor.Position.Y.ToString()); 
            listView1.Items.Add(lv);
            b++;
        }

        /** 
        * Start recording
        */
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start(); 
        }


        /**
        * Stop button
        */
        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();

            
        }


        /**
        * Main form
        */
        private void Form1_Load(object sender, EventArgs e)
        {
            a = 0;
            b = 0;
        }


        /**
        * Clear button
        */
        private void button4_Click(object sender, EventArgs e)
        {

            listView1.Items.Clear();

            timer2.Stop();
            timer1.Stop();

            a = 0;
            b = 0;
        }


        /**
        * Start button
        */
        private void button3_Click(object sender, EventArgs e)
        {
            timer2.Start();

            a = 0;

        }
    }
}
