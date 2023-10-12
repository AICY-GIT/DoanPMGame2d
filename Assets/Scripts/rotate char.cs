using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateChar : MonoBehaviour
{
    public float scaleSpeed = 10f;

    void Update()
    {
        ScaleCharacter();
    }

    private void ScaleCharacter()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput > 0)
        {
            
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (horizontalInput < 0)
        {
            
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }
}


