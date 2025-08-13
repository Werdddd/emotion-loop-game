using UnityEngine;
using System.Collections.Generic; // Needed for List<>

public class PlayerDeathManager : MonoBehaviour
{
    public List<GameObject> crystalsToRespawn; // Drag crystal GameObjects here in Inspector

    public void OnPlayerDeath()
    {
        // Example: remove IceCrystal from inventory
        InventoryManager.Instance.RemoveItem("IceCrystal");

        // Respawn the crystal
        foreach (GameObject crystal in crystalsToRespawn)
        {
            crystal.SetActive(true);
        }
    }
}
