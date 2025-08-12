using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomPlayerParticle : MonoBehaviour
{

    [SerializeField] public GameObject player;
    [SerializeField] public ParticleSystem snow;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (player != null && SceneManager.GetActiveScene().name == "IceRoomScene")
        {
            snow.transform.parent = player.transform;
        }
    }
}
