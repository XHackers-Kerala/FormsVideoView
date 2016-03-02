using System;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using FormsMediaPlayer;
using FormsMediaPlayer.Droid;

[assembly:ExportRenderer(typeof(VideoView), typeof(VideoViewRenderer))]
namespace FormsMediaPlayer.Droid
{
	public class VideoViewRenderer: ViewRenderer<VideoView, Android.Widget.VideoView> 
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

			var videoView = new Android.Widget.VideoView (Forms.Context);

			SetNativeControl (videoView);

			if(Element.MediaFileItem.IsStreaming)
				videoView.SetVideoURI ( Android.Net.Uri.Parse (Element.MediaFileItem.FileName));
			else
				videoView.SetVideoURI ( Android.Net.Uri.FromFile( new Java.IO.File(Element.MediaFileItem.FileName)));

			videoView.Start ();

		}

		protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged (sender, e);

			if (this.Element == null || this.Control == null)
				return;

			if (e.PropertyName == VideoView.MediaFileProperty.PropertyName) {
				if(Element.MediaFileItem.IsStreaming)
					Control.SetVideoURI ( Android.Net.Uri.Parse (Element.MediaFileItem.FileName));
				else
					Control.SetVideoURI ( Android.Net.Uri.FromFile( new Java.IO.File(Element.MediaFileItem.FileName)));
			}
		}

	}
}

