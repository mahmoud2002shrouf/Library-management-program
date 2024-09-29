using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace projectLibary
{
    public partial class Form3 : Form
    {
        LibaryContext ctx = new LibaryContext();
        public Form3()
        {
            InitializeComponent();

            if (Program.LibrarianLogIn != null)
            {
                label13.Text = Program.LibrarianLogIn.Name;
                label12.Text = Convert.ToString(Program.LibrarianLogIn.ID_librarian);
            }
            else
            {
                label12.Text = "";
                label13.Text = "";

            }


            try
            {
                var query2 = from Book in ctx.Books
                             select new
                             {
                                 ISBN = Book.ISBN,
                                 Title = Book.Title,
                                 Author = Book.Author,
                                 Publication = Book.Publication,
                                 status = Book.status,
                                 ldb_id = Book.ldb_id,
                                 ID_librarian = Book.ID_librarian,
                                 UserId = Book.UserId,
                                 dateBorrowing = Book.dateBorrowing,
                                 dateRetarn = Book.dateRetarn,


                             };
                dataGridView1.DataSource = query2.ToList();
                dataGridView3.DataSource = query2.ToList();


            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine($"InvalidCastException: {ex.Message}");
            }

            var query = from account in ctx.Accounts
                        join user in ctx.users on account.UserId equals user.UserId
                        select new
                        {
                            AccountId = account.AccountId,
                            UserName = user.UserName,
                            No_BorrowedBooks = account.No_BorrowedBooks,
                            No_ReturnedBooks = account.No_ReturnedBooks,
                            No_LostBooks = account.No_LostBooks,
                            FineAmount = account.FineAmount,
                            UserId = account.UserId,
                            No_Late_book = account.No_Late_book,

                        };



            dataGridView2.DataSource = query.ToList();
            var userWithMostBooks = (from book in ctx.Books
                                     group book by book.UserId into userBooks
                                     orderby userBooks.Count() descending
                                     select userBooks.Key).FirstOrDefault();
            label29.Text = userWithMostBooks.ToString();

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

            string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            var res = ctx.Books.SingleOrDefault(s => s.ISBN == id);
         
            if (res != null)
            {
                if (res.UserId == null)
                {
                    radioButton1.Enabled = false;
                    radioButton2.Enabled = false;
                    radioButton3.Enabled = false;
                    radioButton4.Enabled = false;


                }
                else
                {
                    radioButton1.Enabled = true;
                    radioButton2.Enabled = true;
                    radioButton3.Enabled = true;
                    radioButton4.Enabled = true;
                }
                textBox1.Text = res.ISBN.ToString();
                textBox2.Text = res.Title;
                textBox3.Text = res.Author;
                textBox4.Text = res.Publication;
                if (res.status == "Existing")
                {
                    radioButton1.Checked = true;
                }
                else if (res.status == "Borrowed")
                {
                    radioButton2.Checked = true;
                }
                else if (res.status == "Late")
                {
                    radioButton4.Checked = true;
                }
                else
                {
                    radioButton3.Checked = true;
                }
            }



        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (chackdata())
            {
                string IBSM = textBox6.Text;
                var bookss = ctx.Books.SingleOrDefault(s => s.ISBN == IBSM);
                if (bookss != null)
                {
                    MessageBox.Show("ISBN مستخدم من قبل");
                }
                else
                {

                    Book book = new Book() { ISBN = textBox6.Text, Author = textBox7.Text, Title = textBox9.Text, Publication = textBox8.Text, status = "Existing", ldb_id = Program.LibrarianLogIn.ldb_id };
                    LibraryDataBase libdb = ctx.LibraryDataBase.SingleOrDefault(s => s.ldb_id == book.ldb_id);
                    if (Program.LibrarianLogIn != null)
                    {
                        libdb.Add(book);


                        textBox6.Text = "";
                        textBox7.Text = "";
                        textBox8.Text = "";
                        textBox9.Text = "";




                        dataGridView1.DataSource = ctx.Books.ToList();



                    }
                    else
                    {
                        MessageBox.Show("null");
                    }






                }


            }
            else
            {
                MessageBox.Show("data null");
            }


        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
        public bool chackdata()
        {
            if (textBox8.Text != null && textBox7.Text != null && textBox9.Text != null)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Program.LibrarianLogIn = null;
            Form2 form = new Form2();
            form.Show();
            this.Hide();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Book b = ctx.Books.SingleOrDefault(s => s.ISBN == textBox1.Text && s.Title == textBox2.Text);
            LibraryDataBase libdb = ctx.LibraryDataBase.SingleOrDefault(s => s.ldb_id == b.ldb_id);
            libdb.Delete(b.ISBN.ToString());
            MessageBox.Show("تم الحذف");
            dataGridView1.DataSource = ctx.Books.ToList();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            Book b = ctx.Books.SingleOrDefault(s => s.ISBN == id);
            LibraryDataBase libdb = ctx.LibraryDataBase.SingleOrDefault(s => s.ldb_id == b.ldb_id);
            if (textBox2.Text != "")
            {
                b.Title = textBox2.Text;


            }
            if (textBox3.Text != "")
            {
                b.Author = textBox3.Text;


            }
            if (textBox4.Text != "")
            {
                b.Publication = textBox4.Text;


            }
            
            if(b.UserId != null)
            {
                Account ac = ctx.Accounts.SingleOrDefault(s => s.UserId == b.UserId);

                if (radioButton1.Checked)

                {
                    b.status = "Existing";
                    b.dateRetarn = null;
                    b.dateBorrowing = null;

                    b.User = null;
                    b.UserId = null;
                    ac.No_ReturnedBooks += 1;
                    if (b.status == "Late")
                    {
                        ac.No_Late_book -= 1;

                    }else if(b.status == "Lost")
                    {
                        ac.No_LostBooks -= 1;

                    }else if(b.status== "Borrowed")
                    {
                        ac.No_BorrowedBooks -= 1;

                    }

                    ctx.Accounts.Update(ac);

                }
                else if (radioButton2.Checked)
                {
                    b.status = "Borrowed";
                    ac.No_BorrowedBooks += 1;
                    ctx.Accounts.Update(ac);


                }
                else if (radioButton4.Checked)
                {
                    b.status = "Late";
                    ac.No_BorrowedBooks -= 1;

                    ac.No_Late_book += 1;
                    ctx.Accounts.Update(ac);

                }
                else
                {
                    b.status = "Lost";

                    ac.No_LostBooks += 1;
                    ac.No_BorrowedBooks -= 1;

                    ctx.Accounts.Update(ac);


                }
             

            }
            ctx.Books.Update(b);
            ctx.SaveChanges();
            //libdb.Update(b.ISBN.ToString());
            MessageBox.Show("تم التحديث");





            dataGridView1.DataSource = ctx.Books.ToList();

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
        }

        private void label7_Click(object sender, EventArgs e)
        {
        }

        private void label8_Click(object sender, EventArgs e)
        {
        }

        private void label9_Click(object sender, EventArgs e)
        {
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
        }

        private void label11_Click(object sender, EventArgs e)
        {
        }

        private void label14_Click(object sender, EventArgs e)
        {
        }

        private void label10_Click(object sender, EventArgs e)
        {
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int id = (int)dataGridView2.CurrentRow.Cells[0].Value;

            Account b = ctx.Accounts.SingleOrDefault(s => s.AccountId == id);

            if (textBox12.Text != "")
            {
                b.No_BorrowedBooks = Convert.ToInt32(textBox12.Text);


            }
            if (textBox5.Text != "")
            {
                b.No_Late_book = Convert.ToInt32(textBox5.Text);


            }
            if (textBox10.Text != "")
            {
                b.No_ReturnedBooks = Convert.ToInt32(textBox10.Text);


            }
            if (textBox13.Text != "")
            {
                b.No_LostBooks = Convert.ToInt32(textBox13.Text);


            }
            if (textBox14.Text != "")
            {
                b.FineAmount = Convert.ToDecimal(textBox14.Text);


            }
            b.FineAmount = (Convert.ToDecimal(textBox13.Text) * 5) + (Convert.ToDecimal(textBox5.Text) * 3);
            b.Update_Acount(b);

            MessageBox.Show("تم التحديث");

            var query = from account in ctx.Accounts
                        join user in ctx.users on account.UserId equals user.UserId
                        select new
                        {
                            AccountId = account.AccountId,
                            UserName = user.UserName,
                            No_BorrowedBooks = account.No_BorrowedBooks,
                            No_ReturnedBooks = account.No_ReturnedBooks,
                            No_LostBooks = account.No_LostBooks,
                            No_Late_book = account.No_Late_book,

                            FineAmount = account.FineAmount,
                            UserId = account.UserId,
                        };



            dataGridView2.DataSource = query.ToList();
        }

        private void label15_Click(object sender, EventArgs e)
        {
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            int AccountId = (int)dataGridView2.CurrentRow.Cells[0].Value;

            var res = ctx.Accounts.SingleOrDefault(s => s.AccountId == AccountId);
            var user = ctx.users.SingleOrDefault(s => s.AccountId == AccountId);
            
            if (res != null)
            {

                textBox11.Text = user.UserName;
                textBox12.Text = res.No_BorrowedBooks.ToString();
                textBox5.Text = res.No_Late_book.ToString();
                textBox10.Text = res.No_ReturnedBooks.ToString();
                textBox13.Text = res.No_LostBooks.ToString();
                textBox14.Text = res.FineAmount.ToString();



            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.Text == "Show the books you are responsible for :")
            {
                var query2 = from book in ctx.Books
                             where book.ID_librarian == Program.LibrarianLogIn.ID_librarian
                             select new
                             {
                                 ISBN = book.ISBN,
                                 Title = book.Title,
                                 Author = book.Author,
                                 Publication = book.Publication,
                                 status = book.status,
                                 ldb_id = book.ldb_id,
                                 ID_librarian = book.ID_librarian,
                                 UserId = book.UserId,
                                 dateBorrowing = book.dateBorrowing,
                                 dateRetarn = book.dateRetarn,
                             };

                dataGridView1.DataSource = query2.ToList();
                button5.Text = "View all books";
            }
            else
            {
                var query2 = from book in ctx.Books
                             select new
                             {
                                 ISBN = book.ISBN,
                                 Title = book.Title,
                                 Author = book.Author,
                                 Publication = book.Publication,
                                 status = book.status,
                                 ldb_id = book.ldb_id,
                                 ID_librarian = book.ID_librarian,
                                 UserId = book.UserId,
                                 dateBorrowing = book.dateBorrowing,
                                 dateRetarn = book.dateRetarn,
                             };
                button5.Text = "Show the books you are responsible for :";


                dataGridView1.DataSource = query2.ToList();

            }
        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            /* List<Book> books = new List<Book>();
             foreach(Book book in ctx.Books)
             {
                 if(book.ISBN== textBox15.Text ||book.Author== textBox17.Text||book.Title== textBox16.Text)
                 {
                     books.Add(book);
                 }
             }
             dataGridView3.DataSource= books.ToList();*/
            if (textBox15.Text == "" && textBox16.Text == "" && textBox17.Text == "")
            {
                MessageBox.Show("Fill out one of these information");
            }
            else
            {


                var searchQuery = from book in ctx.Books
                                  where book.ISBN == textBox15.Text ||
                                        book.Author == textBox17.Text ||
                                        book.Title == textBox16.Text
                                  select new
                                  {
                                      ISBN = book.ISBN,
                                      Title = book.Title,
                                      Author = book.Author,
                                      Publication = book.Publication,
                                      status = book.status,
                                      ldb_id = book.ldb_id,
                                      ID_librarian = book.ID_librarian,
                                      UserId = book.UserId,
                                      dateBorrowing = book.dateBorrowing,
                                      dateRetarn = book.dateRetarn,
                                  };

                dataGridView3.DataSource = searchQuery.ToList();

            }
        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            string authorName = textBox18.Text;
            var authorBooksCount = (from book in ctx.Books
                                    where book.Author == authorName
                                    select book).Count();
            label32.Text = authorBooksCount.ToString();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            var query2 = from Book in ctx.Books
                         select new
                         {
                             ISBN = Book.ISBN,
                             Title = Book.Title,
                             Author = Book.Author,
                             Publication = Book.Publication,
                             status = Book.status,
                             ldb_id = Book.ldb_id,
                             ID_librarian = Book.ID_librarian,
                             UserId = Book.UserId,
                             dateBorrowing = Book.dateBorrowing,
                             dateRetarn = Book.dateRetarn,


                         };
            dataGridView3.DataSource = query2.ToList();

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            var query = from account in ctx.Accounts
                        join user in ctx.users on account.UserId equals user.UserId
                        select new
                        {
                            UserName = user.UserName,

                            FineAmount = account.FineAmount,
                            UserId = account.UserId,
                        };
            dataGridView3.DataSource = query.ToList();

        }
    }
}
