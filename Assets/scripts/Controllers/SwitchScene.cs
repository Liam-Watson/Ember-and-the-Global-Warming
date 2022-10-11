using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public int sceneToSwitchTo;
    private void OnTriggerEnter2D(Collider2D other) {
        SceneManager.LoadScene(sceneToSwitchTo);
    }
}
