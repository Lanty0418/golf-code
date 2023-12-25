using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapcammove : MonoBehaviour
{
    public Camera minicamera;
    public Transform player;
    public Transform miniplayerIcon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        minicamera.transform.position = new Vector3(player.position.x, minicamera.transform.position.y, player.position.z);
        miniplayerIcon.eulerAngles = new Vector3(0, 0, -player.eulerAngles.y);
    }
}
