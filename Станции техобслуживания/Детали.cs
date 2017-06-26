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
    public partial class Детали : Form
    {
        //подключение к БД
        SqlConnection conn = new SqlConnection(@"Data Source=HASD-ПК\SQLEXPRESS;Initial Catalog='BD';Integrated Security=True");
        SqlConnection connect = new SqlConnection(@"Data Source=HASD-ПК\SQLEXPRESS;Initial Catalog='BD';Integrated Security=True");
        public Детали()
        {
            InitializeComponent();
        }
        //активаци формы
        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.ShowDialog();
        }
        //вывод таблицы
        void printtable()
        {
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("select *from Детали", conn);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds, "Детали");
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();
        }
        //вывод таблицы
        void printtable1()
        {
            SqlDataAdapter da = new SqlDataAdapter("select *from Детали", connect);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds, "Детали");
            dataGridView1.DataSource = ds.Tables[0];
        }
        //методы которые вызываются при загрузке формы
        private void Детали_Load(object sender, EventArgs e)
        {
            printtable();
            Detalidostav();
            dataGridView1.Columns[0].HeaderText = "Номер детали";

        }
        //удалние из таблицы Заказ деталей
        void delete(string id)
        {
            string sql = "Delete from [Заказ деталей] where [Номер детали]='" + id + "'";
            SqlCommand command = new SqlCommand(sql, connect);
            command.ExecuteNonQuery();
        }
        //метод который проверяет доставку детали
        void Detalidostav()
        {
            string name = " ";
            string count = " ";
            string stoimostb = " ";
            string status = " ";
            string nomerzaivki;
            int id = 0;
            int lenght = 0;

            conn.Open();
            string sqlSel = "select [Номер детали],Наименование,Количество,[Стоимость 1 детали],Статус from [Заказ деталей]";

            SqlDataReader dr = null;

            SqlCommand cmdSel = new SqlCommand(sqlSel, conn);

            dr = cmdSel.ExecuteReader();

            while (dr.Read())
            {
                nomerzaivki = dr["Номер детали"].ToString();
                name = dr["Наименование"].ToString();
                count = dr["Количество"].ToString();
                stoimostb = dr["Стоимость 1 детали"].ToString();
                status = dr["Статус"].ToString();
                if (status == "Доставлен")
                {
                    lenght++;
                    connect.Open();
                    id = dataGridView1.RowCount;
                    string sql = "insert into Детали ([id детали],Наименование, [Кол-во на складе],[Стоимость 1 детали]) values ('" + id + "','" + name + "','" + count + "','" + stoimostb + "')";
                    SqlCommand command = new SqlCommand(sql, connect);
                    command.ExecuteNonQuery();
                    delete(nomerzaivki);
                    printtable1();
                    connect.Close();
                }
            }
            cmdSel.Dispose();

            cmdSel = null;
            conn.Close();
            printtable();
           MessageBox.Show("Количество новых деталей: "+lenght.ToString());
        }
        //вызов метода
        private void button1_Click(object sender, EventArgs e)
        {
            Detalidostav();
        }
        //удаление из табицы Детали
        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            string s = dataGridView1.CurrentCell.Value.ToString();
            string sql = "Delete from Детали where [id детали]='" + s + "'";
            SqlCommand command = new SqlCommand(sql, conn);
            command.ExecuteNonQuery();
            conn.Close();
            printtable();
        }
        // Обновление таблицы Детали
        private void button7_Click(object sender, EventArgs e)
        {
            conn.Open();
            string sql = "Update Детали set Наименование='" + textBox2.Text + "',[Кол-во на складе]='" + textBox3.Text + "',[Стоимость 1 детали]='" + textBox4.Text + "' where [id детали]='" + textBox1.Text + "'";
            SqlCommand command = new SqlCommand(sql, conn);
            command.ExecuteNonQuery();
            conn.Close();
            printtable();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }
        //копировать данные из таблицы
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
        //очистка textbox
        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }
    }
}
