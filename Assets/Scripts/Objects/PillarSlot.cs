using UnityEngine;

public class PillarSlot : MonoBehaviour
{
    public string requiredCrystal; // Name of crystal needed
    public GameObject placedCrystalPrefab; // Prefab to spawn
    public Transform socket; // Where it will appear
    public AudioSource placeCrystalSound; // Sound when crystal is placed

    private bool isFilled = false;
    public bool IsCrystalPlaced => isFilled;

    private void OnMouseDown()
    {
        if (isFilled) return; // Already placed

        if (InventoryManager.Instance.HasItem(requiredCrystal))
        {
            // Spawn the crystal at socket location
            Instantiate(placedCrystalPrefab, socket.position, socket.rotation);

            // Remove from inventory
            InventoryManager.Instance.RemoveItem(requiredCrystal);

            // Play sound if assigned
            if (placeCrystalSound != null)
            {
                placeCrystalSound.Play();
            }

            isFilled = true;
            Debug.Log(requiredCrystal + " placed on pillar!");
        }
        else
        {
            Debug.Log("You don't have the required crystal: " + requiredCrystal);
        }
    }
}
