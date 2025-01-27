﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using PerpetuumSoft.Reporting.View;
using QLSV.Core.Domain;
using QLSV.Core.LINQ;
using QLSV.Core.Utils.Core;
using QLSV.Frm.Base;
using QLSV.Frm.Frm;
using Color = System.Drawing.Color;

namespace QLSV.Frm.FrmUserControl
{
    public partial class Frm_108_ChonSinhVien : FunctionControlHasGrid
    {
        private readonly IList<KTPhong> _listKtPhong = new List<KTPhong>();
        private readonly IList<XepPhong> _listXepPhong = new List<XepPhong>();
        private readonly int _idkythi;
        private readonly FrmTimkiem _frmTimkiem;
        private UltraGridRow _newRow;

        public Frm_108_ChonSinhVien(int idkythi)
        {
            InitializeComponent();
            _idkythi = idkythi;
            _frmTimkiem = new FrmTimkiem();
            _frmTimkiem.Timkiemsinhvien += Timkiemsinhvien;
        }

        protected virtual DataTable GetTable()
        {
            var table = new DataTable();
            table.Columns.Add("MaSV", typeof(int));
            table.Columns.Add("HoSV", typeof(string));
            table.Columns.Add("TenSV", typeof(string));
            table.Columns.Add("NgaySinh", typeof(string));
            table.Columns.Add("Lop", typeof(string));
            return table;
        }

        protected virtual void LoadGrid()
        {
            try
            {
                IdDelete.Clear();
                _listKtPhong.Clear();
                _listXepPhong.Clear();
                dgv_DanhSach.DataSource = LoadData.Load(12, _idkythi);
            }
            catch (Exception ex)
            {
                Log2File.LogExceptionToFile(ex);
            }
        }

        protected override void InsertRow()
        {
            var frm = new FrmChonSv(_idkythi);
            frm.ShowDialog();
            LoadGrid();
        }

        protected override void DeleteRow()
        {
            try
            {
                bool xoa = false;
                if (dgv_DanhSach.Selected.Rows.Count > 0)
                {
                    if (DialogResult.Yes ==
                        MessageBox.Show(FormResource.msgHoixoa, FormResource.MsgCaption, MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question))
                    {
                        foreach (var row in dgv_DanhSach.Selected.Rows)
                        {
                            var masv = row.Cells["MaSV"].Text;
                            var idPhong = row.Cells["IdPhong"].Text;
                            if (!string.IsNullOrEmpty(idPhong))
                            {
                                var ktp = new KTPhong
                                {
                                    IdKyThi = _idkythi,
                                    IdPhong = int.Parse(idPhong)
                                };
                                _listKtPhong.Add(ktp);
                            }
                            var xp = new XepPhong
                            {
                                IdKyThi = _idkythi,
                                IdSV = int.Parse(masv)
                            };
                            _listXepPhong.Add(xp);
                        }
                        DeleteAndUpdate = true;
                        dgv_DanhSach.DeleteSelectedRows(false);
                        xoa = true;
                    }
                }
                else if (dgv_DanhSach.ActiveRow != null)
                {
                    if (DialogResult.Yes ==
                        MessageBox.Show(FormResource.msgHoixoa, FormResource.MsgCaption, MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question))
                    {
                        var masv = dgv_DanhSach.ActiveRow.Cells["MaSV"].Text;
                        var idPhong = dgv_DanhSach.ActiveRow.Cells["IdPhong"].Text;
                        if (!string.IsNullOrEmpty(idPhong))
                        {
                            var ktp = new KTPhong
                            {
                                IdKyThi = _idkythi,
                                IdPhong = int.Parse(idPhong)
                            };
                            _listKtPhong.Add(ktp);
                        }
                        var xp = new XepPhong
                        {
                            IdKyThi = _idkythi,
                            IdSV = int.Parse(masv)
                        };
                        _listXepPhong.Add(xp);
                        DeleteAndUpdate = true;
                        dgv_DanhSach.ActiveRow.Delete(false);
                        xoa = true;
                    }
                }
                UpdateData.UpdateGiamSiSo(_listKtPhong);
                DeleteData.XoaXepPhong(_listXepPhong);
                if (xoa)
                {
                    MessageBox.Show(@"Xóa dữ liệu thành công.", @"Thông báo");
                }
                LoadGrid();
            }
            catch (Exception ex)
            {
                Log2File.LogExceptionToFile(ex);
            }
        }

        protected override void XoaDetail()
        {
            try
            {
                DeleteData.Xoa("XEPPHONG", _idkythi);
                UpdateData.UpdateKtPhong(_idkythi);
                LoadGrid();
            }
            catch (Exception ex)
            {
                Log2File.LogExceptionToFile(ex);
            }
        }

