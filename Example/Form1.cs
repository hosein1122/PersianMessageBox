using System;
using System.Drawing;
using System.Windows.Forms;

namespace Mssage
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            HF.PersianMessageBox.Show("ذخیره شد!      متن دوم.    متن سوم  \r\n متن چهارم      متن پنجم", " اولین Caption", MessageBoxButtons.OK, MessageBoxIcon.Warning,
                new HF.PersianMessageBox.MessageParams()
                {
                    OKString = "قبول",
                    ShowCaption=true,
                    TimeOut = 2000
                });
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //PersianMessageBox.PersianMessageBox._BackColor = Color.LightGreen;
            //PersianMessageBox.PersianMessageBox._ForeColor = Color.Black;
            //PersianMessageBox.PersianMessageBox._Font= new System.Drawing.Font("tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));

            HF.PersianMessageBox.Show("ذخیره شد!      متن دوم.    متن سوم   متن چهارم      متن پنجم", " اولین Caption",MessageBoxButtons.YesNo,MessageBoxIcon.None , 
                new HF.PersianMessageBox.MessageParams()
                {
                    YesString = "بله",
                    NoString = "خیر",
                    ShowCaption=false,
                    TimeOut = 0
                });
            
        }

        private void Button3_Click(object sender, EventArgs e)
        {

            HF.PersianMessageBox.Show("ذخیره شد!     \r\n متن دوم.    متن سوم \r\n  متن چهارم \r\n     متن پنجم", " اولین Caption", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question,
                new HF.PersianMessageBox.MessageParams()
                {
                    YesString = "ذخیره تغییرات",
                    NoString = "لغو تغییرات",
                    CancelString= "بازگشت",
                    ShowCaption=true,
                    TimeOut = 2000
                });
        }
    }
}
