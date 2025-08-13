using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalToScene4 : MonoBehaviour
{
    [SerializeField] private int sceneIndexToLoad = 4; // Scene 4 by default

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneIndexToLoad);
        }
    }
}
