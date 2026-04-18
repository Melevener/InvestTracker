namespace InvestTracker
{
    partial class StartForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartForm));
            this.btnBond = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCoupon = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonBondStorage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBond
            // 
            this.btnBond.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnBond.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnBond.ForeColor = System.Drawing.Color.White;
            this.btnBond.Location = new System.Drawing.Point(15, 140);
            this.btnBond.Name = "btnBond";
            this.btnBond.Size = new System.Drawing.Size(250, 50);
            this.btnBond.TabIndex = 0;
            this.btnBond.Text = "Покупка облигаций";
            this.btnBond.UseVisualStyleBackColor = false;
            this.btnBond.Click += new System.EventHandler(this.btnBond_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(287, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(450, 55);
            this.label1.TabIndex = 1;
            this.label1.Text = "Учёт по инвестиционным операциям с облигациями\r\n\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCoupon
            // 
            this.btnCoupon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCoupon.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCoupon.ForeColor = System.Drawing.Color.White;
            this.btnCoupon.Location = new System.Drawing.Point(15, 200);
            this.btnCoupon.Name = "btnCoupon";
            this.btnCoupon.Size = new System.Drawing.Size(250, 50);
            this.btnCoupon.TabIndex = 2;
            this.btnCoupon.Text = "Выплата купонов";
            this.btnCoupon.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(15, 260);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(250, 50);
            this.button1.TabIndex = 3;
            this.button1.Text = "Погашение облигаций";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // buttonBondStorage
            // 
            this.buttonBondStorage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonBondStorage.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonBondStorage.ForeColor = System.Drawing.Color.White;
            this.buttonBondStorage.Location = new System.Drawing.Point(15, 80);
            this.buttonBondStorage.Name = "buttonBondStorage";
            this.buttonBondStorage.Size = new System.Drawing.Size(250, 50);
            this.buttonBondStorage.TabIndex = 4;
            this.buttonBondStorage.Text = "Список облигаций";
            this.buttonBondStorage.UseVisualStyleBackColor = false;
            this.buttonBondStorage.Click += new System.EventHandler(this.buttonBondStorage_Click);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1006, 721);
            this.Controls.Add(this.buttonBondStorage);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCoupon);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBond);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StartForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Главное меню";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBond;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCoupon;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonBondStorage;
    }
}

