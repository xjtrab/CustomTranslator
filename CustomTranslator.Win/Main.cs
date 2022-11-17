
using AzureCognitive;
using System.ComponentModel;
using System.Text.Json;

namespace CustomTranslator.Win
{
    public partial class Main : Form
    {
        private static bool ChinseToEnglish = false;
        private string url = @"http://43.154.233.47/customtranslator/api/TextTranslator?text={0}&from={1}&to={2}&ChinseToEnglish={3}";
        private KeyboardHook k_hook;
        private string currentKey = string.Empty;
        private DateTime currentTime = DateTime.UtcNow;
        public Main() 
        {
            k_hook = new KeyboardHook();
            k_hook.KeyDownEvent += new KeyEventHandler(hook_KeyDown);//钩住键按下
            k_hook.Start();//安装键盘钩子
            InitializeComponent();
        }

        private void hook_KeyDown(object? sender, KeyEventArgs e)
        {


            if (e.KeyValue == (int)Keys.C && (int)Control.ModifierKeys == (int)Keys.Control)
            {
                if (currentKey == Keys.C.ToString() + Keys.Control.ToString() && (DateTime.UtcNow - currentTime).TotalMilliseconds < 500)
                {
                    btnPasteCommit_Click(null, null);
                    this.Activate();
                }
                currentKey = Keys.C.ToString() + Keys.Control.ToString();
                currentTime = DateTime.UtcNow;
            }
            else if (e.KeyValue == (int)Keys.Enter)
            {
                BackgroundWorker work = new BackgroundWorker();
                work.DoWork += Work_DoWork;
                work.RunWorkerAsync();
            }


        }

        private void btnSwitch_Click(object sender, EventArgs e)
        {
            ChinseToEnglish = !ChinseToEnglish;
            lab1.Text = ChinseToEnglish ? "中文" : "English";
            lab2.Text = ChinseToEnglish ? "English" : "中文";
            if (!string.IsNullOrEmpty(richTextBox1.Text))
            {
                GetResultAsync();
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            GetResultAsync();
        }

        private void GetResultAsync()
        {
            BackgroundWorker work = new BackgroundWorker();
            work.DoWork += Work_DoWork;
            work.RunWorkerAsync();
        }

        private void Work_DoWork(object? sender, DoWorkEventArgs e)
        {
            GetResponseFromAzure();
        }

        private void GetResponseFromAzure()
        {
            string reichText1 = "";
            //string reichText2 = "";
            if (richTextBox1.InvokeRequired)
            {
                richTextBox1.Invoke(new MethodInvoker(delegate { reichText1 = richTextBox1.Text.Trim('\n'); }));
            }
            using (var httpClient = new HttpClient())
            {
                
                var urlReal = new Uri(string.Format(url, reichText1, ChinseToEnglish ? "zh-hans" : "en", !ChinseToEnglish ? "zh-hans" : "en", ChinseToEnglish));
                var response = httpClient.GetAsync(urlReal).Result;
                var data = response.Content.ReadAsStringAsync().Result;
                var dataObj = JsonSerializer.Deserialize<List<TranslationsResponse>>(data);
                if (richTextBox2.InvokeRequired)
                {
                    richTextBox2.Invoke(new MethodInvoker(delegate
                    {
                        richTextBox2.Text = dataObj?.FirstOrDefault()?.translations?.Where(x => x.to == (!ChinseToEnglish ? "zh-Hans" : "en")).FirstOrDefault()?.text;
                    }));
                }
            }
        }

        private void btnPasteCommit_Click(object sender, EventArgs e)
        {
            IDataObject iData = Clipboard.GetDataObject();
            if (iData.GetDataPresent(DataFormats.Text))
            {
                //如果剪贴板中的数据是文本格式 
                this.richTextBox1.Text = (string)iData.GetData(DataFormats.Text);//检索与指定格式相关联的数据 
            }
            else
            {
                MessageBox.Show("目前剪贴板中数据不可转换为文本", "错误");
            }

            BackgroundWorker work = new BackgroundWorker();
            work.DoWork += Work_DoWork;
            work.RunWorkerAsync();
        }
    }
}