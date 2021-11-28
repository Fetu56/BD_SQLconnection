using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FormsNotes
{
    public partial class AddForm : Form
    {
        private SqlConnection cn;
        public AddForm(SqlConnection con)
        {
            InitializeComponent();
            cn = con;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlCommand command = new SqlCommand($"INSERT INTO NOTES VALUES" + $"('{textBoxName.Text}', '{textBoxDesc.Text}', '{dateTimePicker.Value.ToString("yyyy-MM-dd hh:mm:ss")}')", cn))
            {
                int rows = command.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Added!");
                }
                else
                {
                    MessageBox.Show("Error!");
                }
            }
        }
    }
}
