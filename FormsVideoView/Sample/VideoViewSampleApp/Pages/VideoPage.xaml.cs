using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace VideoViewSampleApp
{
	public partial class VideoPage : ContentPage
	{
		public VideoPage (bool isStreaming,string fileName)
		{
			InitializeComponent ();

			videoView.MediaFileItem = new FormsVideoView.MediaFile (fileName, isStreaming);
		}
	}
}

