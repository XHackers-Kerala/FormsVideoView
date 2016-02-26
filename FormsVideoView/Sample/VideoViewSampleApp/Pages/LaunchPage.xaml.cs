using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XLabs.Ioc;
using XLabs.Platform.Device;
using XLabs.Platform.Services.Media;

namespace VideoViewSampleApp
{
	public partial class LaunchPage : ContentPage
	{
		public LaunchPage ()
		{
			InitializeComponent ();
		}

		void LoadFromWebClicked(object sender, EventArgs e)
		{
			Navigation.PushModalAsync (new VideoPage (true));
		}

		async void LoadEmbeddedClicked(object sender, EventArgs e)
		{
//			try {
//				var device = Resolver.Resolve<IDevice>();
//
//				////RM: hack for working on windows phone? 
//				var _mediaPicker = DependencyService.Get<IMediaPicker>() ?? device.MediaPicker;
//				var takePhotoResult= await _mediaPicker.SelectVideoAsync(new VideoMediaStorageOptions(){});
//			}
//			catch {
//			}
			Navigation.PushModalAsync (new VideoPage (false));
		}
	}
}

