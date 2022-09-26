using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emberParticleMovement : MonoBehaviour
{
    private Transform playerPos;
    private Transform pos;
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        pos = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = GameObject.Find ("Ember").transform;
        pos.position = playerPos.position;
    }
}
