using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Resident_evil_msg_editor
{
    public partial class Tela1 : Form
    {
        public Tela1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Open Title";
            ofd.Filter = "msg file|*.msg *.MSG .*MSG2|MSG|*.MSG|MSG2|* .MSG2";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK);
            {
                MessageBox.Show("msg reconhecido");
                MessageBox.Show("msg não reconhecido");                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save Title";
            sfd.Filter = "msg file|*.msg *.MSG .*MSG2|MSG|*.MSG|MSG2|* .MSG2";
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK);
            {
                MessageBox.Show("msg salvo com sucesso");
                MessageBox.Show("msg foi salvo sem sucesso");
            }
        }
    }
}
