using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionPedestrian : MonoBehaviour
{
    //References
    [Header("References")]
    public Transform ModelTrans;
    public AIController Controller = null;

    // Placeholder values
    private Vector3 SpawnPoint;
    private Quaternion SpawnRotation;

    // Records spawnpoint of vehicle
    void Start()
    {
        SpawnPoint = ModelTrans.position;
        SpawnRotation = ModelTrans.rotation;
    }

    // Checks if vehicle collided with Pedestrian
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Pedestrian")) {
            if (Controller)
            {
                Controller.setWaypointZero();
            }
            ModelTrans.position = new Vector3(SpawnPoint.x, SpawnPoint.y + 2, SpawnPoint.z);
            ModelTrans.rotation = SpawnRotation;
        }
    }
}
