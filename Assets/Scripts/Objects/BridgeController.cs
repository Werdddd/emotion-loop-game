using UnityEngine;

public class BridgeController : MonoBehaviour
{
    public GameObject bridge;
    public PillarSlot icePillar;
    public PillarSlot landPillar;
    public PillarSlot firePillar;

    void Update()
    {
        if (icePillar.IsCrystalPlaced && landPillar.IsCrystalPlaced && firePillar.IsCrystalPlaced)
        {
            if (!bridge.activeSelf)
            {
                bridge.SetActive(true);
                Debug.Log("Bridge is now active!");
            }
        }
        else
        {
            if (bridge.activeSelf)
            {
                bridge.SetActive(false);
            }
        }
    }
}
