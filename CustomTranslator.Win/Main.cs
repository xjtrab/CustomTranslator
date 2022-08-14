
using AzureCognitive;
using System.Text.Json;

namespace CustomTranslator.Win
{
    public partial class Main : Form
    {
        private static bool ChinseToEnglish = false;
        private string url = @"http://103.172.182.110/api/TextTranslator?text={0}&from={1}&to={2}";
        public Main() 
        {
            InitializeComponent();
        }

        private void btnSwitch_Click(object sender, EventArgs e)
        {
            ChinseToEnglish = !ChinseToEnglish;
            lab1.Text = ChinseToEnglish ? "中文" : "English";
            lab2.Text = ChinseToEnglish ? "English" : "中文";
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            using (var httpClient = new HttpClient())
            {
                var urlReal = new Uri(string.Format(url, richTextBox1.Text, ChinseToEnglish ? "zh-hans" : "en", !ChinseToEnglish ? "zh-hans" : "en"));
                var response = httpClient.GetAsync(urlReal).Result;
                var data = response.Content.ReadAsStringAsync().Result;
                var dataObj = JsonSerializer.Deserialize<List<TranslationsResponse>>(data);
                richTextBox2.Text = dataObj?.FirstOrDefault()?.translations?.Where(x => x.to == (!ChinseToEnglish ? "zh-Hans" : "en")).FirstOrDefault()?.text;
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
            using (var httpClient = new HttpClient())
            {
                var urlReal = new Uri(string.Format(url, richTextBox1.Text, ChinseToEnglish ? "zh-hans" : "en", !ChinseToEnglish ? "zh-hans" : "en"));
                var response = httpClient.GetAsync(urlReal).Result;
                var data = response.Content.ReadAsStringAsync().Result;
                var dataObj = JsonSerializer.Deserialize<List<TranslationsResponse>>(data);
                richTextBox2.Text = dataObj?.FirstOrDefault()?.translations?.Where(x => x.to == (!ChinseToEnglish ? "zh-Hans" : "en")).FirstOrDefault()?.text;
            }
        }
    }
}