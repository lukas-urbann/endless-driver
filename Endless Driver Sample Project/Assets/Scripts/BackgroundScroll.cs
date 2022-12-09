using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{

    public MeshRenderer backgroundRenderer;

    private void Update()
    {
        backgroundRenderer.material.mainTextureOffset += new Vector2(0, (GameSpeed.Instance.GetGameSpeed() / 10) * Time.deltaTime);
    }
}