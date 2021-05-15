using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Staj5
{
    public partial class Ayarlar : Form
    {
        public string veritabani1 { get; set; } = "";
        public string veritabani2 { get; set; } = "";

        public Ayarlar()
        {
            InitializeComponent();
            Veritabani1LBL.Text = veritabani1;
            Veritabani2LBL.Text = veritabani2;
        }
    }
}
