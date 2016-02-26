using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace VideoViewSampleApp
{
	public partial class VideoPage : ContentPage
	{
		public VideoPage (bool isStreaming)
		{
			InitializeComponent ();

			var fileName = isStreaming ? Constants.VideoUrl : Constants.EmbeddedUrl;
			videoView.MediaFileItem = new FormsVideoView.MediaFile (fileName, isStreaming);
		}
	}
}

