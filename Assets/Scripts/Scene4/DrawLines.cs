using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class DrawLines : MonoBehaviour {
	//camera script reference
	public new Camera camera;
	//user defined target reference
	public GameObject userTarget;
	public Material LineMaterial;
	public float LineWidth;
	public float depth = 5;
	public LineRenderer lineDraw;
	//line start point in the scene
	private Vector3? lineStartPoint = null;

	// camera initialization
	void Start () {
		camera = GameObject.Find ("ARCamera").GetComponent<Camera>();

	}

	// Update is called once per frame
	void Update () {
		//when left button down
		if (Input.GetMouseButtonDown(0)) {
			//set line start point in the scene
			lineStartPoint = GetMouseCameraPoint ();
			//when left button up
		} else if (Input.GetMouseButtonUp(0)) 
		{
			if (lineStartPoint == null) {
				return;
			}
			//create line end point in the scene
			var lineEndPoint = GetMouseCameraPoint ();

			//Instantiate a line from a prefab
			var lineRender = Instantiate (lineDraw);

			// set lineRender as a child of USERTARGET
			userTarget = GameObject.Find("USERTARGET");
			lineRender.transform.parent = userTarget.transform;

			lineRender.material = LineMaterial;
			lineRender.SetPositions (new Vector3[]{ lineStartPoint.Value, lineEndPoint.Value });
			lineRender.startWidth = LineWidth;
			lineRender.endWidth = LineWidth;
			lineRender.useWorldSpace = false;
			lineRender.alignment = LineAlignment.View;

			lineStartPoint = null;

		}
	}

	//get a point in the world space from mouse click
	private Vector3? GetMouseCameraPoint()
	{
		var ray = camera.ScreenPointToRay (Input.mousePosition);
		return ray.origin + ray.direction * depth;
	}
}
