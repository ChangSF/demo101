using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;

public class PaPa : MonoBehaviour {



}

public class GetMeiziPic
{
	private readonly string _path;
	
	//煎蛋图片样例：<img src="http://ww1.sinaimg.cn/mw600/005vbOHfgw1eohghggdpjj30cz0ll0x5.jpg" style="max-width: 486px; max-height: 450px;">
	private const string ImgRegex = @"<p><img[^>]*?src\s*=\s*[""']?([^'"" >]+?)[ '""][^>]*?></p>";
	
	public GetMeiziPic()
	{
		_path = DealDir(Path.Combine(Environment.CurrentDirectory, "Images"));
		Console.WriteLine("===============   绅士开始采集   ===============");
		for (var i = 900; i < 1315; i++)
		{
			Console.WriteLine("===============   正在下载第{0}页数据   ===============", i);
			DoFetch(i);
		}
		
		Console.WriteLine("===============   采集完成   ===============");
	}
	
	private string DealDir(string path)
	{
		if (!Directory.Exists(path))
			Directory.CreateDirectory(path);
		return path;
	}
	
	private void DoFetch(int pageNum)
	{
		var request = (HttpWebRequest)WebRequest.Create(string.Format("http://jandan.net/ooxx/page-{0}#comments", pageNum));
		request.Credentials = CredentialCache.DefaultCredentials;
		var response = (HttpWebResponse)request.GetResponse();
		
		if (response.StatusCode != HttpStatusCode.OK) return;
		var stream = response.GetResponseStream();
		if (stream == null) return;
		
		using (var sr = new StreamReader(stream))
		{
			FetchLinksFromSource(sr.ReadToEnd());
		}
	}
	
	private void FetchLinksFromSource(string htmlSource)
	{
		var matchesImgSrc = Regex.Matches(htmlSource, ImgRegex, RegexOptions.IgnoreCase | RegexOptions.Singleline);
		foreach (Match m in matchesImgSrc)
		{
			var href = m.Groups[1].Value;
			//只选取来自新浪相册的图片
			if (href.Contains(".sinaimg.") && CheckIsUrlFormat(href))
			{
				Console.WriteLine(href);
			}
			else
				continue;
			
			using (var myWebClient = new WebClient())
			{
				try
				{
					myWebClient.DownloadFile(new Uri(href), Path.Combine(_path, Path.GetRandomFileName() + Path.GetExtension(href)));
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
		}
	}
	
	
	private readonly Regex _isUrlFormat = new Regex(@"http://?([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?");
	private bool CheckIsUrlFormat(string value)
	{
		return _isUrlFormat.IsMatch(value);
	}
}
