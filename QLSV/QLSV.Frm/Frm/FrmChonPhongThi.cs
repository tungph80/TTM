﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using QLSV.Core.Domain;
using QLSV.Core.LINQ;
using QLSV.Core.Utils.Core;
using ColumnStyle = Infragistics.Win.UltraWinGrid.ColumnStyle;

namespace QLSV.Frm.Frm
{
    public partial class FrmChonPhongThi : Form
    {
        private readonly IList<KTPhong> _listPhanPhong = new List<KTPhong>();
        private int _tongsucchua;
        private readonly int _idKythi;
        private FrmLoadding _loading = new FrmLoadding();
        private readonly BackgroundWorker _bgwInsert;

        public FrmChonPhongThi(int idkythi)
        {
            InitializeComponent();
            _idKythi = idkythi;
            _bgwInsert = new BackgroundWorker();
            _bgwInsert.DoWork += bgwInsert_DoWork;
            _bgwInsert.RunWorkerCompleted += bgwInsert_RunWorkerCompleted;
        }

        private void dgv_DanhSach_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            var band = e.Layout.Bands[0];
            band.ColHeadersVisible = false;
            band.Columns["ID"].Hidden = true;
            band.Columns["Chon"].Style = ColumnStyle.CheckBox;

            band.Override.CellAppearance.TextHAlign = HAlign.Center;
            band.Columns["TenPhong"].CellActivation = Activation.NoEdit;
            band.Columns["SucChua"].CellActivation = Activation.NoEdit;
        }

        private void FrmChonPhongThi_Load(object sender, EventArgs e)
        {
            dgv_DanhSach.DataSource = SearchData.LoadPhong(_idKythi);
        }

        private void dgv_DanhSach_CellChange(object sender, CellEventArgs e)
        {
            if (e.Cell.Column.Key != "Chon") return;
            var b = bool.Parse(e.Cell.Row.Cells["Chon"].Text);
            if (b)
            {
                _tongsucchua = _tongsucchua + int.Parse(e.Cell.Row.Cells["SucChua"].Text);
                e.Cell.Row.Appearance.BackColor = Color.LightCyan;
            }
            else
            {
                e.Cell.Row.Appearance.BackColor = Color.White;
                _tongsucchua = _tongsucchua - int.Parse(e.Cell.Row.Cells["SucChua"].Text);
            }

            lbtong.Text = @"Tổng sức chứa: " + _tongsucchua + @" sinh viên.";
        }

        private void ckbChon_CheckedChanged(object sender, EventArgs e)
        {
            _tongsucchua = 0;
            if (ckbChon.Checked)
            {
                foreach (var row in dgv_DanhSach.Rows)
                {
                    row.Cells["Chon"].Value = "true";
                    row.Appearance.BackColor = Color.LightCyan;
                    _tongsucchua = _tongsucchua + int.Parse(row.Cells["SucChua"].Text);
                    
                }
                lbtong.Text = @"Tổng sức chứa: " + _tongsucchua + @" sinh viên.";
            }
            else
            {
                foreach (var row in dgv_DanhSach.Rows)
                {
                    row.Cells["Chon"].Value = "false";
                    row.Appearance.BackColor = Color.White;
                }
                lbtong.Text = @"Tổng sức chứa: " + _tongsucchua + @" sinh viên.";
            }
        }

        private void Xepphong()
        {
            var save = new SqlBulkCopy();
            var tb = save.tbKTPhong();
            foreach (var row in dgv_DanhSach.Rows)
            {
                if (!bool.Parse(row.Cells["Chon"].Text)) continue;
                tb.Rows.Add(row.Cells["ID"].Text, _idKythi, 0);
            }
            save.sp_InsertUpdate("sp_InsertKTPhong", "@tbl", tb);
            Invoke((Action)(() => MessageBox.Show(@"Lưu lại thành công", @"Thông báo")));
            Invoke((Action)(Close));
        }

        private void Luu()
        {
            _bgwInsert.RunWorkerAsync();
            OnShowDialog("Đang lưu dữ liệu");
        }

        #region BackgroundWorker

        private void bgwInsert_DoWork(object sender, DoWorkEventArgs e)
        {
            Xepphong();
        }

        private void bgwInsert_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            OnCloseDialog();
        }

        private void OnShowDialog(string msg)
        {
            try
            {
                _loading = new FrmLoadding();
                _loading.Update(msg);
                _loading.ShowDialog();
            }
            catch (Exception ex)
            {
                Log2File.LogExceptionToFile(ex);
            }
        }

        private void OnCloseDialog()
        {
            try
            {
                if (_loading != null)
                {
                    _loading.Invoke((Action)(() =>
                    {
                        _loading.Close();
                        _loading = null;
                    }));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Log2File.LogExceptionToFile(ex);
            }
        }

        #endregion

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case (Keys.F5):
                    Luu();
                    break;
                case (Keys.Escape):
                    Close();
                    break;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Luu();
        }
    }
}
