using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plank : MonoBehaviour, IInteractible
{
    [SerializeField] public GameObject plank;
    [SerializeField] public bool plankTaken = false;
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;
    [SerializeField] public SoundController soundController;

    [SerializeField] public BoatBuilder boatBuilder;
    public bool Interact(Interactor interactor)
    {
        soundController.InteractSound();
        Debug.Log("Got the Plank");
        boatBuilder.plankCtr++;
        plankTaken = true;
        plank.SetActive(false);
        return true;
    }
}
