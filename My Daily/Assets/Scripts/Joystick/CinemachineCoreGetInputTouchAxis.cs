using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineCoreGetInputTouchAxis : MonoBehaviour
{
    public float touchSensitivity = 30f;

    TouchField touchField;

    // Start is called before the first frame update
    void Start()
    {
        CinemachineCore.GetInputAxis = HandleAxisInputDelegate;
        touchField = FindObjectOfType<TouchField>();
    }

    float HandleAxisInputDelegate(string axisName)
    {
        switch (axisName)
        {

            case "Touch X":
                return touchField.TouchDist.x / touchSensitivity;


            case "Touch Y":
                return touchField.TouchDist.y / touchSensitivity;


            default:
                Debug.LogError("Input <" + axisName + "> not recognyzed.", this);
                break;
        }

        return 0f;
    }
}