using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Pdf;
using DevExpress.Pdf.ContentGeneration.Interop;
using DevExpress.XtraPdfViewer;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace SNP
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        string pdfPath = "C:\\Users\\Administrator\\Downloads\\pdf_Document_Signed_01-merged.pdf";
        Dictionary<string, AcroFields.FieldPosition> signaturePositions = new Dictionary<string, AcroFields.FieldPosition>();
        string clickedSignatureName = null;
        private void pdfSNP_Load(object sender, EventArgs e)
        {
            MemoryStream memoryStream = new MemoryStream();
            using (FileStream fileStream = new FileStream(pdfPath, FileMode.Open, FileAccess.Read))
            {
                fileStream.CopyTo(memoryStream);
            }
            memoryStream.Position = 0;
            pdfSNP.LoadDocument(memoryStream);
        }
        private void napSNP2_Paint(object sender, PaintEventArgs e)
        {
            using (FileStream fileStream = new FileStream(pdfPath, FileMode.Open, FileAccess.Read))
            {
                byte[] bytes = new byte[fileStream.Length];
                fileStream.Read(bytes, 0, (int)fileStream.Length);
                MemoryStream memoryStream = new MemoryStream(bytes);
                PdfReader pdfReader = new PdfReader(memoryStream);
                AcroFields acroFields = pdfReader.AcroFields;
                var names = acroFields.GetSignatureNames();
                StringBuilder signatureInfo = new StringBuilder();
                int rev = 1;
                int yOffset = 10;
                foreach (string name in names)
                {
                    var signature = acroFields.VerifySignature(name);
                    Org.BouncyCastle.X509.X509Certificate[] certificates = signature.Certificates;
                    string signerName = certificates[0].SubjectDN.GetValueList(Org.BouncyCastle.Asn1.X509.X509Name.CN)[0].ToString();
                    string signatureText = $"REV. {rev++}: Signer by {signerName}";
                    signatureInfo.AppendLine(signatureText);
                    if (name == clickedSignatureName)
                    {
                        e.Graphics.DrawString(signatureText, this.Font, Brushes.Red, new PointF(10, yOffset));
                    }
                    else
                    {
                        e.Graphics.DrawString(signatureText, this.Font, Brushes.Black, new PointF(10, yOffset));
                    }
                    float currentYOffset = yOffset;
                    AcroFields.FieldPosition pos = acroFields.GetFieldPositions(name).First();
                    signaturePositions[name] = pos;
                    napSNP2.Click += (s, args) =>
                    {
                        Point mousePoint = napSNP2.PointToClient(Cursor.Position);
                        if (mousePoint.Y >= currentYOffset && mousePoint.Y <= currentYOffset + this.Font.Height)
                        {
                            if (signaturePositions.ContainsKey(name))
                            {
                                AcroFields.FieldPosition signaturePos = signaturePositions[name];
                                signaturePos.position.BackgroundColor = new BaseColor(Color.Red);
                                ScrollToPosition(signaturePos.page, signaturePos.position.Right, signaturePos.position.Left, signaturePos.position.Top, signaturePos.position.Bottom);
                                ShowSignatureInfo(name);
                            }
                        }
                    };
                    yOffset += this.Font.Height + 5;
                }
            }
        }
        private void ScrollToPosition(int page, float r, float l, float t, float b)
        {
            pdfSNP.CurrentPageNumber = page;
            int xPosition = (int)(r * pdfSNP.MinZoomFactor / 100);
            int yPosition = (int)(l * pdfSNP.MinZoomFactor / 100);
            pdfSNP.ScrollHorizontal(xPosition);
            pdfSNP.ScrollVertical(yPosition);
        }
        private void pdfSNP_Click(object sender, EventArgs e)
        {
            Point mousePoint = pdfSNP.PointToClient(Cursor.Position);
            var documentPosition = pdfSNP.GetDocumentPosition(mousePoint, true);
            if (documentPosition != null)
            {
                PdfPoint docPoint = documentPosition.Point;
                int clickedPageIndex = documentPosition.PageNumber;
                foreach (var signaturePos in (from ds in signaturePositions where ds.Value.page == clickedPageIndex select ds).ToList())
                {
                    var position = signaturePos.Value.position;
                    if (
                        docPoint.X >= position.Left &&
                        docPoint.Y <= position.Top &&
                        docPoint.Y >= position.Bottom &&
                        docPoint.X <= position.Right)
                    {
                        clickedSignatureName = signaturePos.Key;
                        ShowSignatureInfo(signaturePos.Key);
                        napSNP2.Invalidate();
                        break;
                    }
                }
            }
        }
        private void ShowSignatureInfo(string signatureName)
        {
            using (FileStream fileStream = new FileStream(pdfPath, FileMode.Open, FileAccess.Read))
            {
                byte[] bytes = new byte[fileStream.Length];
                fileStream.Read(bytes, 0, (int)fileStream.Length);
                MemoryStream memoryStream = new MemoryStream(bytes);
                PdfReader pdfReader = new PdfReader(memoryStream);
                AcroFields acroFields = pdfReader.AcroFields;
                var signature = acroFields.VerifySignature(signatureName);
                Org.BouncyCastle.X509.X509Certificate[] certificates = signature.Certificates;
                string signerName = certificates[0].SubjectDN.GetValueList(Org.BouncyCastle.Asn1.X509.X509Name.CN)[0].ToString();
                string signingTime = signature.SignDate.ToString("dd/MM/yyyy HH:mm:ss");
                string Reason = signature.Reason.ToString();
                string signerIssuerDN = certificates[0].IssuerDN.GetValueList(Org.BouncyCastle.Asn1.X509.X509Name.CN)[0].ToString();
                string startdate = certificates[0].NotBefore.ToString("dd/MM/yyyy HH:mm:ss");
                string enddte = certificates[0].NotAfter.ToString("dd/MM/yyyy HH:mm:ss");
                bool isVerified = signature.Verify();
                if (!isVerified)
                {
                    MessageBox.Show("- Có một số lỗi về định dạng hoặc thông tin chứa trong chữ ký\r\n- Danh tính của người ký chưa được xác minh", "Lỗi trong quá trình xác minh chữ ký.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                frmSignatureInfoDialog dialog = new frmSignatureInfoDialog
                {
                    SignerName = signerName,
                    SigningTime = signingTime,
                    SignerIssuerDN = signerIssuerDN,
                    Startdate = startdate,
                    Enddate= enddte,
                    Reason= Reason
                };
                dialog.ShowDialog(); ;
            }
        }
        private void napSNP2_Click(object sender, EventArgs e)
        {
            pdfSNP_Click(sender, e);
        }
    }
}
