namespace BrowserCrawlTest
{
	partial class Form
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
			this.webBrowser = new System.Windows.Forms.WebBrowser();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.kanjiText = new System.Windows.Forms.Label();
			this.ganaText = new System.Windows.Forms.Label();
			this.statusLabel = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.btnLoadExcel = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.Korean = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Kanji = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Gana = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.startTranslate = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// webBrowser
			// 
			this.webBrowser.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.webBrowser.Location = new System.Drawing.Point(0, 382);
			this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
			this.webBrowser.Name = "webBrowser";
			this.webBrowser.Size = new System.Drawing.Size(800, 68);
			this.webBrowser.TabIndex = 1;
			this.webBrowser.Url = new System.Uri("about:blank", System.UriKind.Absolute);
			this.webBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser2_DocumentCompleted);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(43, 288);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(100, 20);
			this.textBox1.TabIndex = 1;
			this.textBox1.Text = "커피";
			this.textBox1.Visible = false;
			// 
			// button1
			// 
			this.button1.AutoSize = true;
			this.button1.Location = new System.Drawing.Point(43, 314);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(92, 23);
			this.button1.TabIndex = 3;
			this.button1.Text = "Load WebPage";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Visible = false;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label1.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(14, 140);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(45, 22);
			this.label1.TabIndex = 4;
			this.label1.Text = "Kanji";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label2.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(14, 177);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(73, 22);
			this.label2.TabIndex = 5;
			this.label2.Text = "Hiragana";
			// 
			// kanjiText
			// 
			this.kanjiText.AutoSize = true;
			this.kanjiText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.kanjiText.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.kanjiText.Location = new System.Drawing.Point(97, 140);
			this.kanjiText.Name = "kanjiText";
			this.kanjiText.Size = new System.Drawing.Size(48, 22);
			this.kanjiText.TabIndex = 6;
			this.kanjiText.Text = "dfdfd";
			this.kanjiText.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// ganaText
			// 
			this.ganaText.AutoSize = true;
			this.ganaText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.ganaText.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ganaText.Location = new System.Drawing.Point(97, 177);
			this.ganaText.Name = "ganaText";
			this.ganaText.Size = new System.Drawing.Size(48, 22);
			this.ganaText.TabIndex = 7;
			this.ganaText.Text = "dfdfd";
			this.ganaText.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// statusLabel
			// 
			this.statusLabel.AutoSize = true;
			this.statusLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.statusLabel.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.statusLabel.Location = new System.Drawing.Point(12, 88);
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Size = new System.Drawing.Size(52, 22);
			this.statusLabel.TabIndex = 8;
			this.statusLabel.Text = "Status";
			this.statusLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(51, 341);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 9;
			this.button2.Text = "Try to get";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Visible = false;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// btnLoadExcel
			// 
			this.btnLoadExcel.AutoSize = true;
			this.btnLoadExcel.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnLoadExcel.Location = new System.Drawing.Point(12, 12);
			this.btnLoadExcel.Name = "btnLoadExcel";
			this.btnLoadExcel.Size = new System.Drawing.Size(116, 27);
			this.btnLoadExcel.TabIndex = 10;
			this.btnLoadExcel.Text = "Load Worksheet";
			this.btnLoadExcel.UseVisualStyleBackColor = true;
			this.btnLoadExcel.Click += new System.EventHandler(this.btnLoadExcel_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.Filter = "excel File|*.xlsx";
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Korean,
            this.Kanji,
            this.Gana});
			this.dataGridView1.Location = new System.Drawing.Point(281, 12);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(507, 364);
			this.dataGridView1.TabIndex = 11;
			// 
			// Korean
			// 
			this.Korean.DataPropertyName = "Korean";
			this.Korean.HeaderText = "Korean";
			this.Korean.Name = "Korean";
			this.Korean.ReadOnly = true;
			this.Korean.Width = 66;
			// 
			// Kanji
			// 
			this.Kanji.DataPropertyName = "Kanji";
			this.Kanji.HeaderText = "Kanji";
			this.Kanji.Name = "Kanji";
			this.Kanji.Width = 55;
			// 
			// Gana
			// 
			this.Gana.DataPropertyName = "Gana";
			this.Gana.HeaderText = "Gana";
			this.Gana.Name = "Gana";
			this.Gana.Width = 58;
			// 
			// startTranslate
			// 
			this.startTranslate.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.startTranslate.Location = new System.Drawing.Point(12, 45);
			this.startTranslate.Name = "startTranslate";
			this.startTranslate.Size = new System.Drawing.Size(75, 23);
			this.startTranslate.TabIndex = 12;
			this.startTranslate.Text = "Start";
			this.startTranslate.UseVisualStyleBackColor = true;
			this.startTranslate.Click += new System.EventHandler(this.startTranslate_Click);
			// 
			// btnSave
			// 
			this.btnSave.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSave.Location = new System.Drawing.Point(97, 45);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 13;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// Form
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.startTranslate);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.btnLoadExcel);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.statusLabel);
			this.Controls.Add(this.ganaText);
			this.Controls.Add(this.kanjiText);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.webBrowser);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "Form";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "LQ Korean to Japanese Word Finder";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_FormClosing);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.WebBrowser webBrowser;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label kanjiText;
		private System.Windows.Forms.Label ganaText;
		private System.Windows.Forms.Label statusLabel;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button btnLoadExcel;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Button startTranslate;
		private System.Windows.Forms.DataGridViewTextBoxColumn Korean;
		private System.Windows.Forms.DataGridViewTextBoxColumn Kanji;
		private System.Windows.Forms.DataGridViewTextBoxColumn Gana;
		private System.Windows.Forms.Button btnSave;
	}
}

