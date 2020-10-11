using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    private int Place = 1;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Car"))
        {
            Place++;
        }
        else if (collision.gameObject.name.Contains("Player"))
        {
            // Unlocking Cursor
            Cursor.lockState = CursorLockMode.None;
            if (Place == 1)
            {
                SceneManager.LoadScene(2);
            }
            else if (Place == 2)
            {
                SceneManager.LoadScene(3);
            }
            else if (Place == 3)
            {
                SceneManager.LoadScene(4);
            }
            else if (Place == 4)
            {
                SceneManager.LoadScene(5);
            }
        }
    }
}
