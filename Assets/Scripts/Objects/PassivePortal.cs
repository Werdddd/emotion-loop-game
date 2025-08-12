using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassivePortal : MonoBehaviour
{
    [SerializeField] MoveScene moveScene;
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            moveScene.NextScene();
        }
    }
}
