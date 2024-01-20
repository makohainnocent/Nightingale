using System.Windows.Forms;
using System;
using static Nightingale.Common.Functions;

namespace Nightingale
{
    public partial class FormMain : Form
    {
        public enum loginResultStatuses : byte
        {
            success,
            failed,
            canceled
            
        }

        private string loginResult;


        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            var formLogin = new FormLogin();

            

            while (true)
            {
                var result=formLogin.ShowDialog(this);
                if (result == DialogResult.Yes)
                {
                    break;
                }else if (result == DialogResult.Cancel) {
                    closeApplication();
                    break;
                }
            };

        }

    }
}
