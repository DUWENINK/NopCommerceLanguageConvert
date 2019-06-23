using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using System.Xml.Linq;

namespace NopCommerceLanguageConvert
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //C:\Users\DUWENINK\Desktop\Traditional_Chinese_language_pack_nop_420sponser2-1.xml
        private void ConvertToChinese_Click(object sender, EventArgs e)
        {
            var path = txtPath.Text;
            if (File.Exists(path) && Path.GetExtension(path) ==".xml")
            {
                //将XML文件加载进来
                XDocument document = XDocument.Load(path);
                //获取到XML的根元素进行操作
                XElement root = document.Root;
                XElement ele = root.Element("LocaleResource");
                //获取name标签的值
                XElement Value = ele.Element("Value");
                Console.WriteLine(Value.Value);
                //获取根元素下的所有子元素
                IEnumerable<XElement> enumerable = root.Elements();
                foreach (XElement item in enumerable)
                {
                    foreach (XElement item1 in item.Elements())
                    {
                        
                        Console.WriteLine(item1.Value);   //输出 name  name1      

                        TranslationResult result = GetTranslationFromBaiduFanyi(item1.Value, "cht", "zh");
                        //判断是否出错
                        if (result.Error_code == null)
                        {
                            item1.Value = result.Trans_result[0].Dst;
                        }
                        else
                        {
                            //检查appid和密钥是否正确
                           
                        }


                    }
                }
                document.Save(path);
                MessageBox.Show("翻译完成");

            }
           
        }
        //对字符串做md5加密
        public static string GetMD5WithString(string input)
        {
            if (input == null)
            {
                return null;
            }
            MD5 md5Hash = MD5.Create();
            //将输入字符串转换为字节数组并计算哈希数据  
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            //创建一个 Stringbuilder 来收集字节并创建字符串  
            StringBuilder sBuilder = new StringBuilder();
            //循环遍历哈希数据的每一个字节并格式化为十六进制字符串  
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            //返回十六进制字符串  
            return sBuilder.ToString();
        }


        /// <summary>
        /// 调用百度翻译API进行翻译
        /// 详情可参考http://api.fanyi.baidu.com/api/trans/product/apidoc
        /// </summary>
        /// <param name="q">待翻译字符</param>
        /// <param name="from">源语言</param>
        /// <param name="to">目标语言</param>
        /// <returns></returns>
        public static TranslationResult GetTranslationFromBaiduFanyi(string q, string from, string to)
        {
            //可以直接到百度翻译API的官网申请
            //此处的都是子丰随便写的，所以肯定是不能用的
            //一定要去申请，不然程序的翻译功能不能使用
            string appId = "******";
            string password = "******";

            // 转换编码
            UTF8Encoding utf8 = new UTF8Encoding();
            Byte[] encodedBytes = utf8.GetBytes(q);
            String new_q = utf8.GetString(encodedBytes);

            string jsonResult = String.Empty;
            //随机数
            string randomNum = System.DateTime.Now.Millisecond.ToString();
            //md5加密
            string md5Sign = GetMD5WithString(appId + q + randomNum + password);
            //url
            string url = String.Format("http://api.fanyi.baidu.com/api/trans/vip/translate?q={0}&from={1}&to={2}&appid={3}&salt={4}&sign={5}",
                new_q,
                from,
                to,
                appId,
                randomNum,
                md5Sign
                );
            WebClient wc = new WebClient();
            try
            {
                jsonResult = wc.DownloadString(url);
            }
            catch
            {
                jsonResult = string.Empty;
            }
            //解析json
            JavaScriptSerializer jss = new JavaScriptSerializer();
            TranslationResult result = jss.Deserialize<TranslationResult>(jsonResult);
            return result;
        }
        public class Translation
        {
            public string Src { get; set; }
            public string Dst { get; set; }
        }

        public class TranslationResult
        {
            //错误码，翻译结果无法正常返回
            public string Error_code { get; set; }
            public string Error_msg { get; set; }
            public string From { get; set; }
            public string To { get; set; }
            public string Query { get; set; }
            //翻译正确，返回的结果
            //这里是数组的原因是百度翻译支持多个单词或多段文本的翻译，在发送的字段q中用换行符（\n）分隔
            public Translation[] Trans_result { get; set; }
        }
    }
}
