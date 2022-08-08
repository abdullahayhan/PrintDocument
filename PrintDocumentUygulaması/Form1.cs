using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrintDocumentUygulaması
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Yazdır_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.Text = "Yazdırma işlemi başladı";
        }

        private void printDocument1_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            this.Text = "Yazdırma işlemi bitti";
        }
        int sayfa_no = 0;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            sayfa_no += 1;
            e.Graphics.DrawString("Sayfa" + sayfa_no.ToString(), new Font("Tahoma", 50, FontStyle.Regular), Brushes.Black, 100, 100);

            if (sayfa_no == 3)
            {
                e.HasMorePages = false;
                sayfa_no = 0;
            }
            else
            {
                e.HasMorePages = true;
            }
        }
    }
}
