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
    public partial class Оформление_заказа : Form
    {
        //строка подключения к БД
        SqlConnection conn = new SqlConnection(@"Data Source=HASD-ПК\SQLEXPRESS;Initial Catalog='BD';Integrated Security=True");
        public Оформление_заказа()
        {
            InitializeComponent();
        }
        string prisedetali;
        string nomerdet;
        string nameuslg;
        string stoimostbuslug;
        //методы которые вызываюся при загрузке формы
        private void Оформление_заказа_Load(object sender, EventArgs e)
        {
            nomerdetalimethod();
            nomeruslugimethod();
            loadmaster();
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox5.Enabled = false;
            textBox10.Enabled = false;
            fio.Text = Klienparametr.fio;
            textBox7.Text = Klienparametr.nomeravto;
            textBox8.Text = Klienparametr.nomerklient;
            fio.Enabled = false;
            textBox7.Enabled = false;
            textBox8.Enabled = false;
            //this.dataGridView2.Rows.Add();
        }
        //полчение номер клиента
        void nomerdetalimethod()
        {
            conn.Open();
            string sqlSel = "select [id детали] from Детали";

            SqlDataReader dr = null;

            SqlCommand cmdSel = new SqlCommand(sqlSel, conn);

            dr = cmdSel.ExecuteReader();

            while (dr.Read())
            {
                comboBox3.Items.Add(dr["id детали"].ToString());
            }

            cmdSel.Dispose();

            cmdSel = null;
            conn.Close();
        }
        //получение номер услуги
        void nomeruslugimethod()
        {
            conn.Open();
            string sqlSel = "select [id услуги] from Услуги";

            SqlDataReader dr = null;

            SqlCommand cmdSel = new SqlCommand(sqlSel, conn);

            dr = cmdSel.ExecuteReader();

            while (dr.Read())
            {
                comboBox4.Items.Add(dr["id услуги"].ToString());
            }

            cmdSel.Dispose();

            cmdSel = null;
            conn.Close();
        }
        //получаем ФИО мастера
        void loadmaster()
        {
            conn.Open();
            string sqlSel = "select [ФИО мастера] from Мастера";

            SqlDataReader dr = null;

            SqlCommand cmdSel = new SqlCommand(sqlSel, conn);

            dr = cmdSel.ExecuteReader();

            while (dr.Read())
            {
                comboBox1.Items.Add(dr["ФИО мастера"].ToString());
                comboBox2.Items.Add(dr["ФИО мастера"].ToString());
            }

            cmdSel.Dispose();

            cmdSel = null;
            conn.Close();
        }
        //переход к форме работа с клиентом
        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Работа_с_клиентом r = new Работа_с_клиентом();
            r.ShowDialog();
        }
        //добавление и проверка данных
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox3.Text == String.Empty)
            {
                MessageBox.Show("Для добавления выберите номер детали!");
            }
            else if (textBox4.Text == String.Empty)
            {
                MessageBox.Show("Для добавления выберите количество деталей!");
            }
            else if (comboBox1.Text == String.Empty)
            {
                MessageBox.Show("Для добавления детали выберите исполняющего мастера!");
            }
            else
            {
                this.dataGridView1.Rows.Add();

                int count = Convert.ToInt32(comboBox3.Text);
                int itog = Convert.ToInt32(prisedetali) * Convert.ToInt32(textBox4.Text);
                dataGridView1.Rows[count - 1].Cells[0].Value = count;
                dataGridView1.Rows[count - 1].Cells[1].Value = textBox3.Text;
                dataGridView1.Rows[count - 1].Cells[2].Value = textBox4.Text;
                dataGridView1.Rows[count - 1].Cells[3].Value = prisedetali;
                dataGridView1.Rows[count - 1].Cells[4].Value = itog.ToString();
                dataGridView1.Rows[count - 1].Cells[5].Value = comboBox1.Text;
                int sum1 = 0;
                int sum2 = 0;
                int sumitog = 0;
                for (int i = 0; i <= dataGridView1.RowCount; i++)
                {
                    
                    try
                    {
                        sum1 += Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value);
                        sum2 += Convert.ToInt32(dataGridView2.Rows[i].Cells[2].Value);
                    }
                    catch (ArgumentOutOfRangeException )
                    {

                    }
                }
                sumitog = sum1 + sum2;
                textBox10.Text = sumitog.ToString();
            }
        }
        //проверка данных и добавление
        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox4.Text == String.Empty)
            {
                MessageBox.Show("Для добавления выберите номер услуги!");
            }
            else if (comboBox2.Text == String.Empty)
            {
                MessageBox.Show("Для добавления детали выберите исполняющего мастера!");
            }
            else
            {
                this.dataGridView2.Rows.Add();
                int count = Convert.ToInt32(comboBox4.Text);
                dataGridView2.Rows[count - 1].Cells[0].Value = count;
                dataGridView2.Rows[count - 1].Cells[1].Value = nameuslg;
                dataGridView2.Rows[count - 1].Cells[2].Value = stoimostbuslug;
                dataGridView2.Rows[count - 1].Cells[3].Value = comboBox2.Text;
                int sum1 = 0;
                int sum2 = 0;
                int sumitog = 0;
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    try
                    {
                        sum1 += Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value);
                        sum2 += Convert.ToInt32(dataGridView2.Rows[i].Cells[2].Value);
                    }
                    catch (ArgumentOutOfRangeException )
                    {

                    }
                }
                sumitog = sum1 + sum2;
                textBox10.Text = sumitog.ToString();
            }
        }
        //проверка данных и добавление в БД
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox9.Text == String.Empty)
                {
                    MessageBox.Show("Чтобы оформить заказ укажите номер заказа!");
                }
                else if (textBox10.Text == String.Empty)
                {
                    MessageBox.Show("Чтобы оформить заказ нужно выбрать хатя бы 1 услугу и 1 деталь!");
                }
                else
                {
                    conn.Open();
                    int s = Convert.ToInt32(textBox9.Text);
                    string s1 = textBox8.Text;
                    string s2 = textBox10.Text;
                    string s3 = dateTimePicker1.Value.Date.ToShortDateString();
                    string s4 = dateTimePicker1.Value.Date.ToShortDateString();
                    string s5 = dateTimePicker2.Value.Date.ToShortDateString();
                    string sql = "insert into [Работа с клиентом] ([№ заказа],[№ клиента], Стоимость, [Дата оформления], [Дата выполнения],[Дата закрытия]) values ('" + s + "','" + s1 + "','" + s2 + "','" + s3 + "','" + s4 + "','" + s5 + "')";
                    SqlCommand command = new SqlCommand(sql, conn);
                    command.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Заказ добавлен!");
                    this.Hide();
                    Работа_с_клиентом r = new Работа_с_клиентом();
                    r.ShowDialog();
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Заполните все поля!", ex.Message);
                conn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Данный заказ уже имеется!", ex.Message);
                conn.Close();
            }
        }
        //вывод данных на экран
        private void comboBox3_TextChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text == String.Empty)
            {

            }
            else
            {
                string search = comboBox3.Text;
                conn.Open();
                string sqlSel = "select [id детали],Наименование,[Стоимость 1 детали] from Детали where [id детали] like '%" + search + "%'";

                SqlDataReader dr = null;

                SqlCommand cmdSel = new SqlCommand(sqlSel, conn);

                dr = cmdSel.ExecuteReader();

                while (dr.Read())
                {
                    nomerdet = dr["id детали"].ToString();
                    textBox3.Text = dr["Наименование"].ToString();
                    prisedetali = dr["Стоимость 1 детали"].ToString();
                }

                cmdSel.Dispose();

                cmdSel = null;
                conn.Close();
            }
        }
        //вывод данных из таблицы Услуги по id
        private void comboBox4_TextChanged(object sender, EventArgs e)
        {
            if (comboBox4.Text == String.Empty)
            {

            }
            else
            {
                string search = comboBox4.Text;
                conn.Open();
                string sqlSel = "select Наименование,Стоимость from Услуги where [id услуги] like '%" + search + "%'";

                SqlDataReader dr = null;

                SqlCommand cmdSel = new SqlCommand(sqlSel, conn);

                dr = cmdSel.ExecuteReader();

                while (dr.Read())
                {
                    textBox5.Text = dr["Наименование"].ToString();
                    textBox2.Text = dr["Стоимость"].ToString();
                    nameuslg = dr["Наименование"].ToString();
                    stoimostbuslug = dr["Стоимость"].ToString();

                }

                cmdSel.Dispose();

                cmdSel = null;
                conn.Close();
            }
        }
        //формирование отчета в ворд
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox9.Text == String.Empty)
                {
                    MessageBox.Show("Чтобы построить отчёт укажите номер заказа!");
                }
                else
                {
                    Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
                    Microsoft.Office.Interop.Word.Application winword =
                        new Microsoft.Office.Interop.Word.Application();

                    winword.Visible = false;

                    //Заголовок документа
                    winword.Documents.Application.Caption = "Оформление заказа";

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
                    para1.Range.Text = Environment.NewLine + "Заказ: № " + textBox9.Text;
                    para1.Range.InsertParagraphAfter();

                    //Создание таблицы
                    Table firstTable = document.Tables.Add(para1.Range, dataGridView1.RowCount, 6, ref missing, ref missing);

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
                                firstTable.Cell(1, 5).Range.Text = "Общая сумма";
                                firstTable.Cell(1, 6).Range.Text = "Исполняющий мастер";
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
                    }
                    Microsoft.Office.Interop.Word.Paragraph para2 = document.Content.Paragraphs.Add(ref missing);
                    object styleHeading2 = "Обычный";
                    para2.Range.set_Style(styleHeading2);
                    para2.Range.Font.Name = "Times New Roman";
                    para2.Range.Font.Size = 14;
                    para2.Range.Text = "";
                    para2.Range.InsertParagraphAfter();

                    //Создание таблицы
                    Table firstTable2 = document.Tables.Add(para1.Range, dataGridView2.RowCount, 4, ref missing, ref missing);

                    firstTable2.Borders.Enable = 1;

                    foreach (Row row in firstTable2.Rows)
                    {
                        foreach (Cell cell in row.Cells)
                        {
                            //Заголовок таблицы
                            if (cell.RowIndex == 1)
                            {
                                firstTable2.Cell(1, 1).Range.Text = "№ услуги";
                                firstTable2.Cell(1, 2).Range.Text = "Наименование";
                                firstTable2.Cell(1, 3).Range.Text = "Стоимость";
                                firstTable2.Cell(1, 4).Range.Text = "Исполняющий мастер";
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
                    firstTable2.Range.Font.Name = "Times New Roman";
                    firstTable2.Range.Font.Size = 12;
                    //Значения ячеек
                    for (int Row = 2; Row <= dataGridView2.RowCount; Row++)
                    {
                        firstTable2.Cell(Row, 1).Range.Text = dataGridView2.Rows[Row - 2].Cells[0].Value.ToString();
                        firstTable2.Cell(Row, 2).Range.Text = dataGridView2.Rows[Row - 2].Cells[1].Value.ToString();
                        firstTable2.Cell(Row, 3).Range.Text = dataGridView2.Rows[Row - 2].Cells[2].Value.ToString();
                        firstTable2.Cell(Row, 4).Range.Text = dataGridView2.Rows[Row - 2].Cells[3].Value.ToString();
                    }
                    Microsoft.Office.Interop.Word.Paragraph para3 = document.Content.Paragraphs.Add(ref missing);
                    object styleHeading3 = "Обычный";
                    para3.Range.set_Style(styleHeading3);
                    para3.Range.Font.Name = "Times New Roman";
                    para3.Range.Font.Size = 14;
                    para3.Range.Text = Environment.NewLine + "Номер клиента: " + textBox8.Text + Environment.NewLine + "Номер заказа: " + textBox9.Text + Environment.NewLine + "Стоимость: " + textBox10.Text + Environment.NewLine + "Дата оформления: " + dateTimePicker1.Value.Date.ToShortDateString() + Environment.NewLine + "Дата закрытия: " + dateTimePicker2.Value.Date.ToShortDateString() + Environment.NewLine + Environment.NewLine + Environment.NewLine;
                    para3.Range.InsertParagraphAfter();
                    // подпись клиента 
                    Microsoft.Office.Interop.Word.Paragraph para9 = document.Content.Paragraphs.Add(ref missing);
                    object styleHeading9 = "Обычный";
                    para9.Range.set_Style(styleHeading9);
                    para9.Range.Font.Name = "Times New Roman";
                    para9.Range.Font.Size = 14;
                    para9.Range.Text = "                                                                Подпись клиента: ___________________" + Environment.NewLine + "                                                            Подпись директора: ___________________";
                    para9.Range.InsertParagraphAfter();
                    //
                    winword.Visible = true;
                    app.Quit();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
