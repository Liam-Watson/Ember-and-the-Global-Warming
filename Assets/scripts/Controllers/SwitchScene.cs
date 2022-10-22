using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Switches scene to the scene number specified
public class SwitchScene : MonoBehaviour
{
    public int sceneToSwitchTo;
    private void OnTriggerEnter2D(Collider2D other) {
        // SceneManager.LoadScene(sceneToSwitchTo);
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(sceneToSwitchTo);
        }
        
    }
}
