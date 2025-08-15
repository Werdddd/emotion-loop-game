using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ObjectiveText : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI objectiveText; 
    [SerializeField] public BoatBuilder boatBuilder;
    [SerializeField] public GameObject objectiveWrapper;

    void Update()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "IceRoomScene":
                objectiveText.text = "Sadness freezes your every step, turning the ground into peril. Leap across its cold emptiness—only then can you chip away at the loop’s hold.";
                objectiveText.gameObject.SetActive(true);
                objectiveWrapper.gameObject.SetActive(true);
                break;

            case "FireRoomScene":
                objectiveText.text = "Anger twists the path into a burning maze. Every wall of flame dares you to turn back—but to break the loop, you must find the calm to see the way through.";
                objectiveText.gameObject.SetActive(true);
                objectiveWrapper.gameObject.SetActive(true);
                break;

            case "TutorialScene":
                objectiveText.text = "Every journey begins small… learn to walk before you face yourself.";
                objectiveText.gameObject.SetActive(true);
                objectiveWrapper.gameObject.SetActive(true);
                break;

            case "MainScene":
                objectiveText.text = "The loop begins where it always does—beneath the lone tree, before the sealed door. Three emotions must be faced before the bridge can carry you forward.";
                objectiveText.gameObject.SetActive(true);
                objectiveWrapper.gameObject.SetActive(true);
                break;

            case "IslandRoomScene":
                if (boatBuilder.boatCreated == true)
                {
                    objectiveText.text = "Objectives: The boat is created. Get in the boat!";
                    objectiveText.gameObject.SetActive(true);
                    objectiveWrapper.gameObject.SetActive(true);
                    break;
                }
                else
                {
                    objectiveText.text = $"Joy drifts just out of reach, scattered like pieces on the wind. Gather what remains, rebuild your vessel, and sail past the loop's fading shores. \nWood: {boatBuilder.plankCtr}/3 \nPaddle: {boatBuilder.paddleCtr}/1";
                    objectiveText.gameObject.SetActive(true);
                    objectiveWrapper.gameObject.SetActive(true);
                    break;
                }

            case "HorrorRoomScene":
                objectiveText.text = "Objectives: ";
                objectiveText.gameObject.SetActive(true);
                objectiveWrapper.gameObject.SetActive(true);
                break;
            
            default:
                objectiveText.gameObject.SetActive(false);
                objectiveWrapper.gameObject.SetActive(false);
                break;
        }
        
    }
}
