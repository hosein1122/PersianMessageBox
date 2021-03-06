using System;
using System.Windows.Forms;

namespace HF
{
    partial class MessageOK : Form
    {
        Timer timer1;

        string _Message, _Caption;
        int _Timeout;
        public MessageOK(string message, string caption = "", int timeout = 0)
        {
            InitializeComponent();
            _Message = message;
            _Caption = caption;
            _Timeout = timeout;
        }

        public string _Okstring
        {
            set
            {
                btnOK.Text = !String.IsNullOrEmpty(value) ? value : "OK";
            }
        }

        public bool _ShowCaption { get; set; }
        private void SetCaption()
        {
            this.tableLayoutPanel1.RowCount = 3;

            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));

            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblMessage, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnOK, 0, 2);
        }

        private void UnSetCaption()
        {
            this.tableLayoutPanel1.RowCount = 2;

            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));

            this.tableLayoutPanel1.Controls.Remove(this.tableLayoutPanel2);
            this.tableLayoutPanel1.Controls.Add(this.lblMessage, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnOK, 0, 1);
        }

        private void MessageOK_Load(object sender, EventArgs e)
        {
            //نمایش یا عدم نمایش  Capthon
            if (_ShowCaption)
                SetCaption();
            else
                UnSetCaption();
            

            //تعیین اندازه صفحه پیام
            using (System.Drawing.Graphics g = System.Drawing.Graphics.FromHwnd(IntPtr.Zero))
            {
                System.Drawing.SizeF size = g.MeasureString(_Message, this.Font);
                this.Size = new System.Drawing.Size((int)size.Width + 100, (int)size.Height + 80);
            }

            //نمایش پیام
            lblCaption.Text = _Caption;
            lblMessage.Text = _Message;

            //تایمر جهت خروج خودکار
            if (_Timeout > 0)
            {
                timer1 = new Timer();
                timer1.Tick += Timer1_Tick;
                timer1.Interval = _Timeout;
                timer1.Enabled = true;
            }

        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}
