using System;
using System.Drawing;
using System.Windows.Forms;

namespace frist_project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // إعدادات النافذة الرئيسية
            this.Text = "أمان اليمن - المنصة الرئيسية";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            this.MinimumSize = new Size(1100, 650);
            this.BackColor = Color.FromArgb(15, 23, 42);
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // ضع كود تحميل البيانات هنا لاحقاً
        }
    }
}
