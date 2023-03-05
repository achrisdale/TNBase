using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TNBase.Forms
{
    public partial class FormSetDatabaseEncryptionKey : Form
    {
        public FormSetDatabaseEncryptionKey()
        {
            InitializeComponent();
        }

        public string Password { get; internal set; }
    }
}
