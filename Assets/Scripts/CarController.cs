using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class file that handles the movement of the vehicle controlled by the player
public class CarController : MonoBehaviour
{
    //References

    // Variables containing the data of the vehicles characteristics
    [Header("Car Reference Values")]
    [Tooltip("Maximum Steer of Vehicle")]
    public float MaximumSteerAngle = 30f;
    [Tooltip("Maximum Speed")]
    public float MotorForce = 800f;

    // Variables containing the data of the wheel colliders
    [Header("Vehicle Wheel Colliders")]
    [Tooltip("Front Wheels")]
    public WheelCollider FrontR;
    public WheelCollider FrontL;
    [Tooltip("Back Wheels")]
    public WheelCollider BackR, BackL;

    // Variables containing the data of the wheel positions
    [Header("Transform Wheel Positions")]
    [Tooltip("Front Wheels")]
    public Transform TFrontR;
    public Transform TFrontL;
    [Tooltip("Back Wheels")]
    public Transform TBackR, TBackL;

    // Private values
    private float HorizontalInput;
    private float VerticalInput;
    private float SteeringAngle;

    // Get User Input (WASD)
    public void GetInput()
    {
        HorizontalInput = Input.GetAxis("Horizontal");
        VerticalInput = Input.GetAxis("Vertical");
    }

    // Gather horizontal (AD) input from user and convert to steering
    private void Steer()
    {
        SteeringAngle = MaximumSteerAngle * HorizontalInput;
        FrontR.steerAngle = SteeringAngle;
        FrontL.steerAngle = SteeringAngle;
    }

    // Gather vertical (WS) input from user and convert to Acceleration
    private void Accelerate()
    {
        FrontL.motorTorque = VerticalInput * MotorForce;
        FrontR.motorTorque = VerticalInput * MotorForce;
    }

    // Convert Gathered input data and convert to graphical representation
    private void UpdateWheelPoses()
    {        
        UpdateWheelPose(FrontR, TFrontR);
        UpdateWheelPose(FrontL, TFrontL);
        UpdateWheelPose(BackR, TBackR);
        UpdateWheelPose(BackL, TBackL);
    }

    // Main method to convert input data to graphical representation
    private void UpdateWheelPose(WheelCollider WCollider, Transform WTransform)
    {
        Vector3 Position = WTransform.position;
        Quaternion Rotation = transform.rotation;

        WCollider.GetWorldPose(out Position, out Rotation);

        WTransform.position = Position;
        WTransform.rotation = Rotation;
    }

    // Update method that runs based on the physics fps
    private void FixedUpdate()
    {
        GetInput();
        Steer();
        Accelerate();
        UpdateWheelPoses();
    }
}
