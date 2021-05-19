using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WoWs_Randomizer.forms
{
    public partial class MessageGenerator : Form
    {
        public MessageGenerator()
        {
            InitializeComponent();
            Console.WriteLine("MachineName: {0}", Environment.MachineName);
            Controls["id"].Text = "";
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            Guid myuuid = Guid.NewGuid();
            string uuid = myuuid.ToString();
            Controls["id"].Text = uuid;

            string output = "{";
            output += Environment.NewLine;

            output += "\t\"status\":";
            output += "\"" + this.status.Text + "\",";
            output += Environment.NewLine;

            output += "\t\"messageid\":";
            output += "\"" + this.id.Text + "\",";
            output += Environment.NewLine;

            output += "\t\"datetime\":";
            output += "\"" + this.startdate.Value.ToString("yyyy-MM-dd") + "\",";
            output += Environment.NewLine;

            output += "\t\"enddate\":";
            output += "\"" + this.enddate.Value.ToString("yyyy-MM-dd") + "\",";
            output += Environment.NewLine;

            output += "\t\"message\":";
            output += "\"" + this.message.Text + "\",";
            output += Environment.NewLine;

            output += "\t\"link\":";
            output += "\"" + this.link.Text + "\",";
            output += Environment.NewLine;

            output += "\t\"images\":";
            output += "{";
            //ENTER IMAGES HERE
            //"imagesOLD":{"test":"a","tst2":"b"}
            output += "}";
            output += Environment.NewLine;

            output += "}";

            this.result.Text = output;

        }
    }
}
