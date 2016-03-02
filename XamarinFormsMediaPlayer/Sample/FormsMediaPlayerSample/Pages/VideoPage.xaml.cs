using System;
using System.Collections.Generic;

using Xamarin.Forms;
using FormsMediaPlayer;

namespace FormsMediaPlayerSample
{
	public partial class VideoPage : ContentPage
	{
		public VideoPage (bool isStreaming,string fileName)
		{
			InitializeComponent ();

			videoView.MediaFileItem = new MediaFile (fileName, isStreaming);
		}
	}
}

