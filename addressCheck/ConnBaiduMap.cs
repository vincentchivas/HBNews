using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace addressCheck
{
    public partial class ConnBaiduMap : Form
    {
        public ConnBaiduMap()
        {
            InitializeComponent();
        }
        public XmlDocument getXml(string url)
        {
            //geocoder服务，默认返回xml
            // url = @"http://api.map.baidu.com/geocoder/v2/?address=" + txtAddr.Text + "&ak=9560b185de306ae17af47376fa2a3457";
            //http://api.map.baidu.com/place/v2/search 
            //http://api.map.baidu.com/place/v2/detail 与search结果配合使用

            // string url = @"http://api.map.baidu.com/place/v2/search?&q=" + txtAddr.Text + "&region=湖北省&ak=2f5cd7da6262a5ea9756c2f6a8894eaa";
            //http://api.map.baidu.com/place/v2/detail?uid=8ee4560cf91d160e6cc02cd7&ak=2f5cd7da6262a5ea9756c2f6a8894eaa&scope=2
            //string url = @"http://api.map.baidu.com/place/v2/suggestion?query=" + txtAddr.Text + "&region=湖北省&ak=2f5cd7da6262a5ea9756c2f6a8894eaa";
            //详细到街道的结构化地址得到百度经纬度信息
            //http://api.map.baidu.com/geocoder/v2/?ak=2f5cd7da6262a5ea9756c2f6a8894eaa&callback=renderReverse&location=39.983424,116.322987&output=xml&pois=1

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            String strConfig = String.Empty;
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                strConfig = reader.ReadToEnd();
            }
            XmlDocument addrinfo = new XmlDocument();
            addrinfo.LoadXml(strConfig);
            return addrinfo;
        }
        public XmlDocument getAddress(string lat, string lng)
        {
            string url = @"http://api.map.baidu.com/geocoder/v2/?ak=2f5cd7da6262a5ea9756c2f6a8894eaa&callback=renderReverse&location=" + lat + "," + lng + "&output=xml&pois=1";
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            String strConfig = String.Empty;
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                strConfig = reader.ReadToEnd();
            }
            XmlDocument addrinfo = new XmlDocument();
            addrinfo.LoadXml(strConfig);
            return addrinfo;
        }
        private void btnGetxml_Click(object sender, EventArgs e)
        {
            string lat = "";
            string lng = "";
            string url = @"http://api.map.baidu.com/geocoder/v2/?address=" + txtAddr.Text + "&ak=9560b185de306ae17af47376fa2a3457";
            XmlDocument addrinfo = getXml(url);
            txtSource.Text = addrinfo.OuterXml;
            XmlNode nodestatus = addrinfo.DocumentElement.SelectSingleNode("/GeocoderSearchResponse/status");
            if (nodestatus.InnerText == "0")
            {
                XmlNode node1 = addrinfo.DocumentElement.SelectSingleNode("/GeocoderSearchResponse/result/location/lat");
                if (node1 != null)
                {
                    lat = node1.InnerText;
                }
                XmlNode node2 = addrinfo.DocumentElement.SelectSingleNode("/GeocoderSearchResponse/result/location/lng");
                if (node2 != null)
                {
                    lng = node2.InnerText;
                }
                if (lat == "" || lng == "")
                {
                    MessageBox.Show("未获取到信息，请重新输入");
                    return;
                }
                XmlDocument newAddr = getAddress(lat, lng);
                try
                {
                    XmlNode nodenewAddr = newAddr.DocumentElement.SelectSingleNode("/GeocoderSearchResponse/result/formatted_address");
                    XmlNode nodeStrict = newAddr.DocumentElement.SelectSingleNode("/GeocoderSearchResponse/result/addressComponent/district");
                    txtValues.Text = nodenewAddr.InnerText + "\r\n" + nodeStrict.InnerText;
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                }

            }
            else
            {
                MessageBox.Show("返回码状态非正常");
            }


        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            string zip = "";
            string lat = "";
            string lng = "";
            string url = @"http://api.map.baidu.com/geocoder/v2/?address=" + txtAddr.Text + "&ak=9560b185de306ae17af47376fa2a3457";
            XmlDocument addrinfo = getXml(url);
            txtSource.Text = addrinfo.OuterXml;
            XmlNode nodestatus = addrinfo.DocumentElement.SelectSingleNode("/GeocoderSearchResponse/status");
            if (nodestatus.InnerText == "0")
            {
                XmlNode node1 = addrinfo.DocumentElement.SelectSingleNode("/GeocoderSearchResponse/result/location/lat");
                if (node1 != null)
                {
                    lat = node1.InnerText;
                }
                XmlNode node2 = addrinfo.DocumentElement.SelectSingleNode("/GeocoderSearchResponse/result/location/lng");
                if (node2 != null)
                {
                    lng = node2.InnerText;
                }
                if (lat == "" || lng == "")
                {
                    MessageBox.Show("未获取到信息，请重新输入");
                    return;
                }
                XmlDocument newAddr = getAddress(lat, lng);
                txtSource.Text = "";
                txtSource.Text = newAddr.OuterXml;
                XmlNodeList zips = newAddr.DocumentElement.SelectNodes("/GeocoderSearchResponse/result/pois/poi/zip");
                foreach (XmlNode n in zips)
                {
                    if (n.InnerText != "")
                    {
                        zip = n.InnerText;
                        break;
                    }
                }
                txtValues.Text = txtValues.Text + "\r\n" + zip;

            }
        }
    }
}
