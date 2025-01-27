﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using PerpetuumSoft.Reporting.View;
using QLSV.Core.Domain;
using QLSV.Core.LINQ;
using QLSV.Core.Utils.Core;
using QLSV.Frm.Base;
using QLSV.Frm.Frm;

namespace QLSV.Frm.FrmUserControl
{
    public partial class Frm_209_GopKeQuaThi : FunctionControlHasGrid
    {
        private readonly IList<DiemThi> _listThongke = new List<DiemThi>();
        private IList<int> _list;
        IList<Sinhvien> _listtk = new List<Sinhvien>(); 
        private readonly BackgroundWorker _bgwInsert;
        private int _idnamhoc;
        private string _hocky;
        private readonly FrmTimkiem _frmTimkiem;
        private UltraGridRow _newRow;

        public Frm_209_GopKeQuaThi()
        {
            InitializeComponent();
            _bgwInsert = new BackgroundWorker();
            _bgwInsert.DoWork += bgwInsert_DoWork;
            _bgwInsert.RunWorkerCompleted += bgwInsert_RunWorkerCompleted;

            _frmTimkiem = new FrmTimkiem();
            _frmTimkiem.Timkiemsinhvien += Timkiemsinhvien;
        }

        protected virtual DataTable GetTable()
        {
            var table = new DataTable();
            table.Columns.Add("MaSV");
            table.Columns.Add("HoSV");
            table.Columns.Add("TenSV");
            table.Columns.Add("NgaySinh");
            table.Columns.Add("MaLop");
            table.Columns.Add("TongDiem");
            return table;
        }

        protected virtual void LoadGrid()
        {
            try
            {
                var tb1 = Statistic.GopKetQua(_list);
                var tb2 = Statistic.GopKetQua1(_list);
                if (tb2.Rows.Count > 0 && _list.Count > 1)
                {
                    IList<Sinhvien> listthongke = new List<Sinhvien>();
                    foreach (DataRow row in tb2.Rows)
                    {
                        var a = int.Parse(row["MaSV"].ToString());
                        foreach (var sv in listthongke.Where(sv => sv.MaSV == a))
                        {
                            for (var i = 0; i < _list.Count; i++)
                            {
                                var ten = "Diem" + (i + 1);
                                var diem = row[ten].ToString();
                                if (!string.IsNullOrEmpty(diem))
                                    sv.Diemthi[i] = int.Parse(row[ten].ToString());
                            }
                            goto b;
                        }
                        var sv1 = new Sinhvien(_list.Count)
                        {
                            MaSV = a,
                            HoSV = row["HoSV"].ToString(),
                            TenSV = row["TenSV"].ToString(),
                            MaLop = row["MaLop"].ToString(),
                            NgaySinh = row["NgaySinh"].ToString(),
                        };
                        for (var i = 0; i < _list.Count; i++)
                        {
                            var ten = "Diem" + (i + 1);
                            var diem = row[ten].ToString();
                            if (!string.IsNullOrEmpty(diem))
                                sv1.Diemthi[i] = double.Parse(row[ten].ToString());
                            else
                                sv1.Diemthi[i] = 0;
                        }
                        listthongke.Add(sv1);
                        b:;
                    }
                    var t = tb1.Rows.Count;
                    foreach (var item in listthongke)
                    {
                        tb1.Rows.Add(++t, item.MaSV, item.HoSV, item.TenSV, item.NgaySinh, item.MaLop);
                        for (var i = 0; i < _list.Count; i++)
                        {
                            var ten = "Diem" + (i + 1);
                            tb1.Rows[tb1.Rows.Count - 1][ten] = item.Diemthi[i];
                        }
                        tb1.Rows[tb1.Rows.Count - 1]["TongDiem"] = item.Tinhtong();
                    }
                    Invoke((Action)(() => _listtk = listthongke));
                }
                Invoke((Action)(()=>dgv_DanhSach.DataSource = tb1));
                Invoke((Action)(() => pnl_from.Visible = true));
                lock (LockTotal)
                {
                    OnCloseDialog();
                }
            }
            catch (Exception ex)
            {
                Log2File.LogExceptionToFile(ex);
            }
        }

        protected override void LoadFormDetail()
        {
            try
            {
                var frm = new FrmGopKetQua { Check = false };
                frm.ShowDialog();
                _list = frm.LstIdKyThi;
                if (_list.Count>0 && frm.Check)
                {
                    var thread = new Thread(LoadGrid) {IsBackground = true};
                    thread.Start();
                    OnShowDialog("Loading...");
                }
            }
            catch (Exception ex)
            {
                Log2File.LogExceptionToFile(ex);
            }
        }

