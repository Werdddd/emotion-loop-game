using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour, IInteractible
{
    [SerializeField] public GameObject fruit;

    [SerializeField] public bool fruitTaken = false;
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;
    [SerializeField] public SoundController soundController;
    public bool Interact(Interactor interactor)
    {
        soundController.InteractSound();
        Debug.Log("Got the Fruit");
        fruitTaken = true;
        fruit.SetActive(false);
        return true;
    }

}
