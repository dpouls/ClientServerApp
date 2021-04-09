using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientApp
{
    public partial class ClientForm : Form
    {
        SynchronousSocketClient ssc = new SynchronousSocketClient();
        public ClientForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// nothing, but he didnt delete it in the video so I didnt either. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClientForm_Load(object sender, EventArgs e)
        {
           //he cut out the code that was here and placed it at the top of the class 
            
        }
        /// <summary>
        /// establishes stream and sends the users input to the server 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            TxtBoxResponse.Text = ssc.ContactServer(TxtBoxRequest.Text);
        }
    }
}