        protected override void SaveDetail()
        {
            try
            {
                foreach (var row in dgv_DanhSach.Rows)
                {
                    var hs = new DiemThi
                    {
                        MaSV = int.Parse(row.Cells["MaSV"].Text),
                        Diem = double.Parse(row.Cells["TongDiem"].Text),
                        IdNamHoc = _idnamhoc,
                        HocKy = _hocky
                    };
                    _listThongke.Add(hs);
                }
                if (_listThongke.Count > 0)
                {
                    InsertData.ThemThongKe(_listThongke);
                    MessageBox.Show(@"Thêm thành công");
                }
            }
            catch (Exception ex)
            {
                Log2File.LogExceptionToFile(ex);
            }
        }

        public void Ghi()
        {
            var frm = new FrmGopKQ { Update = false };
            frm.ShowDialog();
            if(!frm.Update) return;
            _idnamhoc = int.Parse(frm.cboNamHoc.SelectedValue.ToString());
            _hocky = frm.cbohocky.SelectedValue.ToString();
            _bgwInsert.RunWorkerAsync();
            OnShowDialog("Đang lưu dữ liệu");
        }

        public void InDanhSach()
        {
            var frm = new FrmRptDanhSachDiemThi
            {
                update = false
            };
            frm.ShowDialog();
            if (frm.rdodanhsach.Checked && frm.update)
            {
                RptDanhSach();
            }
            else if(frm.rdoThongke.Checked && frm.update)
            {
                RptThongke();
            }
        }

        private void RptDanhSach()
        {

            reportManager1.DataSources.Clear();
            reportManager1.DataSources.Add("danhsach",dgv_DanhSach.DataSource);
            rptgopdiem.FilePath = Application.StartupPath + @"\Reports\gopdiem.rst";
            rptgopdiem.Prepare();
            var previewForm = new PreviewForm(rptgopdiem)
            {
                WindowState = FormWindowState.Maximized
            };
            previewForm.Show();
        }

        private void RptThongke()
        {

            reportManager1.DataSources.Clear();
            rptthongketong.FilePath = Application.StartupPath + @"\Reports\thongketong.rst";
            rptthongketong.GetReportParameter += GetParameter;
            rptthongketong.Prepare();
            var previewForm = new PreviewForm(rptthongketong)
            {
                WindowState = FormWindowState.Maximized
            };
            previewForm.Show();
        }

        private void GetParameter(object sender,
           PerpetuumSoft.Reporting.Components.GetReportParameterEventArgs e)
        {
            try
            {
                //double bosung = Statistic.Thongkediem(0, _list).Rows.Count;
                //double toiec1 = Statistic.Thongkediem(1, _list).Rows.Count;
                //double toiec2 = Statistic.Thongkediem(2, _list).Rows.Count;
                //double toiec3 = Statistic.Thongkediem(3, _list).Rows.Count;
                //double toiec4 = Statistic.Thongkediem(4, _list).Rows.Count;
                //double miengiam = Statistic.Thongkediem(5, _list).Rows.Count;
                double bosung = 0;
                double toiec1 = 0;
                double toiec2 = 0;
                double toiec3 = 0;
                double toiec4 = 0;
                double miengiam = 0;
                foreach (var row in dgv_DanhSach.Rows)
                {
                    var d = double.Parse(row.Cells["TongDiem"].Text);
                    if (d < 200)
                        bosung = bosung + 1;
                    else if (d >= 200 && d < 250)
                        toiec1 += 1;
                    else if (d >= 250 && d < 300)
                        toiec2 += 1;
                    else if (d >= 300 && d < 374)
                        toiec3 += 1;
                    else if (d >= 374 && d < 450)
                        toiec4 += 1;
                    else
                        miengiam += 1;
                }
                var tong = bosung + toiec1 + toiec2 + toiec3 + toiec4 + miengiam;

                e.Parameters["bosung"].Value = bosung.ToString();
                e.Parameters["toiec1"].Value = toiec1.ToString();
                e.Parameters["toiec2"].Value = toiec2.ToString();
                e.Parameters["toiec3"].Value = toiec3.ToString();
                e.Parameters["toiec4"].Value = toiec4.ToString();
                e.Parameters["miengiam"].Value = miengiam.ToString();
                e.Parameters["TLbosung"].Value = Math.Round(bosung / tong * 100, 1).ToString();
                e.Parameters["TLtoiec1"].Value = Math.Round(toiec1 / tong * 100, 1).ToString();
                e.Parameters["TLtoiec2"].Value = Math.Round(toiec2 / tong * 100, 1).ToString();
                e.Parameters["TLtoiec3"].Value = Math.Round(toiec3 / tong * 100, 1).ToString();
                e.Parameters["TLtoiec4"].Value = Math.Round(toiec4 / tong * 100, 1).ToString();
                e.Parameters["TLmiengiam"].Value = Math.Round(miengiam / tong * 100, 1).ToString();
                e.Parameters["tong"].Value = tong.ToString();
            }
            catch (Exception ex)
            {
                Log2File.LogExceptionToFile(ex);
            }
        }

