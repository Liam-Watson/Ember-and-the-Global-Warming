using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    private float length, startpos, y , z;
    public GameObject cam;
    public float parallaxScale;
    public bool shift = false;
    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().size.x;
        
        y = transform.position.y;
        z = transform.position.z;

    }

    // Update is called once per frame
    void Update()
    {
        float temp = (cam.transform.position.x * (1 - parallaxScale));
        float distance = (cam.transform.position.x * parallaxScale);
        transform.position = new Vector3(startpos + distance, y, z);

        if(shift){
            if(temp >= startpos + (length)) startpos += (length);
            else if(temp < startpos - (length)) startpos -= (length);
        }
        
    }
}
