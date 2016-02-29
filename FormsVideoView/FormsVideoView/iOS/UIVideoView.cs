using System;
using MediaPlayer;
using UIKit;
using Foundation;
using System.Threading.Tasks;

namespace FormsVideoView.iOS
{
	public class UIVideoView : UIView
	{
		bool isMediaSet,isLoading,loaderDisplayed;
		MPMoviePlayerController moviePlayer;
		LoadingOverlay loadingOverlay;

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
			moviePlayer.ShouldAutoplay = false;
			MPMoviePlayerController.Notifications.ObserveLoadStateDidChange (LoadStateChanged);
			Add (moviePlayer.View);
			isLoading = isStreaming;
		}

		public void StartPlaying()
		{
			if(isMediaSet)
				moviePlayer.Play ();
		}

		void LoadStateChanged (object sender, Foundation.NSNotificationEventArgs args)
		{
			if (moviePlayer.LoadState == MPMovieLoadState.Playable && loadingOverlay != null) 
			{
				loadingOverlay.Hide ();
				isLoading = false;
				loaderDisplayed = false;
			}
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

			if (isLoading && !loaderDisplayed) 
			{
				loadingOverlay = new LoadingOverlay (Frame);
				Add (loadingOverlay);
				loaderDisplayed = true;
			}
		}
	}
}

