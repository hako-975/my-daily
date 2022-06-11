using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour
{
    #region Singleton
    public static PlayerPrefsManager instance;

    void Awake()
    {
        instance = this;
    }
    #endregion
    
    public float GetPlayerPositionX()
    {
        return PlayerPrefs.GetFloat("PlayerPositionX", 0f);
    }    

    public float SetPlayerPositionX(float x)
    {
        PlayerPrefs.SetFloat("PlayerPositionX", x);
        return GetPlayerPositionX();
    }

    public float GetPlayerPositionY()
    {
        return PlayerPrefs.GetFloat("PlayerPositionY", 0f);
    }

    public float SetPlayerPositionY(float y)
    {
        PlayerPrefs.SetFloat("PlayerPositionY", y);
        return GetPlayerPositionY();
    }

    public float GetPlayerPositionZ()
    {
        return PlayerPrefs.GetFloat("PlayerPositionZ", 0f);
    }

    public float SetPlayerPositionZ(float z)
    {
        PlayerPrefs.SetFloat("PlayerPositionZ", z);
        return GetPlayerPositionZ();
    }
}
