using System;
using Xamarin.Forms;

namespace FormsVideoView
{
	public class VideoView : View
	{
		public VideoView ()
		{

		}

		public static readonly BindableProperty MediaFileProperty =
			BindableProperty.Create<VideoView,MediaFile> (p => p.MediaFileItem, new MediaFile("",false));

		//Gets or sets the color of the progress bar
		public MediaFile MediaFileItem {
			get { return (MediaFile)GetValue (MediaFileProperty); }
			set { SetValue (MediaFileProperty, value); }
		}

	}  
}

