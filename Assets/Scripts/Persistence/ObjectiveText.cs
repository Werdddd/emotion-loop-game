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
                objectiveText.text = "Objectives: Find your way to the other side";
                objectiveText.gameObject.SetActive(true);
                objectiveWrapper.gameObject.SetActive(true);
                break;

            case "FireRoomScene":
                objectiveText.text = "Objectives: Find your way to the other side";
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
                    objectiveText.text = $"Objectives: Build a boat to escape! \nWood: {boatBuilder.plankCtr}/3 \nPaddle: {boatBuilder.paddleCtr}/1";
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
