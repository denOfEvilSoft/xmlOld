
namespace Progress_SKYRIM_Quest
{
    partial class GAME
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.프로필 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.내용 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.g_1 = new System.Windows.Forms.GroupBox();
            this.g_1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.프로필,
            this.내용});
            this.listView1.Enabled = false;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(6, 20);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Scrollable = false;
            this.listView1.Size = new System.Drawing.Size(169, 84);
            this.listView1.TabIndex = 0;
            this.listView1.TabStop = false;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // 프로필
            // 
            this.프로필.Text = "프로필";
            this.프로필.Width = 64;
            // 
            // 내용
            // 
            this.내용.Text = "내용";
            this.내용.Width = 122;
            // 
            // g_1
            // 
            this.g_1.Controls.Add(this.listView1);
            this.g_1.Location = new System.Drawing.Point(12, 12);
            this.g_1.Name = "g_1";
            this.g_1.Size = new System.Drawing.Size(184, 113);
            this.g_1.TabIndex = 1;
            this.g_1.TabStop = false;
            this.g_1.Text = "캐릭터 시트";
            // 
            // GAME
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.g_1);
            this.Name = "GAME";
            this.Text = "GAME";
            this.Load += new System.EventHandler(this.GAME_Load);
            this.g_1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader 프로필;
        private System.Windows.Forms.ColumnHeader 내용;
        private System.Windows.Forms.GroupBox g_1;
    }
}