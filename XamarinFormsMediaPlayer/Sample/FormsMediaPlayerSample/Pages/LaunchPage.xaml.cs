using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XLabs.Ioc;
using XLabs.Platform.Device;
using XLabs.Platform.Services.Media;

namespace FormsMediaPlayerSample
{
	public partial class LaunchPage : ContentPage
	{
		public LaunchPage ()
		{
			InitializeComponent ();
		}
		void LoadFromWebClicked(object sender, EventArgs e)
		{
			Navigation.PushAsync (new VideoPage (true,Constants.VideoUrl));
		}

		async void LoadEmbeddedClicked(object sender, EventArgs e)
		{
			try {
				var device = Resolver.Resolve<IDevice>();

				////RM: hack for working on windows phone? 
				var _mediaPicker = DependencyService.Get<IMediaPicker>() ?? device.MediaPicker;
				var takePhotoResult= await _mediaPicker.SelectVideoAsync(new VideoMediaStorageOptions(){});
				Navigation.PushAsync (new VideoPage (false,takePhotoResult.Path));
			}
			catch (Exception xx) {
				DisplayAlert("Video Selection", "Video Selection Cancelled","OK");
			}

		}
	}
}

