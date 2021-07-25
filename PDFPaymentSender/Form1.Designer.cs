
namespace PDFPaymentSender
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.choosefilebtn = new System.Windows.Forms.Button();
            this.FilePathBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.FilePagesNumberBox = new System.Windows.Forms.TextBox();
            this.SendButton = new System.Windows.Forms.Button();
            this.UsersManagementList = new System.Windows.Forms.ListView();
            this.RowNumberCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FullNameCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MailAddressCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IDCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StatusCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Filllistbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Script", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(523, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "שליחת תלושים";
            // 
            // choosefilebtn
            // 
            this.choosefilebtn.Location = new System.Drawing.Point(1015, 186);
            this.choosefilebtn.Name = "choosefilebtn";
            this.choosefilebtn.Size = new System.Drawing.Size(75, 31);
            this.choosefilebtn.TabIndex = 1;
            this.choosefilebtn.Text = "בחר קובץ";
            this.choosefilebtn.UseVisualStyleBackColor = true;
            this.choosefilebtn.Click += new System.EventHandler(this.choosefilebtn_Click);
            // 
            // FilePathBox
            // 
            this.FilePathBox.Location = new System.Drawing.Point(741, 193);
            this.FilePathBox.Name = "FilePathBox";
            this.FilePathBox.Size = new System.Drawing.Size(250, 20);
            this.FilePathBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(1025, 271);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = ":כמות דפים";
            // 
            // FilePagesNumberBox
            // 
            this.FilePagesNumberBox.Location = new System.Drawing.Point(972, 268);
            this.FilePagesNumberBox.Name = "FilePagesNumberBox";
            this.FilePagesNumberBox.Size = new System.Drawing.Size(49, 20);
            this.FilePagesNumberBox.TabIndex = 4;
            // 
            // SendButton
            // 
            this.SendButton.Location = new System.Drawing.Point(541, 551);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(75, 23);
            this.SendButton.TabIndex = 6;
            this.SendButton.Text = "שלח";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // UsersManagementList
            // 
            this.UsersManagementList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.RowNumberCol,
            this.FullNameCol,
            this.MailAddressCol,
            this.IDCol,
            this.StatusCol});
            this.UsersManagementList.HideSelection = false;
            this.UsersManagementList.Location = new System.Drawing.Point(36, 59);
            this.UsersManagementList.Name = "UsersManagementList";
            this.UsersManagementList.Size = new System.Drawing.Size(566, 460);
            this.UsersManagementList.TabIndex = 7;
            this.UsersManagementList.UseCompatibleStateImageBehavior = false;
            this.UsersManagementList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.UsersManagementList_MouseClick);
            // 
            // RowNumberCol
            // 
            this.RowNumberCol.Text = "מיקום";
            this.RowNumberCol.Width = 80;
            // 
            // FullNameCol
            // 
            this.FullNameCol.Text = "שם מלא";
            this.FullNameCol.Width = 120;
            // 
            // MailAddressCol
            // 
            this.MailAddressCol.Text = "כתובת מייל";
            this.MailAddressCol.Width = 150;
            // 
            // IDCol
            // 
            this.IDCol.Text = "תעודת זהות";
            this.IDCol.Width = 100;
            // 
            // StatusCol
            // 
            this.StatusCol.Text = "סטאטוס";
            // 
            // Filllistbtn
            // 
            this.Filllistbtn.Location = new System.Drawing.Point(763, 361);
            this.Filllistbtn.Name = "Filllistbtn";
            this.Filllistbtn.Size = new System.Drawing.Size(139, 23);
            this.Filllistbtn.TabIndex = 15;
            this.Filllistbtn.Text = "מלא את הטבלה ";
            this.Filllistbtn.UseVisualStyleBackColor = true;
            this.Filllistbtn.Click += new System.EventHandler(this.Filllistbtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1238, 619);
            this.Controls.Add(this.Filllistbtn);
            this.Controls.Add(this.UsersManagementList);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.FilePagesNumberBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.FilePathBox);
            this.Controls.Add(this.choosefilebtn);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button choosefilebtn;
        private System.Windows.Forms.TextBox FilePathBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox FilePagesNumberBox;
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.ListView UsersManagementList;
        private System.Windows.Forms.ColumnHeader RowNumberCol;
        private System.Windows.Forms.ColumnHeader FullNameCol;
        private System.Windows.Forms.ColumnHeader MailAddressCol;
        private System.Windows.Forms.ColumnHeader IDCol;
        private System.Windows.Forms.ColumnHeader StatusCol;
        private System.Windows.Forms.Button Filllistbtn;
    }
}

