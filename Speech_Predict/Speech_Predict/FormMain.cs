using Baidu.Aip;
using Baidu.Aip.Speech;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Net;
using Baidu.Aip.Ocr;
using System.Collections.Generic;

namespace Speech_Demo
{
    public partial class FormMain : Form
    {
        [DllImport ("winmm.dll", SetLastError = true)]
        static extern long mciSendString (string strCommand, StringBuilder strReturn, int iReturnLength, IntPtr hwndCallback);

        #region Keys
        private const string API_Key = "ShW2rTPyB8vUFRwDvp2MUQxM";
        private const string Secure_Key = "zZh0c4cuIiTL2zD2vUUIv6MUeefLN03A";

        private const string API_Key_Words = "e9K9r9YnzTRM8UvRqYEOTTto";
        private const string Secure_Key_Words = "tBHMUcFSG3DVDYwOpBgIIPdHgLX6ONsa";

        #endregion

        // 百度语音API交互类
        private readonly Asr _asrClient;
        private readonly Tts _ttsClient;
        // 百度文字识别API交互实例
        private readonly Ocr _ocrClient;
        /// <summary>
        /// 构造函数
        /// </summary>
        public FormMain ()
        {
            InitializeComponent ();

            // 初始化百度语音交互类
            _asrClient = new Asr (API_Key, Secure_Key);
            _ttsClient = new Tts (API_Key, Secure_Key);
            //初始化OCR交互实例
            _ocrClient = new Ocr(API_Key_Words, Secure_Key_Words);

            // 初始化控件默认值
            //cbFileType.SelectedIndex = 0;
            //tboxTTSText.Text = "北京航空航天大学软件学院。\r\n软件工程专业人工智能方向。";
        }


        //private void btnTTSStart_Click (object sender, EventArgs e)
        //{

        //    //ScriptRuntime pyRuntime = Python.CreateRuntime();
        //    //dynamic py = pyRuntime.UseFile("PythonFiles/abalone.py");
        //    //string a = py.text();
        //    //MessageBox.Show(a);
        //    //if (tboxTTSText.Text.Trim () == string.Empty)
        //    //    return;

        //    //            HttpWebRequest req= (HttpWebRequest)WebRequest.Create("http://www.contoso.com/");
        //    //;           req.Method = "POST";


            
         
        //}

        private void tboxTTSText_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Net.HttpWebRequest request;
            string params1 = System.Web.HttpUtility.UrlEncode(tboxTTSText.Text.Trim());
            string strURL = "http://127.0.0.1:8000/getTheta";
            request = (System.Net.HttpWebRequest)HttpWebRequest.Create(strURL);
            request.Method = "get";
            System.Net.HttpWebResponse response;
            response = (System.Net.HttpWebResponse)request.GetResponse();
            System.IO.StreamReader myreader = new System.IO.StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string responseText = myreader.ReadToEnd();
            myreader.Close();
            MessageBox.Show(responseText);
        }
        //识别图片文字，并播放
        private void button2_Click(object sender, EventArgs e)
        {
            if (ofdASRFile.FileName == string.Empty)
                return;
            var image = File.ReadAllBytes(ofdASRFile.FileName);
            // Dictionary<String, object> options = null;
            var options = new Dictionary<String, object>();
            JObject wresult;
            wresult = _ocrClient.AccurateBasic(image, options);
            var words_result = wresult["words_result"];
            StringBuilder sb = new StringBuilder();
            foreach (var words in words_result) {
                sb.Append(words["words"]+";") ;
    
            }

            tboxTTSText.Text = sb.ToString().Substring(0,sb.Length-1);//识别出文字结果并展示
            // 创建一个HTTP请求
            System.Net.HttpWebRequest webReq;
            
            string paramsData = tboxTTSText.Text.Trim().Replace(" ", "").Replace("\r\n", "");
            StringBuilder buffer = new StringBuilder();
            buffer.AppendFormat("{0}={1}","traindata", System.Web.HttpUtility.UrlEncode(paramsData));
            
            //string params1 = System.Web.HttpUtility.UrlEncode(input);
            byte[] byteArray = Encoding.UTF8.GetBytes(buffer.ToString());

            string strURL = "http://127.0.0.1:8002/predict/";
            webReq = (System.Net.HttpWebRequest)HttpWebRequest.Create(strURL);
            webReq.Method = "POST";
            webReq.ContentType = "application/x-www-form-urlencoded";
            webReq.ContentLength = byteArray.Length;
            Stream newStream = webReq.GetRequestStream();//根据入参请求，创建入参文件流
            newStream.Write(byteArray, 0, byteArray.Length);//文件流加、写入参数
            newStream.Close();//关闭

            System.Net.HttpWebResponse response;
            response = (System.Net.HttpWebResponse)webReq.GetResponse();
            StreamReader myreader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string responseText = myreader.ReadToEnd();
            myreader.Close();
            tbPredictRt.Text = responseText;

            //语音合成
           TtsResponse result;
            try
            {
                result = _ttsClient.Synthesis(responseText);
            }
            catch (AipException exp)
            {
                MessageBox.Show(exp.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (result.Success)
            {

                // 保存为mp3格式
                File.WriteAllBytes("temp.mp3", result.Data);

                // 播放音频文件
                mciSendString("open temp.mp3 alias temp_alias", null, 0, IntPtr.Zero);
                mciSendString("play temp_alias", null, 0, IntPtr.Zero);

                // 等待播放结束
                StringBuilder strReturn = new StringBuilder(64);
                //do
                //{
                //    mciSendString("status temp_alias mode", strReturn, 64, IntPtr.Zero);
                //} while (!strReturn.ToString().Contains("stopped"));

                // 关闭音频文件
                //mciSendString("close temp_alias", null, 0, IntPtr.Zero);
            }
            else
                MessageBox.Show(result.ErrorMsg, "转换失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ofdASRFile.ShowDialog() == DialogResult.Cancel)
                return;
            tboxFileAddress.Text = ofdASRFile.FileName;
           
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}
