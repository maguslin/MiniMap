using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour {

    public float Speed = 4.0f;
    public float Sensitivity = 15f;
    private float rotationX = 0;
    private float rotationY = 0;
    public float MinAngleX = -360f;
    public float MaxAngleX = 360f;
    public float MinAngleY = -60f;
    public float MaxAngleY = 60f;
    public GameObject Map;
    public GameObject Minimap;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(h, 0, v) * Speed * Time.deltaTime);

        rotationX += Input.GetAxis("Mouse X") * Sensitivity;
        rotationY += Input.GetAxis("Mouse Y") * Sensitivity;
        if (rotationX >= 360f)
            rotationX = 0;
        if (rotationX <= -360f)
            rotationX = 0;
        rotationX = ClampAngle(rotationX,MinAngleX,MaxAngleX);
        rotationY = ClampAngle(rotationY, MinAngleY, MaxAngleY);
        Debug.Log(rotationX);
        Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
        Quaternion yQuaternion = Quaternion.AngleAxis(rotationY, Vector3.left);

        this.transform.rotation = xQuaternion * yQuaternion;

        if (Input.GetKeyDown(KeyCode.M))
        {
            Map.SetActive(true);
            Minimap.SetActive(false);
        }
	}

    public void BackMiniMap()
    {
        Map.SetActive(false);
        Minimap.SetActive(true);
    }

    private float ClampAngle(float angle,float min,float max)
    {
        if (angle < -360f)
            angle += 360f;
        if (angle > 360f)
            angle -= 360f;

        return Mathf.Clamp(angle, min, max);
    }
}
