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
    public partial class СТО_услуги_ : Form
    {
        //строка подключения к БД
        SqlConnection conn = new SqlConnection(@"Data Source=HASD-ПК\SQLEXPRESS;Initial Catalog='BD';Integrated Security=True");
        public СТО_услуги_()
        {
            InitializeComponent();
        }
        //переход к главной форме
        private void button9_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.ShowDialog();
        }
        //методы которые вызваются при загрузке формы
        private void СТО_услуги__Load(object sender, EventArgs e)
        {
            printtable();
            groupBox3.Visible = false;
            groupBox2.Visible = false;
            dataGridView1.Columns[0].HeaderText = "Номер услуги";
        }
        //вывод данных из таблицы Услуги на экран
        void printtable()
        {
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("select *from Услуги", conn);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds, "Услуги");
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();
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
        //добавление данных в таблицу Услуги
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                int s = Convert.ToInt32(id_услугиTextBox.Text);
                string s1 = наименованиеTextBox.Text;
                string s2 = стоимостьTextBox.Text;
                string sql = "insert into Услуги ([id услуги],Наименование, Стоимость) values ('" + s + "','" + s1 + "','" + s2 + "')";
                SqlCommand command = new SqlCommand(sql, conn);
                command.ExecuteNonQuery();
                conn.Close();
                printtable();
                id_услугиTextBox.Clear();
                наименованиеTextBox.Clear();
                стоимостьTextBox.Clear();
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
        //обновление данных в таблице
        private void button7_Click(object sender, EventArgs e)
        {
            conn.Open();
            string sql = "Update Услуги set Наименование='" + textBox2.Text + "',Стоимость='" + textBox3.Text + "' where [id услуги]='" + textBox1.Text + "'";
            SqlCommand command = new SqlCommand(sql, conn);
            command.ExecuteNonQuery();
            conn.Close();
            printtable();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            groupBox2.Visible = false;
        }
        //скопировать данные для изменения
        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            string k = dataGridView1.CurrentRow.Index.ToString();
            int index = Convert.ToInt32(k);
            string s = dataGridView1.Rows[index].Cells[0].Value.ToString();
            string s1 = dataGridView1.Rows[index].Cells[1].Value.ToString();
            string s2 = dataGridView1.Rows[index].Cells[2].Value.ToString();
            textBox1.Text = s;
            textBox2.Text = s1;
            textBox3.Text = s2;
        }
        //удалить данные из таблицы
        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            string s = dataGridView1.CurrentCell.Value.ToString();
            string sql = "Delete from Услуги where [id услуги]='" + s + "'";
            SqlCommand command = new SqlCommand(sql, conn);
            command.ExecuteNonQuery();
            conn.Close();
            printtable();
        }
    }
}
