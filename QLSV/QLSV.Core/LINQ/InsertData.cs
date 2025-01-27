﻿using System;
using System.Collections.Generic;
using QLSV.Core.Domain;
using QLSV.Core.Utils.Core;

namespace QLSV.Core.LINQ
{
    public class InsertData
    {
        private static readonly Connect Conn = new Connect();

        /// <summary>
        /// Thêm 1 người dùng mới
        /// </summary>
        /// <returns></returns>
        public static bool ThemTaiKhoan(Taikhoan item)
        {
            try
            {
                Conn.ExcuteQuerySql("INSERT INTO TAIKHOAN(TaiKhoan,MatKhau,HoTen,Quyen) values(N'" +
                                    item.TaiKhoan + "',N'" + item.MatKhau + "',N'" + item.HoTen + "',N'" +
                                    item.Quyen + "')");
                return true;
            }
            catch (Exception ex)
            {
                Log2File.LogExceptionToFile(ex);
                return false;
            }
        }

        /// <summary>
        /// Thêm người dùng mới mới
        /// </summary>
        /// <returns></returns>
        public static bool ThemTaiKhoan(IList<Taikhoan> list)
        {
            try
            {
                foreach (var item in list)
                {
                    ThemTaiKhoan(item);
                }
                return true;
            }
            catch (Exception ex)
            {
                Log2File.LogExceptionToFile(ex);
                return false;
            }
        }

        /// <summary>
        /// Thêm 1 khoa quản lý
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool ThemKhoa(Khoa item)
        {
            try
            {
                Conn.ExcuteQuerySql("INSERT INTO KHOA(TenKhoa) values(N'" + item.TenKhoa + "')");
                return true;
            }
            catch (Exception ex)
            {
                Log2File.LogExceptionToFile(ex);
                return false;
            }
        }

        /// <summary>
        /// Thêm nhiều khoa quản lý
        /// </summary>
        /// <returns></returns>
        public static bool ThemKhoa(IList<Khoa> list)
        {
            try
            {
                foreach (var item in list)
                {
                    ThemKhoa(item);
                }
                return true;
            }
            catch (Exception ex)
            {
                Log2File.LogExceptionToFile(ex);
                return false;
            }
        }

        /// <summary>
        /// Thêm 1 lớp quản lý
        /// </summary>
        /// <returns></returns>
        public static bool ThemLop(Lop item)
        {
            try
            {
                Conn.ExcuteQuerySql("INSERT INTO LOP(MaLop,IdKhoa) values(N'" +
                            item.MaLop + "'," + item.IdKhoa + ")");
                return true;
            }
            catch (Exception ex)
            {
                Log2File.LogExceptionToFile(ex);
                return false;
            }
        }

        /// <summary>
        /// Thêm nhiều lớp quản lý
        /// </summary>
        /// <returns></returns>
        public static bool ThemLop(IList<Lop> list)
        {
            try
            {
                foreach (var item in list)
                {
                    ThemLop(item);
                }
                return true;
            }
            catch (Exception ex)
            {
                Log2File.LogExceptionToFile(ex);
                return false;
            }
        }

        /// <summary>
        /// Thêm mới 1 sinh viên
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool ThemSinhVien(SinhVien item)
        {
            try
            {
                Conn.ExcuteQuerySql("insert into SINHVIEN(MaSV,HoSV,TenSV,NgaySinh,IdLop) values(" +
                                    item.MaSV + ",N'" + item.HoSV + "',N'" + item.TenSV + "','" +
                                    item.NgaySinh + "'," + item.IdLop + ")");
                return true;
            }
            catch (Exception ex)
            {
                Log2File.LogExceptionToFile(ex);
                return false;
            }
        }

        /// <summary>
        /// Thêm mới nhiều sinh viên
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool ThemSinhVien(IList<SinhVien> list)
        {
            try
            {
                foreach (var item in list)
                {
                    ThemSinhVien(item);
                }
                return true;
            }
            catch (Exception ex)
            {
                Log2File.LogExceptionToFile(ex);
                return false;
            }
        }
        
