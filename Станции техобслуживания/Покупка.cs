using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Станции_техобслуживания
{
    public partial class Покупка : Form
    {
        public Покупка()
        {
            InitializeComponent();
        }
        //отправка смс на почту сервису
        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == String.Empty) || (textBox2.Text == String.Empty) || (textBox3.Text == String.Empty) || (textBox4.Text == String.Empty))
            {
                MessageBox.Show("Для отправки сообщения нужно заполнить все поля!");
            }
            else
            {
                MailMessage mail = new MailMessage("cvb@yandex.ru", textBox2.Text, "Вопрос от клиента", "Клиент: " + textBox1.Text + Environment.NewLine + Environment.NewLine + "Номер телефона: " + textBox3.Text + Environment.NewLine + Environment.NewLine + "Почта клиента: " + textBox2.Text + Environment.NewLine + textBox4.Text);
                SmtpClient client = new SmtpClient("smtp.yandex.ru");
                client.Port = 587;
                client.Credentials = new System.Net.NetworkCredential("cvb@yandex.ru", "sdf435435");
                client.EnableSsl = true;
                client.Send(mail);

                MessageBox.Show("Сообщение отправлено. Наш консультант вам ответит в ближайшее время.", "Success", MessageBoxButtons.OK);
            }
        }
    }
}
