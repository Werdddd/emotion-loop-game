using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plank2 : MonoBehaviour, IInteractible
{
    [SerializeField] public GameObject plank;
    [SerializeField] public bool plankTaken = false;
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;
    [SerializeField] public BoatBuilder boatBuilder;
    [SerializeField] public SoundController soundController;
    public bool Interact(Interactor interactor)
    {
        soundController.InteractSound();
        Debug.Log("Got the Plank2");
        boatBuilder.plankCtr++;
        plankTaken = true;
        plank.SetActive(false);
        return true;
    }
}
