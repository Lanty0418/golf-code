using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class control : MonoBehaviour
{

    public Rigidbody ball;
    public float rotatespeed = 5f;
    public LineRenderer line;
    public float maxPower;
    public float changeAngleSpeed;
    public float lineLength;
    public Slider powerSlider;
    public TextMeshProUGUI puttCountLabel;
    public float minHoleTime;

    private float angle;
    private float angle2;
    private float powerUptime;
    private float power;
    private int putts;
    private float holeTime;
    // Start is called before the first frame update
    void Start()
    {
        holeTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = ball.position;
        if(ball.velocity.magnitude < 0.01f)
        {
            if (Input.GetKey(KeyCode.A))
            {
                ChangeAngle(-1);
            }
            if (Input.GetKey(KeyCode.D))
            {
                ChangeAngle(1);
            }
            if (Input.GetKey(KeyCode.W))
            {
                ChangeAngle2(-1);
            }
            if (Input.GetKey(KeyCode.S))
            {
                ChangeAngle2(1);
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                Putt();
            }
            if (Input.GetKey(KeyCode.Space))
            {
                PowerUp();
            }
            UpdateLinePositions();
        }
        else
        {
            line.enabled = false;
        }
    }
    private void ChangeAngle(int direction)
    {

        angle += changeAngleSpeed * Time.deltaTime * direction;
    }
    private void ChangeAngle2(int direction)
    {
        
            angle2 += changeAngleSpeed * Time.deltaTime * direction;
        
        
    }
    private void UpdateLinePositions()
    {
        if(holeTime == 0) { line.enabled = true; }
        line.SetPosition(0, transform.position);
        line.SetPosition(1, transform.position + Quaternion.Euler(angle2, angle, 0) * Vector3.forward * lineLength);
        transform.rotation = Quaternion.Euler(0, angle, 0);
    }
    private void Putt()
    {
        ball.AddForce(Quaternion.Euler(angle2, angle, 0) * Vector3.forward * maxPower * power, ForceMode.Impulse);
       
        putts++;
        puttCountLabel.text = putts.ToString();
    }
    private void PowerUp()
    {
        powerUptime += Time.deltaTime;
        power = Mathf.PingPong(powerUptime, 1);
        powerSlider.value = power;
    }
  
}
