using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Displays the tutorial for each level for 4 seconds
public class ToggleControlls : MonoBehaviour
{
    public GameObject tutorialOverlay;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("ToggleTutorial", 4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleTutorial(){
        tutorialOverlay.SetActive(false);
    }
}
