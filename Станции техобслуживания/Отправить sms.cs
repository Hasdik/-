using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Станции_техобслуживания
{
    public partial class Отправить_sms : Form
    {
        public Отправить_sms()
        {
            InitializeComponent();
        }
        //отправка смс к клиенту
        private void button1_Click(object sender, EventArgs e)
        {
            SMSC smsc = new SMSC(); // Создает экземпляр класса для работы с сервисом
            string[] r = smsc.send_sms(nomerklient.Text, textinfo.Text, 0, "", 0, 0, otpravitel.Text); // Отправляет SMS на номер
            string Result = "";
            if (r.Length > 2) // Если ошибки нет
            {
                Result += "id = " + r[0] + Environment.NewLine
                         + "количество sms = " + r[1] + Environment.NewLine
                         + "стоимость = " + r[2] + Environment.NewLine;
                label5.Text = r[3] + " рублей";
            }
            else // Если ошибка есть
            {
                Result += "id = " + r[0] + Environment.NewLine
                         + "код ошибки = " + r[1] + Environment.NewLine;
            }

            // Выводит результат
            MessageBox.Show("СМС отправлен!"+Environment.NewLine+Result);

        }

        private void Отправить_sms_Load(object sender, EventArgs e)
        {
            nomerklient.Text = nomerklientClass.nomer;
        }
        //выводим на экран ссылку для регистрации
        private void linkLabel1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("www.smsc.ru/reg/");

        }

    }
}
