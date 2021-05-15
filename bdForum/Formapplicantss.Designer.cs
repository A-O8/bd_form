namespace bdForum
{
    partial class Formapplicantss
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.buttonWrite = new System.Windows.Forms.Button();
            this.buttonLike = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonListLikes = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(-1, 0);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(701, 449);
            this.dataGridView.TabIndex = 0;
            // 
            // buttonWrite
            // 
            this.buttonWrite.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonWrite.Location = new System.Drawing.Point(707, 30);
            this.buttonWrite.Name = "buttonWrite";
            this.buttonWrite.Size = new System.Drawing.Size(75, 43);
            this.buttonWrite.TabIndex = 1;
            this.buttonWrite.Text = "Написать сообщение";
            this.buttonWrite.UseVisualStyleBackColor = false;
            this.buttonWrite.Click += new System.EventHandler(this.buttonWrite_Click);
            // 
            // buttonLike
            // 
            this.buttonLike.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonLike.Location = new System.Drawing.Point(707, 103);
            this.buttonLike.Name = "buttonLike";
            this.buttonLike.Size = new System.Drawing.Size(75, 41);
            this.buttonLike.TabIndex = 2;
            this.buttonLike.Text = "Поставить лайк";
            this.buttonLike.UseVisualStyleBackColor = false;
            this.buttonLike.Click += new System.EventHandler(this.buttonLike_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonDelete.Location = new System.Drawing.Point(707, 178);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 3;
            this.buttonDelete.Text = "Удалить";
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonListLikes
            // 
            this.buttonListLikes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonListLikes.Location = new System.Drawing.Point(707, 224);
            this.buttonListLikes.Name = "buttonListLikes";
            this.buttonListLikes.Size = new System.Drawing.Size(81, 46);
            this.buttonListLikes.TabIndex = 4;
            this.buttonListLikes.Text = "Посмотреть лайки";
            this.buttonListLikes.UseVisualStyleBackColor = false;
            this.buttonListLikes.Click += new System.EventHandler(this.buttonListLikes_Click);
            // 
            // Formapplicantss
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonListLikes);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonLike);
            this.Controls.Add(this.buttonWrite);
            this.Controls.Add(this.dataGridView);
            this.Name = "Formapplicantss";
            this.Text = "Formapplicants";
            this.Load += new System.EventHandler(this.FormMessages_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonWrite;
        private System.Windows.Forms.Button buttonLike;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonListLikes;
    }
}