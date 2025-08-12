using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour, IInteractible
{
    [SerializeField] public GameObject animal;

    [SerializeField] public Fruit fruit;

    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;
    [SerializeField] public AudioSource birdChirp;

    public bool Interact(Interactor interactor)
    {
        Debug.Log("test");
        if (fruit.fruitTaken == true)
        {
            Debug.Log("Feeding the animal");
            StartCoroutine(FeedAnimal());
            return true;
        }
        return true;
    }

    IEnumerator FeedAnimal()
    {
        birdChirp.Play();
        animal.GetComponent<Animator>().Play("Jump");
        yield return new WaitForSeconds(5.0f);
    }
}
