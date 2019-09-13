namespace DataView
{
    partial class Views
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.typeListView1 = new DataView.TypeListView();
            this.logListView1 = new DataView.LogListView();
            this.bankListView1 = new DataView.BankListView();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(3, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(556, 350);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.typeListView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(548, 339);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Виды валют";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.bankListView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(548, 321);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Банки";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.logListView1);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(548, 339);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Журнал курсов";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // typeListView1
            // 
            this.typeListView1.AllowCurrentRemove = false;
            this.typeListView1.Location = new System.Drawing.Point(6, 6);
            this.typeListView1.Name = "typeListView1";
            this.typeListView1.Size = new System.Drawing.Size(500, 300);
            this.typeListView1.TabIndex = 0;
            // 
            // logListView1
            // 
            this.logListView1.AllowAddLog = true;
            this.logListView1.Location = new System.Drawing.Point(6, 6);
            this.logListView1.Name = "logListView1";
            this.logListView1.Size = new System.Drawing.Size(522, 311);
            this.logListView1.TabIndex = 0;
            // 
            // bankListView1
            // 
            this.bankListView1.AllowCurrentRemove = false;
            this.bankListView1.Location = new System.Drawing.Point(6, 6);
            this.bankListView1.Name = "bankListView1";
            this.bankListView1.Size = new System.Drawing.Size(500, 292);
            this.bankListView1.TabIndex = 0;
            // 
            // Views
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "Views";
            this.Size = new System.Drawing.Size(579, 379);
            this.Load += new System.EventHandler(this.Views_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private TypeListView typeListView1;
        private LogListView logListView1;
        private BankListView bankListView1;
    }
}
