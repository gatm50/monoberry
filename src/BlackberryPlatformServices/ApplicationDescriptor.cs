using System;
using System.Collections.Generic;

namespace BlackBerry.ApplicationDescriptor
{
	public class ApplicationIdentifierAttribute : Attribute
	{
		public string Identifier { get; protected set; }

		public ApplicationIdentifierAttribute (string val)
		{
			Identifier = val;
		}

		public override string ToString ()
		{
			return Identifier;
		}
	}

	public enum Action {
		AccessSharedData,
		RecordAudio,
		ReadGeoLocation,
		UseCamera,
		AccessInternet,
		PlayAudio,
		PostNotifications,
		SetAudioVolume,
		ReadDeviceIdentifyingInformation,
		AccessLedControl
	}

	public class RequestedPermissionsAttribute : Attribute
	{

		public ISet<Action> Actions { get; protected set; }

		public RequestedPermissionsAttribute (params Action[] actions)
		{
			Actions = new HashSet<Action> (actions);
		}
	}

	public class PlatformVersionAttribute : Attribute
	{
		public string Version { get; protected set; }

		public PlatformVersionAttribute (string val)
		{
			Version = val;
		}

		public override string ToString ()
		{
			return Version;
		}
	}
}

