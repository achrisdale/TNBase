using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using TNBase.Domain;

namespace TNBase
{
    public partial class FormPrintLabels
    {
        Listener myListener;

        int myIndex = 0;
        public void setupForm(Listener theListener, int startIndex)
        {
            myListener = theListener;
            myIndex = startIndex;
            if (myIndex == 0) { Interaction.MsgBox("Place the label sheets label-side down in the laser printer tray."); }
            else { Interaction.MsgBox("Place the sheet to be printed again in position 5-8 label-side down in the laser printer tray with the top towards you."); }
   //            Interaction.MsgBox("Please choose the correct printer for label printing by right clicking on the printer icon on the next screen - top left picture of printer.");
            printLabels();

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Print labels.
        private void printLabels()
        {
            printPreview.Document = printLabelDoc;
            printPreview.ClientSize = new Size(600, 600);
            printPreview.ShowDialog();
        }

        private void printLabelDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font reportFont = new Font("Times New Roman", 24, FontStyle.Bold);
            Font reportFontSmall = new Font("Times New Roman", 12);
            Font reportFontSmallBold = new Font("Times New Roman", 14, FontStyle.Bold);
            Font reportFontSmallBoldTitles = new Font("Times New Roman", 16, FontStyle.Bold);
            Font reportFontBigBoldTitles = new Font("Times New Roman", 20, FontStyle.Bold);

            Graphics g = e.Graphics;
            var lineHeight = 16;
            var labelContentWidth = 260;
            var spacing = 4;

            int theIndex = myIndex;

            var addressLines = new List<string>
            {
                string.Join(" ", myListener.Title, myListener.Forename, myListener.Surname),
                myListener.Addr1,
                myListener.Addr2,
                myListener.Town,
                myListener.County,
                myListener.Postcode
            }.Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
            /*          Solihull Version
                        for (int value = 0; value <= 3; value++)
                        {
                            int myRow = (int)Math.Ceiling((double)((double)(theIndex + 1) / (double)3)) - 1;
                            int myColumn = theIndex % 3;

                            var initialY = (183 * myRow) + 33;
                            var initialX = (myColumn * 260) + Properties.Settings.Default.LabelXAdjust;
                            theIndex++;

                            g.DrawString("First Class Post", reportFontSmallBoldTitles, Brushes.Black, initialX, initialY);

                            for (int i = 0; i < addressLines.Count; i++)
                            {
                                g.DrawString(addressLines[i], reportFontSmall, Brushes.Black, new RectangleF(initialX, initialY + lineHeight * (i + 1) + spacing, labelContentWidth, lineHeight), new StringFormat(StringFormatFlags.NoWrap));
                            }

                            BarcodeLib.Barcode b = new BarcodeLib.Barcode();
                            Image newImage = b.Encode(BarcodeLib.TYPE.CODE39, myListener.Wallet.ToString(), Color.Black, Color.White, 150, 34);

                            e.Graphics.DrawImage(newImage, initialX, initialY + lineHeight * 7 + spacing * 2, 150, 34);

                            g.DrawString(myListener.Wallet.ToString(), reportFontBigBoldTitles, Brushes.Black, initialX + 142, initialY + lineHeight * 7 + spacing * 3);
                        }
            */
            //          Birmingham version
            for (int value = 0; value <= 3; value++)     //Prints 4 copies
            {
                int myRow = (int)Math.Ceiling((double)((double)(theIndex + 1) / (double)2)) - 1;
                int myColumn = theIndex % 2;
                var initialY = (214 * myRow) + 58;
                var initialX = (myColumn * 360) + 98;
                theIndex++;

                g.DrawString("Articles for the Blind", reportFontSmallBoldTitles, Brushes.Black, initialX, initialY);
                g.DrawString("BTNBVI", reportFontSmallBold, Brushes.Black, initialX + 52, initialY + 24);

                for (int i = 0; i < addressLines.Count; i++)
                {
                    g.DrawString(addressLines[i], reportFontSmall, Brushes.Black, new RectangleF(initialX, initialY + lineHeight * (i + 2) + spacing * 2, labelContentWidth, lineHeight), new StringFormat(StringFormatFlags.NoWrap));
                }

                BarcodeLib.Barcode b = new BarcodeLib.Barcode();
                Image newImage = b.Encode(BarcodeLib.TYPE.CODE39, myListener.Wallet.ToString(), Color.Black, Color.White, 180, 30);

                e.Graphics.DrawImage(newImage, initialX, initialY + lineHeight * 7 + spacing * 3, 180, 30);

                g.DrawString(myListener.Wallet.ToString(), reportFontBigBoldTitles, Brushes.Black, initialX + 172, initialY + lineHeight * 7 + spacing * 3);

            }


        }
        public FormPrintLabels()
        {
            InitializeComponent();
        }

        private void FormPrintLabels_Load(object sender, EventArgs e)
        {

        }
    }
}
