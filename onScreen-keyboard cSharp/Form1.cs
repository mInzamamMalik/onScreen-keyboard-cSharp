using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace onScreen_keyboard_cSharp
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
            
        }

       
        ///  this peice of code will make my form "never active or focused", i dont know how but its working :-)       
        const int WS_EX_NOACTIVATE = 0x08000000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams param = base.CreateParams;
                param.ExStyle |= WS_EX_NOACTIVATE;
                return param;
            }
        } ///  End


        bool capsLock = false;

        private void BUTTON_CLICK(object sender, EventArgs e)
        {
            try
            {
                Button thisButton = (Button)sender;
                if (capsLock)
                {
                    System.Windows.Forms.SendKeys.SendWait("{" + thisButton.Text.ToUpper() + "}");
                }
                else
                {
                    System.Windows.Forms.SendKeys.SendWait("{" + thisButton.Text.ToLower() + "}");
                }
            }
            catch (Exception)
            {
                //***do nothing on exception***
                //some time when system busy and
                //we press to many buttons at a time it a throwing an exception
            }
                    
        }

        private void button35_Click(object sender, EventArgs e)
        {
            capsLock = !capsLock;
            button35.Text = "Caps lock is " + capsLock.ToString();         
        }

    }
}
