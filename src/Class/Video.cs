using System;

namespace MusicWebOnline
{
    public class Video
    {
        public int MaVideo { get; set; }

        public string TenVideo { get; set; }

        public string TenKhongDau { get; set; }

        public int? MaCaSi { get; set; }

        public int? MaTheLoai { get; set; }

        public string TenFile { get; set; }

        public DateTime? NgayDang { get; set; }

        public string Hinh { get; set; }

        public int LuotXem { get; set; }
    }
}