        #region BackgroundWorker

        private void bgwInsert_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                SaveDetail();
            }
            catch (Exception ex)
            {
                Log2File.LogExceptionToFile(ex);
            }
        }

        private void bgwInsert_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            OnCloseDialog();
        }

        #endregion

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

        private void dgv_DanhSach_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            try
            {
                var band = e.Layout.Bands[0];
                band.Groups.Clear();
                band.Override.HeaderAppearance.FontData.SizeInPoints = 10;
                band.Override.HeaderAppearance.FontData.Bold = DefaultableBoolean.True;
                band.Columns["STT"].CellAppearance.BackColor = Color.LightCyan;

                #region Caption
                var columns = band.Columns;
                band.ColHeadersVisible = false;
                var group5 = band.Groups.Add("STT");
                columns["STT"].Group = group5;
                var group0 = band.Groups.Add("Mã SV");
                columns["MaSV"].Group = group0;
                var group1 = band.Groups.Add("Họ và tên");
                columns["HoSV"].Group = group1;
                columns["TenSV"].Group = group1;
                var group2 = band.Groups.Add("Ngày sinh");
                columns["NgaySinh"].Group = group2;
                var group3 = band.Groups.Add("Lớp");
                columns["MaLop"].Group = group3;

                for (var i = 0; i < _list.Count; i++)
                {
                    var ten = "Diem" + (i + 1);
                    var ten1 = "Điểm môn " + (i + 1);
                    var group = band.Groups.Add(ten1);
                    band.Columns[ten].Group = group;
                    band.Columns[ten].MinWidth = 100;
                    band.Columns[ten].MaxWidth = 110;
                    band.Columns[ten].CellAppearance.TextHAlign = HAlign.Center;
                }

                var group4 = band.Groups.Add("Tổng điểm");
                columns["TongDiem"].Group = group4;

                #endregion

                #region Size

                band.Columns["STT"].MinWidth = 60;
                band.Columns["STT"].MaxWidth = 70;
                band.Columns["MaSV"].MinWidth = 100;
                band.Columns["MaSV"].MaxWidth = 120;
                band.Columns["HoSV"].MinWidth = 130;
                band.Columns["HoSV"].MaxWidth = 150;
                band.Columns["TenSV"].MinWidth = 90;
                band.Columns["TenSV"].MaxWidth = 100;
                band.Columns["NgaySinh"].MinWidth = 100;
                band.Columns["NgaySinh"].MaxWidth = 100;
                band.Columns["MaLop"].MinWidth = 100;
                band.Columns["MaLop"].MaxWidth = 110;
                band.Columns["TongDiem"].MinWidth = 100;
                band.Columns["TongDiem"].MaxWidth = 120;

                #endregion

                band.Columns["STT"].CellAppearance.TextHAlign = HAlign.Center;
                band.Columns["MaSV"].CellAppearance.TextHAlign = HAlign.Center;
                band.Columns["TenSV"].CellAppearance.TextHAlign = HAlign.Center;
                band.Columns["MaLop"].CellAppearance.TextHAlign = HAlign.Center;
                band.Columns["TongDiem"].CellAppearance.TextHAlign = HAlign.Center;
                
                foreach (var coloum in band.Columns)
                {
                    coloum.CellActivation = Activation.NoEdit;
                }

                dgv_DanhSach.DisplayLayout.UseFixedHeaders = true;
                dgv_DanhSach.DisplayLayout.FixedHeaderOffImage = Properties.Resources.trang;
                dgv_DanhSach.DisplayLayout.FixedHeaderOnImage = Properties.Resources.trang;
                group0.Header.Fixed = true;
                group1.Header.Fixed = true;
                group2.Header.Fixed = true; 
                group3.Header.Fixed = true;
                group5.Header.Fixed = true;
            }
            catch (Exception ex)
            {
                Log2File.LogExceptionToFile(ex);
            }
        }

        private void Frm_209_GopKeQuaThi_Load(object sender, EventArgs e)
        {
            LoadFormDetail();
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
            e.DisplayPromptMsg = false;
            e.Cancel = true;
        }
    }

    public class Sinhvien
    {
        public int MaSV { get; set; }
        public string HoSV { get; set; }
        public string TenSV { get; set; }
        public string NgaySinh { get; set; }
        public string MaLop { get; set; }
        public double[] Diemthi { get; set; }
        public double TongDiem { get; set; }

        public Sinhvien(int count)
        {
            Diemthi = new double[count];
            TongDiem = 0;
        }

        public double Tinhtong()
        {
            foreach (var t in Diemthi)
            {
                TongDiem = TongDiem + t;
            }
            return TongDiem;
        }
    }
}
