using System.Data;

namespace NoteTakingApp
{
    public partial class Form1 : Form
    {
        DataTable table;
        bool btnClicked = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            table = new DataTable();
            table.Columns.Add("Title", typeof(string));
            table.Columns.Add("Messages", typeof(string));

            dataGridView1.DataSource = table;
            dataGridView1.RowTemplate.Height = 35;
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button btnSender = (Button)sender;
            if (btnSender == newBtn)
            {
                txtTitle.Clear();
                txtMessage.Clear();

                btnClicked = false;
            }
            else if (btnSender == saveBtn)
            {
                MessageBox.Show(btnClicked.ToString());
                if (btnClicked == true)
                {
                    MessageBox.Show("Read button clicked!");
                    int index = dataGridView1.CurrentCell.RowIndex;

                    table.Rows[index]["Title"] = txtTitle.Text;
                    table.Rows[index]["Messages"] = txtMessage.Text;
                }
                else if (btnClicked == false)
                {
                    table.Rows.Add(txtTitle.Text, txtMessage.Text);
                }

                txtTitle.Clear();
                txtMessage.Clear();

                btnClicked = false;
            }
            else if (btnSender == readBtn)
            {
                int index = dataGridView1.CurrentCell.RowIndex;
                if (index > -1)
                {
                    txtTitle.Text = table.Rows[index][0].ToString();
                    txtMessage.Text = table.Rows[index][1].ToString();
                }

                btnClicked = true;
            }
            else if (btnSender == deleteBtn)
            {
                int index = dataGridView1.CurrentCell.RowIndex;

                table.Rows.RemoveAt(index);

                txtTitle.Clear();
                txtMessage.Clear();

                btnClicked = false;
            }
        }
    }
}