        /// <summary>
        /// Thêm mới 1 năm học
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool ThemNamHoc(NamHoc item)
        {
            try
            {
                Conn.ExcuteQuerySql("insert into NAMHOC(NamHoc) values('"+item.namhoc+"')");
                return true;
            }
            catch (Exception ex)
            {
                Log2File.LogExceptionToFile(ex);
                return false;
            }
        }

        public static bool ThemNamHoc(IList<NamHoc> list)
        {
            try
            {
                foreach (var item in list)
                {
                    ThemNamHoc(item);
                }
                return true;
            }
            catch (Exception ex)
            {
                Log2File.LogExceptionToFile(ex);
                return false;
            }
        }

        /// <summary>
        /// Thêm 1 kỳ thi
        /// </summary>
        /// <returns></returns>
        public static bool ThemKyThi(Kythi item)
        {
            try
            {
                Conn.ExcuteQuerySql("insert into KYTHI(MaKT,TenKT,NgayThi,TGLamBai,TGBatDau,TGKetThuc,GhiChu,TrangThai) values(N'" +
                            item.MaKT + "',N'" + item.TenKT + "','" + item.NgayThi + "',N'" +
                            item.TGLamBai + "',N'" + item.TGBatDau + "',N'" + item.TGKetThuc + "',N'"+item.GhiChu+"',1)");
                return true;
            }
            catch (Exception ex)
            {
                Log2File.LogExceptionToFile(ex);
                return false;
            }
        }

        /// <summary>
        /// Thêm nhiều kỳ thi
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool ThemKythi(IList<Kythi> list)
        {
            try
            {
                foreach (var item in list)
                {
                    ThemKyThi(item);
                }
                return true;
            }
            catch (Exception ex)
            {
                Log2File.LogExceptionToFile(ex);
                return false;
            }
        }

        /// <summary>
        /// Thêm 1 phòng thi
        /// </summary>
        /// <returns></returns>
        public static bool ThemPhongThi(PhongThi item)
        {
            try
            {
                Conn.ExcuteQuerySql("insert into PHONGTHI(TenPhong,SucChua,GhiChu) values(N'" +
                            item.TenPhong + "'," + item.SucChua + ",N'" + item.GhiChu + "')");
                return true;
            }
            catch (Exception ex)
            {
                Log2File.LogExceptionToFile(ex);
                return false;
            }
        }

        /// <summary>
        /// Thêm nhiều phòng thi
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool ThemPhongThi(IList<PhongThi> list)
        {
            try
            {
                foreach (var item in list)
                {
                    ThemPhongThi(item);
                }
                return true;
            }
            catch (Exception ex)
            {
                Log2File.LogExceptionToFile(ex);
                return false;
            }
        }

        /// <summary>
        /// Thêm 1 đáp án cho mã đề
        /// </summary>
        /// <returns></returns>
        public static bool ThemDapAn(DapAn item)
        {
            try
            {
                Conn.ExcuteQuerySql("insert into DapAn(IdKyThi,MaMon,MaDe,CauHoi,Dapan,ThangDiem) values(" +
                            item.IdKyThi + ",'" + item.MaMon + "','" + item.MaDe + "'," +
                            item.CauHoi + ",'" + item.Dapan + "'," + item.ThangDiem + ")");
                return true;
            }
            catch (Exception ex)
            {
                Log2File.LogExceptionToFile(ex);
                return false;
            }
        }

        /// <summary>
        /// Thêm nhiều đáp án cho mã đề
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool ThemDapAn(IList<DapAn> list)
        {
            try
            {
                foreach (var item in list)
                {
                    ThemDapAn(item);
                }
                return true;
            }
            catch (Exception ex)
            {
                Log2File.LogExceptionToFile(ex);
                return false;
            }
        }

        /// <summary>
        /// Thêm 1 bài làm của sinh viên
        /// </summary>
        /// <returns></returns>
        private static bool ThemBaiLam(BaiLam item)
        {
            try
            {
                var str = "insert into BAILAM(IdKyThi,MaSV,MaDe,KetQua,MaHoiDong,MaLoCham,TenFile) values(" +
                          item.IdKyThi + "," + item.MaSV + ",N'" + item.MaDe + "',N'" +
                          item.KetQua + "','" + item.MaHoiDong + "','" + item.MaLoCham + "','" + item.TenFile + "')";
                Conn.ExcuteQuerySql(str);
                return true;
            }
            catch (Exception ex)
            {
                Log2File.LogExceptionToFile(ex);
                return false;
            }
        }

