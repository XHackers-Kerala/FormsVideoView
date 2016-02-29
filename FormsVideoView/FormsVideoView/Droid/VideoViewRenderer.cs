using System;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using FormsVideoView;
using FormsVideoView.Droid;

[assembly:ExportRenderer(typeof(VideoView), typeof(VideoViewRenderer))]
namespace FormsVideoView.Droid
{
	public class VideoViewRenderer: ViewRenderer<VideoView, Android.Widget.VideoView> 
	{
		public VideoViewRenderer ()
		{
		}

		protected override void OnElementChanged (ElementChangedEventArgs<VideoView> e)
		{
			base.OnElementChanged (e);


			if (e.OldElement != null || this.Element == null)
				return;

			var videoView = new Android.Widget.VideoView (Forms.Context);
			if(Element.MediaFileItem.IsStreaming)
				videoView.SetVideoURI ( Android.Net.Uri.Parse (Element.MediaFileItem.FileName));
			else
				videoView.SetVideoURI ( Android.Net.Uri.FromFile( new Java.IO.File(Element.MediaFileItem.FileName)));

			videoView.Start ();

			SetNativeControl (videoView);
		}

	}
}

