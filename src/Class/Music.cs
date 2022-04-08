using System;

namespace MusicWebOnline
{
    public class Music
    {
        public int MaBaiHat { get; set; }

        public int? MaTheLoai { get; set; }

        public int? MaNhacSi { get; set; }

        public int? MaCaSi { get; set; }

        public int? MaAlbum { get; set; }

        public string TenBaiHat { get; set; }

        public string TenKhongDau { get; set; }

        public string TenFile { get; set; }

        public string NoiDung { get; set; }

        public DateTime? NgayDang { get; set; }

        public int LuotXem { get; set; }
    }
}