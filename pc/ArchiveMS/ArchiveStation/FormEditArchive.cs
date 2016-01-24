using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ArchiveStation
{
    public partial class FormEditArchive : FormBase
    {
        int _id = 0;
        public FormEditArchive( int  id )
        {
            InitializeComponent();

            this._id = id;
        }
    }
}
