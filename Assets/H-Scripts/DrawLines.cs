using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLines : MonoBehaviour {
	public Camera camera;
	public GameObject test;
	public Material LineMatrial;
	public float LineWidth;
	public float depth = 5;
	public LineRenderer lineDraw;
	private Vector3? lineStartPoint = null;

	// Use this for initialization
	void Start () {
		camera = GameObject.Find ("ARCamera").GetComponent<Camera>();

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			lineStartPoint = GetMouseCameraPoint ();
		} else if (Input.GetMouseButtonUp(0)) 
		{
			if (lineStartPoint == null) {
				return;
			}
				var lineEndPoint = GetMouseCameraPoint ();

			var lineRender = Instantiate (lineDraw);
			test = GameObject.Find("UserDefinedTarget-1");
			lineRender.transform.parent = test.transform;

				lineRender.material = LineMatrial;
				lineRender.SetPositions (new Vector3[]{ lineStartPoint.Value, lineEndPoint.Value });
			lineRender.startWidth = LineWidth;
			lineRender.endWidth = LineWidth;
			lineRender.useWorldSpace = false;

				

			lineStartPoint = null;


		}

		
	}

	private Vector3? GetMouseCameraPoint()
	{
		var ray = camera.ScreenPointToRay (Input.mousePosition);
		return ray.origin + ray.direction * depth;
	}
}
