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
    public partial class Отслеживание_клиентов_список_клиентов_ : Form
    {
        //строка подключения к БД
        SqlConnection conn = new SqlConnection(@"Data Source=HASD-ПК\SQLEXPRESS;Initial Catalog='BD';Integrated Security=True");
        public Отслеживание_клиентов_список_клиентов_()
        {
            InitializeComponent();
        }
        //переход к форме отслеживание клиентов
        private void button1_Click(object sender, EventArgs e)
        {
            Отслеживание_клиентов o = new Отслеживание_клиентов();
            o.ShowDialog();
        }
        //переход к главной форме
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.ShowDialog();
        }

        private void Отслеживание_клиентов_список_клиентов__Load(object sender, EventArgs e)
        {
            printtable();
            dataGridView1.Columns[0].HeaderText = "Номер клиента";
        }
        //вывод на экран табицы клиенты
        void printtable()
        {
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("select id, [ФИО клиента], [Номер автомобиля] from Клиенты", conn);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds, "Клиенты");
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();
        }
    }
}
