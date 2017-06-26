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
    public partial class Поставщики : Form
    {
        //строка подключения к БД
        SqlConnection conn = new SqlConnection(@"Data Source=HASD-ПК\SQLEXPRESS;Initial Catalog='BD';Integrated Security=True");
        public Поставщики()
        {
            InitializeComponent();
        }
        //переход к форме заказ деталей
        private void button4_Click(object sender, EventArgs e)
        {
            Заказ_деталей z = new Заказ_деталей();
            z.ShowDialog();
        }
        //переход к главной форме
        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.ShowDialog();


        }
        //метод для активации groupBox
        private void Add_newklient_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            groupBox2.Visible = false;
        }
        //методы которые вызваются при загрузке формы
        private void Поставщики_Load(object sender, EventArgs e)
        {
            printtable();
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            dataGridView1.Columns[0].HeaderText = "Номер поставщика";
        }
        //метод для активации groupBox
        private void update_klient_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = true;
        }
        //метод для скрытия groupBox
        private void button7_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
        }
        //метод для скрытия groupBox
        private void button6_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
        }
        //вывод данных из БД на экран
        void printtable()
        {
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("select *from Поставщики", conn);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds, "Поставщики");
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();
        }
        //удаление данных из таблицы Поставщики
        private void delete_klient_Click(object sender, EventArgs e)
        {
            conn.Open();
            string s = dataGridView1.CurrentCell.Value.ToString();
            string sql = "Delete from Поставщики where id='" + s + "'";
            SqlCommand command = new SqlCommand(sql, conn);
            command.ExecuteNonQuery();
            conn.Close();
            printtable();
        }
        //добавление данных в таблицу Поставщики
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                int s = Convert.ToInt32(idTextBox.Text);
                string s1 = название_фирмыTextBox.Text;
                string s2 = марки_автомобилейTextBox.Text;
                string s3 = адрессTextBox.Text;
                string s4 = телефонTextBox.Text;
                string sql = "insert into Поставщики (id,[Название фирмы],[Марки автомобилей], Адресс, Телефон) values ('" + s + "','" + s1 + "','" + s2 + "','" + s3 + "','" + s4 + "')";
                SqlCommand command = new SqlCommand(sql, conn);
                command.ExecuteNonQuery();
                conn.Close();
                printtable();
                idTextBox.Clear();
                название_фирмыTextBox.Clear();
                марки_автомобилейTextBox.Clear();
                телефонTextBox.Clear();
                адрессTextBox.Clear();
                groupBox1.Visible = false;
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
        //обновление данных в таблице Поставщики
        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            string sql = "Update Поставщики set [Название фирмы]='" + textBox2.Text + "',[Марки автомобилей]='" + textBox3.Text + "',Адресс='" + textBox4.Text + "',Телефон='" + textBox5.Text + "' where id='" + textBox1.Text + "'";
            SqlCommand command = new SqlCommand(sql, conn);
            command.ExecuteNonQuery();
            conn.Close();
            printtable();
            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();
            textBox5.Clear();
            groupBox2.Visible = false;
        }
        //скопировать данный из таблицы в textbox для изменения
        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();

            string k = dataGridView1.CurrentRow.Index.ToString();
            int index = Convert.ToInt32(k);
            string s = dataGridView1.Rows[index].Cells[0].Value.ToString();
            string s1 = dataGridView1.Rows[index].Cells[1].Value.ToString();
            string s2 = dataGridView1.Rows[index].Cells[2].Value.ToString();
            string s3 = dataGridView1.Rows[index].Cells[3].Value.ToString();
            string s4 = dataGridView1.Rows[index].Cells[4].Value.ToString();
            textBox1.Text = s;
            textBox2.Text = s1;
            textBox3.Text = s2;
            textBox4.Text = s3;
            textBox5.Text = s4;
        }
    }
}
