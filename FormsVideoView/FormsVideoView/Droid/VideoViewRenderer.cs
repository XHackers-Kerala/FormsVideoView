using System;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using FormsVideoView;
using FormsVideoView.Droid;

[assembly:ExportRenderer(typeof(FormsVideoView.VideoView), typeof(VideoViewRenderer))]
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

