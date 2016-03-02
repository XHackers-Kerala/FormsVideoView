using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using FormsMediaPlayer.Droid;
using XLabs.Ioc;
using XLabs.Forms;
using XLabs.Platform.Device;
using XLabs.Platform.Services.Media;
using XLabs.Platform.Services;
using XLabs.Platform.Mvvm;

namespace FormsMediaPlayerSample.Droid
{
	[Activity (Label = "FormsMediaPlayerSample.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : XFormsApplicationDroid
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			if (!Resolver.IsSet)
			{
				this.SetIoc();
			}
			else
			{
				var app = Resolver.Resolve<IXFormsApp>() as IXFormsApp<XFormsApplicationDroid>;
				if (app != null) app.AppContext = this;
			}


			global::Xamarin.Forms.Forms.Init (this, bundle);

			LoadApplication (new App ());
			VideoViewRenderer.Init ();

		}
		void SetIoc()
		{
			var resolverContainer = new SimpleContainer();

			var app = new XFormsAppDroid();
			app.Init(this);

			resolverContainer.Register<IDisplay> (t => t.Resolve<IDevice> ().Display);
			resolverContainer.Register<INetwork>(t=> t.Resolve<IDevice>().Network);
			resolverContainer.Register<IDevice>(t => AndroidDevice.CurrentDevice)
				.Register<IMediaPicker, MediaPicker>();

			Resolver.SetResolver(resolverContainer.GetResolver());
		}
	}
}

