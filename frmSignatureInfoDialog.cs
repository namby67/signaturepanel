using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Org.BouncyCastle.X509;
using Org.BouncyCastle.Crypto.Tls;
namespace SNP
{
    public partial class frmSignatureInfoDialog : DevExpress.XtraEditors.XtraForm
    {
        public frmSignatureInfoDialog()
        {
            InitializeComponent();
        }
        public string SignerName { get; set; }
        public string SigningTime { get; set; }
        public string SignerIssuerDN { get; set; }
        public string Startdate { get; set; }
        public string Enddate  { get; set; }
        public string Reason { get; set; }
        private void frmSignatureInfoDialog_Load(object sender, EventArgs e)
        {    
                lblNguoiky.Text = SignerName;
                lblGioky.Text = SigningTime;
                lblDonvicapphep.Text = SignerIssuerDN;
                lblNgaybatdau.Text = Startdate;
                lblngaycapphep.Text = Enddate;
                lblLydo.Text = Reason;
        }
    }
}