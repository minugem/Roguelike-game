using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
/// <summary>
/// Camera follow the player
/// </summary>
public class AutoSetupCamera : MonoBehaviour
{
    Player player;
    

    private void Awake()
    {
        CinemachineVirtualCamera camera = GetComponent<CinemachineVirtualCamera>();

        player = FindObjectOfType<Player>(); //Find player in the scene

        if (player != null)
        {
            camera.Follow = player.transform;
        }
    }

}
