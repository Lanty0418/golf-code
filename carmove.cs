using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carmove : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform startMarker;
    public Transform endMakrker;
    public float speed = 1.0f;
    private float startTime;
    private float journeyLength;
    private int move = 0;

    void Start()
    {
        transform.rotation = Quaternion.identity;
        journeyLength = Vector3.Distance(startMarker.position, endMakrker.position);
    }
    void Update()
    {
        
     
            
            transform.LookAt(endMakrker);
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(startMarker.position, endMakrker.position, fracJourney);
            transform.rotation = Quaternion.identity;


    }
    void OnCollisionEnter(Collision a)
    {
        startTime = Time.time;
        move = 1;
        Debug.Log("yes");
    }
}
