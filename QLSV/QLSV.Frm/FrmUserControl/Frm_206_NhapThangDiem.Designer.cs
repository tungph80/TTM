﻿namespace QLSV.Frm.FrmUserControl
{
    partial class Frm_206_NhapThangDiem
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dgv_DanhSach = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.menu_ug = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip_nhapdiem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnnhapdiem = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txtmade = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.txtcauhoi = new System.Windows.Forms.ToolStripTextBox();
            this.btnTimkiem = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnrefresh = new System.Windows.Forms.ToolStripButton();
            this.pnl_from = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DanhSach)).BeginInit();
            this.menu_ug.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.pnl_from.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_DanhSach
            // 
            this.dgv_DanhSach.ContextMenuStrip = this.menu_ug;
            this.dgv_DanhSach.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            this.dgv_DanhSach.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.dgv_DanhSach.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.True;
            this.dgv_DanhSach.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.dgv_DanhSach.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.dgv_DanhSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_DanhSach.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgv_DanhSach.Location = new System.Drawing.Point(0, 0);
            this.dgv_DanhSach.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_DanhSach.Name = "dgv_DanhSach";
            this.dgv_DanhSach.Size = new System.Drawing.Size(664, 468);
            this.dgv_DanhSach.TabIndex = 26;
            this.dgv_DanhSach.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.dgv_DanhSach_InitializeLayout);
            this.dgv_DanhSach.AfterExitEditMode += new System.EventHandler(this.dgv_DanhSach_AfterExitEditMode);
            this.dgv_DanhSach.BeforeRowsDeleted += new Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventHandler(this.dgv_DanhSach_BeforeRowsDeleted);
            this.dgv_DanhSach.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgv_DanhSach_KeyDown);
            // 
            // menu_ug
            // 
            this.menu_ug.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.menu_ug.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStrip_nhapdiem});
            this.menu_ug.Name = "contextMenuStrip1";
            this.menu_ug.Size = new System.Drawing.Size(134, 26);
            // 
            // menuStrip_nhapdiem
            // 
            this.menuStrip_nhapdiem.Name = "menuStrip_nhapdiem";
            this.menuStrip_nhapdiem.Size = new System.Drawing.Size(133, 22);
            this.menuStrip_nhapdiem.Text = "Nhập điểm";
            this.menuStrip_nhapdiem.Click += new System.EventHandler(this.menuStrip_nhapdiem_Click);
            // 
            // btnnhapdiem
            // 
            this.btnnhapdiem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnnhapdiem.Name = "btnnhapdiem";
            this.btnnhapdiem.Size = new System.Drawing.Size(70, 22);
            this.btnnhapdiem.Text = "Nhập điểm";
            this.btnnhapdiem.Click += new System.EventHandler(this.btnnhapdiem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.txtmade,
            this.toolStripSeparator1,
            this.toolStripLabel2,
            this.txtcauhoi,
            this.btnTimkiem,
            this.toolStripSeparator2,
            this.btnrefresh});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(664, 25);
            this.toolStrip1.TabIndex = 33;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(76, 22);
            this.toolStripLabel1.Text = "Nhập mã đề :";
            // 
            // txtmade
            // 
            this.txtmade.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtmade.Name = "txtmade";
            this.txtmade.Size = new System.Drawing.Size(100, 25);
            this.txtmade.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtmade.ToolTipText = "Nhập mã đề cần tìm kiếm";
            this.txtmade.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtcauhoi_KeyDown);
            this.txtmade.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtcauhoi_KeyUp);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(51, 22);
            this.toolStripLabel2.Text = "Câu hỏi:";
            // 
            // txtcauhoi
            // 
            this.txtcauhoi.Name = "txtcauhoi";
            this.txtcauhoi.Size = new System.Drawing.Size(100, 25);
            this.txtcauhoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtcauhoi_KeyDown);
            this.txtcauhoi.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtcauhoi_KeyUp);
            // 
            // btnTimkiem
            // 
            this.btnTimkiem.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnTimkiem.Image = global::QLSV.Frm.Properties.Resources.find_icon;
            this.btnTimkiem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTimkiem.Name = "btnTimkiem";
            this.btnTimkiem.Size = new System.Drawing.Size(74, 22);
            this.btnTimkiem.Text = "Tìm kiếm";
            this.btnTimkiem.ToolTipText = "Enter";
            this.btnTimkiem.Click += new System.EventHandler(this.btnTimkiem_Click_1);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnrefresh
            // 
            this.btnrefresh.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnrefresh.Image = global::QLSV.Frm.Properties.Resources.refresh1_icon;
            this.btnrefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnrefresh.Name = "btnrefresh";
            this.btnrefresh.Size = new System.Drawing.Size(71, 22);
            this.btnrefresh.Text = "Quay lại";
            this.btnrefresh.ToolTipText = "Tải lại dữ liệu";
            this.btnrefresh.Click += new System.EventHandler(this.btnrefresh_Click);
            // 
            // pnl_from
            // 
            this.pnl_from.Controls.Add(this.dgv_DanhSach);
            this.pnl_from.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_from.Location = new System.Drawing.Point(0, 25);
            this.pnl_from.Name = "pnl_from";
            this.pnl_from.Size = new System.Drawing.Size(664, 468);
            this.pnl_from.TabIndex = 34;
            this.pnl_from.Visible = false;
            // 
            // Frm_206_NhapThangDiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnl_from);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Name = "Frm_206_NhapThangDiem";
            this.Size = new System.Drawing.Size(664, 493);
            this.Load += new System.EventHandler(this.FrmDapAnCacMaDe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DanhSach)).EndInit();
            this.menu_ug.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.pnl_from.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.UltraWinGrid.UltraGrid dgv_DanhSach;
        private System.Windows.Forms.ContextMenuStrip menu_ug;
        private System.Windows.Forms.ToolStripButton btnnhapdiem;
        private System.Windows.Forms.ToolStripMenuItem menuStrip_nhapdiem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox txtmade;
        private System.Windows.Forms.ToolStripButton btnTimkiem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnrefresh;
        private System.Windows.Forms.Panel pnl_from;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox txtcauhoi;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}
