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
        bool shift = false;
        bool ctrl = false;
        bool alt = false;

        private void BUTTON_CLICK(object sender, EventArgs e)
        {
            try
            {
                Button thisButton = (Button)sender;
                if (ctrl)
                {                   
                    System.Windows.Forms.SendKeys.SendWait("^{" + thisButton.Text+"}");
                    ctrl = false;

                }
                else if (alt)
                {

                    System.Windows.Forms.SendKeys.SendWait("%{" + thisButton.Text+"}");
                    alt = false;
                }
                else if (shift)
                {

                    System.Windows.Forms.SendKeys.SendWait("+{" + thisButton.Text+"}");
                    shift = false;
                }
                else if (capsLock)
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

       
        private void Ctrl(object sender, EventArgs e)
        {
            ctrl = !ctrl;            
        }

        private void Alt(object sender, EventArgs e)
        {
            alt = !alt;
        }

        private void Shift(object sender, EventArgs e)
        {
            shift = !shift;
        }

        private void capslock(object sender, EventArgs e)
        {
            capsLock = !capsLock;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
