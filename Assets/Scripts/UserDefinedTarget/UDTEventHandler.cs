using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Vuforia;

public class UDTEventHandler : MonoBehaviour, IUserDefinedTargetEventHandler
{
    /// <summary>
    /// Can be set in the Unity inspector to reference an ImageTargetBehaviour 
    /// that is instantiated for augmentations of new User-Defined Targets.
    /// </summary>
    public ImageTargetBehaviour ImageTargetTemplate;

    UserDefinedTargetBuildingBehaviour m_TargetBuildingBehaviour;
	//Quality dialog message
    QualityDialog m_QualityDialog;
    ObjectTracker m_ObjectTracker;
	MeasureDistance measureDistance;

    // DataSet that newly defined targets are added to
    DataSet m_UDT_DataSet;

    // Currently observed frame quality
    ImageTargetBuilder.FrameQuality m_FrameQuality = ImageTargetBuilder.FrameQuality.FRAME_QUALITY_NONE;


    #region MONOBEHAVIOUR_METHODS
    void Start()
    {
        m_TargetBuildingBehaviour = GetComponent<UserDefinedTargetBuildingBehaviour>();

        if (m_TargetBuildingBehaviour)
        {
            m_TargetBuildingBehaviour.RegisterEventHandler(this);
            Debug.Log("Registering User Defined Target event handler.");
        }

		measureDistance = FindObjectOfType<MeasureDistance>();
       
        m_QualityDialog = FindObjectOfType<QualityDialog>();

        if (m_QualityDialog)
        {
			//hiding Quality message at the begining if its enabled
            m_QualityDialog.GetComponent<CanvasGroup>().alpha = 0;
        }
    }
    #endregion //MONOBEHAVIOUR_METHODS

//create new target when camera button clicked
	public void BuildNewTarget()
	{
		if (m_FrameQuality == ImageTargetBuilder.FrameQuality.FRAME_QUALITY_MEDIUM ||
			m_FrameQuality == ImageTargetBuilder.FrameQuality.FRAME_QUALITY_HIGH)
		{
			measureDistance.buildButtonClicked ();
			// create the name of the next target.
			// the TrackableName of the original, linked ImageTargetBehaviour is extended with a continuous number to ensure unique names
			string targetName = "USERTARGET";

			// generate a new target:
			m_TargetBuildingBehaviour.BuildNewTarget(targetName, ImageTargetTemplate.GetSize().x);
		}
		else
		{
			Debug.Log("Cannot build new target, due to poor camera image quality");
			if (m_QualityDialog)
			{
				StopAllCoroutines();
				//showing Quality message for a sertain time buy StartCoroutine
				m_QualityDialog.GetComponent<CanvasGroup>().alpha = 1;
				StartCoroutine(FadeOutQualityDialog());
			}
		}
	}
		
	IEnumerator FadeOutQualityDialog()
	{
		yield return new WaitForSeconds(1f);
		CanvasGroup canvasGroup = m_QualityDialog.GetComponent<CanvasGroup>();

		for (float f = 1f; f >= 0; f -= 0.1f)
		{
			f = (float)Math.Round(f, 1);
			Debug.Log("FadeOut: " + f);
			canvasGroup.alpha = (float)Math.Round(f, 1);
			yield return null;
		}
	}
		

    #region IUserDefinedTargetEventHandler Implementation
    /// <summary>
    /// Called when UserDefinedTargetBuildingBehaviour has been initialized successfully
    /// </summary>
    public void OnInitialized()
    {
        m_ObjectTracker = TrackerManager.Instance.GetTracker<ObjectTracker>();
        if (m_ObjectTracker != null)
        {
            // Create a new dataset
            m_UDT_DataSet = m_ObjectTracker.CreateDataSet();
            m_ObjectTracker.ActivateDataSet(m_UDT_DataSet);
        }
    }

    /// <summary>
    /// Updates the current frame quality and calls measureDistance
    /// </summary>
    public void OnFrameQualityChanged(ImageTargetBuilder.FrameQuality frameQuality)
    {
        Debug.Log("Frame quality changed: " + frameQuality.ToString());
        m_FrameQuality = frameQuality;
        if (m_FrameQuality == ImageTargetBuilder.FrameQuality.FRAME_QUALITY_LOW)
        {
            Debug.Log("Low camera image quality");
        }

		measureDistance.SetQuality(frameQuality);
    }

    /// <summary>
    /// Takes a new trackable source and adds it to the dataset
    /// This gets called automatically as soon as you 'BuildNewTarget with UserDefinedTargetBuildingBehaviour
    /// </summary>
	public void OnNewTrackableSource(TrackableSource trackableSource)
	{

		// Deactivates the dataset first
		m_ObjectTracker.DeactivateDataSet(m_UDT_DataSet);

		// Destroy the oldest target in the dataset if a new target is created 
		IEnumerable<Trackable> trackables = m_UDT_DataSet.GetTrackables();
		Trackable oldest = null;
		//fetch for the last target to destroy it
		foreach (Trackable trackable in trackables)
		{
			if (oldest == null || trackable.ID < oldest.ID)
				oldest = trackable;
		}
		if (oldest != null)
		{
			Debug.Log("Destroying oldest trackable in UDT dataset: " + oldest.Name);
			m_UDT_DataSet.Destroy(oldest, true);
		}


		// Get predefined trackable and instantiate it
		ImageTargetBehaviour imageTargetCopy = Instantiate(ImageTargetTemplate);
		imageTargetCopy.gameObject.name = "USERTARGET";
		// Add the duplicated trackable to the data set and activate it
		m_UDT_DataSet.CreateTrackable(trackableSource, imageTargetCopy.gameObject);

		// Activate the dataset again
		m_ObjectTracker.ActivateDataSet(m_UDT_DataSet);

		m_ObjectTracker.Stop();
		m_ObjectTracker.ResetExtendedTracking();
		m_ObjectTracker.Start();

		// Make sure TargetBuildingBehaviour keeps scanning...
		m_TargetBuildingBehaviour.StartScanning();
	}
    #endregion IUserDefinedTargetEventHandler implementation


 
}