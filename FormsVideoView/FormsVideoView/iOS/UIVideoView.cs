using System;
using MediaPlayer;
using UIKit;
using Foundation;
using System.Threading.Tasks;

namespace FormsVideoView.iOS
{
	public class UIVideoView : UIView
	{
		bool isMediaSet;
		MPMoviePlayerController moviePlayer;

		public UIVideoView (string videoUrl,bool isStreaming)
		{
			moviePlayer = new MPMoviePlayerController ();
			moviePlayer.ControlStyle = MPMovieControlStyle.Embedded;
			if (!string.IsNullOrEmpty (videoUrl)) 
			{
				moviePlayer.SourceType = isStreaming ? MPMovieSourceType.Streaming : MPMovieSourceType.File;
				moviePlayer.ContentUrl = isStreaming ? NSUrl.FromString (videoUrl) : NSUrl.FromFilename (videoUrl);
				isMediaSet = true;
			}
			moviePlayer.View.ContentMode = UIViewContentMode.ScaleAspectFit;
			moviePlayer.RepeatMode = MPMovieRepeatMode.None;
			moviePlayer.ScalingMode = MPMovieScalingMode.AspectFit;
			moviePlayer.ControlStyle = MPMovieControlStyle.Fullscreen;
			moviePlayer.ShouldAutoplay = false;

			Add (moviePlayer.View);
		}

		public void StartPlaying()
		{
			if(isMediaSet)
				moviePlayer.Play ();
		}

		public void ChangeMedia(string videoUrl,bool isStreaming)
		{
			if (!string.IsNullOrEmpty (videoUrl)) 
			{
				moviePlayer.ContentUrl = isStreaming ? NSUrl.FromString ( videoUrl): NSUrl.FromFilename(videoUrl) ;
				moviePlayer.SourceType= isStreaming ? MPMovieSourceType.Streaming : MPMovieSourceType.File ;
				isMediaSet = true;
			}
			else
				isMediaSet = false;
		}

		public override void LayoutSubviews ()
		{
			base.LayoutSubviews ();

			moviePlayer.View.Frame = Frame;
		}
	}
}

