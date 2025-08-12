using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] public AudioSource spawn;
    [SerializeField] public AudioSource interact;
    [SerializeField] public AudioSource doorOpen;
    [SerializeField] public AudioSource hurt;
    [SerializeField] public AudioSource dead;

    void Start()
    {
        spawn.Play();
    }

    public void InteractSound()
    {
        interact.Play();
    }

    public void DoorOopenSound()
    {
        doorOpen.Play();
    }

    public void PlayerHurtSound()
    {
        hurt.Play();
    }

    public void PlayerDeadSound()
    {
        dead.Play();
    }
    
}

