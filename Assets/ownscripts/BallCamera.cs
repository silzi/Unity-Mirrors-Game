using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCamera : MonoBehaviour {

    private const float Y_ANGLE_MIN = 0.0f;
    private const float Y_ANGLE_MAX = 180.0f;

    private Transform thisTransform;
    private Camera cam;
    private float distance =10.0f;
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    private float sensitivyX = 1.0f;
    private float sensitivyY = 1.0f;

    public VirtualJoystick JoyStick;
    public Transform CamTransform { set; get; }
    

	void Start ()
    {
    CamTransform = new GameObject("Camera Container").transform;
    cam = CamTransform.gameObject.AddComponent<Camera>();
    cam.tag = "MainCamera";

    thisTransform = transform;

	}
	
	// Update is called once per frame
	void Update ()
    {
        currentX += JoyStick.Horizontal() * sensitivyX;
        currentY += JoyStick.Vertical() * sensitivyY;

        currentY = ClampAngle(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
    }

    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, - distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        CamTransform.position = thisTransform.position + rotation * dir;
        CamTransform.LookAt(thisTransform.position);
    }

    private float ClampAngle(float angle, float min, float max)
    {
        do
        {
            if (angle < -360)
                angle += 360;
            if (angle > 360)
                angle -= 360;
        } while (angle < -360 || angle > 360);

        return Mathf.Clamp(angle, min, max);
    }
}
