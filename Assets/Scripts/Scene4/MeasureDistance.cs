using UnityEngine;
using UnityEngine.UI;

public class MeasureDistance : MonoBehaviour
{
	public Camera cam;
	private GameObject target;
    public Image[] LowMedHigh;
	private float distance;
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
	void Update()
	{
		if (!target) {
			target = GameObject.Find ("USERTARGET");
		}
		if (target) {
			//calculat distance between camera and user defined target
			distance = Vector3.Distance (cam.transform.position, target.transform.position);
			distanceText.text = distance.ToString() +" \n cm";


		}
	}
}
