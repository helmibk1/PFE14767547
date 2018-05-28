using UnityEngine;
using System.Collections;
using Vuforia;
using UnityEngine.UI;
public class ARcamera: MonoBehaviour {



	void Start() {    
		VuforiaARController vuforia = VuforiaARController.Instance;    
		vuforia.RegisterVuforiaStartedCallback(OnVuforiaStarted);    
		vuforia.RegisterOnPauseCallback(OnPaused);
	}  

	private void OnVuforiaStarted() {    
		CameraDevice.Instance.SetFocusMode(
			CameraDevice.FocusMode.FOCUS_MODE_INFINITY);
		
	}

	private void OnPaused(bool paused) {    
		if (!paused) // resumed
		{
			// Set again autofocus mode when app is resumed
			CameraDevice.Instance.SetFocusMode(
				CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);    
		}
	}
}