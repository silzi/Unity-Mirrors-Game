using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMotor : MonoBehaviour {

    public float moveSpeed = 5.0f;
    public float drag = 0.5f;
    public float terminalRotationSpeed = 25.0f;
    public Vector3 MoveVector { set; get; }
    public VirtualJoystick JoyStick;

    private Rigidbody thisRigidBody;
    private Transform CamTransform;

	void Start ()
    {
        thisRigidBody = gameObject.AddComponent<Rigidbody>();
        thisRigidBody.maxAngularVelocity = terminalRotationSpeed;
        thisRigidBody.drag = drag;
		
	}


    void Update()
    {
        MoveVector = PoolInput();

        MoveVector = RotateWithView();

        Move();
    }

    private void Move()
       {
           thisRigidBody.AddForce((MoveVector * moveSpeed));
       }

    private Vector3 PoolInput()
    {
         Vector3 dir = Vector3.zero;

        

        dir.x = JoyStick.Horizontal();
        dir.z = JoyStick.Vertical();

        if (dir.magnitude > 1)
        dir.Normalize();

    return dir;
    }

    private Vector3 RotateWithView()
    {
        if (CamTransform != null)
        {
            Vector3 dir = CamTransform.TransformDirection(MoveVector);
            dir.Set(dir.x, 0, dir.z);
            return dir.normalized * MoveVector.magnitude;
        }

        else
        {
            CamTransform = GetComponent<BallCamera>().CamTransform;
            return MoveVector;
            
        }

    }

}
