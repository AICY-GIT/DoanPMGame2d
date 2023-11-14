using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;
using Unity.VisualScripting;

public class Brightness : MonoBehaviour
{
    public Slider brightnessSlider;

    public PostProcessProfile brightness;

    public PostProcessLayer layer;

    AutoExposure exposure;
    // Start is called before the first frame update
    void Start()
    {
        brightness.TryGetSettings(out exposure);
    }

    // Update is called once per frame
    public void AdjustBrightness(float value)
    {
        if(value != 0)
        {
            exposure.keyValue.value = value;

        }
        else
        {
            exposure.keyValue.value = .05f;
        }
    }    
   
}
