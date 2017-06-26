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
    public partial class Работа_с_клиентом : Form
    {
        //строка подключения к БД
        SqlConnection conn = new SqlConnection(@"Data Source=HASD-ПК\SQLEXPRESS;Initial Catalog='BD';Integrated Security=True");
        public Работа_с_клиентом()
        {
            InitializeComponent();
        }
        //проверка на ввод
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == String.Empty)
            {
                MessageBox.Show("Чтобы оформить заказ нужно выбрать клиента!");
            }
            else
            {
                Оформление_заказа o = new Оформление_заказа();
                o.ShowDialog();
            }
        }
        //метод для перехода к форме Клиенты
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Клиенты k = new Клиенты();
            k.ShowDialog();
        }
        //получеам номер клиента
        void nomerklienmethod()
        {
            conn.Open();
            string sqlSel = "select id from Клиенты";

            SqlDataReader dr = null;

            SqlCommand cmdSel = new SqlCommand(sqlSel, conn);

            dr = cmdSel.ExecuteReader();

            while (dr.Read())
            {
                comboBox1.Items.Add(dr["id"].ToString());
            }

            cmdSel.Dispose();

            cmdSel = null;
            conn.Close();
        }
        //методы которые вызываются при загрузке формы
        private void Работа_с_клиентом_Load(object sender, EventArgs e)
        {
            nomerklienmethod();
            textBox2.Enabled = false;
            textBox7.Enabled = false;
            printtable();
        }
        //вывод на экран таблицы работа с клиентом
        void printtable()
        {
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter("select *from [Работа с клиентом]", conn);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds, "[Работа с клиентом]");
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();
        }
        //полчение фио и номер авто клиента
        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == String.Empty)
            {
               
            }
            else
            {
                string search = comboBox1.Text;
                conn.Open();
                string sqlSel = "select [ФИО клиента],[Номер автомобиля] from Клиенты where id like '%" + search + "%'";

                SqlDataReader dr = null;

                SqlCommand cmdSel = new SqlCommand(sqlSel, conn);

                dr = cmdSel.ExecuteReader();

                while (dr.Read())
                {

                    textBox2.Text = dr["ФИО клиента"].ToString();
                    textBox7.Text = dr["Номер автомобиля"].ToString();

                }

                cmdSel.Dispose();

                cmdSel = null;
                conn.Close();
            }
            Klienparametr.fio = textBox2.Text;
            Klienparametr.nomeravto = textBox7.Text;
            Klienparametr.nomerklient = comboBox1.Text;
        }
        //формирование отчета в word
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
                Microsoft.Office.Interop.Word.Application winword =
                    new Microsoft.Office.Interop.Word.Application();

                winword.Visible = false;

                //Заголовок документа
                winword.Documents.Application.Caption = "Очередь заказов";

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
                para1.Range.Text = Environment.NewLine + "Очередь заказов";
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
                            firstTable.Cell(1, 1).Range.Text = "№ заказа";
                            firstTable.Cell(1, 2).Range.Text = "№ клиента";
                            firstTable.Cell(1, 3).Range.Text = "Стоимость";
                            firstTable.Cell(1, 4).Range.Text = "Дата оформления";
                            firstTable.Cell(1, 5).Range.Text = "Дата выполнения";
                            firstTable.Cell(1, 6).Range.Text = "Дата закрытия";
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

                // подпись клиента 
                Microsoft.Office.Interop.Word.Paragraph para9 = document.Content.Paragraphs.Add(ref missing);
                object styleHeading9 = "Обычный";
                para9.Range.set_Style(styleHeading9);
                para9.Range.Font.Name = "Times New Roman";
                para9.Range.Font.Size = 14;
                para9.Range.Text = Environment.NewLine+Environment.NewLine+Environment.NewLine+"                                                                Подпись клиента: ___________________" + Environment.NewLine + "                                                            Подпись директора: ___________________";
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
    //класс для полчения парметров клиента
    class Klienparametr
    {
        public static string fio { get; set; }
        public static string nomeravto { get; set; }
        public static string nomerklient { get; set; }
    }
}
