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
    public partial class Сотрудники : Form
    {
        //строка подключения к БД
        SqlConnection conn = new SqlConnection(@"Data Source=HASD-ПК\SQLEXPRESS;Initial Catalog='BD';Integrated Security=True");
        public Сотрудники()
        {
            InitializeComponent();
        }
        //метод для перехода к главной форме
        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.ShowDialog();
        }

        private void Сотрудники_Load(object sender, EventArgs e)
        {
            printtable();
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            dataGridView1.Columns[0].HeaderText = "Номер сотрудника";
        }
        //вывод на экран таблицы Сотрудники
        void printtable()
        {
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("select *from Сотрудники", conn);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds, "Сотрудники");
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();
        }
        //метод для активации groupBox
        private void button1_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            groupBox3.Visible = true;
        }
        //метод для активации groupBox
        private void button2_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
            groupBox3.Visible = false;
        }
        //добавление данных в таблицу
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                int s = Convert.ToInt32(idTextBox.Text);
                string s1 = фИО_сотрудникаTextBox.Text;
                string s2 = должностьTextBox.Text;
                string s3 = стаж_работыTextBox.Text;
                string s4 = dateTimePicker1.Value.Date.ToShortDateString();
                string s5 = зарплатаTextBox.Text;
                string s6 = адрессTextBox.Text;
                string s7 = телефонTextBox.Text;
                string s8 = номер_паспортаTextBox.Text;
                string sql = "insert into Сотрудники (id,[ФИО сотрудника], Должность, [Стаж работы], [Дата рождения],Зарплата,Адресс,Телефон,[Номер паспорта]) values ('" + s + "','" + s1 + "','" + s2 + "','" + s3 + "','" + s4 + "','" + s5 + "','" + s6 + "','" + s7 + "','" + s8 + "')";
                SqlCommand command = new SqlCommand(sql, conn);
                command.ExecuteNonQuery();
                conn.Close();
                printtable();
                idTextBox.Clear();
                фИО_сотрудникаTextBox.Clear();
                номер_паспортаTextBox.Clear();
                телефонTextBox.Clear();
                стаж_работыTextBox.Clear();
                зарплатаTextBox.Clear();
                адрессTextBox.Clear();
                должностьTextBox.Clear();
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
        //удаление данных из БД
        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            string s = dataGridView1.CurrentCell.Value.ToString();
            string sql = "Delete from Сотрудники where id='" + s + "'";
            SqlCommand command = new SqlCommand(sql, conn);
            command.ExecuteNonQuery();
            conn.Close();
            printtable();
        }
        //метод для скрытия groupBox
        private void button5_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = false;
        }
        //метод для скрытия groupBox
        private void button6_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
        }
        // Обновление данных в табице Сотрудники
        private void button7_Click(object sender, EventArgs e)
        {
            conn.Open();
            string data = dateTimePicker2.Value.Date.ToShortDateString();
            string sql = "Update Сотрудники set [ФИО сотрудника]='" + textBox2.Text + "',Должность='" + textBox4.Text + "',[Стаж работы]='" + textBox6.Text + "',[Дата рождения]='" + data + "',Зарплата='" + textBox6.Text + "',Адресс='" + textBox8.Text + "',Телефон='" + textBox9.Text + "' where id='" + textBox1.Text + "'";
            SqlCommand command = new SqlCommand(sql, conn);
            command.ExecuteNonQuery();
            conn.Close();
            printtable();
            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            groupBox2.Visible = false;
        }
        //скопировать данные для изменения
        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            string k = dataGridView1.CurrentRow.Index.ToString();
            int index = Convert.ToInt32(k);
            string s = dataGridView1.Rows[index].Cells[0].Value.ToString();
            string s1 = dataGridView1.Rows[index].Cells[1].Value.ToString();
            string s2 = dataGridView1.Rows[index].Cells[2].Value.ToString();
            string s4 = dataGridView1.Rows[index].Cells[3].Value.ToString();
            string s5 = dataGridView1.Rows[index].Cells[5].Value.ToString();
            string s6 = dataGridView1.Rows[index].Cells[6].Value.ToString();
            string s7 = dataGridView1.Rows[index].Cells[7].Value.ToString();
            string s8 = dataGridView1.Rows[index].Cells[8].Value.ToString();
            textBox1.Text = s;
            textBox2.Text = s1;
            textBox3.Text = s2;
            textBox4.Text = s4;
            textBox6.Text = s5;
            textBox7.Text = s6;
            textBox8.Text = s7;
            textBox9.Text = s8;
        }
    }
}
