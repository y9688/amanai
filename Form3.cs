using System;
using System.Drawing;
using System.Windows.Forms;

namespace frist_project
{
    public partial class Form3 : Form
    {
        private TextBox inputText;
        private Label resultLabel;
        private ProgressBar progress;

        public Form3()
        {
            InitializeComponent();
            Text = "أمان اليمن - التحليل والأدلة";
            Size = new Size(950, 620);
            StartPosition = FormStartPosition.CenterParent;
            BackColor = Color.FromArgb(15, 23, 42);
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            BuildForm();
        }

        private void BuildForm()
        {
            MenuStrip menu = new MenuStrip();
            menu.BackColor = Color.FromArgb(30, 41, 59);
            menu.ForeColor = Color.White;
            ToolStripMenuItem analysis = new ToolStripMenuItem("التحليل");
            analysis.DropDownItems.Add(Item("تحليل النص", AnalyzeText));
            analysis.DropDownItems.Add(Item("اختيار ملف", SelectFile));
            analysis.DropDownItems.Add(Item("مسح النتيجة", ClearResult));
            menu.Items.Add(analysis);
            ToolStripMenuItem help = new ToolStripMenuItem("مساعدة");
            help.DropDownItems.Add(Item("حول المحلل", About));
            menu.Items.Add(help);
            Controls.Add(menu);
            MainMenuStrip = menu;

            Label title = new Label();
            title.Text = "محرك تحليل البلاغات والأدلة";
            title.Left = 30;
            title.Top = 55;
            title.Width = 700;
            title.Height = 45;
            title.ForeColor = Color.White;
            title.Font = new Font("Tahoma", 18F, FontStyle.Bold);
            Controls.Add(title);

            Label hint = new Label();
            hint.Text = "اكتب نص البلاغ ثم اضغط تحليل النص، أو اختر ملفاً للفحص الأولي.";
            hint.Left = 30;
            hint.Top = 105;
            hint.Width = 750;
            hint.ForeColor = Color.FromArgb(148, 163, 184);
            Controls.Add(hint);

            inputText = new TextBox();
            inputText.Left = 30;
            inputText.Top = 145;
            inputText.Width = 850;
            inputText.Height = 150;
            inputText.Multiline = true;
            inputText.ScrollBars = ScrollBars.Vertical;
            inputText.BackColor = Color.FromArgb(30, 41, 59);
            inputText.ForeColor = Color.White;
            Controls.Add(inputText);

            Button analyze = new Button();
            analyze.Text = "تحليل النص";
            analyze.Left = 30;
            analyze.Top = 320;
            analyze.Width = 150;
            analyze.Height = 42;
            analyze.BackColor = Color.FromArgb(37, 99, 235);
            analyze.ForeColor = Color.White;
            analyze.FlatStyle = FlatStyle.Flat;
            analyze.Click += AnalyzeText;
            Controls.Add(analyze);

            Button file = new Button();
            file.Text = "اختيار ملف";
            file.Left = 195;
            file.Top = 320;
            file.Width = 150;
            file.Height = 42;
            file.Click += SelectFile;
            Controls.Add(file);

            progress = new ProgressBar();
            progress.Left = 30;
            progress.Top = 385;
            progress.Width = 850;
            progress.Height = 25;
            Controls.Add(progress);

            resultLabel = new Label();
            resultLabel.Text = "النتيجة ستظهر هنا";
            resultLabel.Left = 30;
            resultLabel.Top = 435;
            resultLabel.Width = 850;
            resultLabel.Height = 75;
            resultLabel.BackColor = Color.FromArgb(30, 41, 59);
            resultLabel.ForeColor = Color.White;
            resultLabel.Font = new Font("Tahoma", 11F, FontStyle.Bold);
            resultLabel.TextAlign = ContentAlignment.MiddleRight;
            Controls.Add(resultLabel);
        }

        private ToolStripMenuItem Item(string text, EventHandler handler)
        {
            ToolStripMenuItem item = new ToolStripMenuItem(text);
            item.Click += handler;
            return item;
        }

        private void AnalyzeText(object sender, EventArgs e)
        {
            string text = inputText.Text;
            int score = 10;
            if (text.Contains("تهديد")) score += 25;
            if (text.Contains("ابتزاز")) score += 30;
            if (text.Contains("تحويل مالي")) score += 20;
            if (text.Contains("عاجل")) score += 15;
            if (score > 100) score = 100;
            progress.Value = score;
            resultLabel.Text = "درجة الخطورة: " + score + "%\n" + (score >= 70 ? "المستوى: مرتفع - يحتاج مراجعة عاجلة" : "المستوى: يحتاج مراجعة بشرية");
        }

        private void SelectFile(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "كل الملفات|*.*|الصور|*.png;*.jpg;*.jpeg|الصوت|*.wav;*.mp3|الفيديو|*.mp4;*.avi";
            using (dialog)
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                    resultLabel.Text = "تم اختيار الملف للفحص الأولي:\n" + dialog.FileName;
            }
        }

        private void ClearResult(object sender, EventArgs e)
        {
            inputText.Clear();
            progress.Value = 0;
            resultLabel.Text = "النتيجة ستظهر هنا";
        }

        private void About(object sender, EventArgs e)
        {
            MessageBox.Show("هذا محلل أولي مساعد وليس حكماً جنائياً.", "حول المحلل");
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // هذه الدالة مطلوبة لأن Form3.Designer.cs يربط حدث Load بها.
            // يمكن وضع أوامر تحميل البيانات الأولية هنا لاحقاً.
        }
    }
}
