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
    public partial class Отслеживание_клиентов : Form
    {
        //строка подключения к БД
        SqlConnection conn = new SqlConnection(@"Data Source=HASD-ПК\SQLEXPRESS;Initial Catalog='BD';Integrated Security=True");
        public Отслеживание_клиентов()
        {
            InitializeComponent();
        }
        //переход к главной форме
        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.ShowDialog();
        }
        //открытие окна для отправки смс
        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1234.Text == String.Empty)
            {
                MessageBox.Show("Выберите клиента чтобы отправить смс!");
            }
            else
            {
                Отправить_sms o = new Отправить_sms();
                o.ShowDialog();
            }
            }
        DataTable dtRouter;
        private void Отслеживание_клиентов_Load(object sender, EventArgs e)
        {
            textBoxsdf.Enabled = false;
            textBoxdsf.Enabled = false;
            textBoxsd.Enabled = false;
            textBoxdfd.Enabled = false;
            textBox6.Enabled = false;
            textBox5.Enabled = false;
            textBox4.Enabled = false;
            textBox3.Enabled = false;
            textBox2.Enabled = false;
            textBox1.Enabled = false;
            nomerklienmethod();
            //Настройки для компонента GMap.
            gMapControl1.Bearing = 0;

            //CanDragMap - Если параметр установлен в True,
            //пользователь может перетаскивать карту 
            //с помощью правой кнопки мыши. 
            gMapControl1.CanDragMap = true;

            //Указываем, что перетаскивание карты осуществляется 
            //с использованием левой клавишей мыши.
            //По умолчанию - правая.
            gMapControl1.DragButton = MouseButtons.Left;

            gMapControl1.GrayScaleMode = true;

            //MarkersEnabled - Если параметр установлен в True,
            //любые маркеры, заданные вручную будет показаны.
            //Если нет, они не появятся.
            gMapControl1.MarkersEnabled = true;

            //Указываем значение максимального приближения.
            gMapControl1.MaxZoom = 18;

            //Указываем значение минимального приближения.
            gMapControl1.MinZoom = 2;

            //Устанавливаем центр приближения/удаления для
            //курсора мыши.
            gMapControl1.MouseWheelZoomType =
                GMap.NET.MouseWheelZoomType.MousePositionAndCenter;

            //Отказываемся от негативного режима.
            gMapControl1.NegativeMode = false;

            //Разрешаем полигоны.
            gMapControl1.PolygonsEnabled = true;

            //Разрешаем маршруты.
            gMapControl1.RoutesEnabled = true;

            //Скрываем внешнюю сетку карты
            //с заголовками.
            gMapControl1.ShowTileGridLines = false;

            //Указываем, что при загрузке карты будет использоваться 
            //2х кратное приближение.
            gMapControl1.Zoom = 2;

            //Указываем что будем использовать карты Google.
            gMapControl1.MapProvider =
                GMap.NET.MapProviders.GMapProviders.GoogleMap;
            GMap.NET.GMaps.Instance.Mode =
                GMap.NET.AccessMode.ServerOnly;

            //Если вы используете интернет через прокси сервер,
            //указываем свои учетные данные.
            GMap.NET.MapProviders.GMapProvider.WebProxy =
                System.Net.WebRequest.GetSystemWebProxy();
            GMap.NET.MapProviders.GMapProvider.WebProxy.Credentials =
                System.Net.CredentialCache.DefaultCredentials;

            //инициализируем новую таблицу,
            //для хранения данных о маршруте.
            dtRouter = new DataTable();

            //Добавляем в инициализированную таблицу,
            //новые колонки.
            dtRouter.Columns.Add("Шаг");
            dtRouter.Columns.Add("Нач. точка (latitude)");
            dtRouter.Columns.Add("Нач. точка (longitude)");
            dtRouter.Columns.Add("Кон. точка (latitude)");
            dtRouter.Columns.Add("Кон. точка (longitude)");
            dtRouter.Columns.Add("Время пути");
            dtRouter.Columns.Add("Расстояние");
            dtRouter.Columns.Add("Описание маршрута");

            //Задаем источник данных, для объекта
            //System.Windows.Forms.DataGridView.            
            dataGridView1.DataSource = dtRouter;

            //Задаем ширину седьмого столбца.
            dataGridView1.Columns[7].Width = 250;

            //Задаем значение, указывающее, что необходимо скрыть 
            //для пользователя параметр добавления строк.
            dataGridView1.AllowUserToAddRows = false;

            //Задаем значение, указывающее, что пользователю
            //запрещено удалять строки.
            dataGridView1.AllowUserToDeleteRows = false;

            //Задаем значение, указывающее, что пользователь
            //не может изменять ячейки элемента управления.
            dataGridView1.ReadOnly = false;

            //Добавляем способы перемещения.
            comboBox1.Items.Add("Автомобильные маршруты");
            comboBox1.Items.Add("Пешеходные маршруты");

            //Выставляем по умолчанию способ перемещения:
            //Автомобильные маршруты по улично-дорожной сети.
            comboBox1.SelectedIndex = 0;
        }
        //вывод данных по номеру клиента
        private void comboBox1_TextChanged(object sender, EventArgs e)
        {

            if (comboBox1234.Text == String.Empty)
            {

            }
            else if (comboBox1234.Text != String.Empty)
            {
                
                string search = comboBox1234.Text;
                conn.Open();
                string sqlSel = "select [ФИО клиента],[Номер автомобиля],Телефон,[Место жительства] from Клиенты where id like '%" + search + "%'";

                SqlDataReader dr = null;

                SqlCommand cmdSel = new SqlCommand(sqlSel, conn);

                dr = cmdSel.ExecuteReader();

                while (dr.Read())
                {
                    textBoxsdf.Text = dr["ФИО клиента"].ToString();
                    textBoxdsf.Text = dr["Номер автомобиля"].ToString();
                    textBoxsd.Text = dr["Телефон"].ToString();
                    textBox2.Text = dr["Место жительства"].ToString();
                }

                cmdSel.Dispose();

                cmdSel = null;
                conn.Close();
            }
            if (comboBox1234.Text != String.Empty)
            {
                textBoxdfd.Clear();
                string search = comboBox1234.Text;
                conn.Open();
                string sqlSel = "select [Дата закрытия] from [Работа с клиентом] where [№ клиента] like '%" + search + "%'";

                SqlDataReader dr = null;

                SqlCommand cmdSel = new SqlCommand(sqlSel, conn);

                dr = cmdSel.ExecuteReader();

                while (dr.Read())
                {
                    string data = dr["Дата закрытия"].ToString();
                    if (data != String.Empty)
                    {
                        textBoxdfd.Text = data;
                    }
                }
                if (textBoxdfd.Text == String.Empty)
                {
                    textBoxdfd.Text = "Не проходил";
                }
                cmdSel.Dispose();

                cmdSel = null;
                conn.Close();
            }
            nomerklientClass.nomer = textBoxsd.Text;
        }
        //получем все номеры клиента
        void nomerklienmethod()
        {
            conn.Open();
            string sqlSel = "select id from Клиенты";

            SqlDataReader dr = null;

            SqlCommand cmdSel = new SqlCommand(sqlSel, conn);

            dr = cmdSel.ExecuteReader();

            while (dr.Read())
            {
                comboBox1234.Items.Add(dr["id"].ToString());
            }

            cmdSel.Dispose();

            cmdSel = null;
            conn.Close();
        }
        //метод для отслежки клиента
        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1234.Text == String.Empty)
            {
                MessageBox.Show("Выберите клиента чтобы отследить!");
            }
            else
            {
                //Очищаем таблицу перед загрузкой данных.
                dtRouter.Rows.Clear();

                //Создаем список способов перемещения.
                List<string> mode = new List<string>();
                //Автомобильные маршруты по улично-дорожной сети.
                mode.Add("driving");
                //Пешеходные маршруты по прогулочным дорожкам и тротуарам.
                mode.Add("walking");
                //Велосипедные маршруты по велосипедным дорожкам и предпочитаемым улицам.
                mode.Add("bicycling");
                //Маршруты общественного транспорта.
                mode.Add("transit");

                //Фрмируем запрос к API маршрутов Google.
                string url = string.Format(
                    "http://maps.googleapis.com/maps/api/directions/xml?origin={0},&destination={1}&sensor=false&language=ru&mode={2}",
                    Uri.EscapeDataString(textBox1.Text), Uri.EscapeDataString(textBox2.Text), Uri.EscapeDataString(mode[comboBox1.SelectedIndex]));

                //Выполняем запрос к универсальному коду ресурса (URI).
                System.Net.HttpWebRequest request =
                    (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);

                //Получаем ответ от интернет-ресурса.
                System.Net.WebResponse response =
                    request.GetResponse();

                //Экземпляр класса System.IO.Stream 
                //для чтения данных из интернет-ресурса.
                System.IO.Stream dataStream =
                    response.GetResponseStream();

                //Инициализируем новый экземпляр класса 
                //System.IO.StreamReader для указанного потока.
                System.IO.StreamReader sreader =
                    new System.IO.StreamReader(dataStream);

                //Считываем поток от текущего положения до конца.            
                string responsereader = sreader.ReadToEnd();

                //Закрываем поток ответа.
                response.Close();

                System.Xml.XmlDocument xmldoc =
                    new System.Xml.XmlDocument();

                xmldoc.LoadXml(responsereader);

                if (xmldoc.GetElementsByTagName("status")[0].ChildNodes[0].InnerText == "OK")
                {
                    System.Xml.XmlNodeList nodes =
                        xmldoc.SelectNodes("//leg//step");

                    //Формируем строку для добавления в таблицу.
                    object[] dr;
                    for (int i = 0; i < nodes.Count; i++)
                    {
                        //Указываем что массив будет состоять из 
                        //восьми значений.
                        dr = new object[8];
                        //Номер шага.
                        dr[0] = i;
                        //Получение координат начала отрезка.
                        dr[1] = xmldoc.SelectNodes("//start_location").Item(i).SelectNodes("lat").Item(0).InnerText.ToString();
                        dr[2] = xmldoc.SelectNodes("//start_location").Item(i).SelectNodes("lng").Item(0).InnerText.ToString();
                        //Получение координат конца отрезка.
                        dr[3] = xmldoc.SelectNodes("//end_location").Item(i).SelectNodes("lat").Item(0).InnerText.ToString();
                        dr[4] = xmldoc.SelectNodes("//end_location").Item(i).SelectNodes("lng").Item(0).InnerText.ToString();
                        //Получение времени необходимого для прохождения этого отрезка.
                        dr[5] = xmldoc.SelectNodes("//duration").Item(i).SelectNodes("text").Item(0).InnerText.ToString();
                        //Получение расстояния, охватываемое этим отрезком.
                        dr[6] = xmldoc.SelectNodes("//distance").Item(i).SelectNodes("text").Item(0).InnerText.ToString();
                        //Получение инструкций для этого шага, представленные в виде текстовой строки HTML.
                        dr[7] = HtmlToPlainText(xmldoc.SelectNodes("//html_instructions").Item(i).InnerText.ToString());
                        //Добавление шага в таблицу.
                        dtRouter.Rows.Add(dr);
                    }

                    //Выводим в текстовое поле адрес начала пути.
                    textBox1.Text = xmldoc.SelectNodes("//leg//start_address").Item(0).InnerText.ToString();
                    //Выводим в текстовое поле адрес конца пути.
                    textBox2.Text = xmldoc.SelectNodes("//leg//end_address").Item(0).InnerText.ToString();
                    //Выводим в текстовое поле время в пути.
                    textBox3.Text = xmldoc.GetElementsByTagName("duration")[nodes.Count].ChildNodes[1].InnerText;
                    //Выводим в текстовое поле расстояние от начальной до конечной точки.
                    textBox4.Text = xmldoc.GetElementsByTagName("distance")[nodes.Count].ChildNodes[1].InnerText;

                    //Переменные для хранения координат начала и конца пути.
                    double latStart = 0.0;
                    double lngStart = 0.0;
                    double latEnd = 0.0;
                    double lngEnd = 0.0;

                    //Получение координат начала пути.
                    latStart = System.Xml.XmlConvert.ToDouble(xmldoc.GetElementsByTagName("start_location")[nodes.Count].ChildNodes[0].InnerText);
                    lngStart = System.Xml.XmlConvert.ToDouble(xmldoc.GetElementsByTagName("start_location")[nodes.Count].ChildNodes[1].InnerText);
                    //Получение координат конечной точки.
                    latEnd = System.Xml.XmlConvert.ToDouble(xmldoc.GetElementsByTagName("end_location")[nodes.Count].ChildNodes[0].InnerText);
                    lngEnd = System.Xml.XmlConvert.ToDouble(xmldoc.GetElementsByTagName("end_location")[nodes.Count].ChildNodes[1].InnerText);

                    //Выводим в текстовое поле координаты начала пути.
                    textBox5.Text = latStart + ";" + lngStart;
                    //Выводим в текстовое поле координаты конечной точки.
                    textBox6.Text = latEnd + ";" + lngEnd;

                    //Устанавливаем заполненную таблицу в качестве источника.
                    dataGridView1.DataSource = dtRouter;

                    //Устанавливаем позицию карты на начало пути.
                    gMapControl1.Position = new GMap.NET.PointLatLng(latStart, lngStart);

                    //Создаем новый список маркеров, с указанием компонента 
                    //в котором они будут использоваться и названием списка.
                    GMap.NET.WindowsForms.GMapOverlay markersOverlay =
                        new GMap.NET.WindowsForms.GMapOverlay(gMapControl1, "marker");

                    //Инициализация нового ЗЕЛЕНОГО маркера, с указанием координат начала пути.
                    GMap.NET.WindowsForms.Markers.GMapMarkerGoogleGreen markerG =
                        new GMap.NET.WindowsForms.Markers.GMapMarkerGoogleGreen(
                        new GMap.NET.PointLatLng(latStart, lngStart));
                    markerG.ToolTip =
                        new GMap.NET.WindowsForms.ToolTips.GMapRoundedToolTip(markerG);

                    //Указываем, что подсказку маркера, необходимо отображать всегда.
                    markerG.ToolTipMode = GMap.NET.WindowsForms.MarkerTooltipMode.Always;

                    //Формируем подсказку для маркера.
                    string[] wordsG = textBox1.Text.Split(',');
                    string dataMarkerG = string.Empty;
                    foreach (string word in wordsG)
                    {
                        dataMarkerG += word + ";\n";
                    }

                    //Устанавливаем текст подсказки маркера.               
                    markerG.ToolTipText = dataMarkerG;

                    //Инициализация нового Красного маркера, с указанием координат конца пути.
                    GMap.NET.WindowsForms.Markers.GMapMarkerGoogleRed markerR =
                        new GMap.NET.WindowsForms.Markers.GMapMarkerGoogleRed(
                        new GMap.NET.PointLatLng(latEnd, lngEnd));
                    markerG.ToolTip =
                        new GMap.NET.WindowsForms.ToolTips.GMapRoundedToolTip(markerG);

                    //Указываем, что подсказку маркера, необходимо отображать всегда.
                    markerR.ToolTipMode = GMap.NET.WindowsForms.MarkerTooltipMode.Always;

                    //Формируем подсказку для маркера.
                    string[] wordsR = textBox2.Text.Split(',');
                    string dataMarkerR = string.Empty;
                    foreach (string word in wordsR)
                    {
                        dataMarkerR += word + ";\n";
                    }

                    //Текст подсказки маркера.               
                    markerR.ToolTipText = dataMarkerR;

                    //Добавляем маркеры в список маркеров.
                    markersOverlay.Markers.Add(markerG);
                    markersOverlay.Markers.Add(markerR);

                    //Очищаем список маркеров компонента.
                    gMapControl1.Overlays.Clear();

                    //Создаем список контрольных точек для прокладки маршрута.
                    List<GMap.NET.PointLatLng> list = new List<GMap.NET.PointLatLng>();

                    //Проходимся по определенным столбцам для получения
                    //координат контрольных точек маршрута и занесением их
                    //в список координат.
                    for (int i = 0; i < dtRouter.Rows.Count; i++)
                    {
                        double dbStartLat = double.Parse(dtRouter.Rows[i].ItemArray[1].ToString(), System.Globalization.CultureInfo.InvariantCulture);
                        double dbStartLng = double.Parse(dtRouter.Rows[i].ItemArray[2].ToString(), System.Globalization.CultureInfo.InvariantCulture);

                        list.Add(new GMap.NET.PointLatLng(dbStartLat, dbStartLng));

                        double dbEndLat = double.Parse(dtRouter.Rows[i].ItemArray[3].ToString(), System.Globalization.CultureInfo.InvariantCulture);
                        double dbEndLng = double.Parse(dtRouter.Rows[i].ItemArray[4].ToString(), System.Globalization.CultureInfo.InvariantCulture);

                        list.Add(new GMap.NET.PointLatLng(dbEndLat, dbEndLng));
                    }

                    //Очищаем все маршруты.
                    markersOverlay.Routes.Clear();

                    //Создаем маршрут на основе списка контрольных точек.
                    GMap.NET.WindowsForms.GMapRoute r = new GMap.NET.WindowsForms.GMapRoute(list, "Route");

                    //Указываем, что данный маршрут должен отображаться.
                    r.IsVisible = true;

                    //Устанавливаем цвет маршрута.
                    r.Stroke.Color = Color.DarkGreen;

                    //Добавляем маршрут.
                    markersOverlay.Routes.Add(r);

                    //Добавляем в компонент, список маркеров и маршрутов.
                    gMapControl1.Overlays.Add(markersOverlay);

                    //Указываем, что при загрузке карты будет использоваться 
                    //9ти кратное приближение.
                    gMapControl1.Zoom = 9;

                    //Обновляем карту.
                    gMapControl1.Refresh();
                }
            }
        }
        //Удаляем HTML теги.
        public string HtmlToPlainText(string html)
        {
            html = html.Replace("</b>", "");
            return html.Replace("<b>", "");
        }

    }
    //класс для получения номера клиента
    class nomerklientClass
    {
        public static string nomer { get; set; }
    }
}
