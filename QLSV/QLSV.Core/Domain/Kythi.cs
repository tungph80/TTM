﻿using System;

namespace QLSV.Core.Domain
{
    public class Kythi
    {
        public virtual int ID { get; set; }

        public virtual string MaKT { get; set; }

        public virtual string TenKT { get; set; }

        public virtual string NgayThi { get; set; }

        public virtual string TGLamBai { get; set; }

        public virtual string TGBatDau { get; set; }

        public virtual string TGKetThuc { get; set; }
        
        public virtual string GhiChu { get; set; }

        public virtual bool TrangThai { get; set; }
    }
}
