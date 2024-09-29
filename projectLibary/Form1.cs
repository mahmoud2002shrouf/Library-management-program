using Microsoft.VisualBasic.ApplicationServices;
using System.Collections;
using System.Drawing.Imaging;
using static System.Reflection.Metadata.BlobBuilder;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace projectLibary
{
    public partial class Form1 : Form
    {
        LibaryContext context = new LibaryContext();

        public Form1()
        {
            InitializeComponent();
            Bitmap originalImage = Properties.Resources.R; // Þã ÈÊÛííÑ YourImage Åáì ÇÓã ãáÝ ÇáÕæÑÉ ÇáÎÇÕ Èß
            // ÅäÔÇÁ ÕæÑÉ ÌÏíÏÉ ÈäÝÓ ÇáÍÌã áÊÍÏíÏ ÔÝÇÝíÉ
            Bitmap newImage = new Bitmap(originalImage.Width, originalImage.Height);

            // ÇÓÊÎÏÇã Graphics áÊÍÏíÏ ÔÝÇÝíÉ
            using (Graphics g = Graphics.FromImage(newImage))
            {
                // ÖÈØ ãÓÊæì ÇáÔÝÇÝíÉ
                float opacity = 0.4f; // ÖÈØ åÐÇ ÇáÑÞã Èíä 0 æ 1 ÍÓÈ ÇáÍÇÌÉ
                ColorMatrix matrix = new ColorMatrix();
                matrix.Matrix33 = opacity;
                ImageAttributes attributes = new ImageAttributes();
                attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                // ÑÓã ÇáÕæÑÉ ÈÔÝÇÝíÉ ãÚíäÉ
                g.DrawImage(originalImage, new Rectangle(0, 0, newImage.Width, newImage.Height), 0, 0, originalImage.Width, originalImage.Height, GraphicsUnit.Pixel, attributes);
            }

            // ÊÚííä ÇáÕæÑÉ ßÎáÝíÉ ááäãæÐÌ
            this.BackgroundImage = newImage;

            // Þã ÈÖÈØ ÎÇÕíÉ ÇáÎáÝíÉ áÊãÊÏ æÊÛØí ÇáäãæÐÌ
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                label7.Text = "Class";
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {



        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                label7.Text = "Dept";
            }
        }
        public bool checkDataUser()
        {
            bool radio = radioButton1.Checked || radioButton2.Checked;
            if (textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && radio)
            {
                return true;

            }
            else
            {

                return false;
            }
        }
        public bool checkDataLibrarian()
        {
            if (textBox7.Text != "" && textBox6.Text != "")
            {
                return true;

            }
            else
            {
                MessageBox.Show("Make sure that you have filled in all the information ^_^");
                return false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (checkDataUser())
            {
                User users = context.users.SingleOrDefault(s => s.name == textBox2.Text);

                if (users != null)
                {
                    MessageBox.Show("Use another name ^_^");
                }
                else
                {

                    if (radioButton1.Checked)
                    {


                        Studant studants = new Studant()
                        {
                            name = textBox2.Text,
                            UserName = textBox2.Text,
                            Password = textBox3.Text,
                            UserTayp = "studant user",
                            account = new Account()
                            {
                                No_BorrowedBooks = 0,
                                No_Late_book = 0,
                                No_ReturnedBooks = 0,
                                No_LostBooks = 0,
                                FineAmount = 0,



                            },
                            Class = textBox4.Text,

                        };
                        studants.Register(studants);
                        var user = context.users.FirstOrDefault(u => u.UserName == textBox2.Text && u.Password == textBox3.Text);
                        var account = context.Accounts.FirstOrDefault(u => u.AccountId == user.AccountId);
                        account.UserId = user.UserId;
                        context.Accounts.Update(account);
                        context.SaveChanges();


                    }
                    else if (radioButton2.Checked)
                    {
                        Staff sttaf = new Staff()
                        {
                            name = textBox2.Text,
                            UserName = textBox2.Text,
                            Password = textBox3.Text,
                            UserTayp = "Sttaf user",
                            account = new Account()
                            {
                                No_BorrowedBooks = 0,
                                No_Late_book = 0,
                                No_ReturnedBooks = 0,
                                No_LostBooks = 0,
                                FineAmount = 0,


                            },
                            Department = textBox4.Text,

                        };
                        sttaf.Register(sttaf);
                        var sttafs = context.users.FirstOrDefault(u => u.UserName == textBox2.Text && u.Password == textBox3.Text);
                        var accountss = context.Accounts.FirstOrDefault(u => u.AccountId == sttafs.AccountId);
                        accountss.UserId = sttafs.UserId;
                        context.Accounts.Update(accountss);
                        context.SaveChanges();
                        MessageBox.Show("successfully registered");

                    }






                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    radioButton1.Checked = false;
                }
            }
            else
            {
                MessageBox.Show("Make sure that you have filled in all the information ^_^");

            }




        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (checkDataLibrarian())
            {
                Librarian libr = context.librarians.SingleOrDefault(s => s.UserName == textBox7.Text);
                if (libr != null)
                {
                    MessageBox.Show("Use another name ^_^");

                }
                else
                {
                    Librarian lib = new Librarian()
                    {
                        UserName = textBox7.Text,
                        Password = textBox6.Text,
                        UserTayp = "librarian",
                        Name = textBox7.Text,
                        LibraryDataBase = new LibraryDataBase()
                        {
                            ListOfBooks = new List<Book> { },

                            Accounts = new List<Account> { new Account()
                    {

                        No_BorrowedBooks = 0,
                        No_Late_book = 0,
                        No_ReturnedBooks = 0,
                        No_LostBooks = 0,
                        FineAmount = 0,


                    },}
                        },
                        Books = new List<Book> { }

                    };
                    lib.Register(lib);
                    //ÓÌá ãÏíÑ æ ÓæÇ Çáå ÞÇÚÏÉ ÈíÇäÇÊ
                    var librarianan = context.librarians.FirstOrDefault(u => u.UserName == textBox7.Text && u.Password == textBox6.Text);
                    //ÇÎÐäÇ Çáí ÓÌáäÇå
                    var liDB = context.LibraryDataBase.FirstOrDefault(u => u.ID_librarian == librarianan.ID_librarian);
                    //ÑÈØäÇ ÞÇÚÏÉ ÇáÈíÇäÇÊ È ÇáãÏíÑ
                    librarianan.ldb_id=liDB.ldb_id;
                    var account = context.Accounts.FirstOrDefault(u => u.ldb_id == liDB.ldb_id);

                    liDB.AccountId = account.AccountId;
                    context.librarians.Update(librarianan);
                    context.LibraryDataBase.Update(liDB);
                    context.SaveChanges();
                    textBox6.Text = "";
                    textBox7.Text = "";
                    MessageBox.Show("successfully registered");
                }
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
            this.Hide();
        }
    }
}