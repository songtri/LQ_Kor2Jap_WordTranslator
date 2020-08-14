using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;

namespace TranslateTest
{
	class Program
	{
		static HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();

		[STAThread]
		static void Main(string[] args)
		{
			Run();
		}

		static void Run()
		{
			Console.WriteLine("Test");

			//string searchWord = Console.ReadLine();
			string searchWord = "사전";

			string url = $"https://ja.dict.naver.com/search.nhn?range=word&page=1&q={searchWord}";
			//string url = "https://html-agility-pack.net/from-browser";

			string html;
			//Console.Write(html);
			//Console.WriteLine();
			//Console.WriteLine();

			//html = ManualHtml();
			//HtmlDocument doc = LoadByHtml(html);
			//HtmlAgilityPack.HtmlDocument doc = LoadDirectly(url);
			//var web = new HtmlWeb();
			//doc = web.LoadFromBrowser(url, o =>
			//{
			//	var webBrowser = (WebBrowser)o;

			//	// WAIT until the dynamic text is set
			//	return !string.IsNullOrEmpty(webBrowser.Document.GetElementById("u_skip").InnerText);
			//});
			//Task loadByBrowserTask = Task.Run(() => LoadByBrowser(url));
			//await loadByBrowserTask;
			//await LoadByBrowser(url);

			//using (HttpClient client = new HttpClient())
			//{
			//	html = await client.GetStringAsync(url);
			//}
			//Console.Write(html);
			LoadByWebBroswer(url);
			return;
			//doc.LoadHtml(html);

			HtmlNode node = doc.DocumentNode;
			if (node == null)
				Console.WriteLine("Node is null");

			//node = node.SelectSingleNode("//*[text()[contains(., 'lst_txt')]]");
			//PrintNodeInfo(node);
			//return;
			while (node != null)
			{
				if (node != null)
					PrintNodeInfo(node);
				//Console.WriteLine(node.InnerText);

				//var node = doc.DocumentNode.SelectSingleNode("//body");
				//var node = doc.DocumentNode;
				//foreach (var n in node.ChildNodes)
				//{
				//	Console.WriteLine($"{node.Id} {node.Name} {node.NodeType} {node.Attributes} {node.XPath}");
				//}

				Console.WriteLine();
				var nextSib = node.NextSibling;
				Console.WriteLine("Next Sibling:");
				PrintNodeInfo(nextSib);
				Console.WriteLine();
				Console.WriteLine("First Child:");
				var firstChild = node.FirstChild;
				PrintNodeInfo(firstChild);
				Console.WriteLine();

				Console.WriteLine("s: go to next sibling, c: go to first child");
				string input = Console.ReadLine();
				if (input == "s")
					node = node.NextSibling;
				else if (input == "c")
					node = node.FirstChild;
				else
					break;

				Console.WriteLine();
			}
		}

		static void PrintNodeInfo(HtmlNode node)
		{
			if (node == null)
			{
				Console.WriteLine("Node is null");
				return;
			}

			Console.WriteLine($"Id: {node.Id}");
			Console.WriteLine($"Name: { node.Name}");
			Console.WriteLine($"Type: {node.NodeType}");
			Console.WriteLine($"Path: {node.XPath}");
			if (node.OuterLength > 0)
			{
				var splits = node.OuterHtml.Split('\n');
				if (splits.Length > 0)
					Console.WriteLine($"Content: {splits[0]}");
			}
		}

		static string ManualHtml()
		{
			return
				@"<!DOCTYPE html>
<html>
<body>
	<h1>This is <b>bold</b> heading</h1>
	<i>italic 0</i>
	<div>This is <u>underlined</u> <h2>This is <i>italic1</i> heading1</h2><h2>This is <i>italic2</i> heading2
	
	<h2>T3</h2>
	</h2>paragraph <i>italic3</i></div>
	<h2>This is <i>italic</i> heading</h2>
</body>
</html> ";
		}

		static string LoadByWebClient(string url)
		{
			WebClient wc = new WebClient();
			return wc.DownloadString(url);
		}

		static string LoadByWebRequest(string url)
		{
			HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
			request.Method = "POST";
			HttpWebResponse response = request.GetResponse() as HttpWebResponse;
			var stream = response.GetResponseStream();
			var sr = new StreamReader(stream);
			string html = sr.ReadToEnd().Trim();
			sr.Close();

			return html;
		}

		static HtmlAgilityPack.HtmlDocument LoadByHtml(string html)
		{
			var doc = new HtmlAgilityPack.HtmlDocument();
			doc.LoadHtml(html);
			return doc;
		}

		static async Task<bool> LoadByBrowser(string url)
		{
			Console.WriteLine($"LoadByBrowser");
			doc = new HtmlWeb().LoadFromBrowser(url, o =>
			{
				var webBrowser = (WebBrowser)o;

				// WAIT until the dynamic text is set
				Console.WriteLine($"LoadByBrowser Return");
				return !string.IsNullOrEmpty(webBrowser.Document.GetElementById("u_skip").InnerText);
			});

			Console.WriteLine($"LoadByBrowser End");
			while (true) ;
			return false;
		}

		static WebBrowser webBrowser = new WebBrowser();
		static void LoadByWebBroswer(string url)
		{
			webBrowser.Navigate(new Uri(url));
			while (webBrowser.ReadyState != WebBrowserReadyState.Complete)
				Application.DoEvents();
			Console.Write(webBrowser.DocumentText);
			webBrowser.DocumentCompleted += WebBrowser_DocumentCompleted;
		}

		private static void WebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
		{
			Console.Write(webBrowser.DocumentText);
		}

		static HtmlAgilityPack.HtmlDocument LoadDirectly(string url)
		{
			return new HtmlWeb().Load(url);
		}
	}
}
