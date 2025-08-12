using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour, IInteractible
{
    [SerializeField] public GameObject door;

    [SerializeField] public bool isOpened = false;
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;
    [SerializeField] public SoundController soundController;

    public bool Interact(Interactor interactor)
    {
        Debug.Log("Opening Door");
        StartCoroutine(OpenDoor());
        return true;
    }

    IEnumerator OpenDoor()
    {
        soundController.DoorOopenSound();
        isOpened = true;
        door.GetComponent<Animator>().Play("DoorOpen");
        yield return new WaitForSeconds(5.0f);
    }
}
