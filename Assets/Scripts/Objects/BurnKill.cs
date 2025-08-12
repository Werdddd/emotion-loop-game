using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnKill : MonoBehaviour
{
    [SerializeField] PlayerStats player;

    private void OnParticleCollision(GameObject other)
    {
        if(other.tag == "Player")
        {
            player.TakeDamage(1.5f);
            Debug.Log(player.health);
        }
    }
}
