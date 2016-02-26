using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using XLabs.Forms;
using XLabs.Ioc;
using XLabs.Platform.Device;
using XLabs.Platform.Services;
using XLabs.Platform.Services.Media;

namespace VideoViewSampleApp.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : XFormsApplicationDelegate
	{
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			this.SetIoc();

			global::Xamarin.Forms.Forms.Init ();

			LoadApplication (new App ());

			base.FinishedLaunching (app, options);
			return true;
		}
		private void SetIoc()
		{
			var resolverContainer = new SimpleContainer();

			var app = new XFormsAppiOS();
			app.Init(this);
			resolverContainer.Register<IDevice> (t => AppleDevice.CurrentDevice);
			resolverContainer.Register<IDisplay> (t => t.Resolve<IDevice> ().Display);
			resolverContainer.Register<INetwork>(t=> t.Resolve<IDevice>().Network);
			resolverContainer.Register<IDevice>(t => AppleDevice.CurrentDevice)
				.Register<IMediaPicker, MediaPicker>();

			Resolver.SetResolver(resolverContainer.GetResolver());
		}
	}
}

