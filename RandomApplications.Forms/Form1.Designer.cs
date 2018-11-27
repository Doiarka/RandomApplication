namespace RandomApplications.Forms
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.CreateButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.openListBox = new System.Windows.Forms.ListBox();
            this.confirmButton = new System.Windows.Forms.Button();
            this.returnButton = new System.Windows.Forms.Button();
            this.readyListBox = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.closeListBox = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.filterComboBox = new System.Windows.Forms.ComboBox();
            this.appsListBox = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.deleteAppButton = new System.Windows.Forms.Button();
            this.historyListBox = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Создание заявки";
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new System.Drawing.Point(11, 45);
            this.titleTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(112, 20);
            this.titleTextBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 28);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Название";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 65);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Описание";
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(11, 81);
            this.descriptionTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(112, 184);
            this.descriptionTextBox.TabIndex = 5;
            // 
            // CreateButton
            // 
            this.CreateButton.Location = new System.Drawing.Point(11, 269);
            this.CreateButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(111, 19);
            this.CreateButton.TabIndex = 6;
            this.CreateButton.Text = "Создать";
            this.CreateButton.UseVisualStyleBackColor = true;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(124, 7);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Открытые заявки";
            // 
            // openListBox
            // 
            this.openListBox.FormattingEnabled = true;
            this.openListBox.Location = new System.Drawing.Point(127, 27);
            this.openListBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.openListBox.Name = "openListBox";
            this.openListBox.ScrollAlwaysVisible = true;
            this.openListBox.Size = new System.Drawing.Size(157, 238);
            this.openListBox.TabIndex = 8;
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(127, 269);
            this.confirmButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(156, 19);
            this.confirmButton.TabIndex = 9;
            this.confirmButton.Text = "Подтвердить";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // returnButton
            // 
            this.returnButton.Location = new System.Drawing.Point(287, 306);
            this.returnButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.returnButton.Name = "returnButton";
            this.returnButton.Size = new System.Drawing.Size(156, 19);
            this.returnButton.TabIndex = 12;
            this.returnButton.Text = "Вернуть";
            this.returnButton.UseVisualStyleBackColor = true;
            this.returnButton.Click += new System.EventHandler(this.returnButton_Click);
            // 
            // readyListBox
            // 
            this.readyListBox.FormattingEnabled = true;
            this.readyListBox.Location = new System.Drawing.Point(287, 27);
            this.readyListBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.readyListBox.Name = "readyListBox";
            this.readyListBox.ScrollAlwaysVisible = true;
            this.readyListBox.Size = new System.Drawing.Size(157, 238);
            this.readyListBox.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(285, 7);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Решенные заявки";
            // 
            // closeListBox
            // 
            this.closeListBox.FormattingEnabled = true;
            this.closeListBox.Location = new System.Drawing.Point(448, 27);
            this.closeListBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.closeListBox.Name = "closeListBox";
            this.closeListBox.ScrollAlwaysVisible = true;
            this.closeListBox.Size = new System.Drawing.Size(157, 238);
            this.closeListBox.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(446, 7);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Закрытые заявки";
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(287, 269);
            this.closeButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(156, 19);
            this.closeButton.TabIndex = 16;
            this.closeButton.Text = "Закрыть";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // filterComboBox
            // 
            this.filterComboBox.FormattingEnabled = true;
            this.filterComboBox.Items.AddRange(new object[] {
            "Открыта",
            "Решена",
            "Возврат",
            "Закрыта"});
            this.filterComboBox.Location = new System.Drawing.Point(609, 27);
            this.filterComboBox.Name = "filterComboBox";
            this.filterComboBox.Size = new System.Drawing.Size(155, 21);
            this.filterComboBox.TabIndex = 17;
            this.filterComboBox.SelectedIndexChanged += new System.EventHandler(this.filterComboBox_SelectedIndexChanged);
            // 
            // appsListBox
            // 
            this.appsListBox.FormattingEnabled = true;
            this.appsListBox.Location = new System.Drawing.Point(609, 53);
            this.appsListBox.Margin = new System.Windows.Forms.Padding(2);
            this.appsListBox.Name = "appsListBox";
            this.appsListBox.ScrollAlwaysVisible = true;
            this.appsListBox.Size = new System.Drawing.Size(157, 238);
            this.appsListBox.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(607, 7);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Все заявки";
            // 
            // deleteAppButton
            // 
            this.deleteAppButton.Location = new System.Drawing.Point(447, 269);
            this.deleteAppButton.Margin = new System.Windows.Forms.Padding(2);
            this.deleteAppButton.Name = "deleteAppButton";
            this.deleteAppButton.Size = new System.Drawing.Size(156, 19);
            this.deleteAppButton.TabIndex = 20;
            this.deleteAppButton.Text = "Удалить";
            this.deleteAppButton.UseVisualStyleBackColor = true;
            this.deleteAppButton.Click += new System.EventHandler(this.deleteAppButton_Click);
            // 
            // historyListBox
            // 
            this.historyListBox.FormattingEnabled = true;
            this.historyListBox.Location = new System.Drawing.Point(770, 28);
            this.historyListBox.Margin = new System.Windows.Forms.Padding(2);
            this.historyListBox.Name = "historyListBox";
            this.historyListBox.ScrollAlwaysVisible = true;
            this.historyListBox.Size = new System.Drawing.Size(379, 329);
            this.historyListBox.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(767, 13);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "История статусов";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 366);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.historyListBox);
            this.Controls.Add(this.deleteAppButton);
            this.Controls.Add(this.appsListBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.filterComboBox);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.closeListBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.returnButton);
            this.Controls.Add(this.readyListBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.openListBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CreateButton);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Произвольные заявки";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox openListBox;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Button returnButton;
        private System.Windows.Forms.ListBox readyListBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox closeListBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.ComboBox filterComboBox;
        private System.Windows.Forms.ListBox appsListBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button deleteAppButton;
        private System.Windows.Forms.ListBox historyListBox;
        private System.Windows.Forms.Label label8;
    }
}

