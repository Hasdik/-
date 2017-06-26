namespace Станции_техобслуживания
{
    partial class Заказ_деталей
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label id_деталиLabel;
            System.Windows.Forms.Label наименованиеLabel;
            System.Windows.Forms.Label кол_во_на_складеLabel;
            System.Windows.Forms.Label стоимость_1_деталиLabel;
            System.Windows.Forms.Label label2;
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.id_деталиTextBox = new System.Windows.Forms.TextBox();
            this.наименованиеTextBox = new System.Windows.Forms.TextBox();
            this.кол_во_на_складеTextBox = new System.Windows.Forms.TextBox();
            this.стоимость_1_деталиTextBox = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            id_деталиLabel = new System.Windows.Forms.Label();
            наименованиеLabel = new System.Windows.Forms.Label();
            кол_во_на_складеLabel = new System.Windows.Forms.Label();
            стоимость_1_деталиLabel = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // id_деталиLabel
            // 
            id_деталиLabel.AutoSize = true;
            id_деталиLabel.Location = new System.Drawing.Point(16, 25);
            id_деталиLabel.Name = "id_деталиLabel";
            id_деталиLabel.Size = new System.Drawing.Size(82, 13);
            id_деталиLabel.TabIndex = 24;
            id_деталиLabel.Text = "Номер детали:";
            // 
            // наименованиеLabel
            // 
            наименованиеLabel.AutoSize = true;
            наименованиеLabel.Location = new System.Drawing.Point(16, 51);
            наименованиеLabel.Name = "наименованиеLabel";
            наименованиеLabel.Size = new System.Drawing.Size(86, 13);
            наименованиеLabel.TabIndex = 26;
            наименованиеLabel.Text = "Наименование:";
            // 
            // кол_во_на_складеLabel
            // 
            кол_во_на_складеLabel.AutoSize = true;
            кол_во_на_складеLabel.Location = new System.Drawing.Point(16, 77);
            кол_во_на_складеLabel.Name = "кол_во_на_складеLabel";
            кол_во_на_складеLabel.Size = new System.Drawing.Size(69, 13);
            кол_во_на_складеLabel.TabIndex = 28;
            кол_во_на_складеLabel.Text = "Количество:";
            // 
            // стоимость_1_деталиLabel
            // 
            стоимость_1_деталиLabel.AutoSize = true;
            стоимость_1_деталиLabel.Location = new System.Drawing.Point(16, 103);
            стоимость_1_деталиLabel.Name = "стоимость_1_деталиLabel";
            стоимость_1_деталиLabel.Size = new System.Drawing.Size(112, 13);
            стоимость_1_деталиLabel.TabIndex = 30;
            стоимость_1_деталиLabel.Text = "Стоимость 1 детали:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(17, 127);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(68, 13);
            label2.TabIndex = 34;
            label2.Text = "Поставщик:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(13, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(762, 281);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Очередь заказов";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button2);
            this.groupBox4.Location = new System.Drawing.Point(212, 159);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(228, 57);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Удалить заказы которых не доставили";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(15, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(104, 32);
            this.button2.TabIndex = 1;
            this.button2.Text = "Удалить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comboBox3);
            this.groupBox3.Controls.Add(this.comboBox2);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Location = new System.Drawing.Point(7, 159);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(199, 118);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Изменить статус заказа если он был доставлен";
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "Ожидание",
            "Доставлен"});
            this.comboBox3.Location = new System.Drawing.Point(91, 57);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(102, 21);
            this.comboBox3.TabIndex = 38;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(91, 23);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(102, 21);
            this.comboBox2.TabIndex = 37;
            this.comboBox2.TextChanged += new System.EventHandler(this.comboBox2_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Статус:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Номер заказа:";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(66, 89);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "Изменить";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(7, 20);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(740, 133);
            this.dataGridView1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(label2);
            this.groupBox2.Controls.Add(id_деталиLabel);
            this.groupBox2.Controls.Add(this.id_деталиTextBox);
            this.groupBox2.Controls.Add(наименованиеLabel);
            this.groupBox2.Controls.Add(this.наименованиеTextBox);
            this.groupBox2.Controls.Add(кол_во_на_складеLabel);
            this.groupBox2.Controls.Add(this.кол_во_на_складеTextBox);
            this.groupBox2.Controls.Add(стоимость_1_деталиLabel);
            this.groupBox2.Controls.Add(this.стоимость_1_деталиTextBox);
            this.groupBox2.Location = new System.Drawing.Point(13, 289);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(281, 202);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Оформление заказа";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(30, 154);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(195, 36);
            this.button1.TabIndex = 36;
            this.button1.Text = "Добавить в заказ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(135, 127);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 35;
            // 
            // id_деталиTextBox
            // 
            this.id_деталиTextBox.Location = new System.Drawing.Point(134, 22);
            this.id_деталиTextBox.Name = "id_деталиTextBox";
            this.id_деталиTextBox.Size = new System.Drawing.Size(121, 20);
            this.id_деталиTextBox.TabIndex = 25;
            // 
            // наименованиеTextBox
            // 
            this.наименованиеTextBox.Location = new System.Drawing.Point(134, 48);
            this.наименованиеTextBox.Name = "наименованиеTextBox";
            this.наименованиеTextBox.Size = new System.Drawing.Size(121, 20);
            this.наименованиеTextBox.TabIndex = 27;
            // 
            // кол_во_на_складеTextBox
            // 
            this.кол_во_на_складеTextBox.Location = new System.Drawing.Point(134, 74);
            this.кол_во_на_складеTextBox.Name = "кол_во_на_складеTextBox";
            this.кол_во_на_складеTextBox.Size = new System.Drawing.Size(121, 20);
            this.кол_во_на_складеTextBox.TabIndex = 29;
            // 
            // стоимость_1_деталиTextBox
            // 
            this.стоимость_1_деталиTextBox.Location = new System.Drawing.Point(134, 100);
            this.стоимость_1_деталиTextBox.Name = "стоимость_1_деталиTextBox";
            this.стоимость_1_деталиTextBox.Size = new System.Drawing.Size(121, 20);
            this.стоимость_1_деталиTextBox.TabIndex = 31;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(398, 314);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(184, 29);
            this.button3.TabIndex = 2;
            this.button3.Text = "Заказать";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(398, 357);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(184, 30);
            this.button6.TabIndex = 3;
            this.button6.Text = "Отчёт";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(398, 400);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(184, 29);
            this.button7.TabIndex = 4;
            this.button7.Text = "Назад";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // Заказ_деталей
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 498);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Заказ_деталей";
            this.Text = "Заказ деталей";
            this.Load += new System.EventHandler(this.Заказ_деталей_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox id_деталиTextBox;
        private System.Windows.Forms.TextBox наименованиеTextBox;
        private System.Windows.Forms.TextBox кол_во_на_складеTextBox;
        private System.Windows.Forms.TextBox стоимость_1_деталиTextBox;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
    }
}