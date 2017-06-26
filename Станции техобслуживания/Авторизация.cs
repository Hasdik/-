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
    public partial class Авторизация : Form
    {
        //Строка подключения к БД
        SqlConnection connection = new SqlConnection(@"Data Source=HASD-ПК\SQLEXPRESS;Initial Catalog='BD';Integrated Security=True");
        public Авторизация()
        {
            InitializeComponent();
        }
        //Метод проверки и авторизации 
        private void button1_Click(object sender, EventArgs e)
        {
            int count = 0;

            using (SqlCommand command = new SqlCommand("select * from Users WHERE login = '" + textBox1.Text + "' AND password = '" + textBox2.Text + "'", connection))
            {
                command.Parameters.AddWithValue("par1", textBox1.Text);
                command.Parameters.AddWithValue("par2", textBox2.Text);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        count += 1;
                }
                connection.Close();
            }
            if (count == 0)
            {
                MessageBox.Show("Пароль неверен!");
                return;
            }
            this.Hide();
            if (textBox1.Text == "Клиент")
            {
                Покупка p = new Покупка();
                p.ShowDialog();
            }
            else if (textBox1.Text == "admin")
            {
                Администратор a = new Администратор();
                a.ShowDialog();
            }
            else if (textBox1.Text == "Поставщик")
            {
                Поставщики a = new Поставщики();
                a.ShowDialog();
            }
            else if (textBox1.Text == "Мастер")
            {
                Мастера a = new Мастера();
                a.ShowDialog();
            }
            else if (textBox2.Text == "1")
            {
                Сотрудники a = new Сотрудники();
                a.ShowDialog();
            }
            else if (textBox2.Text == "клиент")
            {
                Клиенты a = new Клиенты();
                a.ShowDialog();
            }
            else if (textBox2.Text == "деталь")
            {
                Детали a = new Детали();
                a.ShowDialog();
            }
            else if (textBox2.Text == "услуга")
            {
                СТО_услуги_ a = new СТО_услуги_();
                a.ShowDialog();
            }
            else if (textBox2.Text == "отследить")
            {
                Отслеживание_клиентов_список_клиентов_ a = new Отслеживание_клиентов_список_клиентов_();
                a.ShowDialog();
            }
        }
    }
}
