using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FormsNotes
{
    public partial class FormNotes : Form
    {
        List<string> notes;
        private SqlConnection cn;
        public FormNotes()
        {
            InitializeComponent();
            cn = new SqlConnection($"Data Source=ALPC;Initial Catalog=DB_SHOP;Integrated Security=False;Trusted_Connection=true;");
            notes = new List<string>();
            cn.Open();

            using (SqlCommand command = new SqlCommand($"CREATE TABLE NOTES([id] INT IDENTITY, [name] VARCHAR(15) NOT NULL, [desc] TEXT NOT NULL, [date] DATETIME null)", cn))
            {
                try
                {
                    int res = command.ExecuteNonQuery();
                    if (res > 0)
                    {
                        MessageBox.Show("Table created");
                    }
                }
                catch (SqlException) { }
            }

            RefreshNotes();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            new AddForm(cn).ShowDialog();
            RefreshNotes();
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            using (SqlCommand command = new SqlCommand($"DELETE FROM NOTES WHERE [id]='{notes.ElementAt(comboBoxNotes.SelectedIndex).Split('↨')[0]}'", cn))
            {
                int rows = command.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Deleted!");
                    RefreshNotes();
                }
                else
                {
                    MessageBox.Show("Error!");
                }
            }
        }

        private void comboBoxNotes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxNotes.SelectedIndex != -1 && comboBoxNotes.SelectedIndex < notes.Count)
            {
                textBoxNotes.Text = notes.ElementAt(comboBoxNotes.SelectedIndex).Split('↨')[2];
                labelDate.Text = "Created at: " + notes.ElementAt(comboBoxNotes.SelectedIndex).Split('↨')[3];
            }
            else
            {
                textBoxNotes.Text = string.Empty;
                labelDate.Text = string.Empty;
            }
        }

        private void RefreshNotes()
        {
            notes.Clear();
            comboBoxNotes.Items.Clear();
            using (SqlCommand command = new SqlCommand($"SELECT * FROM NOTES", cn))
            {
                var data = command.ExecuteReader();
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        StringBuilder val = new StringBuilder();
                        for (int i = 0; i < data.FieldCount; i++)
                        {
                            val.Append(data.GetValue(i).ToString().Replace('↨', ' ') + "↨");
                        }
                        notes.Add(val.ToString());
                    }
                }
                data.Close();
            }
            notes.ForEach(x => comboBoxNotes.Items.Add(x.Split("↨")[1]));
            comboBoxNotes.SelectedIndex = -1;
            GC.Collect();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RefreshNotes();
        }
    }
}
