namespace FileNameParser
{
    partial class Form1
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
            this.SelectFileButton = new System.Windows.Forms.Button();
            this.ListClearButton = new System.Windows.Forms.Button();
            this.FileList = new System.Windows.Forms.ListBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ListCopybutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SelectFileButton
            // 
            this.SelectFileButton.Location = new System.Drawing.Point(12, 12);
            this.SelectFileButton.Name = "SelectFileButton";
            this.SelectFileButton.Size = new System.Drawing.Size(75, 23);
            this.SelectFileButton.TabIndex = 0;
            this.SelectFileButton.Text = "파일선택";
            this.SelectFileButton.UseVisualStyleBackColor = true;
            this.SelectFileButton.Click += new System.EventHandler(this.SelectFileButton_Click);
            // 
            // ListClearButton
            // 
            this.ListClearButton.Location = new System.Drawing.Point(12, 41);
            this.ListClearButton.Name = "ListClearButton";
            this.ListClearButton.Size = new System.Drawing.Size(75, 23);
            this.ListClearButton.TabIndex = 1;
            this.ListClearButton.Text = "클리어";
            this.ListClearButton.UseVisualStyleBackColor = true;
            this.ListClearButton.Click += new System.EventHandler(this.ListClearButton_Click);
            // 
            // FileList
            // 
            this.FileList.FormattingEnabled = true;
            this.FileList.ItemHeight = 12;
            this.FileList.Location = new System.Drawing.Point(93, 12);
            this.FileList.Name = "FileList";
            this.FileList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.FileList.Size = new System.Drawing.Size(307, 400);
            this.FileList.TabIndex = 2;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.Multiselect = true;
            // 
            // ListCopybutton
            // 
            this.ListCopybutton.Location = new System.Drawing.Point(12, 381);
            this.ListCopybutton.Name = "ListCopybutton";
            this.ListCopybutton.Size = new System.Drawing.Size(75, 23);
            this.ListCopybutton.TabIndex = 3;
            this.ListCopybutton.Text = "복사";
            this.ListCopybutton.UseVisualStyleBackColor = true;
            this.ListCopybutton.Click += new System.EventHandler(this.ListCopybutton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 421);
            this.Controls.Add(this.ListCopybutton);
            this.Controls.Add(this.FileList);
            this.Controls.Add(this.ListClearButton);
            this.Controls.Add(this.SelectFileButton);
            this.Name = "Form1";
            this.Text = "파일이름";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SelectFileButton;
        private System.Windows.Forms.Button ListClearButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        public System.Windows.Forms.ListBox FileList;
        private System.Windows.Forms.Button ListCopybutton;
    }
}

