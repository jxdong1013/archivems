using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ArchiveStation.Bean;

namespace ArchiveStation
{
    public partial class PageControl : UserControl
    {
        public event EventHandler onFirst;
        public event EventHandler<PageEventArgs> onPre;
        public event EventHandler<PageEventArgs> onNext;
        public event EventHandler<PageEventArgs> onLast;
        public event EventHandler<PageEventArgs> onGo;
        public PageBase Page;

        public void SetPage( PageBase page)
        {
            this.Page = page;

            btnFirst.Tag = 0;
            btnPre.Tag =page.PageIdx - 1;
            btnNext.Tag = Page.PageIdx + 1;
            btnLast.Tag = Page.TotalPages - 1;
            txtPage.Text = (Page.PageIdx + 1) >= Page.TotalPages ? Page.TotalPages.ToString() : (Page.PageIdx + 1).ToString();

            lblTotal.Text = "共" + Page.TotalPages + "页/" + Page.TotalRecords + "条";


            if (Page.PageIdx == 0)
            {
                btnFirst.Enabled = false;
            }
            else
            {
                btnFirst.Enabled = true;
            }

            if (Page.PageIdx > 0)
            {
                btnPre.Enabled = true;
            }
            else
            {
                btnPre.Enabled = false;
            }


            if (Page.TotalPages > 0 && Page.PageIdx + 1 < Page.TotalPages)
            {
                btnNext.Enabled = true;
            }
            else
            {
                btnNext.Enabled = false;
            }

            if (Page.PageIdx == Page.TotalPages - 1)
            {
                btnLast.Enabled = false;
            }
            else
            {
                btnLast.Enabled = true;
            }

        }


        public PageControl()
        {
            InitializeComponent();
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            if (onFirst != null)
            {
                onFirst(sender, e);
            }
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            if (onPre != null)
            {
                int pageidx = 0;
                if (btnPre.Tag == null)
                {
                    pageidx = 0;
                }
                else
                {
                    int.TryParse(btnPre.Tag.ToString(), out pageidx);
                }

               
                PageEventArgs pe = new PageEventArgs();
                pe.pageidx = pageidx;
                
                onPre(sender, pe);
            }
        }

        private void btnPage_Click(object sender, EventArgs e)
        {
            if (onGo != null)
            {
                int pageidx = 0;
                if (txtPage.Text == null)
                {
                    txtPage.Text = "1";
                    pageidx = 1;
                }
                else
                {
                    int.TryParse(txtPage.Text.ToString(), out pageidx);
                }
                pageidx--;
                if (pageidx < 0) pageidx = 0;

                PageEventArgs pe = new PageEventArgs();
                pe.pageidx = pageidx;
                onGo(sender, pe);
            }

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (onNext != null)
            {
             
                int pageidx = 0;
                if (btnNext.Tag == null)
                {
                    pageidx = 0;
                }
                else
                {
                    int.TryParse(btnNext.Tag.ToString(), out pageidx);
                }

                //String key = txtKey.Text.Trim();
                PageEventArgs pe = new PageEventArgs();
                pe.pageidx = pageidx;

           
                onNext(sender, pe);
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            if (onLast != null)
            {
                int pageidx = 0;
                if (btnLast.Tag == null)
                {
                    pageidx = 0;
                }
                else
                {
                    int.TryParse(btnLast.Tag.ToString(), out pageidx);
                }

                PageEventArgs pe = new PageEventArgs();
                pe.pageidx = pageidx;

                onLast(sender, pe);
            }
        }

        private void txtPage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (onGo != null)
                {
                    int pageidx = 0;
                    if (txtPage.Text == null)
                    {
                        txtPage.Text = "1";
                        pageidx = 1;
                    }
                    else
                    {
                        int.TryParse(txtPage.Text.ToString(), out pageidx);
                    }
                    pageidx--;
                    if (pageidx < 0) pageidx = 0;

                    
                    PageEventArgs pe = new PageEventArgs();
                    pe.pageidx = pageidx;
                    onGo(sender, pe);
                }
            }
        }
    }

 public class PageEventArgs : EventArgs
 {
     public int pageidx{get;set;}
 }

}
