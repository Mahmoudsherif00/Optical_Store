using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Optical_store
{
    public partial class Item : Form
    {
        public Item()
        {
            InitializeComponent();
        }

        private void Item_Load(object sender, EventArgs e)
        {
            // ===== Form Styling =====
            this.Text = "Optical Store - Select Item";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(1200, 800);
            this.BackColor = Color.FromArgb(245, 247, 250);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            Font comboFont = new Font("Segoe UI", 12);
            Font btnFont = new Font("Segoe UI", 12, FontStyle.Bold);
            Font labelFont = new Font("Segoe UI", 12, FontStyle.Bold);
            Font descFont = new Font("Segoe UI", 10, FontStyle.Regular);

            // ===== Main Label =====
            label5.Font = labelFont;
            label5.ForeColor = Color.FromArgb(52, 73, 94);
            label5.Size = new Size(1000, 60);
            label5.Location = new Point(100, 20);
            label5.TextAlign = ContentAlignment.MiddleCenter;
            label5.Text = "Select your item options and calculate price.";
            this.Controls.Add(label5);

            // ===== ComboBoxes with Descriptive Labels =====

            // Frame Type
            Label lblFrame = new Label();
            lblFrame.Text = "Frame Type:";
            lblFrame.Font = descFont;
            lblFrame.Location = new Point(100, 90);
            lblFrame.AutoSize = true;
            this.Controls.Add(lblFrame);

            comboBox1.Font = comboFont;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Items.AddRange(new string[] { "Full Rim", "Half Rim", "Rimless" });
            comboBox1.SelectedIndex = 0;
            comboBox1.Location = new Point(100, 120);
            comboBox1.Size = new Size(250, 35);
            this.Controls.Add(comboBox1);

            // Lens Type
            Label lblLens = new Label();
            lblLens.Text = "Lens Type:";
            lblLens.Font = descFont;
            lblLens.Location = new Point(100, 150);
            lblLens.AutoSize = true;
            this.Controls.Add(lblLens);

            comboBox2.Font = comboFont;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.Items.AddRange(new string[] { "Single Vision", "Bifocal", "Progressive" });
            comboBox2.SelectedIndex = 0;
            comboBox2.Location = new Point(100, 180);
            comboBox2.Size = new Size(250, 35);
            this.Controls.Add(comboBox2);

            // Additional Options
            Label lblOption = new Label();
            lblOption.Text = "Additional Options:";
            lblOption.Font = descFont;
            lblOption.Location = new Point(100, 210);
            lblOption.AutoSize = true;
            this.Controls.Add(lblOption);

            comboBox3.Font = comboFont;
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.Items.AddRange(new string[] { "None", "Anti-Glare", "UV Protection", "Blue Light Filter" });
            comboBox3.SelectedIndex = 0;
            comboBox3.Location = new Point(100, 240);
            comboBox3.Size = new Size(250, 35);
            this.Controls.Add(comboBox3);

            // ===== Buttons =====
            // Calculate Price
            button1.Text = "Calculate Price";
            button1.Font = btnFont;
            button1.BackColor = Color.FromArgb(52, 152, 219);
            button1.ForeColor = Color.White;
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            button1.Size = new Size(250, 50);
            button1.Location = new Point(400, 120);
            button1.Cursor = Cursors.Hand;
            button1.MouseEnter += (s, ev) => button1.BackColor = Color.FromArgb(41, 128, 185);
            button1.MouseLeave += (s, ev) => button1.BackColor = Color.FromArgb(52, 152, 219);
            this.Controls.Add(button1);

            // Save Item
            button2.Text = "Save Item";
            button2.Font = btnFont;
            button2.BackColor = Color.FromArgb(46, 204, 113);
            button2.ForeColor = Color.White;
            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;
            button2.Size = new Size(250, 50);
            button2.Location = new Point(400, 180);
            button2.Cursor = Cursors.Hand;
            button2.MouseEnter += (s, ev) => button2.BackColor = Color.FromArgb(39, 174, 96);
            button2.MouseLeave += (s, ev) => button2.BackColor = Color.FromArgb(46, 204, 113);
            this.Controls.Add(button2);


        }
        int price = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            price = 0;

            // Frame Type Price
            switch (comboBox1.SelectedItem.ToString())
            {
                case "Full Rim": price += 100; break;
                case "Half Rim": price += 80; break;
                case "Rimless": price += 60; break;
            }

            // Lens Type Price
            switch (comboBox2.SelectedItem.ToString())
            {
                case "Single Vision": price += 50; break;
                case "Bifocal": price += 80; break;
                case "Progressive": price += 120; break;
            }

            // Additional Options Price
            switch (comboBox3.SelectedItem.ToString())
            {
                case "Anti-Glare": price += 30; break;
                case "UV Protection": price += 20; break;
                case "Blue Light Filter": price += 25; break;
            }

            label5.Text = $"Selected: {comboBox1.SelectedItem}, {comboBox2.SelectedItem}, {comboBox3.SelectedItem}\nPrice: ${price}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = @"Server=LAPTOP-28SVJLGB ;Database=Optical;Integrated Security=True;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string userId = Global.id;

                string insertQuery = @"INSERT INTO items (userid, frame, lens, option_selected, price)
                                       VALUES (@userid, @frame, @lens, @option_selected, @price)";

                using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@userid", userId);
                    cmd.Parameters.AddWithValue("@frame", comboBox1.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@lens", comboBox2.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@option_selected", comboBox3.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@price", price);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show($"Item saved! Total price: ${price}");
        }
    }
    }

