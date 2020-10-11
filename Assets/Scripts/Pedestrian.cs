using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedestrian : MonoBehaviour
{
    [Header("References")]
    [Tooltip("Pedestrian Object")]
    public GameObject PedestrianObject;
    
    [Tooltip("1 = North, 2 = South, 3 = East, 4 = West")]
    // Direction of Travel
    public int Direction;

    [Tooltip("Speed of Pedestrian")]
    // Speed of Pedestrian Movement
    public float Speed;

    [Tooltip("Hitbox Controller")]
    // Speed of Pedestrian Movement
    public CharacterController Controller;

    // Check if pedestrian is still alive
    private bool MoveForward;
    private Vector3 InitialPosition;
    private Vector3 Move;
    private float Multiplier;

    // Start is called before the first frame update
    void Start()
    {
        InitialPosition = transform.position;
        MoveForward = true;

        // Determine direction of pedestrian
        if (Direction == 1)
        {
            Multiplier = 1;
        }
        else if (Direction == 2)
        {
            Multiplier = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Move forward
        if (MoveForward)
        {
            // If pedestrian walked over the street
            if (transform.position.z > InitialPosition.z + 15) MoveForward = false;
            // Convert movement data to a vector 3
            Move = transform.forward * Speed * Multiplier;
        }
        // Move Back
        else
        {
            // If pedestrian walked over the street
            if (transform.position.z < InitialPosition.z) MoveForward = true;
            // Convert movement data to a vector 3
            Move = transform.forward * Speed * Multiplier * -1;
        }

        // Apply Movement
        Controller.Move(Move * Speed * Time.deltaTime);
    }

    // Handles mechanics when a pedestrian is hit
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Car") || collision.gameObject.name.Contains("Player"))
        {
            // Deactivates hit pedestrian
            PedestrianObject.SetActive(false);
        }        
    }
}
