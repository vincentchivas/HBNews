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

namespace addressCheck
{
    public partial class TEXT : Form
    {

        public static string whereString = "where  (t.校验结果 <> '确认通过' and t.校验结果 <> '指定通过' ) and t.月份=1 and t.年='2011' and t.县区2 is null and t.申请人地址 is not null ";
        public static string cmdText = "select top 100  t.id,t.申请号,t.专利名称,t.校验结果,t.申请人邮编,t.规则1,t.县区1,t.申请人地址,t.规则2,t.县区2,t.申请人姓名,t.规则3,t.县区3  from patentInfo t  " + whereString;
        public void Bind()
        {
            dgvAddr.DataSource = sqlhelper.ReadTable(cmdText);
        }
        public TEXT()
        {
            InitializeComponent();
            Bind();
            DataTable dt = sqlhelper.ReadTable("select count(*) from patentInfo t " + whereString);
            textBox1.Text = dt.Rows[0][0].ToString();
            textBox1.Enabled = false;
            label1.Text = "总条数";
        }
        //返回规则
        public string filtAddr(string addr)
        {
            StringBuilder sb = new StringBuilder();
            if (addr.StartsWith("湖北省"))
            {
                addr = addr.Replace("湖北省", "");
            }
            string[] stricts = { "市", "区", "县", "镇", "街", "道", "路", "大学", "学院", "中学" };
            for (int i = 0; i < stricts.Length; i++)
            {
                string pivot = stricts[i];
                if (addr.Contains(pivot))
                {
                    string[] strs = addr.Split(pivot.ToCharArray());
                    sb.Append(strs[0]);
                    sb.Append(pivot);
                    sb.Append(" ");
                    addr = strs[1];
                }
            }

            return sb.ToString();
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
        public string getDistrict(string address)
        {
            string url = @"http://api.map.baidu.com/geocoder/v2/?address=" + address + "&ak=9560b185de306ae17af47376fa2a3457";
            string lat = "";
            string lng = "";
            string district = "";
            // string zip = "";
            XmlDocument addrinfo = getXml(url);
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
                    return "empty";//经纬度为空
                }
                XmlDocument newAddr = getAddress(lat, lng);
                try
                {

                    XmlNode nodeStrict = newAddr.DocumentElement.SelectSingleNode("/GeocoderSearchResponse/result/addressComponent/district");
                    district = nodeStrict.InnerText;
                    /*
                    XmlNodeList zips = newAddr.DocumentElement.SelectNodes("/GeocoderSearchResponse/result/pois/poi/zip");
                    foreach (XmlNode n in zips)
                    {
                        if (n.InnerText != "")
                        {
                            zip = n.InnerText;
                            break;
                        }
                    }
                     */
                    return district;
                }
                catch (Exception ee)
                {
                    return "except";
                }

            }
            else
            {
                return "error"; //返回码状态非正常
            }
        }
        private void btnDeal_Click(object sender, EventArgs e)
        {
            label2.Text = "开始处理";
            string id;
            string addr;
            string result;
            // string regular;
            DataTable dtAddrs = sqlhelper.ReadTable(cmdText);
            foreach (DataRow row in dtAddrs.Rows)
            {

                id = row["id"].ToString();
                addr = row["申请人地址"].ToString();//详细地址              
                row["规则2"] = filtAddr(addr);
                result = getDistrict(addr);
                switch (result)
                {
                    case "empty":
                        {
                            result = getDistrict(row["规则2"].ToString());
                            row["县区2"] = result;
                            break;
                        }
                    case "error":
                        {
                            row["县区2"] = result;
                            break;
                        }
                    case "except":
                        {
                            row["县区2"] = result;
                            break;
                        }
                    default:
                        {

                            if (!result.EndsWith("区") && !result.EndsWith("县"))
                            {
                                result = getDistrict(row["规则2"].ToString());
                            }
                            row["县区2"] = result;
                            break;
                        }


                }
                label2.Text = "正在处理ID为" + id + "的地址";
            }
            label2.Text = "处理完毕";
            dgvAddr.DataSource = dtAddrs;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
        }

        private void btnbaidu_Click(object sender, EventArgs e)
        {
            ConnBaiduMap f = new ConnBaiduMap();
            f.Show();
        }
    }
}
