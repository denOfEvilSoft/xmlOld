
namespace xmlOld
{
    partial class l_nameList
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
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.b_selectFile = new System.Windows.Forms.Button();
            this.l_fileLocation = new System.Windows.Forms.Label();
            this.l_fileName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.l_countNum = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.propertyGrid2 = new System.Windows.Forms.PropertyGrid();
            this.b_parse = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.b_db = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // b_selectFile
            // 
            this.b_selectFile.Location = new System.Drawing.Point(6, 20);
            this.b_selectFile.Name = "b_selectFile";
            this.b_selectFile.Size = new System.Drawing.Size(75, 23);
            this.b_selectFile.TabIndex = 0;
            this.b_selectFile.Text = "파일 선택";
            this.b_selectFile.UseVisualStyleBackColor = true;
            this.b_selectFile.Click += new System.EventHandler(this.b_selectFile_Click);
            // 
            // l_fileLocation
            // 
            this.l_fileLocation.AutoSize = true;
            this.l_fileLocation.Location = new System.Drawing.Point(77, 67);
            this.l_fileLocation.Name = "l_fileLocation";
            this.l_fileLocation.Size = new System.Drawing.Size(0, 12);
            this.l_fileLocation.TabIndex = 1;
            // 
            // l_fileName
            // 
            this.l_fileName.AutoSize = true;
            this.l_fileName.Location = new System.Drawing.Point(77, 46);
            this.l_fileName.Name = "l_fileName";
            this.l_fileName.Size = new System.Drawing.Size(0, 12);
            this.l_fileName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "파일 이름 :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "파일 경로 :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.l_countNum);
            this.groupBox1.Controls.Add(this.b_selectFile);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.l_fileLocation);
            this.groupBox1.Controls.Add(this.l_fileName);
            this.groupBox1.Location = new System.Drawing.Point(6, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(302, 86);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "파일";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // l_countNum
            // 
            this.l_countNum.AutoSize = true;
            this.l_countNum.Location = new System.Drawing.Point(150, 25);
            this.l_countNum.Name = "l_countNum";
            this.l_countNum.Size = new System.Drawing.Size(0, 12);
            this.l_countNum.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(87, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 12);
            this.label6.TabIndex = 15;
            this.label6.Text = "파싱 수 : ";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(6, 113);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(302, 328);
            this.listBox1.TabIndex = 6;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // propertyGrid2
            // 
            this.propertyGrid2.Location = new System.Drawing.Point(314, 66);
            this.propertyGrid2.Name = "propertyGrid2";
            this.propertyGrid2.Size = new System.Drawing.Size(343, 375);
            this.propertyGrid2.TabIndex = 8;
            // 
            // b_parse
            // 
            this.b_parse.Location = new System.Drawing.Point(395, 20);
            this.b_parse.Name = "b_parse";
            this.b_parse.Size = new System.Drawing.Size(75, 23);
            this.b_parse.TabIndex = 9;
            this.b_parse.Text = "파싱";
            this.b_parse.UseVisualStyleBackColor = true;
            this.b_parse.Click += new System.EventHandler(this.b_parse_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DimGray;
            this.pictureBox1.Location = new System.Drawing.Point(-11, -8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1297, 37);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.DimGray;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(10, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "노인 xml 통합 파싱, DB 업로드";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.DimGray;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(664, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "X";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.DimGray;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(647, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "_";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // b_db
            // 
            this.b_db.Location = new System.Drawing.Point(477, 20);
            this.b_db.Name = "b_db";
            this.b_db.Size = new System.Drawing.Size(75, 23);
            this.b_db.TabIndex = 14;
            this.b_db.Text = "DB 업로드";
            this.b_db.UseVisualStyleBackColor = true;
            this.b_db.Click += new System.EventHandler(this.b_db_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.listBox1);
            this.groupBox2.Controls.Add(this.propertyGrid2);
            this.groupBox2.Controls.Add(this.b_parse);
            this.groupBox2.Controls.Add(this.b_db);
            this.groupBox2.Location = new System.Drawing.Point(12, 39);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(665, 448);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "업데이트";
            // 
            // l_nameList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 491);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "l_nameList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button b_selectFile;
        private System.Windows.Forms.Label l_fileLocation;
        private System.Windows.Forms.Label l_fileName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PropertyGrid propertyGrid2;
        private System.Windows.Forms.Button b_parse;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button b_db;
        public System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label l_countNum;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

