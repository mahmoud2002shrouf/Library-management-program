using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace projectLibary
{

    public partial class Form2 : Form
    {
        LibaryContext ctx = new LibaryContext();


        public Form2()
        {
            InitializeComponent();
            Color panelColor = Color.FromArgb(150, 0, 0, 0); // 100 هو قيمة الألفا
            panel2.BackColor = panelColor;
            label2.BackColor = panelColor;



            Bitmap originalImage = Properties.Resources.R; // قم بتغيير YourImage إلى اسم ملف الصورة الخاص بك
            // إنشاء صورة جديدة بنفس الحجم لتحديد شفافية
            Bitmap newImage = new Bitmap(originalImage.Width, originalImage.Height);

            // استخدام Graphics لتحديد شفافية
            using (Graphics g = Graphics.FromImage(newImage))
            {
                // ضبط مستوى الشفافية
                float opacity = 0.4f; // ضبط هذا الرقم بين 0 و 1 حسب الحاجة
                ColorMatrix matrix = new ColorMatrix();
                matrix.Matrix33 = opacity;
                ImageAttributes attributes = new ImageAttributes();
                attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                // رسم الصورة بشفافية معينة
                g.DrawImage(originalImage, new Rectangle(0, 0, newImage.Width, newImage.Height), 0, 0, originalImage.Width, originalImage.Height, GraphicsUnit.Pixel, attributes);
            }

            // تعيين الصورة كخلفية للنموذج
            this.BackgroundImage = newImage;

            // قم بضبط خاصية الخلفية لتمتد وتغطي النموذج
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                string userName = textBox7.Text;
                string password = textBox6.Text;
                User user = new User();
                user = user.Verify(userName, password);
                if (user != null)
                {
                    Program.UserLogin = user;

                    Form4 f = new Form4();
                    f.SetUserLabel(Program.UserLogin);
                    f.Show();
                    this.Hide();



                }
                else
                {
                    MessageBox.Show("فشل تسجيل الدخول. تحقق من صحة بيانات تسجيل الدخول.");

                }
            }
            else if (radioButton2.Checked)
            {
                String userName = textBox7.Text;
                string password = textBox6.Text;
                Librarian lip = new Librarian();
                lip = lip.VerifyLibrarian(userName, password);

                if (lip != null)
                {
                    Program.LibrarianLogIn = lip;
                    Form3 form = new Form3();
                    form.Show();
                    this.Hide();


                }
                else
                {
                    MessageBox.Show("فشل تسجيل الدخول. تحقق من صحة بيانات تسجيل الدخول.");

                }

            }

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked || radioButton2.Checked)
            {
                button2.Enabled = true;

            }
            else
            {
                button2.Enabled = false;

            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked || radioButton2.Checked)
            {
                button2.Enabled = true;

            }
            else
            {
                button2.Enabled = false;

            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 forms = new Form1();
            forms.Show();
            this.Hide();


        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
