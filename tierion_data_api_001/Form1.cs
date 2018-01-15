using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tierion_data_api_001
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string url = "https://api.tierion.com/v1/records";

            System.Net.WebClient wc = new System.Net.WebClient();

            wc.Headers.Add("X-Username: " + this.txtBoxEmail.Text);
            wc.Headers.Add("X-Api-Key: " + this.txtBoxApiKey.Text);

            System.Collections.Specialized.NameValueCollection ps = new System.Collections.Specialized.NameValueCollection();
            ps.Add("datastoreId", this.txtBoxDataStoreId.Text);
            ps.Add(this.txtBoxKey.Text, this.txtBoxValue.Text);

            byte[] resData = wc.UploadValues(url, ps);
            wc.Dispose();

            string resText = System.Text.Encoding.UTF8.GetString(resData);
            this.txtBoxResponse.Text = resText;
        }

        private void btnSubmitReceipt_Click(object sender, EventArgs e)
        {
            string url = "https://api.tierion.com/v1/records/" + this.txtBoxId.Text;

            System.Net.WebClient wc = new System.Net.WebClient();

            wc.Headers.Add("X-Username: " + this.txtBoxEmail.Text);
            wc.Headers.Add("X-Api-Key: " + this.txtBoxApiKey.Text);

            byte[] resData = wc.DownloadData(url);
            wc.Dispose();

            string resText = System.Text.Encoding.UTF8.GetString(resData);
            this.txtBoxResponseId.Text = resText;
        }
    }
}
