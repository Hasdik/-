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
    public partial class Администратор : Form
    {
        //Строка подкючения к БД
        SqlConnection conn = new SqlConnection(@"Data Source=HASD-ПК\SQLEXPRESS;Initial Catalog='BD';Integrated Security=True");
        public Администратор()
        {
            InitializeComponent();
        }

        private void Администратор_Load(object sender, EventArgs e)
        {
            printtable();//вызов метода
            groupBox2.Visible = false; //скрыть groupBox2
            groupBox3.Visible = false;//скрыть groupBox3
            dataGridView1.Columns[0].HeaderText = "Номер";
            dataGridView1.Columns[1].HeaderText = "Логин";
            dataGridView1.Columns[2].HeaderText = "Пароль";
            dataGridView1.Columns[3].HeaderText = "ФИО";
        }
        //Вывод таблицы на экран
        void printtable()
        {
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("select *from Users", conn);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds, "Users");
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();
        }
        //удаление данных из БД
        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            string s = dataGridView1.CurrentCell.Value.ToString();
            string sql = "Delete from Users where id='" + s + "'";
            SqlCommand command = new SqlCommand(sql, conn);
            command.ExecuteNonQuery();
            conn.Close();
            printtable();
        }
        //добавление данных в БД
        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                int s = Convert.ToInt32(textBox5.Text);
                string s1 = textBox6.Text;
                string s2 = textBox7.Text;
                string s3 = textBox8.Text;
                string sql = "insert into Users (id,login, password,FIO) values ('" + s + "','" + s1 + "','" + s2 + "','" + s3 + "')";
                SqlCommand command = new SqlCommand(sql, conn);
                command.ExecuteNonQuery();
                conn.Close();
                printtable();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
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
        //добавление активация
        private void button1_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = true;
            groupBox2.Visible = false;
        }
        //обновление активация
        private void button2_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = false;
            groupBox2.Visible = true;
        }
        //обновление данных 
        private void button7_Click(object sender, EventArgs e)
        {
            conn.Open();
            string sql = "Update Users set login='" + textBox2.Text + "',password='" + textBox3.Text + "',FIO='" + textBox4.Text + "' where id='" + textBox1.Text + "'";
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
        //скопировать данные
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
        //переход на другую форму
        private void button9_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.ShowDialog();
        }
    }
}
