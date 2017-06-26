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

namespace Станции_техобслуживания
{
    public partial class Мастера : Form
    {
        //строка подключения к БД
        SqlConnection conn = new SqlConnection(@"Data Source=HASD-ПК\SQLEXPRESS;Initial Catalog='BD';Integrated Security=True");
        public Мастера()
        {
            InitializeComponent();
        }
        //переход к главной форме
        private void button9_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.ShowDialog();
        }
        //вывод данных из Бд на экран
        void printtable()
        {
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("select *from Мастера", conn);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds, "Мастера");
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();
        }
        //методы которые вызваются при загрузке формы
        private void Мастера_Load(object sender, EventArgs e)
        {
            printtable();
            groupBox3.Visible = false;
            groupBox2.Visible = false;
            dataGridView1.Columns[0].HeaderText = "Номер мастера";
        }
        //добавление данных в БД
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                int s = Convert.ToInt32(id_мастераTextBox.Text);
                string s1 = фИО_мастераTextBox.Text;
                string s2 = стаж_работыTextBox.Text;
                string s3 = телефонTextBox.Text;
                string sql = "insert into Мастера ([id мастера],[ФИО мастера], [Стаж работы],Телефон) values ('" + s + "','" + s1 + "','" + s2 + "','" + s3 + "')";
                SqlCommand command = new SqlCommand(sql, conn);
                command.ExecuteNonQuery();
                conn.Close();
                printtable();
                id_мастераTextBox.Clear();
                фИО_мастераTextBox.Clear();
                стаж_работыTextBox.Clear();
                телефонTextBox.Clear();
                groupBox3.Visible = false;
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Заполните все поля!", ex.Message);
                conn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Запись имеется уже в БД!", ex.Message);
                conn.Close();
            }
        }
        //обновление данных
        private void button7_Click(object sender, EventArgs e)
        {
            conn.Open();
            string sql = "Update Мастера set [ФИО мастера]='" + textBox2.Text + "',[Стаж работы]='" + textBox3.Text + "',Телефон='" + textBox4.Text + "' where [id мастера]='" + textBox1.Text + "'";
            SqlCommand command = new SqlCommand(sql, conn);
            command.ExecuteNonQuery();
            conn.Close();
            printtable();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            groupBox2.Visible = false;
        }
        //скопировать данные из таблицы в textbox
        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            string k = dataGridView1.CurrentRow.Index.ToString();
            int index = Convert.ToInt32(k);
            string s = dataGridView1.Rows[index].Cells[0].Value.ToString();
            string s1 = dataGridView1.Rows[index].Cells[1].Value.ToString();
            string s2 = dataGridView1.Rows[index].Cells[2].Value.ToString();
            string s3 = dataGridView1.Rows[index].Cells[3].Value.ToString();
            textBox1.Text = s;
            textBox2.Text = s1;
            textBox3.Text = s2;
            textBox4.Text = s3;
        }
        //метод для скрытия groupBox
        private void button6_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
        }
        //метод для скрытия groupBox
        private void button5_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = false;
        }
        //удаление данных из БД
        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            string s = dataGridView1.CurrentCell.Value.ToString();
            string sql = "Delete from Мастера where [id мастера]='" + s + "'";
            SqlCommand command = new SqlCommand(sql, conn);
            command.ExecuteNonQuery();
            conn.Close();
            printtable();
        }
        //метод для активации groupBox
        private void button1_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = true;
            groupBox2.Visible = false;
        }
        //метод для активации groupBox
        private void button2_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = false;
            groupBox2.Visible = true;
        }
    }
}
