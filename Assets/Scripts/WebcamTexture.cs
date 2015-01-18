using UnityEngine;
using System.Collections;

public class WebcamTexture : MonoBehaviour {

	 WebCamTexture webcamTexture;
	public int webcamNumber;
	GUITexture BackgroundTexture;
	float cameraAspect;

	//fit screen
	private float margin = 0f;
	public float scaleFactor = 1f;
    public bool rotatePlane = false;

	void Start ()
	{
		
		WebCamDevice[] devices = WebCamTexture.devices;
		webcamTexture = new WebCamTexture();

		BackgroundTexture = gameObject.GetComponent<GUITexture>();
		BackgroundTexture.pixelInset = new Rect(0,0,Screen.width,Screen.height);


		if(devices.Length > 0)
		{
			webcamTexture.deviceName = devices[webcamNumber].name;
			webcamTexture.Play();
			this.renderer.material.mainTexture = webcamTexture;
			BackgroundTexture.texture = webcamTexture;

		}

        if (rotatePlane) this.transform.Rotate(Vector3.forward, 180);
		FitScreen ();
	}

	void FitScreen() {
		Camera cam = this.transform.parent.camera;
		
		float height = cam.orthographicSize * 2.0f;
		float width = height * Screen.width / Screen.height;
		float fix = 0;
		
		if( width > height ) fix = width + margin;
		if( width < height ) fix = height +margin;
		this.transform.localScale = new Vector3((fix/scaleFactor ) * 4/3, fix/scaleFactor, 0.1f);
	}

}
