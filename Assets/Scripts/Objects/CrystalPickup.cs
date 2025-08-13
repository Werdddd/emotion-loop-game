using UnityEngine;

public class CrystalPickup : MonoBehaviour
{
    public string crystalName; // e.g., "IceCrystal"

    private void OnMouseDown()
    {
        Debug.Log("Crystal clicked: " + crystalName);

        if (InventoryManager.Instance != null)
        {
            InventoryManager.Instance.AddItem(crystalName);
        }

        gameObject.SetActive(false); // Hide instead of Destroy
    }
}
