using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class MeasureDistance : MonoBehaviour
{
	
	public static bool reset = false;
	public  GameObject resetButton;
	public GameObject distancePanel;
	public GameObject stopDistance;
	public GameObject buildPanel;
	public Camera cam;
	private GameObject target;
    public Image[] LowMedHigh;
	private float distance;
	private Double douDistance;
	public Text distanceText;



	//called in SetQuality to change UI bar color
    void SetMeter(Color low, Color med, Color high)
    {
        if (LowMedHigh.Length == 3)
        {
            if (LowMedHigh[0])
                LowMedHigh[0].color = low;
            if (LowMedHigh[1])
                LowMedHigh[1].color = med;
            if (LowMedHigh[2])
                LowMedHigh[2].color = high;
        }
    }

	//called in UDTEventHandler to change meter colors based on frame quality
    public void SetQuality(Vuforia.ImageTargetBuilder.FrameQuality quality)
    {
        switch (quality)
        {
            case (Vuforia.ImageTargetBuilder.FrameQuality.FRAME_QUALITY_NONE):
                SetMeter(Color.gray, Color.gray, Color.gray);
                break;
            case (Vuforia.ImageTargetBuilder.FrameQuality.FRAME_QUALITY_LOW):
                SetMeter(Color.red, Color.gray, Color.gray);
                break;
            case (Vuforia.ImageTargetBuilder.FrameQuality.FRAME_QUALITY_MEDIUM):
                SetMeter(Color.red, Color.yellow, Color.gray);
                break;
            case (Vuforia.ImageTargetBuilder.FrameQuality.FRAME_QUALITY_HIGH):
                SetMeter(Color.red, Color.yellow, Color.green);
                break;
        }
    }


	//build button click
	public void buildButtonClicked()
	{		
			
			distancePanel.SetActive (true);
			buildPanel.SetActive (false);
			stopDistance.SetActive (true);

	}
	// stop button click
	public void DistanceMeasureStop()
	{
		stopDistance.SetActive (false);
		//this variable used in the drawlines script to allow drowing lines
		resetButton.SetActive (true);
		distancePanel.SetActive (false);

			reset = true;

	}


	//reset drawing button click
	public void Reset(){
		
		GameObject line = GameObject.Find ("LinePrefab(Clone)");
		if (line != null) {
			reset=true;
			Destroy (line.gameObject);
		}
		else {
			distancePanel.SetActive (false);
			buildPanel.SetActive (true);
			stopDistance.SetActive (false);
			resetButton.SetActive (false);
			distanceText.text = "0 \n cm";
			GameObject target = GameObject.Find ("USERTARGET");
			target.SetActive (false);
			reset=false;

		}


	}

	void Update()
	{
		if (!target) {
			target = GameObject.Find ("USERTARGET");
		}
		if (target) {
			//calculat distance between camera and user defined target
			distance = Vector3.Distance (cam.transform.position, target.transform.position);
			distance = distance * 13;
			douDistance = Math.Round (distance);
			distanceText.text = douDistance.ToString() +" \n cm";





		}
	}
}
