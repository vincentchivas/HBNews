using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;

namespace addressCheck
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            /*
            HtmlWeb webClient = new HtmlWeb();
            HtmlDocument doc = webClient.Load("http://xxx");

            HtmlNodeCollection hrefList = doc.DocumentNode.SelectNodes(".//a[@href]");

            if (hrefList != null)
            {
                foreach (HtmlNode href in hrefList)
                {
                    HtmlAttribute att = href.Attributes["href"];
                    doSomething(att.Value);

                }

            }  
             */
            InitializeComponent();
        }
        public string GetDataFromUrl(string url)
        {
            string str = string.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            //设置Http头；
            request.AllowAutoRedirect = true;
            request.AllowWriteStreamBuffering = true;
            request.Referer = "";
            request.Timeout = 10 * 1000;
            request.UserAgent = "";
            HttpWebResponse response = null;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    //根据http应答头来判别编码
                    string Characterset = response.CharacterSet;
                    Encoding encode;
                    if (Characterset != "")
                    {
                        if (Characterset == "ISO-8859-1")
                        {
                            Characterset = "gb2312";
                        }
                        encode = Encoding.GetEncoding(Characterset);
                    }
                    else
                    {
                        encode = Encoding.Default;
                    }
                    //声明一个内存流来贮存http应答流
                    Stream Receivestream = response.GetResponseStream();
                    MemoryStream mstream = new MemoryStream();
                    byte[] bf = new byte[255];
                    int count = Receivestream.Read(bf, 0, 255);
                    while (count > 0)
                    {
                        mstream.Write(bf, 0, count);
                        count = Receivestream.Read(bf, 0, 255);
                    }
                    Receivestream.Close();
                    mstream.Seek(0, SeekOrigin.Begin);
                    //从内存流里读取字符串这里涉及到了编码方案
                    StreamReader reader = new StreamReader(mstream, encode);
                    char[] buf = new char[1024];
                    count = reader.Read(buf, 0, 1024);
                    while (count > 0)
                    {
                        str += new string(buf, 0, 1024);
                        count = reader.Read(buf, 0, 1024);

                    }
                    reader.Close();
                    mstream.Close();

                }

            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());

            }
            finally
            {
                if (response != null)
                    response.Close();
            }

            return str;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtAddr.Text.Trim() == "")
            {
                MessageBox.Show("input website!");
            }
            else
            {
                if (!txtAddr.Text.Trim().StartsWith("http"))
                {
                    txtAddr.Text = "http://" + txtAddr.Text;
                }
                string html = GetDataFromUrl(txtAddr.Text.Trim());
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(@html);
                foreach (var script in doc.DocumentNode.Descendants("script").ToArray())
                {
                    script.Remove();
                }
                foreach (var style in doc.DocumentNode.Descendants("style").ToArray())
                {
                    style.Remove();
                }

               // foreach (var comment in doc.DocumentNode.SelectNodes("//comment()").ToArray())
               // {
                //    comment.Remove();//新增的代码
               // }
                 txtSource.Text = doc.DocumentNode.OuterHtml;
     
            }
          
            
        }

        private void btnFilt_Click(object sender, EventArgs e)
        {
            if (txtAddr.Text.Trim() == "")
            {
                MessageBox.Show("input website!");
            }
            else
            {
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(@txtSource.Text);
                HtmlNode noot = doc.GetElementbyId("setf");
                
            
             
              
            }
           
        }
    }
}
