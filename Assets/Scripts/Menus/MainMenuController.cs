using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    [SerializeField] public MoveScene moveScene;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Play()
    {
        moveScene.NextScene();
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("The Player Has Quit The Game") ;
    }
}
