using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace BrowserCrawlTest
{
	public partial class Form : System.Windows.Forms.Form
	{
		Microsoft.Office.Interop.Excel.Application application = null;
		Workbook workBook = null;
		Worksheet workSheet = null;
		List<TranslateData> translateDataList = new List<TranslateData>();
		bool pageLoadComplete = false;
		bool found = false;
		string foundKanji;
		string foundGana;

		public Form()
		{
			InitializeComponent();

			application = new Microsoft.Office.Interop.Excel.Application();
		}

		private /*async */void webBrowser2_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
		{
			//Console.WriteLine($"webBrowser2_DocumentCompleted - AbsoluteUri:{e.Url.AbsoluteUri}, browser:{webBrowser.Url.AbsoluteUri}");
			if (e.Url.AbsoluteUri == webBrowser.Url.AbsoluteUri)
			{
				pageLoadComplete = true;
				statusLabel.Text = "Completed";
				kanjiText.Text = string.Empty;
				ganaText.Text = string.Empty;
				found = false;

				for (int i = 0; i < webBrowser.Document.All.Count; ++i)
				{
					HtmlElement elem = webBrowser.Document.All[i];
					FindRecursive(elem);
				}
			}

			//await CheckStatus();
		}

		async Task CheckStatus()
		{
			while (!pageLoadComplete)
			{
				//var elem = webBrowser.Document.GetElementById("u_skip");
				//if (elem != null)
				//{
				//	statusLabel.Text = "Really Completed";
				//	break;
				//}
				await Task.Delay(1);
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			LoadWebPage(textBox1.Text);
		}

		private void LoadWebPage(string searchWord)
		{
			string url = $"https://ja.dict.naver.com/search.nhn?range=word&q={searchWord}&version=1";
			statusLabel.Text = "Loading...";
			Console.WriteLine(statusLabel.Text);
			webBrowser.Navigate(new Uri(url));
			pageLoadComplete = false;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < webBrowser.Document.All.Count; ++i)
			{
				HtmlElement elem = webBrowser.Document.All[i];
				FindRecursive(elem);
			}
		}

		void FindRecursive(HtmlElement node, int step = 0)
		{
			if (found)
				return;

			if (node == null)
				return;

			//for (int i = 0; i < step; ++i)
			//	Console.Write("\t");
			//Console.WriteLine($"<{node.TagName}> - {elemcount++}");
			bool found1 = false, found2 = false;

			if (node.TagName.ToLower().Equals("span"))
			{
				if (node.GetAttribute("className") == "jp")
					found1 = true;
				if (node.GetAttribute("lang") == "ja")
					found2 = true;

				if (node.InnerHtml != null && node.InnerHtml.Contains("ruby"))
				{
					var rubys = node.GetElementsByTagName("ruby");
					if (rubys.Count > 0)
					{
						var splits = rubys[0].InnerText.Split('(', ')');
						kanjiText.Text = splits[0];
						ganaText.Text = splits[1];
						found = true;
						foundKanji = splits[0];
						foundGana = splits[1];
						return;
					}
				}
			}

			if (found1 && found2)
			{
				Console.WriteLine(node.InnerText);
				ganaText.Text = node.InnerText;
				found = true;
				foundGana = node.InnerText;
				return;
			}

			FindRecursive(node.FirstChild, step + 1);
			FindRecursive(node.NextSibling, step);
		}

		private void btnLoadExcel_Click(object sender, EventArgs e)
		{
			string fileName;
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				fileName = openFileDialog1.FileName;
			}
			else
				return;

			if (workBook != null)
			{
				workBook.Close();
				Marshal.ReleaseComObject(workBook);
				workBook = null;
			}

			try
			{
				workBook = application.Workbooks.Open(fileName);
				application.Visible = false;
				LoadWords();
				MessageBox.Show("Load Excel Completed", "", MessageBoxButtons.OK);
			}
			catch(Exception exception)
			{
				ReleaseExcelObjects();
				Console.WriteLine(exception.Message);
			}
		}

		private void Form_FormClosing(object sender, FormClosingEventArgs e)
		{
			ReleaseExcelObjects();
		}

		private void startTranslate_Click(object sender, EventArgs e)
		{
			StartBatch();
		}

		private async void StartBatch()
		{
			int index = 0;
			foreach (var td in translateDataList)
			{
				statusLabel.Text = $"Start working on the word {td.Korean}";
				Console.WriteLine(statusLabel.Text);
				if (index >= 10)
					break;
				if (!string.IsNullOrEmpty(td.Kanji) || !string.IsNullOrEmpty(td.Gana))
				{
					statusLabel.Text = $"Translation for {td.Korean} exists. skipping..";
					Console.WriteLine(statusLabel.Text);
					++index;
					continue;
				}
				LoadWebPage(td.Korean);

				await CheckStatus();
				statusLabel.Text = $"Dictionary page about {td.Korean} loading completed";
				Console.WriteLine(statusLabel.Text);

				found = false;
				foundKanji = string.Empty;
				foundGana = string.Empty;

				for (int i = 0; i < webBrowser.Document.All.Count; ++i)
				{
					HtmlElement elem = webBrowser.Document.All[i];
					FindRecursive(elem);
					if (found)
					{
						Console.WriteLine($"found elem count: {i}");
						break;
					}
				}
				if (found)
				{
					td.Kanji = foundKanji;
					td.Gana = foundGana;
					//statusLabel.Text = $"found translation: {foundKanji} {foundGana}";
					Console.WriteLine(statusLabel.Text);
				}

				dataGridView1.DataSource = null;
				dataGridView1.DataSource = translateDataList;
				++index;
			}
			statusLabel.Text = "Batch completed";
			Console.WriteLine(statusLabel.Text);
		}

		private void LoadWords()
		{
			try
			{
				workSheet = workBook.Worksheets[1];
				Range range = workSheet.UsedRange;
				for (int i = 2; i <= range.Rows.Count; ++i)
				{
					TranslateData td = new TranslateData();
					var cell = range.Cells[i, 13];
					if (cell.Value != null)
					{
						td.Korean = cell.Value.ToString();
					}
					else
						continue;
					cell = range.Cells[i, 14];
					if (cell.Value != null)
					{
						td.Kanji = cell.Value.ToString();
					}
					cell = range.Cells[i, 15];
					if (cell.Value != null)
					{
						td.Gana = cell.Value.ToString();
					}
					//Console.WriteLine($"{td.Korean} {td.Kanji} {td.Gana}");
					translateDataList.Add(td);
				}
				dataGridView1.DataSource = null;
				dataGridView1.DataSource = translateDataList;
			}
			catch (Exception exception)
			{
				ReleaseExcelObjects();
				Console.WriteLine(exception.Message);
			}
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (workBook == null)
				return;

			try
			{
				workSheet = workBook.Worksheets[1];

				int index = 2;
				foreach (var td in translateDataList)
				{
					workSheet.Cells[index, 14].Value = td.Kanji;
					workSheet.Cells[index, 15].Value = td.Gana;
					++index;
				}
			}
			catch (Exception exception)
			{
				ReleaseExcelObjects();
				Console.WriteLine(exception.Message);
			}

			workBook.Save();
		}

		private void ReleaseExcelObjects()
		{
			if (workSheet != null)
			{
				Marshal.ReleaseComObject(workSheet);
				workSheet = null;
			}
			if (workBook != null)
			{
				workBook.Close();
				Marshal.ReleaseComObject(workBook);
				workBook = null;
			}
			if (application != null)
			{
				application.Quit();
				Marshal.ReleaseComObject(application);
				application = null;
			}
		}
	}
}
