namespace projectLibary
{
    partial class Form4
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            button1 = new Button();
            dateTimePicker1 = new DateTimePicker();
            dataGridView1 = new DataGridView();
            label14 = new Label();
            label12 = new Label();
            label13 = new Label();
            label10 = new Label();
            button4 = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            textBox2 = new TextBox();
            label3 = new Label();
            textBox3 = new TextBox();
            label4 = new Label();
            textBox4 = new TextBox();
            label5 = new Label();
            button2 = new Button();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            button3 = new Button();
            label11 = new Label();
            textBox5 = new TextBox();
            label15 = new Label();
            textBox6 = new TextBox();
            label16 = new Label();
            textBox7 = new TextBox();
            button5 = new Button();
            label17 = new Label();
            label18 = new Label();
            label19 = new Label();
            button6 = new Button();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ScrollBar;
            button1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(1177, 677);
            button1.Name = "button1";
            button1.Size = new Size(158, 49);
            button1.TabIndex = 1;
            button1.Text = "Borrow";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(1177, 615);
            dateTimePicker1.MinDate = new DateTime(2023, 12, 15, 0, 0, 0, 0);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(250, 27);
            dateTimePicker1.TabIndex = 4;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle1.BackColor = Color.HotPink;
            dataGridViewCellStyle1.Font = new Font("Tahoma", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.Padding = new Padding(2);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(192, 192, 255);
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridView1.BorderStyle = BorderStyle.Fixed3D;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            dataGridView1.ColumnHeadersHeight = 29;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.MenuHighlight;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.Location = new Point(192, 264);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(879, 472);
            dataGridView1.StandardTab = true;
            dataGridView1.TabIndex = 6;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.RowPrePaint += dataGridView1_RowPrePaint;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.BackColor = Color.Transparent;
            label14.BorderStyle = BorderStyle.FixedSingle;
            label14.FlatStyle = FlatStyle.Popup;
            label14.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label14.ForeColor = SystemColors.ControlLightLight;
            label14.Location = new Point(453, 47);
            label14.Margin = new Padding(0, 3, 0, 3);
            label14.MinimumSize = new Size(100, 50);
            label14.Name = "label14";
            label14.Padding = new Padding(10);
            label14.Size = new Size(100, 53);
            label14.TabIndex = 27;
            label14.Text = "ID : ";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = SystemColors.ScrollBar;
            label12.BorderStyle = BorderStyle.Fixed3D;
            label12.FlatStyle = FlatStyle.Popup;
            label12.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label12.ForeColor = SystemColors.ControlLightLight;
            label12.Location = new Point(559, 47);
            label12.MinimumSize = new Size(100, 50);
            label12.Name = "label12";
            label12.Padding = new Padding(10);
            label12.Size = new Size(100, 53);
            label12.TabIndex = 26;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = SystemColors.ScrollBar;
            label13.BorderStyle = BorderStyle.FixedSingle;
            label13.FlatStyle = FlatStyle.Popup;
            label13.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label13.ForeColor = Color.White;
            label13.Location = new Point(227, 47);
            label13.MinimumSize = new Size(100, 50);
            label13.Name = "label13";
            label13.Padding = new Padding(10);
            label13.Size = new Size(100, 53);
            label13.TabIndex = 25;
            label13.Click += label13_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.BorderStyle = BorderStyle.FixedSingle;
            label10.FlatStyle = FlatStyle.Popup;
            label10.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label10.ForeColor = SystemColors.ControlLightLight;
            label10.Location = new Point(54, 47);
            label10.MinimumSize = new Size(100, 50);
            label10.Name = "label10";
            label10.Padding = new Padding(10);
            label10.Size = new Size(167, 53);
            label10.TabIndex = 24;
            label10.Text = "User Name :";
            label10.Click += label10_Click;
            // 
            // button4
            // 
            button4.BackColor = SystemColors.ScrollBar;
            button4.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            button4.ForeColor = SystemColors.Window;
            button4.Location = new Point(1729, 52);
            button4.MinimumSize = new Size(100, 50);
            button4.Name = "button4";
            button4.Size = new Size(136, 50);
            button4.TabIndex = 23;
            button4.Text = "Log Out";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(1177, 373);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 28;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(1177, 327);
            label1.Name = "label1";
            label1.Padding = new Padding(20, 5, 20, 5);
            label1.Size = new Size(108, 43);
            label1.TabIndex = 29;
            label1.Text = "ISBN";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(1403, 373);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 30;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.BorderStyle = BorderStyle.Fixed3D;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(1403, 449);
            label3.Name = "label3";
            label3.Padding = new Padding(20, 5, 20, 5);
            label3.Size = new Size(180, 43);
            label3.TabIndex = 35;
            label3.Text = "Publication";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(1403, 495);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(125, 27);
            textBox3.TabIndex = 34;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.BorderStyle = BorderStyle.Fixed3D;
            label4.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label4.ForeColor = SystemColors.ButtonHighlight;
            label4.Location = new Point(1177, 449);
            label4.Name = "label4";
            label4.Padding = new Padding(20, 5, 20, 5);
            label4.Size = new Size(105, 43);
            label4.TabIndex = 33;
            label4.Text = "Title";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(1177, 495);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(125, 27);
            textBox4.TabIndex = 32;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.BorderStyle = BorderStyle.Fixed3D;
            label5.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.ButtonHighlight;
            label5.Location = new Point(1177, 566);
            label5.Name = "label5";
            label5.Padding = new Padding(20, 5, 20, 5);
            label5.Size = new Size(184, 43);
            label5.TabIndex = 36;
            label5.Text = "Return date";
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ScrollBar;
            button2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            button2.ForeColor = SystemColors.ButtonHighlight;
            button2.Location = new Point(192, 188);
            button2.MinimumSize = new Size(100, 50);
            button2.Name = "button2";
            button2.Size = new Size(136, 50);
            button2.TabIndex = 37;
            button2.Text = "My Book";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click_2;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.BorderStyle = BorderStyle.FixedSingle;
            label6.FlatStyle = FlatStyle.Flat;
            label6.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label6.ForeColor = SystemColors.ControlLightLight;
            label6.Location = new Point(779, 47);
            label6.MinimumSize = new Size(100, 50);
            label6.Name = "label6";
            label6.Padding = new Padding(10);
            label6.Size = new Size(154, 53);
            label6.TabIndex = 39;
            label6.Text = "User Type :";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = SystemColors.ScrollBar;
            label7.BorderStyle = BorderStyle.Fixed3D;
            label7.FlatStyle = FlatStyle.Popup;
            label7.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label7.ForeColor = SystemColors.ControlLightLight;
            label7.Location = new Point(939, 47);
            label7.MinimumSize = new Size(100, 50);
            label7.Name = "label7";
            label7.Padding = new Padding(10);
            label7.Size = new Size(100, 53);
            label7.TabIndex = 38;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.BorderStyle = BorderStyle.FixedSingle;
            label8.FlatStyle = FlatStyle.Popup;
            label8.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label8.ForeColor = SystemColors.ControlLightLight;
            label8.Location = new Point(1175, 47);
            label8.MinimumSize = new Size(100, 50);
            label8.Name = "label8";
            label8.Padding = new Padding(10);
            label8.Size = new Size(100, 53);
            label8.TabIndex = 41;
            label8.Text = "----";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = SystemColors.ScrollBar;
            label9.BorderStyle = BorderStyle.Fixed3D;
            label9.FlatStyle = FlatStyle.Popup;
            label9.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label9.ForeColor = SystemColors.ControlLightLight;
            label9.Location = new Point(1281, 47);
            label9.MinimumSize = new Size(100, 50);
            label9.Name = "label9";
            label9.Padding = new Padding(10);
            label9.Size = new Size(100, 53);
            label9.TabIndex = 40;
            // 
            // button3
            // 
            button3.BackColor = SystemColors.ScrollBar;
            button3.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            button3.ForeColor = SystemColors.ButtonHighlight;
            button3.Location = new Point(1360, 677);
            button3.Name = "button3";
            button3.Size = new Size(158, 49);
            button3.TabIndex = 42;
            button3.Text = "Return";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.Transparent;
            label11.BorderStyle = BorderStyle.Fixed3D;
            label11.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label11.ForeColor = Color.Transparent;
            label11.Location = new Point(362, 178);
            label11.Name = "label11";
            label11.Padding = new Padding(20, 5, 20, 5);
            label11.Size = new Size(108, 43);
            label11.TabIndex = 44;
            label11.Text = "ISBN";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(362, 224);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(125, 27);
            textBox5.TabIndex = 43;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.BackColor = Color.Transparent;
            label15.BorderStyle = BorderStyle.Fixed3D;
            label15.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label15.ForeColor = SystemColors.ButtonHighlight;
            label15.Location = new Point(585, 178);
            label15.Name = "label15";
            label15.Padding = new Padding(20, 5, 20, 5);
            label15.Size = new Size(131, 43);
            label15.TabIndex = 46;
            label15.Text = "Author";
            // 
            // textBox6
            // 
            textBox6.Location = new Point(585, 224);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(125, 27);
            textBox6.TabIndex = 45;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.BackColor = Color.Transparent;
            label16.BorderStyle = BorderStyle.Fixed3D;
            label16.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label16.ForeColor = SystemColors.ButtonHighlight;
            label16.Location = new Point(789, 178);
            label16.Name = "label16";
            label16.Padding = new Padding(20, 5, 20, 5);
            label16.Size = new Size(105, 43);
            label16.TabIndex = 48;
            label16.Text = "Title";
            // 
            // textBox7
            // 
            textBox7.Location = new Point(789, 224);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(125, 27);
            textBox7.TabIndex = 47;
            // 
            // button5
            // 
            button5.BackColor = SystemColors.ScrollBar;
            button5.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            button5.ForeColor = SystemColors.Window;
            button5.Location = new Point(971, 188);
            button5.MinimumSize = new Size(100, 50);
            button5.Name = "button5";
            button5.Size = new Size(100, 50);
            button5.TabIndex = 49;
            button5.Text = "Search";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.BackColor = SystemColors.ScrollBar;
            label17.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label17.ForeColor = SystemColors.ButtonHighlight;
            label17.Location = new Point(725, 200);
            label17.Name = "label17";
            label17.Padding = new Padding(2, 8, 2, 8);
            label17.Size = new Size(43, 44);
            label17.TabIndex = 50;
            label17.Text = "OR";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.BackColor = SystemColors.ScrollBar;
            label18.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label18.ForeColor = SystemColors.ButtonHighlight;
            label18.Location = new Point(510, 200);
            label18.Name = "label18";
            label18.Padding = new Padding(2, 8, 2, 8);
            label18.Size = new Size(43, 44);
            label18.TabIndex = 51;
            label18.Text = "OR";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.BackColor = SystemColors.ControlLightLight;
            label19.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label19.ForeColor = SystemColors.ButtonHighlight;
            label19.Location = new Point(343, 161);
            label19.MaximumSize = new Size(3, 200);
            label19.MinimumSize = new Size(3, 100);
            label19.Name = "label19";
            label19.Padding = new Padding(20, 5, 20, 5);
            label19.Size = new Size(3, 100);
            label19.TabIndex = 52;
            // 
            // button6
            // 
            button6.BackColor = Color.LightSteelBlue;
            button6.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            button6.ForeColor = SystemColors.Window;
            button6.Location = new Point(599, 794);
            button6.MinimumSize = new Size(100, 50);
            button6.Name = "button6";
            button6.Size = new Size(117, 50);
            button6.TabIndex = 63;
            button6.Text = "UpDate";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(1403, 327);
            label2.Name = "label2";
            label2.Padding = new Padding(20, 5, 20, 5);
            label2.Size = new Size(131, 43);
            label2.TabIndex = 64;
            label2.Text = "Author";
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1924, 1033);
            Controls.Add(label2);
            Controls.Add(button6);
            Controls.Add(label19);
            Controls.Add(label18);
            Controls.Add(label17);
            Controls.Add(button5);
            Controls.Add(label16);
            Controls.Add(textBox7);
            Controls.Add(label15);
            Controls.Add(textBox6);
            Controls.Add(label11);
            Controls.Add(textBox5);
            Controls.Add(button3);
            Controls.Add(label8);
            Controls.Add(label9);
            Controls.Add(label6);
            Controls.Add(label7);
            Controls.Add(button2);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(textBox3);
            Controls.Add(label4);
            Controls.Add(textBox4);
            Controls.Add(textBox2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(label14);
            Controls.Add(label12);
            Controls.Add(label13);
            Controls.Add(label10);
            Controls.Add(button4);
            Controls.Add(dataGridView1);
            Controls.Add(dateTimePicker1);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            IsMdiContainer = true;
            Name = "Form4";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "User Page";
            Load += Form4_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button1;
        private DateTimePicker dateTimePicker1;
        private DataGridView dataGridView1;
        private Label label14;
        private Label label12;
        private Label label13;
        private Label label10;
        private Button button4;
        private TextBox textBox1;
        private Label label1;
        private TextBox textBox2;
        private Label label3;
        private TextBox textBox3;
        private Label label4;
        private TextBox textBox4;
        private Label label5;
        private Button button2;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Button button3;
        private Label label11;
        private TextBox textBox5;
        private Label label15;
        private TextBox textBox6;
        private Label label16;
        private TextBox textBox7;
        private Button button5;
        private Label label17;
        private Label label18;
        private Label label19;
        private Button button6;
        private Label label2;
    }
}