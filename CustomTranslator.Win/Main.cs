
using AzureCognitive;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using OpenAI_API;
using System.ComponentModel;
using System.Diagnostics;
using System.Text.Json;

namespace CustomTranslator.Win
{
    public partial class Main : Form
    {
        private static bool ChinseToEnglish = false;
        private string url = @"http://43.154.233.47/customtranslator/api/TextTranslator?text={0}&from={1}&to={2}&ChinseToEnglish={3}";
        private string OpenAIKey = Environment.GetEnvironmentVariable("OpenAIKey");
        private KeyboardHook k_hook;
        private string currentKey = string.Empty;
        private DateTime currentTime = DateTime.UtcNow;
        OpenAIAPI openAIAPI = null;
        public Main()
        {
            k_hook = new KeyboardHook();
            k_hook.KeyDownEvent += new KeyEventHandler(hook_KeyDown);//钩住键按下
            k_hook.Start();//安装键盘钩子
            InitializeComponent();
            openAIAPI = new OpenAIAPI(OpenAIKey);
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
            //GetAIResponse();
        }

        private void GetAIResponse()
        {
            var chat = openAIAPI.Chat.CreateConversation();

            string reichText1 = "";
            if (richTextBox1.InvokeRequired)
            {
                richTextBox1.Invoke(new MethodInvoker(delegate { reichText1 = richTextBox1.Text.Trim('\n'); }));
            }
            // now let's ask it a question'
            chat.AppendUserInput(reichText1);
            // and get the response
            string response = chat.GetResponseFromChatbotAsync().GetAwaiter().GetResult();
            this.richTextBox3.Text = response;

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

        private async void btnListen_Click(object sender, EventArgs e)
        {
            var config = SpeechConfig.FromSubscription("92255497bf4e497c835faa364e2719b8", "eastus");
            using var audioConfigStream = AudioInputStream.CreatePushStream();
            using var audioConfig = AudioConfig.FromStreamInput(audioConfigStream);
            using var speechRecognizer = new SpeechRecognizer(config, audioConfig);

            var stopRecognition = new TaskCompletionSource<int>();

            speechRecognizer.Recognizing += (s, e) =>
            {
                //richTextBox3.Text += $"RECOGNIZING: Text={e.Result.Text}";
                Debug.WriteLine($"RECOGNIZING: Text={e.Result.Text}");
            };

            speechRecognizer.Recognized += (s, e) =>
            {
                if (e.Result.Reason == ResultReason.RecognizedSpeech)
                {
                    //richTextBox3.Text += $"RECOGNIZED: Text={e.Result.Text}";
                    Debug.WriteLine($"RECOGNIZED: Text={e.Result.Text}");
                }
                else if (e.Result.Reason == ResultReason.NoMatch)
                {
                    Debug.WriteLine($"NOMATCH: Speech could not be recognized.");
                }
            };

            speechRecognizer.Canceled += (s, e) =>
            {
                Debug.WriteLine($"CANCELED: Reason={e.Reason}");

                if (e.Reason == CancellationReason.Error)
                {
                    Debug.WriteLine($"CANCELED: ErrorCode={e.ErrorCode}");
                    Debug.WriteLine($"CANCELED: ErrorDetails={e.ErrorDetails}");
                    Debug.WriteLine($"CANCELED: Did you set the speech resource key and region values?");
                }

                stopRecognition.TrySetResult(0);
            };

            speechRecognizer.SessionStopped += (s, e) =>
            {
                Console.WriteLine("\n    Session stopped event.");
                stopRecognition.TrySetResult(0);
            };

            await speechRecognizer.StartContinuousRecognitionAsync();
            this.btnListen.Enabled = false;
            // Waits for completion. Use Task.WaitAny to keep the task rooted.
            Task.WaitAny(new[] { stopRecognition.Task });
            this.btnListen.Enabled = true;
        }
    }
}