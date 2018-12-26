using Baidu.Aip;
using Baidu.Aip.Speech;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System.Net;

namespace Speech_Demo
{
    public partial class FormMain : Form
    {
        [DllImport ("winmm.dll", SetLastError = true)]
        static extern long mciSendString (string strCommand, StringBuilder strReturn, int iReturnLength, IntPtr hwndCallback);

        #region Keys
        private const string API_Key = "ShW2rTPyB8vUFRwDvp2MUQxM";
        private const string Secure_Key = "zZh0c4cuIiTL2zD2vUUIv6MUeefLN03A";
        #endregion

        // 百度语音API交互类
        private readonly Asr _asrClient;
        private readonly Tts _ttsClient;

        /// <summary>
        /// 构造函数
        /// </summary>
        public FormMain ()
        {
            InitializeComponent ();

            // 初始化百度语音交互类
            _asrClient = new Asr (API_Key, Secure_Key);
            _ttsClient = new Tts (API_Key, Secure_Key);

            // 初始化控件默认值
            //cbFileType.SelectedIndex = 0;
            //tboxTTSText.Text = "北京航空航天大学软件学院。\r\n软件工程专业人工智能方向。";
        }


        private void btnTTSStart_Click (object sender, EventArgs e)
        {

            //ScriptRuntime pyRuntime = Python.CreateRuntime();
            //dynamic py = pyRuntime.UseFile("PythonFiles/abalone.py");
            //string a = py.text();
            //MessageBox.Show(a);
            //if (tboxTTSText.Text.Trim () == string.Empty)
            //    return;

            //            HttpWebRequest req= (HttpWebRequest)WebRequest.Create("http://www.contoso.com/");
            //;           req.Method = "POST";


            
            System.Net.HttpWebRequest request;
            // 创建一个HTTP请求
            string input = tboxTTSText.Text.Trim().Replace(" ", "").Replace("\r\n","");
            string params1= System.Web.HttpUtility.UrlEncode(input);
            string strURL = "http://127.0.0.1:8000/predict?data=" + params1;
            request = (System.Net.HttpWebRequest)HttpWebRequest.Create(strURL);
            request.Method = "get";
            System.Net.HttpWebResponse response;
            response = (System.Net.HttpWebResponse)request.GetResponse();
            System.IO.StreamReader myreader = new System.IO.StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string responseText = myreader.ReadToEnd();
            myreader.Close();
            // 语音合成
            TtsResponse result;
            try
            {
                result = _ttsClient.Synthesis (responseText);
            }
            catch (AipException exp)
            {
                MessageBox.Show (exp.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (result.Success)
            {
              
                // 保存为mp3格式
                File.WriteAllBytes ("temp.mp3", result.Data);

                // 播放音频文件
                mciSendString ("open temp.mp3 alias temp_alias", null, 0, IntPtr.Zero);
                mciSendString ("play temp_alias", null, 0, IntPtr.Zero);

                // 等待播放结束
                StringBuilder strReturn = new StringBuilder (64);
                do
                {
                    mciSendString ("status temp_alias mode", strReturn, 64, IntPtr.Zero);
                } while (!strReturn.ToString ().Contains ("stopped"));

                // 关闭音频文件
                mciSendString ("close temp_alias", null, 0, IntPtr.Zero);
            }
            else
                MessageBox.Show (result.ErrorMsg, "转换失败", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
        }

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
    }
}
