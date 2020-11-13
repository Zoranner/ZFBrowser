using UnityEngine;
#if UNITY_2017_2_OR_NEWER
using UnityEngine.XR;
#else
using UnityEngine.VR;
#endif

namespace ZenFulcrum.EmbeddedBrowser
{

    public class VRMode : MonoBehaviour
    {

        public bool EnableVR;
        //private XRInputSubsystem _XRInputSubsystem;

#if UNITY_2017_2_OR_NEWER
        private bool _OldState;
        public void OnEnable()
        {
            _OldState = XRSettings.enabled;
            XRSettings.enabled = EnableVR;
            if (XRSettings.enabled)
            {
                //Debug.Log("VR system: " + XRSettings.loadedDeviceName + " device: " + XRDevice.model);

                //Unity is drunk again. This time it likes to give us y=0=floor for OpenVR and y=0=standing height
                //for Oculus SDK unless we call this:
                XRDevice.SetTrackingSpaceType(TrackingSpaceType.RoomScale);
                //_XRInputSubsystem = new XRInputSubsystem();
                //_XRInputSubsystem.TrySetTrackingOriginMode(TrackingOriginModeFlags.Floor);
            }
        }

        public void OnDisable()
        {
            XRSettings.enabled = _OldState;
        }
#else
	private bool oldState;
	public void OnEnable() {
		oldState = VRSettings.enabled;
		VRSettings.enabled = enableVR;
	}

	public void OnDisable() {
		VRSettings.enabled = oldState;
	}
#endif
    }

}