using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BULs;
using DTOs;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace ATM.GUI
{
    public partial class frmPrintReceipt : Form
    {
        frmMain _main;
        CashTransferTransaction _cash;
        CashTransferBUL transferBUL = new CashTransferBUL();
        LogDTO log = new LogDTO();
        
        public frmPrintReceipt()
        {
            InitializeComponent();
        }

        public frmPrintReceipt(frmMain main, CashTransferTransaction cash)
        {
            InitializeComponent();
            _main = main;
            _cash = cash;
        }

        private void frmPrintReceipt_Shown(object sender, EventArgs e)
        {
            if (_main != null)
                _main.Hide();
        }

        private void frmPrintReceipt_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_main != null)
                _main.Close();
        }

        private void btnRightThree_Click(object sender, EventArgs e)
        {
            log = transferBUL.GetTransferLog(_cash.LogId);
            _cash.LogId = _cash.LogId;
            _cash.LogDate = log.LogDate;

        }

        private void PrintReceipt()
        {
            FileStream fs = new
                FileStream(@"F:\C#\ATMSystem\ATM\Resources\cash_transfer.pdf",
                            FileMode.Create,
                            FileAccess.Write,
                            FileShare.None);
            iTextSharp.text.Rectangle rec =
                new iTextSharp.text.Rectangle(240, 340);
            rec.BackgroundColor = new BaseColor(System.Drawing.Color.WhiteSmoke);
            Document doc = new Document(rec, 14, 14, 22.6f, 22.6f);
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            doc.Open();
            iTextSharp.text.Font headerFont = FontFactory.GetFont("Verdana", 8);
            iTextSharp.text.Font emptyFont = FontFactory.GetFont("Verdana", 5);
            string imageURL = @"F:\C#\ATMSystem\ATM\Resources\bidv_logo.png";
            iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(imageURL);
            jpg.Alignment = Element.ALIGN_CENTER;
            jpg.ScaleToFit(240f, 120f);
            Paragraph receiptNamePara =
                new Paragraph("BIEN LAI GIAO DICH CHUYEN KHOAN", headerFont);
            Paragraph emptyPara = new Paragraph("    ", emptyFont);
            receiptNamePara.Alignment = Element.ALIGN_CENTER;
            doc.Add(jpg);
            doc.Add(receiptNamePara);
            doc.Add(emptyPara);
            PdfPTable table = new PdfPTable(3);
            table.HorizontalAlignment = Element.ALIGN_CENTER;
            table.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            table.WidthPercentage = 95f;
            Phrase pHNgay = new Phrase("NGAY", headerFont);
            Phrase pHGio = new Phrase("       GIO", headerFont);
            Phrase pHATMID = new Phrase("ATMID", headerFont);
            Phrase pNgay =
                new Phrase(_cash.LogDate.ToString("dd-MM-yyyy"),
                            headerFont);
            Phrase pGio = new Phrase(String.Format("      {0}",
                                        _cash.LogDate.ToString("HH:mm")),
                                     headerFont);
            Phrase pATMID = new Phrase(_cash.ATMId, headerFont);
            string sendCardNo =
                _cash.
                    SenderCardNo.Remove(2, 8).Insert(2, "XXXXXXXX");
            PdfPCell cCardNo =
                new PdfPCell(
                    new Phrase(
                        String.Format("SO THE                       :  {0}", sendCardNo),
                        headerFont));
            cCardNo.Colspan = 3;
            cCardNo.Border = iTextSharp.text.Rectangle.NO_BORDER;
            PdfPCell cTransNo =
                new PdfPCell(
                    new Phrase(
                        String.Format("SO GD                         :  {0}",
                                        _cash.LogId),
                        headerFont));
            cTransNo.Colspan = 3;
            cTransNo.Border = iTextSharp.text.Rectangle.NO_BORDER;
            PdfPCell cAvailBal =
                new PdfPCell(
                    new Phrase(
                        String.Format("SO DU KHA DUNG     :  1,570,056",
                                        _cash.AvailBalance),
                        headerFont));
            cAvailBal.Colspan = 3;
            cAvailBal.Border = iTextSharp.text.Rectangle.NO_BORDER;
            PdfPCell cSendAccNo =
                new PdfPCell(
                    new Phrase(String.Format("TK CHUYEN TIEN      :  {0}",
                                                _cash.ReceiverAccountNo),
                                headerFont));
            cSendAccNo.Colspan = 3;
            cSendAccNo.Border = iTextSharp.text.Rectangle.NO_BORDER;
            PdfPCell cRecAccNo =
                new PdfPCell(
                    new Phrase(
                        String.Format("TK NHAN TIEN           :  {0}",
                                       _cash.ReceiverAccountNo),
                        headerFont));
            cRecAccNo.Colspan = 3;
            cRecAccNo.Border = iTextSharp.text.Rectangle.NO_BORDER;
            PdfPCell cRecName = new PdfPCell(
                new Phrase(
                    String.Format("TEN TK NHAN TIEN   :  {0}",
                                    _cash.ReceiverName),
                    headerFont));
            cRecName.Colspan = 3;
            cRecName.Border = iTextSharp.text.Rectangle.NO_BORDER;
            PdfPCell cAmount =
                new PdfPCell(
                    new Phrase(
                        String.Format("SO TIEN                      :  {0} VND",
                            _cash.Amount),
                        headerFont));
            cAmount.Colspan = 3;
            cAmount.Border = iTextSharp.text.Rectangle.NO_BORDER;
            PdfPCell cFee =
                new PdfPCell(
                    new Phrase(
                        String.Format("PHI DICH VU:  {0} VND",
                                                _cash.TransferFee),
                        headerFont));
            cFee.Colspan = 3;
            cFee.Border = iTextSharp.text.Rectangle.NO_BORDER;
            PdfPCell cVAT =
                new PdfPCell(
                    new Phrase("(DA BAO GOM VAT)",
                    headerFont));
            cVAT.Colspan = 3;
            cVAT.Border = iTextSharp.text.Rectangle.NO_BORDER;
            cVAT.Rowspan = 5;
            table.AddCell(pHNgay);
            table.AddCell(pHGio);
            table.AddCell(pHATMID);
            table.AddCell(pNgay);
            table.AddCell(pGio);
            table.AddCell(pATMID);
            table.AddCell(cCardNo);
            table.AddCell(cTransNo);
            table.AddCell(cAvailBal);
            table.AddCell(cSendAccNo);
            table.AddCell(cRecAccNo);
            table.AddCell(cRecName);
            table.AddCell(cAmount);
            table.AddCell(cFee);
            table.AddCell(cVAT);
            doc.Add(table);

            FileStream fs1 =
                new FileStream(@"F:\C#\ATMSystem\ATM\Resources\watermark.png",
                                FileMode.Open);
            iTextSharp.text.Image watermark =
                iTextSharp.text.Image.GetInstance(System.Drawing.Image.FromStream(fs1),
                                                    ImageFormat.Png);
            watermark.ScalePercent(50f);
            watermark.SetAbsolutePosition(60f, 70f);
            fs1.Close();
            FileStream fs2 =
                new FileStream(@"F:\C#\ATMSystem\ATM\Resources\footer.png",
                                FileMode.Open);


            iTextSharp.text.Image footer =
                iTextSharp.text.Image.GetInstance(System.Drawing.Image.FromStream(fs2),
                                                    ImageFormat.Png);
            footer.ScalePercent(75f);
            footer.SetAbsolutePosition(3f, 20f);
            fs2.Close();
            doc.Add(footer);
            doc.Add(watermark);
            doc.Close();
        }
    }
}
