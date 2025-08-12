using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterKill : MonoBehaviour
{
    [SerializeField] PlayerStats player;
    private float timeInWater = 0f;
    private bool isInWater = false;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInWater = true;
            timeInWater += Time.deltaTime;
            if (timeInWater >= 3f)
            {
                player.TakeDamage(2);
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInWater = false;
            timeInWater = 0f;
        }
    }
}
