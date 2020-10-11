using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathing : MonoBehaviour
{
    // Visualize Pathing for coding purposes
    [Header("Car Reference Values")]
    [Tooltip("Representation color of the pathing")]
    public Color LineColor;

    // Array containing valid waypoints
    private List<Transform> Waypoints = new List<Transform>();

    // Validate and draw waypoint
    private void OnDrawGizmos()
    {
        Gizmos.color = LineColor;

        // Storage for waypoints to verify and validate
        Transform[] WaypointTransforms = GetComponentsInChildren<Transform>();
        Waypoints = new List<Transform>();

        // Verify Pathing
        for (int i = 0; i < WaypointTransforms.Length; i++)
        {
            if(WaypointTransforms[i] != transform)
            {
                Waypoints.Add(WaypointTransforms[i]);
            }
        }

        // Draw Pathing on Editor
        for (int i = 0; i < Waypoints.Count; i++)
        {
            Vector3 CurrentNode = Waypoints[i].position;
            Vector3 PreviousNode = Waypoints[i].position;
            if (i > 0)
            {
                PreviousNode = Waypoints[i - 1].position;
            }            

            // Draw Pathing and Waypoint Game Object on verified Waypoints
            Gizmos.DrawLine(PreviousNode, CurrentNode);
            Gizmos.DrawWireSphere(CurrentNode, 0.3f);
        }
    }
}
