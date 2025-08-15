using UnityEngine;

public class CrystalPickup : MonoBehaviour
{
    public string crystalName; // e.g., "IceCrystal"
    public AudioSource pickupSound; // Reference to the sound controller

    private void OnMouseDown()
    {
        Debug.Log("Crystal clicked: " + crystalName);

        if (InventoryManager.Instance != null)
        {
            InventoryManager.Instance.AddItem(crystalName);
        }

        // Play sound if available
        if (pickupSound != null)
        {
            pickupSound.Play();
        }

        gameObject.SetActive(false); // Hide instead of Destroy
    }
}
