using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ObjectiveText : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI objectiveText;
    [SerializeField] public GameObject objectiveWrapper;
    [SerializeField] public BoatBuilder boatBuilder; // used in IslandRoom

    [Header("FinalScene required crystals (names must match InventoryManager.AddItem)")]
    [SerializeField] private string[] requiredCrystals = { "FireCrystal", "IceCrystal", "IslandCrystal" };

    private void Awake()
    {
        // Try to auto-wire references if not assigned in the Inspector
        if (objectiveText == null)
            objectiveText = GetComponentInChildren<TextMeshProUGUI>(true);

        if (objectiveWrapper == null && objectiveText != null)
            objectiveWrapper = objectiveText.transform.parent != null
                ? objectiveText.transform.parent.gameObject
                : null;

        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void Update()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        if (sceneName == "IslandRoomScene")
        {
            if (boatBuilder == null)
                boatBuilder = FindObjectOfType<BoatBuilder>();

            if (boatBuilder != null)
            {
                if (boatBuilder.boatCreated)
                {
                    SetObjective("Objectives: The boat is created. Get in the boat!");
                }
                else
                {
                    SetObjective(
                        $"Joy drifts just out of reach, scattered like pieces on the wind. " +
                        $"Gather what remains, rebuild your vessel, and sail past the loop's fading shores. " +
                        $"\nWood: {boatBuilder.plankCtr}/3 \nPaddle: {boatBuilder.paddleCtr}/1");
                }
            }
        }
        else if (sceneName == "FinalScene")
        {
            // Update the objective text dynamically for FinalScene
            UpdateFinalSceneObjective();
        }
    }
    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Start()
    {
        // Apply immediately for the starting scene
        ApplyForScene(SceneManager.GetActiveScene().name);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ApplyForScene(scene.name);
    }

    private void ApplyForScene(string sceneName)
    {
        if (objectiveText == null)
        {
            Debug.LogError("[ObjectiveText] objectiveText is not assigned or found in children.");
            return;
        }

        // default hidden unless we set something below
        objectiveText.gameObject.SetActive(false);
        if (objectiveWrapper != null) objectiveWrapper.SetActive(false);

        switch (sceneName)
        {
            case "IceRoomScene":
                SetObjective("Sadness freezes your every step, turning the ground into peril. Leap across its cold emptiness—only then can you chip away at the loop's hold.");
                break;

            case "FireRoomScene":
                SetObjective("Anger twists the path into a burning maze. Every wall of flame dares you to turn back—but to break the loop, you must find the calm to see the way through.");
                break;

            case "TutorialScene":
                SetObjective("Every journey begins small… learn to walk before you face yourself.");
                break;

            case "MainScene":
                SetObjective("The loop begins where it always does—beneath the lone tree, before the sealed door. Three emotions must be faced before the bridge can carry you forward.");
                break;

            case "HorrorRoomScene":
                SetObjective("Objectives: ");
                break;

            case "FinalScene":
                UpdateFinalSceneObjective();
                break;

            default:
                // keep hidden
                break;
        }
    }

    private void UpdateFinalSceneObjective()
    {
        // Find all pillar slots in the scene
        PillarSlot[] pillarSlots = FindObjectsOfType<PillarSlot>();

        bool allPillarsFilled = pillarSlots.Length > 0 && pillarSlots.All(pillar => pillar.IsCrystalPlaced);

        if (allPillarsFilled)
        {
            SetObjective("You have broken the loop. You have rewritten the pattern. And now, with every thread set free, you unravel yourself—stepping beyond the cycle into the life that waits ahead.");
        }
        else
        {
            SetObjective("The pillars stand empty, the bridge lies broken, and the loop pulls you back once more.");
        }
    }

    private void SetObjective(string msg)
    {
        objectiveText.text = msg;
        objectiveText.gameObject.SetActive(true);
        if (objectiveWrapper != null) objectiveWrapper.SetActive(true);
    }
}