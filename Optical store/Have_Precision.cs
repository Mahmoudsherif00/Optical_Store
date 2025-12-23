using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Optical_store
{
    public partial class Have_Precision : Form
    {
       
        public Have_Precision()
        {
            InitializeComponent();

        }

        private void Have_Precision_Load(object sender, EventArgs e)
        {
      
            // ===== Form Styling =====
            this.Text = "Prescription Check";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(245, 247, 250);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Size = new Size(400, 250);

            // ===== Label =====
            label1 = new Label();
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            label1.Location = new Point(50, 30); // adjust as needed
            label1.ForeColor = Color.Black;

            // Check prescription (replace with your real logic)
            bool hasPrescription = CheckPrescription();

            if (hasPrescription)
            {
                label1.Text = "You have a prescription ✅";
                label1.ForeColor = Color.Green;
            }
            else
            {
                label1.Text = "No prescription found ❌";
                label1.ForeColor = Color.Red;
            }

            this.Controls.Add(label1);

            // ===== Button1 =====
           
            button1.Text = "Yes";
            button1.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            button1.Size = new Size(120, 40);
            button1.Location = new Point(50, 100);
            button1.BackColor = Color.FromArgb(52, 152, 219);
            button1.ForeColor = Color.White;
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;

            this.Controls.Add(button1);

            // ===== Button2 =====
          
            button2.Text = "No";
            button2.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            button2.Size = new Size(120, 40);
            button2.Location = new Point(200, 100);
            button2.BackColor = Color.FromArgb(52, 152, 219);
            button2.ForeColor = Color.White;
            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;

            this.Controls.Add(button2);

        }
        private bool CheckPrescription()
        {
            // TODO: Replace with actual database or user info check
            return true; // or false
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Item d = new Item();
            d.ShowDialog    ();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Make_Makepericsion d = new Make_Makepericsion();
            d.ShowDialog();
        }
    }

}
