using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidKill : MonoBehaviour
{
    [SerializeField] PlayerStats player;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            player.TakeDamage(5f);
            Debug.Log(player.health);
        }
    }
}
