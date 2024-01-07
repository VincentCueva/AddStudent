using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AddStudent
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to cancel adding?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string studNumber = textBox1.Text;
            string studFirstName = textBox2.Text;
            string studLastName = textBox3.Text;

            if (string.IsNullOrEmpty(studNumber) || string.IsNullOrEmpty(studFirstName) || string.IsNullOrEmpty(studLastName))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                Dbase db = new Dbase();
                db.Connect();

                int classId = 1;

                string insertQuery = "INSERT INTO student (class_id, stud_number, stud_firstname, stud_lastname) VALUES (@classId, @studNumber, @studFirstName, @studLastName)";

                using (MySqlCommand command = new MySqlCommand(insertQuery, db.con))
                {
                    command.Parameters.AddWithValue("@classId", classId);
                    command.Parameters.AddWithValue("@studNumber", studNumber);
                    command.Parameters.AddWithValue("@studFirstName", studFirstName);
                    command.Parameters.AddWithValue("@studLastName", studLastName);

                    command.ExecuteNonQuery();

                    MessageBox.Show("Record added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                }

                db.Disconnect();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void cleartext() 
        {
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
        }
    }
}
