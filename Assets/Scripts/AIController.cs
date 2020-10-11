using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class file that handles the movement of the vehicle controlled by the enemy AI
public class AIController : MonoBehaviour
{
    // Variables containing the path of the AI vehicle
    [Header("Pathing Reference")]
    [Tooltip("Contains the waypoints")]
    public Transform Path;    

    [Header("AI Characteristics")]
    [Tooltip("Contains Data of the vehicle of the AI")]
    public Transform CarPosition;
    [Tooltip("Contains the Maximum Steer of the vehicle")]
    public float MaxSteerAngle = 30;
    [Tooltip("Contains the Maximum Speed of the vehicle")]
    public float MotorForce;

    // Variables containing the data of the wheel colliders
    [Header("Vehicle Wheel Colliders")]
    [Tooltip("Front Wheels")]
    public WheelCollider FrontL;
    public WheelCollider FrontR;
    [Tooltip("Back Wheels")]
    public WheelCollider BackR, BackL;

    // Variables containing the data of the wheel positions
    [Header("Transform Wheel Positions")]
    [Tooltip("Front Wheels")]
    public Transform TFrontR;
    public Transform TFrontL;
    [Tooltip("Back Wheels")]
    public Transform TBackR, TBackL;

    // contains the current index of waypoint being followed and the array container of the waypoints
    private int CurrentWaypoint = 0;
    private List<Transform> Waypoints;

    // Start is called before the first frame update
    void Start()
    {
        Transform[] WaypointTransforms = Path.GetComponentsInChildren<Transform>();
        Waypoints = new List<Transform>();

        // Verify Pathing
        for (int i = 0; i < WaypointTransforms.Length; i++)
        {
            if (WaypointTransforms[i].transform != Path.transform)
            {
                Waypoints.Add(WaypointTransforms[i]);
            }
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (CurrentWaypoint < Waypoints.Count)
        {
            ApplySteer();
            Drive();
            CheckWaypointDistance();
            UpdateWheelPoses();
        }        
    }

    // Method that applies waypoint data to corresponding steer
    private void ApplySteer()
    {
        if (CurrentWaypoint <= Waypoints.Count)
        {
            Vector3 RelativeVector = CarPosition.InverseTransformPoint(Waypoints[CurrentWaypoint].position);
            float NewSteerAngle = (RelativeVector.x / RelativeVector.magnitude) * MaxSteerAngle;
            FrontL.steerAngle = NewSteerAngle;
            FrontR.steerAngle = NewSteerAngle;
        }
    }

    // Method that accelerates AI vehicle
    private void Drive()
    {
        FrontL.motorTorque = MotorForce;
        FrontR.motorTorque = MotorForce;
    }

    // Method that checks waypoint distance and decides when to switch waypoint
    private void CheckWaypointDistance()
    {
        if (Vector3.Distance(CarPosition.position, Waypoints[CurrentWaypoint].position) < 10f)
        {
            CurrentWaypoint += 1;
        }
    }

    // General method that applies the graphical representation of a moving vehicle
    private void UpdateWheelPoses()
    {
        UpdateWheelPose(FrontR, TFrontR);
        UpdateWheelPose(FrontL, TFrontL);
        UpdateWheelPose(BackR, TBackR);
        UpdateWheelPose(BackL, TBackL);
    }

    // Specific method that applies the graphical representation of a moving vehicle
    private void UpdateWheelPose(WheelCollider WCollider, Transform WTransform)
    {
        Vector3 Position = WTransform.position;
        Quaternion Rotation = transform.rotation;

        WCollider.GetWorldPose(out Position, out Rotation);

        WTransform.position = Position;
        WTransform.rotation = Rotation;
    }

    public void setWaypointZero ()
    {
        CurrentWaypoint = 0;
    }
}
