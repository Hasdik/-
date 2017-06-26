using Microsoft.Office.Interop.Word;
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
using Word = Microsoft.Office.Interop.Word;
namespace Станции_техобслуживания
{
    public partial class Заказ_деталей : Form
    {
        //строка подключения к БД
        SqlConnection conn = new SqlConnection(@"Data Source=HASD-ПК\SQLEXPRESS;Initial Catalog='BD';Integrated Security=True");
        public Заказ_деталей()
        {
            InitializeComponent();
        }
        //переход к форме поставщики
        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Поставщики p = new Поставщики();
            p.ShowDialog();
        }
        //методы котоыре вызваются при загрузке формы
        private void Заказ_деталей_Load(object sender, EventArgs e)
        {
            postavwik();
            nomerzakazdetalei();
            printtable();
        }
        //Вывод талицы заказ деталей
        void printtable()
        {
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("select *from [Заказ деталей]", conn);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds, "[Заказ деталей]");
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();
        }
        //получение поставщиков
        void postavwik()
        {
            conn.Open();
            string sqlSel = "select [Название фирмы] from Поставщики";

            SqlDataReader dr = null;

            SqlCommand cmdSel = new SqlCommand(sqlSel, conn);

            dr = cmdSel.ExecuteReader();

            while (dr.Read())
            {
                comboBox1.Items.Add(dr["Название фирмы"].ToString());
            }

            cmdSel.Dispose();

            cmdSel = null;
            conn.Close();
        }
        //получение номера детали
        void nomerzakazdetalei()
        {
            conn.Open();
            string sqlSel = "select [Номер детали] from [Заказ деталей]";

            SqlDataReader dr = null;

            SqlCommand cmdSel = new SqlCommand(sqlSel, conn);

            dr = cmdSel.ExecuteReader();

            while (dr.Read())
            {
                comboBox2.Items.Add(dr["Номер детали"].ToString());
            }

            cmdSel.Dispose();

            cmdSel = null;
            conn.Close();
        }
        //добавление в БД
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                int s = Convert.ToInt32(id_деталиTextBox.Text);
                string s1 = наименованиеTextBox.Text;
                string s2 = кол_во_на_складеTextBox.Text;
                string s3 = стоимость_1_деталиTextBox.Text;
                string s4 = comboBox1.Text;
                int s5 = Convert.ToInt32(s2) * Convert.ToInt32(s3);
                string s7 = "Ожидание";
                string sql = "insert into [Заказ деталей] ([Номер детали],Наименование, Количество, [Стоимость 1 детали], [Общая стоимость],Поставщик, Статус) values ('" + s + "','" + s1 + "','" + s2 + "','" + s3 + "','" + s5.ToString() + "','" + s4 + "','" + s7 + "')";
                SqlCommand command = new SqlCommand(sql, conn);
                command.ExecuteNonQuery();
                conn.Close();
                printtable();
                id_деталиTextBox.Clear();
                наименованиеTextBox.Clear();
                кол_во_на_складеTextBox.Clear();
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
        //удаление из БД
        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            string s = dataGridView1.CurrentCell.Value.ToString();
            string sql = "Delete from [Заказ деталей] where [Номер детали]='" + s + "'";
            SqlCommand command = new SqlCommand(sql, conn);
            command.ExecuteNonQuery();
            conn.Close();
            printtable();
        }
        //получение статуса заказа деталей
        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == String.Empty)
            {

            }
            else
            {
                string search = comboBox2.Text;
                conn.Open();
                string sqlSel = "select Статус from [Заказ деталей] where [Номер детали] like '%" + search + "%'";

                SqlDataReader dr = null;

                SqlCommand cmdSel = new SqlCommand(sqlSel, conn);

                dr = cmdSel.ExecuteReader();

                while (dr.Read())
                {

                    comboBox3.Text = dr["Статус"].ToString();

                }

                cmdSel.Dispose();

                cmdSel = null;
                conn.Close();
            }
        }
        //обновление таблицы 
        private void button4_Click(object sender, EventArgs e)
        {
            conn.Open();
            string sql = "Update [Заказ деталей] set Статус='" + comboBox3.Text + "'where [Номер детали]='" + comboBox2.Text + "'";
            SqlCommand command = new SqlCommand(sql, conn);
            command.ExecuteNonQuery();
            conn.Close();
            printtable();
        }
        //проверка заказов на наличее
        private void button3_Click(object sender, EventArgs e)
        {
            int k = dataGridView1.RowCount;
            int kzakaz = k - 1;
            MessageBox.Show("Было заказано: " + kzakaz.ToString() + " заказа");
        }
        //формирование отчета в word
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
                Microsoft.Office.Interop.Word.Application winword =
                    new Microsoft.Office.Interop.Word.Application();

                winword.Visible = false;

                //Заголовок документа
                winword.Documents.Application.Caption = "Очередь деталей для заказа";

                object missing = System.Reflection.Missing.Value;

                //Создание нового документа
                Microsoft.Office.Interop.Word.Document document =
                    winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);

                //Добавление текста со стилем Обычный
                Microsoft.Office.Interop.Word.Paragraph para1 = document.Content.Paragraphs.Add(ref missing);
                object styleHeading1 = "Обычный";
                para1.Range.set_Style(styleHeading1);
                para1.Range.Font.Name = "Times New Roman";
                para1.Range.Font.Size = 20;
                para1.Range.Text = Environment.NewLine + "Очередь деталей";
                para1.Range.InsertParagraphAfter();

                //Создание таблицы
                Table firstTable = document.Tables.Add(para1.Range, dataGridView1.RowCount, 7, ref missing, ref missing);

                firstTable.Borders.Enable = 1;

                foreach (Row row in firstTable.Rows)
                {
                    foreach (Cell cell in row.Cells)
                    {
                        //Заголовок таблицы
                        if (cell.RowIndex == 1)
                        {
                            firstTable.Cell(1, 1).Range.Text = "№ детали";
                            firstTable.Cell(1, 2).Range.Text = "Наименование";
                            firstTable.Cell(1, 3).Range.Text = "Количество";
                            firstTable.Cell(1, 4).Range.Text = "Стоимость 1 детали";
                            firstTable.Cell(1, 5).Range.Text = "Общая стоимость";
                            firstTable.Cell(1, 6).Range.Text = "Поставщик";
                            firstTable.Cell(1, 7).Range.Text = "Статус";
                            cell.Range.Font.Bold = 1;
                            //Задаем шрифт и размер текста
                            cell.Range.Font.Name = "Times New Roman";
                            cell.Range.Font.Size = 12;
                            cell.Shading.BackgroundPatternColor = WdColor.wdColorGray25;
                            //Выравнивание текста в заголовках столбцов по центру
                            cell.VerticalAlignment =
                            WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                            cell.Range.ParagraphFormat.Alignment =
                            WdParagraphAlignment.wdAlignParagraphCenter;
                        }

                    }
                }
                firstTable.Range.Font.Name = "Times New Roman";
                firstTable.Range.Font.Size = 12;
                //Значения ячеек
                for (int Row = 2; Row <= dataGridView1.RowCount; Row++)
                {
                    firstTable.Cell(Row, 1).Range.Text = dataGridView1.Rows[Row - 2].Cells[0].Value.ToString();
                    firstTable.Cell(Row, 2).Range.Text = dataGridView1.Rows[Row - 2].Cells[1].Value.ToString();
                    firstTable.Cell(Row, 3).Range.Text = dataGridView1.Rows[Row - 2].Cells[2].Value.ToString();
                    firstTable.Cell(Row, 4).Range.Text = dataGridView1.Rows[Row - 2].Cells[3].Value.ToString();
                    firstTable.Cell(Row, 5).Range.Text = dataGridView1.Rows[Row - 2].Cells[4].Value.ToString();
                    firstTable.Cell(Row, 6).Range.Text = dataGridView1.Rows[Row - 2].Cells[5].Value.ToString();
                    firstTable.Cell(Row, 7).Range.Text = dataGridView1.Rows[Row - 2].Cells[6].Value.ToString();
                }

                // подпись клиента 
                Microsoft.Office.Interop.Word.Paragraph para9 = document.Content.Paragraphs.Add(ref missing);
                object styleHeading9 = "Обычный";
                para9.Range.set_Style(styleHeading9);
                para9.Range.Font.Name = "Times New Roman";
                para9.Range.Font.Size = 14;
                para9.Range.Text = Environment.NewLine + Environment.NewLine + Environment.NewLine + "                                                                Подпись клиента: ___________________" + Environment.NewLine + "                                                            Подпись директора: ___________________";
                para9.Range.InsertParagraphAfter();
                //
                winword.Visible = true;
                app.Quit();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
