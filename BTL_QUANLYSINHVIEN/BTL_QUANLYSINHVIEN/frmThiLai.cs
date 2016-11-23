using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;

namespace BTL_QUANLYSINHVIEN
{
    public partial class frmThiLai : Form
    {
        public string tenMh;
        public frmThiLai()
        {
            InitializeComponent();
        }

        private void btnDS_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tenMh = cboMH.Text;
            load_DS();
        }
        public void load_DS()
        {
            try
            {
                int t = gvSV.RowCount;
                for (int i = 0; i < t; i++)
                    bindingSource1.RemoveAt(0);
                bindingSource1.DataSource = MonHoc_BUS.DSThiLai(tenMh);
                gcSV.DataSource = bindingSource1;
            }
            catch
            {
                MessageBox.Show("Load không thành công!");
            }
        }
        public void loadInfo()
        {
            DataTable dtb1 = MonHoc_BUS.DSMH();
            int t = cboMH.Items.Count;
            for (int i = 0; i < t; i++)
            {
                cboMH.Items.RemoveAt(0);
            }
            for (int i = 0; i < dtb1.Rows.Count; i++)
            {
                string name = dtb1.Rows[i][0].ToString();
                cboMH.Items.Add(name);
            }
            cboMH.SelectedIndex = 0;
            tenMh = cboMH.Text;
        }
    }
}