        /// <summary>
        /// Thêm 1 bài làm của sinh viên
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool ThemBaiLam(IList<BaiLam> list)
        {
            try
            {
                foreach (var item in list)
                {
                    ThemBaiLam(item);
                }
                return true;
            }
            catch (Exception ex)
            {
                Log2File.LogExceptionToFile(ex);
                return false;
            }
        }

        /// <summary>
        /// Thêm bảng thống kê
        /// </summary>
        /// <returns></returns>
        public static bool ThemThongKe(DiemThi item)
        {
            try
            {
                var diem = item.Diem.ToString().Replace(',', '.');
                Conn.ExcuteQuerySql("insert into DIEMTHI(MaSV,IdNamHoc,HocKy,Diem) values(" +
                item.MaSV + "," + item.IdNamHoc + ",'" + item.HocKy + "'," +diem + ")");
                return true;
            }
            catch (Exception ex)
            {
                Log2File.LogExceptionToFile(ex);
                return false;
            }
        }

        public static bool ThemThongKe(IList<DiemThi> list)
        {
            try
            {
                foreach (var item in list)
                {
                    ThemThongKe(item);
                }
                return true;
            }
            catch (Exception ex)
            {
                Log2File.LogExceptionToFile(ex);
                return false;
            }
        }

        /// <summary>
        /// xếp phòng cho 1 sinh viên
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool XepPhong(XepPhong item)
        {
            try
            {
                Conn.ExcuteQuerySql("insert into XepPhong(IdSV,IdPhong,IdKyThi) values(" + item.IdSV + "," + item.IdPhong +
                                    "," + item.IdKyThi + ")");
                return true;
            }
            catch (Exception ex)
            {
                Log2File.LogExceptionToFile(ex);
                return false;
            }
        }

        /// <summary>
        /// Thêm vào bảng xếp phòng
        /// </summary>
        /// <param name="list"></param>
        public static bool XepPhong(IList<XepPhong> list)
        {
            try
            {
                foreach (var item in list)
                {
                    XepPhong(item);
                }
                return true;
            }
            catch (Exception ex)
            {
                Log2File.LogExceptionToFile(ex);
                return false;
            }
        }

        /// <summary>
        /// Lưu 1 phòng được sử dụng trong kỳ thi
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool KtPhong(KTPhong item)
        {
            try
            {
                Conn.ExcuteQuerySql("insert into KT_PHONG(IdKyThi,IdPhong,SiSo) values(" + item.IdKyThi + "," + item.IdPhong +
                                    "," + item.SiSo + ")");
                return true;
            }
            catch (Exception ex)
            {
                Log2File.LogExceptionToFile(ex);
                return false;
            }
        }

        /// <summary>
        /// Thêm vào bảng xếp phòng lưu nhiều phòng được sử dụng trong kỳ thi
        /// </summary>
        /// <param name="list"></param>
        public static bool KtPhong(IList<KTPhong> list)
        {
            try
            {
                foreach (var item in list)
                {
                    KtPhong(item);
                }
                return true;
            }
            catch (Exception ex)
            {
                Log2File.LogExceptionToFile(ex);
                return false;
            }
        }

        /// <summary>
        /// lưu 1 sv được chọn tham gia thi
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool Chonsinhvien(XepPhong item)
        {
            try
            {
                Conn.ExcuteQuerySql("insert into XepPhong(IdSV,IdKyThi) values(" + item.IdSV + "," + item.IdKyThi + ")");
                return true;
            }
            catch (Exception ex)
            {
                Log2File.LogExceptionToFile(ex);
                return false;
            }
        }

        /// <summary>
        /// lưu nhiều sv được chọn tham gia thi
        /// </summary>
        /// <param name="list"></param>
        public static bool Chonsinhvien(IList<XepPhong> list)
        {
            try
            {
                foreach (var item in list)
                {
                    Chonsinhvien(item);
                }
                return true;
            }
            catch (Exception ex)
            {
                Log2File.LogExceptionToFile(ex);
                return false;
            }
        }
       
    }
}
