using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ppp.Program;
using MySql.Data.MySqlClient;

namespace ppp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        MySqlConnection сon;
        Connect connect = new Connect("server=192.168.25.23;port=33333;username=st_2_20_28;password=29461060;database=is_2_20_st28_KURS");
        DataTable dtable = new DataTable();
        MySqlDataAdapter medtable = new MySqlDataAdapter();
        BindingSource bs = new BindingSource();
        public void Infomation()
        {
            dtable.Clear();
            string sqlI = "SELECT * FROM Shop";
            сon.Open();

            medtable.SelectCommand = new MySqlCommand(sqlI, сon);
            medtable.Fill(dtable);

            bs.DataSource = dtable;

            dataGridView1.DataSource = bs;
            сon.Close();

            dataGridView1.Columns[0].Visible = true;
            dataGridView1.Columns[1].Visible = true;
            dataGridView1.Columns[2].Visible = true;
            dataGridView1.Columns[3].Visible = true;

            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[3].ReadOnly = true;

            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView1.RowHeadersVisible = false;

            dataGridView1.ColumnHeadersVisible = true;
            label1.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            сon = connect.Connection();
            Infomation();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

            сon.Open();
            string i1 = "";
            string i2 = "";
            string i3 = "";
            string i4 = "";
            string sql = $"SELECT Shop.Code AS 'Код', Shop.Name AS 'Наименование', Shop.Prise 'Цена', Shop.Data AS 'Срок годности' FROM Shop WHERE Shop.Code = " + id;
            MySqlCommand cmd = new MySqlCommand(sql, сon);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                i1 = reader[0].ToString();
                i2 = reader[1].ToString();
                i3 = reader[2].ToString();
                i4 = reader[3].ToString();
            }
            reader.Close();
            label1.Text = $"Code: " + i1 + "\n" + "Name: " + i2 + "\n" + "Phone: " + i3 + "\n" + "Mail: " + i4;
            label1.Visible = true;
            сon.Close();
        }
        //код наим срок годности
        //добавление продукта
        //подсветка просрочки(желтый, красный)
        //Поиск по наименованием
    }
}
