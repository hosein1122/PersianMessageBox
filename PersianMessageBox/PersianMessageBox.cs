using System.Drawing;
using System.Windows.Forms;
namespace HF
{
    public class PersianMessageBox
    {
        #region Propery
        public static Color BackColor { get; set; }
        public static Color ForeColor { get; set; }
        public static Font Font { get; set; }
        #endregion

        public class MessageParams
        {
            /// <summary>
            /// String that will be shown on the 'OK' Button
            ///نمایش داده می شود 'OK' مقداری که روی کلید
            /// </summary>
            public string OKString ="OK";

            /// <summary>
            /// String that will be shown on the 'Yes' Button
            ///نمایش داده می شود 'Yes' مقداری که روی کلید
            /// </summary>
            public string YesString ="Yes";
            
            /// <summary>
            /// String that will be shown on the 'No' Button
            ///نمایش داده می شود 'No' مقداری که روی کلید
            /// </summary>
            public string NoString = "NO";
            
            /// <summary>
            /// String that will be shown on the 'Cancel' Button
            ///نمایش داده می شود 'Cancel' مقداری که روی کلید
            /// </summary>
            public string CancelString= "Cancel";

            /// <summary>
            /// Set it to 'true', if message should be shown from Right To Left, else set it to 'false'.
            ///قرار دهید 'true' برای متون فارسی این مقدار را برابر
            /// </summary>
            public bool RightToLeft = true;

            /// <summary>
            /// '0': No Auto Close  -  '1-999999' : Auto Close Time Out in Millisecond
            ///مقدار زمان بر حسب میلی ثانیه، که پس از آن پیام بطور خودکار خارج می شود.
            ///اگر 0 قرار داده شود تایم اوت در نظر گرفته نخواهد شد و
            /// </summary>
            public int TimeOut = 0;

            /// <summary>
            /// 'true': To Show Caption - 'false': To Hide Caption 
            /// برای نمایش کپشن مقدار درست و در غیر این صورت مقدار نادرست را قرار دهید
            /// </summary>
            public bool ShowCaption = true;
        }

        
        private static MessageParams DeafultMessageParams = new MessageParams();
        private static System.Drawing.Icon MakeIcon(MessageBoxIcon icon)
        {
            System.Drawing.Icon myIcon;
            if (icon == MessageBoxIcon.Asterisk)
                myIcon = new System.Drawing.Icon(System.Drawing.SystemIcons.Asterisk, 32, 32);
            else if (icon == MessageBoxIcon.Error)
                myIcon = new System.Drawing.Icon(System.Drawing.SystemIcons.Error, 32, 32);
            else if (icon == MessageBoxIcon.Exclamation)
                myIcon = new System.Drawing.Icon(System.Drawing.SystemIcons.Exclamation, 32, 32);
            else if (icon == MessageBoxIcon.Hand)
                myIcon = new System.Drawing.Icon(System.Drawing.SystemIcons.Hand, 32, 32);            
            else if (icon == MessageBoxIcon.Question)
                myIcon = new System.Drawing.Icon(System.Drawing.SystemIcons.Question, 32, 32);
            else if (icon == MessageBoxIcon.Stop)
                myIcon = new System.Drawing.Icon(System.Drawing.SystemIcons.Error, 32, 32);
            else if (icon == MessageBoxIcon.Warning)
                myIcon = new System.Drawing.Icon(System.Drawing.SystemIcons.Warning, 32, 32);
            else 
                myIcon = new System.Drawing.Icon(System.Drawing.SystemIcons.Information, 32, 32);

            return myIcon;
        }

        private static DialogResult showBox(string message, string caption = "", MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.None, MessageParams messageParams = null)
        {
            if (messageParams == null)
                messageParams = DeafultMessageParams;

            DialogResult result = DialogResult.None;
            if (buttons == MessageBoxButtons.OK)
            {
                using (MessageOK mok = new MessageOK(message, caption, messageParams.TimeOut))
                {
                    if (Font != null)
                        mok.Font = Font;
                    if (BackColor != null)
                        mok.BackColor = BackColor;
                    if (ForeColor != null)
                        mok.ForeColor = ForeColor;


                    mok._Okstring = messageParams.OKString;

                    mok._ShowCaption = messageParams.ShowCaption;

                    if (icon != MessageBoxIcon.None)
                        mok.lblMessage.Image = MakeIcon(icon).ToBitmap();

                    mok.RightToLeft = messageParams.RightToLeft ? RightToLeft.Yes : RightToLeft.No;

                    result = mok.ShowDialog();
                }
            }

            if (buttons == MessageBoxButtons.YesNo)
            {
                using (MessageYesNo mYesNo= new MessageYesNo(message, caption, messageParams.TimeOut))
                {
                    if (Font != null)
                        mYesNo.Font = Font;
                    if (BackColor != null)
                        mYesNo.BackColor = BackColor;
                    if (ForeColor != null)
                        mYesNo.ForeColor = ForeColor;

                    mYesNo._YesString = messageParams.YesString;
                    mYesNo._NoString = messageParams.NoString;

                    mYesNo._ShowCaption = messageParams.ShowCaption;
                    
                    if (icon != MessageBoxIcon.None)
                        mYesNo.lblMessage.Image = MakeIcon(icon).ToBitmap();

                    mYesNo.RightToLeft = messageParams.RightToLeft ? RightToLeft.Yes : RightToLeft.No;

                    result = mYesNo.ShowDialog();
                }
            }

            if (buttons == MessageBoxButtons.YesNoCancel)
            {
                using (MessageYesNoCancel mYesNoCancel = new MessageYesNoCancel(message, caption, messageParams.TimeOut))
                {
                    if (Font != null)
                        mYesNoCancel.Font = Font;
                    if (BackColor != null)
                        mYesNoCancel.BackColor = BackColor;
                    if (ForeColor != null)
                        mYesNoCancel.ForeColor = ForeColor;

                    mYesNoCancel._YesString = messageParams.YesString;
                    mYesNoCancel._NoString = messageParams.NoString;
                    mYesNoCancel._CancelString = messageParams.CancelString;

                    mYesNoCancel._ShowCaption = messageParams.ShowCaption;

                    if (icon != MessageBoxIcon.None)
                        mYesNoCancel.lblMessage.Image = MakeIcon(icon).ToBitmap();

                    mYesNoCancel.RightToLeft = messageParams.RightToLeft ? RightToLeft.Yes : RightToLeft.No;

                    result = mYesNoCancel.ShowDialog();
                }
            }

            return result;

        }


        //MessageBox.Show("message", "caption", MessageBoxButtons.OK, MessageBoxIcon.None);
        public static DialogResult Show(string message, MessageParams messageParams = null)
        {
            return showBox(message, "", MessageBoxButtons.OK, MessageBoxIcon.None, messageParams);
        }

        public static DialogResult Show(string message, string caption, MessageParams messageParams = null)
        {
            return showBox(message, caption, MessageBoxButtons.OK, MessageBoxIcon.None, messageParams);
        }

        public static DialogResult Show(string message, string caption, MessageBoxButtons buttons, MessageParams messageParams = null)
        {
            return showBox(message, caption, buttons, MessageBoxIcon.None, messageParams);
        }

        public static DialogResult Show(string message, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageParams messageParams = null)
        {
            return showBox(message, caption, buttons, icon, messageParams);
        }

    }
}
