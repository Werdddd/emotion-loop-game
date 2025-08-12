using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    [SerializeField] GameObject player;

    [SerializeField] float speed = 1f;

    [SerializeField] Door door;

    [SerializeField] MoveScene moveScene;

    void Update()
    {
        if (door.isOpened == true)
        {
            Follow();
        }
    }

    void Follow()
    {
        transform.position = Vector3.MoveTowards(
            transform.position, 
            player.transform.position, 
            speed * Time.deltaTime);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            moveScene.NextScene();
        }
    }
}
