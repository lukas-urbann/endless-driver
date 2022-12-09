using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Obstacle : MonoBehaviour
{
    public List<Sprite> spriteList = new List<Sprite>();
    private SpriteRenderer objectSprite;
    private float timeOut;
    private float speed = 0;

    private void OnEnable()
    {
        objectSprite = GetComponent<SpriteRenderer>();
        
        SetRandomSprite();
    }

    private void SetRandomSprite()
    {
        try
        {
            objectSprite.sprite = spriteList[Random.Range(0, spriteList.Count + 1)];
        }
        catch (ArgumentOutOfRangeException)
        {
            objectSprite.sprite = spriteList[spriteList.Count-1];
        }
    }

    private void Update()
    {
        speed = GameSpeed.Instance.GetGameSpeed();
        timeOut -= Time.deltaTime * 1;

        transform.Translate(0, -speed * Time.deltaTime, 0);
    }

    private void OnBecameInvisible()
    {
        if(timeOut <= 0)
            Destroy(gameObject);
    }

    private void OnBecameVisible()
    {
        timeOut = 1f;
    }
}
