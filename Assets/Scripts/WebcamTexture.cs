using UnityEngine;
using System.Collections;

public class WebcamTexture : MonoBehaviour {

	WebCamTexture webcamTexture;
	public int webcamNumber;
	float cameraAspect;

	//fit camera plane to screen
	private float margin = 0f;
	public float scaleFactor = 1f;
    public bool rotatePlane = false;

	void Start ()
	{
		
		WebCamDevice[] devices = WebCamTexture.devices;
		webcamTexture = new WebCamTexture();

		if(devices.Length > 0)
		{
			webcamTexture.deviceName = devices[webcamNumber].name;
			webcamTexture.Play();
			this.GetComponent<Renderer>().material.mainTexture = webcamTexture;
		}

        if (rotatePlane) this.transform.Rotate(Vector3.forward, 180);
		FitScreen ();
	}

	void FitScreen()
    {
		Camera cam = this.transform.parent.GetComponent<Camera>();
		
		float height = cam.orthographicSize * 2.0f;
		float width = height * Screen.width / Screen.height;
		float fix = 0;
		
		if( width > height ) fix = width + margin;
		if( width < height ) fix = height +margin;
		this.transform.localScale = new Vector3((fix/scaleFactor ) * 4/3, fix/scaleFactor, 0.1f);
	}

}
