using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class sceneSwitchOnVideoEnd : MonoBehaviour
{
    // Start is called before the first frame update
    public VideoPlayer vp;

    public int nextScene;

    void Start()
    {
        vp.Play();
 
        //Invoke repeating of checkOver method
        InvokeRepeating("checkOver", .1f,.1f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void checkOver()
{
       long playerCurrentFrame = vp.GetComponent<VideoPlayer>().frame;
       long playerFrameCount = System.Convert.ToInt64(vp.GetComponent<VideoPlayer>().frameCount);
    //    Debug.Log(playerCurrentFrame);
    //    Debug.Log(playerFrameCount);
     
       if(playerCurrentFrame >= playerFrameCount-1)
       {
          //Do w.e you want to do for when the video is done playing.
       
          //Cancel Invoke since video is no longer playing
           CancelInvoke("checkOver");
           SceneManager.LoadScene(nextScene);
       }
}
    
}
