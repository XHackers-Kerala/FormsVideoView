using System;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using FormsMediaPlayer;
using FormsMediaPlayer.iOS;

[assembly:ExportRenderer(typeof(VideoView), typeof(VideoViewRenderer))]
namespace FormsMediaPlayer.iOS
{
	public class VideoViewRenderer: ViewRenderer<VideoView, UIVideoView> 
	{
		public VideoViewRenderer ()
		{
		}
		public static void Init()
		{
		}
		protected override void OnElementChanged (ElementChangedEventArgs<VideoView> e)
		{
			base.OnElementChanged (e);

			if (e.OldElement != null || this.Element == null)
				return;

			var videoView = new UIVideoView (Element.MediaFileItem.FileName,Element.MediaFileItem.IsStreaming);
			videoView.StartPlaying ();
			SetNativeControl (videoView);
		}

		protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged (sender, e);

			if (this.Element == null || this.Control == null)
				return;

			if (e.PropertyName == VideoView.MediaFileProperty.PropertyName) {
				Control.ChangeMedia (Element.MediaFileItem.FileName,Element.MediaFileItem.IsStreaming);
			}
		}

	}
}

