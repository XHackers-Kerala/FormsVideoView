using System;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using FormsMediaPlayer;
using FormsMediaPlayer.Droid;
using Android.Widget;
using Android.Media;
using Android.App;

[assembly:ExportRenderer(typeof(FormsMediaPlayer.VideoView), typeof(VideoViewRenderer))]
namespace FormsMediaPlayer.Droid
{
	public class VideoViewRenderer: ViewRenderer<VideoView, Android.Widget.VideoView>,MediaPlayer.IOnPreparedListener
	{
		ProgressDialog progress;
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

			var mediaController = new MediaController (Forms.Context);
			mediaController.SetMediaPlayer (videoView);
			videoView.SetMediaController (mediaController);

			SetNativeControl (videoView);

			if (Element.MediaFileItem.IsStreaming) 
			{
				videoView.SetVideoURI (Android.Net.Uri.Parse (Element.MediaFileItem.FileName));
				progress = new ProgressDialog (Forms.Context,Resource.Style.progress_bar_style);
				progress.Indeterminate = true;
				progress.SetProgressStyle (ProgressDialogStyle.Spinner);
				progress.SetCancelable (false);
				progress.Show ();
				progress.SetContentView (Resource.Layout.ProgressLayout);
			}
			else
				videoView.SetVideoURI ( Android.Net.Uri.FromFile( new Java.IO.File(Element.MediaFileItem.FileName)));

			videoView.SetOnPreparedListener (this);

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

		public void OnPrepared (MediaPlayer mp)
		{
			if(progress!=null)
				progress.Dismiss ();
		}

	}
}

