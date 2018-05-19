using UnityEngine;
using System.Collections;
using Vuforia;

public class ARcamera : MonoBehaviour
{

	private bool mVuforiaStarted = false;
	private bool mAutofocusEnabled = true;


	void Start()
	{
		var vuforia = VuforiaARController.Instance;
		vuforia.RegisterVuforiaStartedCallback(OnVuforiaStarted);
		vuforia.RegisterOnPauseCallback(OnPaused);
	}

	//enable autofocus when vuforia start 
	private void OnVuforiaStarted()
	{
		mVuforiaStarted = true;
		// Try enabling continuous autofocus
		SwitchAutofocus(true);
	}

	//handle autofocus when vuforia paused
	private void OnPaused(bool paused)
	{
		bool appResumed = !paused;
		if (appResumed && mVuforiaStarted)
		{
			// Restore original focus mode when app is resumed
			if (mAutofocusEnabled)
				CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
			else
				CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_NORMAL);
		}

	}

	//set autofocus
	public void SwitchAutofocus(bool ON)
	{
		if (ON)
		{
			CameraDevice.Instance.SetFocusMode (CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);

			if (CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO))
			{
				Debug.Log("Successfully enabled continuous autofocus.");
				mAutofocusEnabled = true;
			}
			else
			{
				// Fallback to normal focus mode
				Debug.Log("Failed to enable continuous autofocus, switching to normal focus mode");
				mAutofocusEnabled = false;
				CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_NORMAL);
			}
		}
		else
		{
			Debug.Log("Disabling continuous autofocus (enabling normal focus mode).");
			mAutofocusEnabled = false;
			CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_NORMAL);
		}
	}
		
}
