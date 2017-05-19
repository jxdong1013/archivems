using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ArchiveStation.Bean;

namespace ArchiveStation
{
    public partial class FormQuery : FormLabelConfig
    {
        public FormQuery()
        {
            InitializeComponent();
        }


        private void FormQuery_Load(object sender, EventArgs e)
        {
        }


        public List<ArchiveBean> SelectedRecords
        {
            get
            {
                dataGridView1.EndEdit();
                List<ArchiveBean> records = new List<ArchiveBean>();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    object obj = row.Cells["ckbselect"].Value;
                    if (obj == null) continue;
                    bool isckb;
                    bool.TryParse(obj.ToString(), out isckb);
                    if (isckb == false) continue;
                    obj = row.Cells["id"].Value;
                    if (obj == null) continue;
                    int id;
                    int.TryParse(obj.ToString(), out id);
                    records.Add( row.DataBoundItem as ArchiveBean);
                }
                return records;

            }
        }

    }
}
