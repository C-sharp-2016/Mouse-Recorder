using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading; 
   

namespace MouseRec
{
    public partial class Form1 : Form
    {
        ListViewItem lv;
        int a, b;
        public event EventHandler Click;
        private string keyPressed;



 
      










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


                //trigger inputed key to press 
                string forceKey = listView1.Items[a].SubItems[2].Text.ToString(); 
                SendKeys.Send(forceKey);


                //go to the point direction where the cursor is been recorded
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
            lv.SubItems.Add(keyPressed);
            listView1.Items.Add(lv);
            b++;
            keyPressed = "";
        }

        /** 
        * Start recording
        */
        private void button1_Click(object sender, EventArgs e)
        {
            //listView1.Clear();
            timer1.Start();
            a = 0;
            b = 0;
            
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

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Console.WriteLine("key pressed");
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Console.WriteLine("Key pressed");
        }


        /**
        * Text field key pressed
        */
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            Console.WriteLine("pressed  key code = " + e.KeyCode + " key data = " + e.KeyData + " key SuppressKeyPress = " + e.SuppressKeyPress + " key value = " + e.KeyValue);

            keyPressed = e.KeyData.ToString(); 
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
