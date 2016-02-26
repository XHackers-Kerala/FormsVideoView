using System;

namespace FormsVideoView
{
	public class MediaFile
	{
		public MediaFile (string filename,bool isStreaming)
		{
			FileName = filename;
			IsStreaming = isStreaming;
		}
		public string FileName;
		public bool IsStreaming;
	}
}

