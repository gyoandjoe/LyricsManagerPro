using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMP.Domain.LirycsEditor
{
    public class SongInfo
    {
        public LyricsInfo Lyrics { get; set; }
        public string Title { get; set; }

        public string Interprete { get; set; }
    }
}
