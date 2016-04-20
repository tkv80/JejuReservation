namespace JejuReservation.Frm
{
    partial class SeoqwipoForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnReservation = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numCount = new System.Windows.Forms.NumericUpDown();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbSite = new System.Windows.Forms.ComboBox();
            this.gbSetting = new System.Windows.Forms.GroupBox();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.chbMainSite = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chbAll = new System.Windows.Forms.CheckBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbSuccessMessage = new System.Windows.Forms.Label();
            this.udDelay = new System.Windows.Forms.NumericUpDown();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCount)).BeginInit();
            this.gbSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udDelay)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReservation
            // 
            this.btnReservation.Location = new System.Drawing.Point(200, 288);
            this.btnReservation.Name = "btnReservation";
            this.btnReservation.Size = new System.Drawing.Size(75, 23);
            this.btnReservation.TabIndex = 0;
            this.btnReservation.Text = "예약걸기";
            this.btnReservation.UseVisualStyleBackColor = true;
            this.btnReservation.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(82, 20);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(173, 21);
            this.txtName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "이름 ㅣ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numCount);
            this.groupBox1.Controls.Add(this.txtTel);
            this.groupBox1.Controls.Add(this.txtAddress);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Location = new System.Drawing.Point(10, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(265, 125);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "사용자정보";
            // 
            // numCount
            // 
            this.numCount.Location = new System.Drawing.Point(82, 99);
            this.numCount.Name = "numCount";
            this.numCount.Size = new System.Drawing.Size(63, 21);
            this.numCount.TabIndex = 8;
            this.numCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numCount.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(82, 71);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(173, 21);
            this.txtTel.TabIndex = 7;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(82, 44);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(173, 21);
            this.txtAddress.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "인원 ㅣ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "연락처 ㅣ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "주소 ㅣ";
            // 
            // cbSite
            // 
            this.cbSite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSite.FormattingEnabled = true;
            this.cbSite.Location = new System.Drawing.Point(53, 75);
            this.cbSite.Name = "cbSite";
            this.cbSite.Size = new System.Drawing.Size(200, 20);
            this.cbSite.TabIndex = 4;
            // 
            // gbSetting
            // 
            this.gbSetting.Controls.Add(this.txtFilter);
            this.gbSetting.Controls.Add(this.cbSite);
            this.gbSetting.Controls.Add(this.chbMainSite);
            this.gbSetting.Controls.Add(this.label6);
            this.gbSetting.Controls.Add(this.chbAll);
            this.gbSetting.Controls.Add(this.dateTimePicker1);
            this.gbSetting.Controls.Add(this.dateTimePicker2);
            this.gbSetting.Controls.Add(this.label7);
            this.gbSetting.Controls.Add(this.label8);
            this.gbSetting.Location = new System.Drawing.Point(12, 143);
            this.gbSetting.Name = "gbSetting";
            this.gbSetting.Size = new System.Drawing.Size(263, 129);
            this.gbSetting.TabIndex = 35;
            this.gbSetting.TabStop = false;
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(152, 101);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(101, 21);
            this.txtFilter.TabIndex = 38;
            // 
            // chbMainSite
            // 
            this.chbMainSite.AutoSize = true;
            this.chbMainSite.Location = new System.Drawing.Point(98, 101);
            this.chbMainSite.Name = "chbMainSite";
            this.chbMainSite.Size = new System.Drawing.Size(48, 16);
            this.chbMainSite.TabIndex = 34;
            this.chbMainSite.Text = "명당";
            this.chbMainSite.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 27;
            this.label6.Text = "시작일";
            // 
            // chbAll
            // 
            this.chbAll.AutoSize = true;
            this.chbAll.Location = new System.Drawing.Point(8, 101);
            this.chbAll.Name = "chbAll";
            this.chbAll.Size = new System.Drawing.Size(84, 16);
            this.chbAll.TabIndex = 33;
            this.chbAll.Text = "모든사이트";
            this.chbAll.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(53, 21);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 21);
            this.dateTimePicker1.TabIndex = 24;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(53, 48);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(201, 21);
            this.dateTimePicker2.TabIndex = 25;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 28;
            this.label7.Text = "종료일";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 29;
            this.label8.Text = "사이트";
            // 
            // lbSuccessMessage
            // 
            this.lbSuccessMessage.AutoSize = true;
            this.lbSuccessMessage.Location = new System.Drawing.Point(12, 463);
            this.lbSuccessMessage.Name = "lbSuccessMessage";
            this.lbSuccessMessage.Size = new System.Drawing.Size(75, 12);
            this.lbSuccessMessage.TabIndex = 42;
            this.lbSuccessMessage.Text = "No Success";
            // 
            // udDelay
            // 
            this.udDelay.Location = new System.Drawing.Point(58, 286);
            this.udDelay.Name = "udDelay";
            this.udDelay.Size = new System.Drawing.Size(37, 21);
            this.udDelay.TabIndex = 41;
            this.udDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.udDelay.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // txtLog
            // 
            this.txtLog.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtLog.Location = new System.Drawing.Point(10, 313);
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(265, 147);
            this.txtLog.TabIndex = 40;
            this.txtLog.Text = "";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 288);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 12);
            this.label9.TabIndex = 39;
            this.label9.Text = "delay";
            // 
            // SeoqwipoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 484);
            this.Controls.Add(this.lbSuccessMessage);
            this.Controls.Add(this.gbSetting);
            this.Controls.Add(this.udDelay);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnReservation);
            this.Name = "SeoqwipoForm";
            this.Text = "서귀포 자연휴양림";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCount)).EndInit();
            this.gbSetting.ResumeLayout(false);
            this.gbSetting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udDelay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReservation;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numCount;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.ComboBox cbSite;
        private System.Windows.Forms.GroupBox gbSetting;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.CheckBox chbMainSite;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chbAll;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbSuccessMessage;
        private System.Windows.Forms.NumericUpDown udDelay;
        private System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.Label label9;
    }
}

