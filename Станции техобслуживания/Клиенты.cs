using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Станции_техобслуживания
{
    
    public partial class Клиенты : Form
    {
        //строка подключения к БД
        SqlConnection conn = new SqlConnection(@"Data Source=HASD-ПК\SQLEXPRESS;Initial Catalog='BD';Integrated Security=True");
        public Клиенты()
        {
            InitializeComponent();
        }
        //вывод таблицы из БД
        void printtable()
        {
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("select *from Клиенты", conn);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds, "Клиенты");
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();
        }
        //методы которые вызваются при загрузке формы
        private void Клиенты_Load(object sender, EventArgs e)
        {
            groupBoxADD.Visible = false;
            groupBoxUPDATE.Visible = false;
            printtable();
            dataGridView1.Columns[0].HeaderText = "Номер клиента";
        }
        //добавление данных в БД
        private void ADD_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                int s = Convert.ToInt32(idTextBox.Text);
                string s1 = фИО_клиентаTextBox.Text;
                string s2 = dateTimePicker1.Value.Date.ToShortDateString();
                string s3 = номер_паспортаTextBox.Text;
                string s4 = телефонTextBox.Text;
                string s5 = место_жительстваTextBox.Text;
                string s6 = номер_автомобиляTextBox.Text;
                string s7 = comboBox1.Text;
                string sql = "insert into Клиенты (id,[ФИО клиента], [Дата рождения], [Номер паспорта], Телефон,[Место жительства],[Номер автомобиля],Статус) values ('" + s + "','" + s1 + "','" + s2 + "','" + s3 + "','" + s4 + "','" + s5 + "','" + s6 + "','" + s7 + "')";
                SqlCommand command = new SqlCommand(sql, conn);
                command.ExecuteNonQuery();
                conn.Close();
                printtable();
                idTextBox.Clear();
                фИО_клиентаTextBox.Clear();
                номер_паспортаTextBox.Clear();
                телефонTextBox.Clear();
                место_жительстваTextBox.Clear();
                номер_автомобиляTextBox.Clear();
                groupBoxADD.Visible = false;
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
        //обновление данных в БД
        private void UPDATE_Click(object sender, EventArgs e)
        {
            conn.Open();
            string data = dateTimePicker2.Value.Date.ToShortDateString();
            string sql = "Update Клиенты set [ФИО клиента]='" + textBox2.Text + "',[Дата рождения]='" + data + "',[Номер паспорта]='" + textBox4.Text + "',Телефон='" + textBox5.Text + "',[Место жительства]='" + textBox6.Text + "',[Номер автомобиля]='" + textBox7.Text + "',Статус='" + comboBox2.Text + "' where id='" + textBox1.Text + "'";
            SqlCommand command = new SqlCommand(sql, conn);
            command.ExecuteNonQuery();
            conn.Close();
            printtable();
            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            groupBoxUPDATE.Visible = false;
        }
        //копировать данные из таблицы в textbox
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            string k = dataGridView1.CurrentRow.Index.ToString();
            int index = Convert.ToInt32(k);
            string s = dataGridView1.Rows[index].Cells[0].Value.ToString();
            string s1 = dataGridView1.Rows[index].Cells[1].Value.ToString();
            string s2 = dataGridView1.Rows[index].Cells[3].Value.ToString();
            string s4 = dataGridView1.Rows[index].Cells[4].Value.ToString();
            string s5 = dataGridView1.Rows[index].Cells[5].Value.ToString();
            string s6 = dataGridView1.Rows[index].Cells[6].Value.ToString();
            string s7 = dataGridView1.Rows[index].Cells[7].Value.ToString();
            textBox1.Text = s;
            textBox2.Text = s1;
            textBox4.Text = s2;
            textBox5.Text = s4;
            textBox6.Text = s5;
            textBox7.Text = s6;
            comboBox2.Text = s7;
        }
        //метод для скрытия groupBox
        private void button2_Click(object sender, EventArgs e)
        {
            groupBoxADD.Visible = false;
        }
        //метод для скрытия groupBox
        private void button3_Click(object sender, EventArgs e)
        {
            groupBoxUPDATE.Visible = false;
        }
        //переход к главной форме
        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 d = new Form1();
            d.ShowDialog();
        }
        //переход к форме работа с клиентом
        private void button4_Click(object sender, EventArgs e)
        {
            Работа_с_клиентом r = new Работа_с_клиентом();
            r.ShowDialog();
        }
        //метод для активации groupBox
        private void Add_newklient_Click_1(object sender, EventArgs e)
        {
            groupBoxADD.Visible = true;
            groupBoxUPDATE.Visible = false;
        }
        //метод для активации groupBox
        private void update_klient_Click(object sender, EventArgs e)
        {
            groupBoxADD.Visible = false;
            groupBoxUPDATE.Visible = true;
        }
        //удаление данных из БД
        private void delete_klient_Click(object sender, EventArgs e)
        {
            conn.Open();
            string s = dataGridView1.CurrentCell.Value.ToString();
            string sql = "Delete from Клиенты where id='" + s + "'";
            SqlCommand command = new SqlCommand(sql, conn);
            command.ExecuteNonQuery();
            conn.Close();
            printtable();
        }
    }
}
