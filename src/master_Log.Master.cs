using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MusicWebOnline
{
    public partial class master_Log : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Play__.InnerHtml = "<video id='example_video_1' class='video-js vjs-default-skin' controls preload='none' width='100%' height='310' poster='../MusicWeb/img_QuangCao/den.png' data-setup='{}'>";
            Play__.InnerHtml += "<source src='../MusicWeb/img_QuangCao/QC_Video.mp4' type='video/mp4' /> <source src='../MusicWeb/img_QuangCao/QC_Video.mp4' type='video/webm' /> <source src='../MusicWeb/img_QuangCao/QC_Video.mp4' type='video/ogg' />";
            Play__.InnerHtml += "<track kind='captions' src='../MusicWeb/video-js/demo.captions.vtt' srclang='en' label='English'></track>";
            Play__.InnerHtml += "<track kind='subtitles' src='../MusicWeb/video-js/demo.captions.vtt' srclang='en' label='English'></track>";
        }
    }
}