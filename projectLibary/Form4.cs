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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace projectLibary
{
    public partial class Form4 : Form
    {
        LibaryContext ctx = new LibaryContext();

        public Form4()
        {
            InitializeComponent();
            ApplyCustomStyles(Form4.ActiveForm);
            ApplyLabelStyle(this.Controls);


            ApplyDataGridViewStyle(dataGridView1);
            Bitmap originalImage = Properties.Resources.R;
            Bitmap newImage = new Bitmap(originalImage.Width, originalImage.Height);

            using (Graphics g = Graphics.FromImage(newImage))
            {
                float opacity = 0.4f;
                ColorMatrix matrix = new ColorMatrix();

                matrix.Matrix33 = opacity;
                ImageAttributes attributes = new ImageAttributes();
                attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                g.DrawImage(originalImage, new Rectangle(0, 0, newImage.Width, newImage.Height), 0, 0, originalImage.Width, originalImage.Height, GraphicsUnit.Pixel, attributes);
            }

            this.BackgroundImage = newImage;

            this.BackgroundImageLayout = ImageLayout.Stretch;




            var query2 = from Book in ctx.Books
                         select new
                         {
                             ISBN = Book.ISBN,
                             Title = Book.Title,
                             Author = Book.Author,
                             Publication = Book.Publication,
                             status = Book.status


                         };
            dataGridView1.DataSource = query2.ToList();

        }
        public void SetUserLabel(User user)
        {
            if (user != null)
            {
                label13.Text = user.UserName;
                label12.Text = Convert.ToString(user.UserId);
                label7.Text = user.UserTayp;
                Account ac = ctx.Accounts.SingleOrDefault(s => s.UserId == user.UserId);
                /*   label25.Text = Convert.ToString(ac.No_BorrowedBooks);
                   label24.Text = Convert.ToString(ac.No_ReturnedBooks);
                   label26.Text = Convert.ToString(ac.No_Late_book);
                   label27.Text = Convert.ToString(ac.No_LostBooks);
                   label28.Text = Convert.ToString(ac.FineAmount);*/






                Studant stu = ctx.studants.SingleOrDefault(s => s.UserId == user.UserId);
                Staff staf = ctx.staff.SingleOrDefault(s => s.UserId == user.UserId);
                if (staf != null)
                {
                    label8.Text = "Department";
                    label9.Text = staf.Department;


                }
                if (stu != null)
                {
                    label8.Text = "Class";
                    label9.Text = stu.Class;

                }
            }
            else
            {
                label12.Text = "";
                label13.Text = "";

            }

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }



        private void button1_Click(object sender, EventArgs e)
        {
            User userLogin = Program.UserLogin;

            Book b = ctx.Books.SingleOrDefault(s => s.ISBN == textBox1.Text);
            if (button1.Text == "Lost")
            {
                b.status = "Lost";
                Account ac = ctx.Accounts.FirstOrDefault(s => s.UserId == b.UserId);
                ac.No_LostBooks += 1;
                ctx.Accounts.Update(ac);
                ctx.Books.Update(b);
                ctx.SaveChanges();

            }
            else
            {



                if (b.status != "Existing")
                {
                    MessageBox.Show("This book is not currently available. It may be available at some date " + b.dateRetarn);
                }
                else
                {
                    b.Borrow(Program.UserLogin, dateTimePicker1.Value, b.ISBN.ToString());
                }




            }




            var query2 = from Book in ctx.Books
                         select new
                         {
                             ISBN = Book.ISBN,
                             Title = Book.Title,
                             Author = Book.Author,
                             Publication = Book.Publication,
                             status = Book.status


                         };
            dataGridView1.DataSource = query2.ToList();



        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Program.UserLogin = null;
            Form2 form = new Form2();
            form.Show();
            this.Hide();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.MinDate = DateTime.Now;
        }

        private void label13_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

            string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            Book book = ctx.Books.SingleOrDefault(s => s.ISBN == id);

            textBox1.Text = id;

            textBox2.Text = book.Author;
            textBox3.Text = book.Publication;
            textBox4.Text = book.Title;

        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            if (button2.Text == "My Book")
            {
                button2.Text = "All Book";
                var userBooksQuery = from book in ctx.Books
                                     where book.UserId == Program.UserLogin.UserId
                                     select new
                                     {
                                         ISBN = book.ISBN,
                                         Title = book.Title,
                                         Author = book.Author,
                                         Publication = book.Publication,
                                         Status = book.status,
                                         DateBorrowing = book.dateBorrowing,
                                         DateReturn = book.dateRetarn,
                                     };
                dataGridView1.DataSource = userBooksQuery.ToList();
            }
            else
            {
                button2.Text = "My Book";
                var userBooksQuery = from book in ctx.Books
                                     select new
                                     {
                                         ISBN = book.ISBN,
                                         Title = book.Title,
                                         Author = book.Author,
                                         Publication = book.Publication,
                                         Status = book.status,
                                         DateBorrowing = book.dateBorrowing,
                                         DateReturn = book.dateRetarn,
                                     };
                dataGridView1.DataSource = userBooksQuery.ToList();

            }
        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            string statusValue = row.Cells["Status"].Value.ToString();
            switch (statusValue)
            {
                case "Borrowed":
                    row.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                    break;
                case "Existing":
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                    break;
                case "Late":
                    row.DefaultCellStyle.BackColor = Color.LightCoral;
                    break;
                case "Lost":
                    row.DefaultCellStyle.BackColor = Color.LightGray;
                    break;
                default:
                    row.DefaultCellStyle.BackColor = Color.White;
                    break;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == "" && textBox6.Text == "" && textBox7.Text == "")
            {
                MessageBox.Show("Fill out one of these information");
            }
            else
            {
                var searchQuery = from book in ctx.Books
                                  where book.ISBN == textBox5.Text ||
                                  book.Author == textBox6.Text ||
                                                          book.Title == textBox7.Text
                                  select new
                                  {
                                      ISBN = book.ISBN,
                                      Title = book.Title,
                                      Author = book.Author,
                                      Publication = book.Publication,
                                      status = book.status,

                                      dateBorrowing = book.dateBorrowing,
                                      dateRetarn = book.dateRetarn,
                                  };

                dataGridView1.DataSource = searchQuery.ToList();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            User userLogin = Program.UserLogin;


            Book b = ctx.Books.SingleOrDefault(s => s.ISBN == textBox1.Text);

            b.UpdateStatus(b.ISBN, Convert.ToInt32(b.UserId));

            var query2 = from Book in ctx.Books
                         where b.UserId == Program.UserLogin.UserId

                         select new
                         {
                             ISBN = Book.ISBN,
                             Title = Book.Title,
                             Author = Book.Author,
                             Publication = Book.Publication,
                             status = Book.status


                         };
            dataGridView1.DataSource = query2.ToList();









        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            var books = ctx.Books.ToList();
            foreach (var book in books)
            {
                if (DateTime.Now > book.dateRetarn && book.status == "Borrowed" && book.UserId != null)
                {
                    book.status = "Late";
                    book.User.account.No_Late_book += 1;
                    book.User.account.No_BorrowedBooks -= 1;
                    ctx.Books.Update(book);
                }
            }
            var userId = Program.UserLogin.UserId;
            Account account = ctx.Accounts.SingleOrDefault(s => s.UserId == Program.UserLogin.UserId);
            account.No_BorrowedBooks = ctx.Books.Count(book => book.UserId == userId && book.status == "Borrowed");
            account.No_Late_book = ctx.Books.Count(book => book.UserId == userId && book.status == "Late");
            account.No_LostBooks = ctx.Books.Count(book => book.UserId == userId && book.status == "Lost");

            ctx.Accounts.Update(account);
            ctx.SaveChanges();
            Form5 f = new Form5();
            f.ShowDialog();





        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (button2.Text == "My Book")
            {
                button3.Enabled = false;
                button1.Text = "Borrow";




            }
            else
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                    string status = selectedRow.Cells["status"].Value.ToString();

                    if (status == "Existing")
                    {
                        button1.Text = "Borrow";
                        button3.Enabled = false;
                    }
                    else
                    {
                        button1.Text = "Lost";
                        button3.Enabled = true;
                    }
                }
            }

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
        private void ApplyCustomStyles(Form tabControl)
        {


            tabControl.BackColor = Color.LightSkyBlue;


            // إضافة معالج الرسم المخصص
        }

        private void DrawTabItem(object sender, DrawItemEventArgs e)
        {

            // تعديل ألوان التابات والخلفية كما ترغب
            using (Brush backBrush = new SolidBrush(this.BackColor))
            {
                e.Graphics.FillRectangle(backBrush, e.Bounds);
            }

            var format = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            // تعديل ألوان وخصائص التاب حسب الحالة
            Brush brush = new SolidBrush(this.ForeColor);
            Pen pen = new Pen(this.ForeColor);


            brush = new SolidBrush(this.BackColor);
            pen = new Pen(this.BackColor, 2);


            e.Graphics.FillRectangle(brush, e.Bounds);
            e.Graphics.DrawRectangle(pen, e.Bounds);

        }
        private void ApplyLabelStyle(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control is Label)
                {
                    Label label = (Label)control;
                    label.ForeColor = Color.WhiteSmoke;
                    label.BackColor = Color.LightSteelBlue;
                    label.Font = new Font("Segoe UI", 13.8f, FontStyle.Bold | FontStyle.Italic);  // تعيين الخط وحجم الخط والنمط هنا
                }

                if (control.HasChildren)
                {
                    ApplyLabelStyle(control.Controls);
                }
            }

        }

        private void ApplyDataGridViewStyle(DataGridView dataGridView)
        {
            dataGridView.DefaultCellStyle.BackColor = Color.LightGray;
            dataGridView.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView.RowsDefaultCellStyle.BackColor = Color.White;
            dataGridView.RowsDefaultCellStyle.ForeColor = Color.Black;
            dataGridView.DefaultCellStyle.BackColor = Color.LightGray;
            dataGridView.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView.RowsDefaultCellStyle.BackColor = Color.White;
            dataGridView.RowsDefaultCellStyle.ForeColor = Color.Black;
            dataGridView.ColumnHeadersHeight = 40;

            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;


        }

    }
}

