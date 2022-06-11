using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeManager : MonoBehaviour
{
    public PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        // set player position
        player.GetComponent<CharacterController>().enabled = false;
        player.GetComponent<CharacterController>().transform.position = new Vector3(PlayerPrefsManager.instance.GetPlayerPositionX(), PlayerPrefsManager.instance.GetPlayerPositionY(), PlayerPrefsManager.instance.GetPlayerPositionZ());
        player.GetComponent<CharacterController>().enabled = true;

        InvokeRepeating("SavePosition", 1, 5);
    }

    void SavePosition()
    {
        PlayerPrefsManager.instance.SetPlayerPositionX(player.transform.position.x);
        PlayerPrefsManager.instance.SetPlayerPositionY(player.transform.position.y);
        PlayerPrefsManager.instance.SetPlayerPositionZ(player.transform.position.z);
    }
}