        /// <summary>
        /// Hàm lấy dữ liệu từ file excel
        /// </summary>
        public void Napdulieu()
        {
            try
            {
                var frmNapDuLieu = new FrmNDLSinhVien(GetTable(),1);
                frmNapDuLieu.ShowDialog();
                var resultValue = frmNapDuLieu.ResultValue;
                var tbsvError = _save.sp_checkData("sp_CheckSV", "@tbl", resultValue);
                if (resultValue == null || resultValue.Rows.Count == 0) return;
                if (tbsvError.Rows.Count > 0)
                {
                    var text = @"Thao tác không hoành thành vì có "+ tbsvError.Rows.Count +@" sv đăng ký dự thi chưa có trong từ điển";
                    MessageBox.Show(text, FormResource.MsgCaption);
                    RptView("danhsachsinhvien", tbsvError);
                }
                else
                {
                    var tbxp = _save.tbXepPhong();
                    foreach (DataRow row in resultValue.Rows)
                    {
                        tbxp.Rows.Add(row["MaSV"],_idkythi);
                    }
                    _save.sp_InsertUpdate("sp_InsertXepPhong","@tbl", tbxp);
                    LoadGrid();
                    MessageBox.Show(tbxp.Rows.Count +@" Sinh viên đã được inport thành công.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Thao tác thất bại",FormResource.MsgCaption);
                Log2File.LogExceptionToFile(ex);
            }
        }

        private void RptView(string rptname, DataTable table, string source = "danhsach")
        {
            try
            {
                reportManager1.DataSources.Clear();
                reportManager1.DataSources.Add(source, table);
                rptdanhsachsinhvien.FilePath = Application.StartupPath + @"\Reports\" + rptname + ".rst";
                rptdanhsachsinhvien.Prepare();
                var previewForm = new PreviewForm(rptdanhsachsinhvien)
                {
                    WindowState = FormWindowState.Maximized
                };
                previewForm.Show();
            }
            catch (Exception ex)
            {
                Log2File.LogExceptionToFile(ex);
            }
        }

        private void Frm_ChonSinhVien_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void dgv_DanhSach_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            var band = e.Layout.Bands[0];
            band.Override.HeaderAppearance.FontData.Bold = DefaultableBoolean.True;
            band.Override.HeaderAppearance.FontData.SizeInPoints = 10;

            #region Caption
            band.Groups.Clear();
            var columns = band.Columns;
            band.ColHeadersVisible = false;
            var group5 = band.Groups.Add("STT");
            var group0 = band.Groups.Add("Mã SV");
            var group1 = band.Groups.Add("Họ và tên");
            var group2 = band.Groups.Add("Ngày sinh");
            var group3 = band.Groups.Add("Lớp");
            columns["STT"].Group = group5;
            columns["MaSV"].Group = group0;
            columns["HoSV"].Group = group1;
            columns["TenSV"].Group = group1;
            columns["NgaySinh"].Group = group2;
            columns["MaLop"].Group = group3;

            #endregion

            band.Columns["IdPhong"].Hidden = true;
            band.Columns["STT"].CellActivation = Activation.NoEdit;
            band.Columns["MaSV"].CellActivation = Activation.NoEdit;
            band.Columns["HoSV"].CellActivation = Activation.NoEdit;
            band.Columns["TenSV"].CellActivation = Activation.NoEdit;
            band.Columns["NgaySinh"].CellActivation = Activation.NoEdit;
            band.Columns["MaLop"].CellActivation = Activation.NoEdit;

            band.Columns["STT"].CellAppearance.TextHAlign = HAlign.Center;
            band.Columns["MaSV"].CellAppearance.TextHAlign = HAlign.Center;
            band.Columns["TenSV"].CellAppearance.TextHAlign = HAlign.Center;
            band.Columns["NgaySinh"].CellAppearance.TextHAlign = HAlign.Center;
            band.Columns["MaLop"].CellAppearance.TextHAlign = HAlign.Center;

            band.Columns["STT"].CellAppearance.BackColor = Color.LightCyan;
            band.Columns["STT"].MinWidth = 60;
            band.Columns["MaSV"].MinWidth = 110;
            band.Columns["HoSV"].MinWidth = 170;
            band.Columns["TenSV"].MinWidth = 120;
            band.Columns["NgaySinh"].MinWidth = 140;
            band.Columns["MaLop"].MinWidth = 140;
            band.Columns["STT"].MaxWidth = 70;
            band.Columns["MaSV"].MaxWidth = 120;
            band.Columns["HoSV"].MaxWidth = 180;
            band.Columns["TenSV"].MaxWidth = 130;
            band.Columns["NgaySinh"].MaxWidth = 150;
            band.Columns["MaLop"].MaxWidth = 150;
            band.Override.HeaderClickAction = HeaderClickAction.SortSingle;
        }

        private void Timkiemsinhvien(object sender, string masinhvien)
        {
            try
            {
                if (_newRow != null) _newRow.Selected = false;
                foreach (
                    var row in dgv_DanhSach.Rows.Where(row => row.Cells["MaSV"].Value.ToString() == masinhvien))
                {
                    dgv_DanhSach.ActiveRowScrollRegion.ScrollPosition = row.Index;
                    row.Selected = true;
                    _newRow = row;
                }
            }
            catch (Exception ex)
            {
                Log2File.LogExceptionToFile(ex);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case (Keys.Control | Keys.F):
                    _frmTimkiem.ShowDialog();
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void dgv_DanhSach_BeforeRowsDeleted(object sender, BeforeRowsDeletedEventArgs e)
        {
            e.Cancel = !DeleteAndUpdate;
            DeleteAndUpdate = false;
        }

        private void menuStrip_chonphong_Click(object sender, EventArgs e)
        {
            InsertRow();
        }
    }
}
