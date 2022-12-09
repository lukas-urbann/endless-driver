using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject explosion;
    private float speed = 3;
    private Quaternion wantedRotation;

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            DriveUp();
        else if (Input.GetKey(KeyCode.DownArrow))
            DriveDown();
        
        if (Input.GetKey(KeyCode.LeftArrow))
            TurnLeft();
        else if (Input.GetKey(KeyCode.RightArrow))
            TurnRight();
        else
            TurnStraight();
        
        Turn();
    }

    private void Turn()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, wantedRotation,  Time.deltaTime * 5);
    }

    private void DriveUp()
    {
        transform.Translate(0, speed * Time.deltaTime, 0, Space.World);
    }

    private void DriveDown()
    {
        transform.Translate(0, -speed * Time.deltaTime, 0, Space.World);
    }

    private void TurnLeft()
    {
        wantedRotation = Quaternion.Euler(0, 0, 20);
        transform.Translate(-speed * Time.deltaTime, 0, 0, Space.World);
    }

    private void TurnRight()
    {
        wantedRotation = Quaternion.Euler(0, 0, -20);
        transform.Translate(speed * Time.deltaTime, 0, 0, Space.World);
    }

    private void TurnStraight()
    {
        wantedRotation = Quaternion.Euler(0, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Obstacle"))
        {
            Instantiate(explosion, transform.position, transform.rotation);
            GameSpeed.Instance.GameOver();
            
            gameObject.SetActive(false);
        }
    }
}