using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatVisibility : MonoBehaviour
{
    public bool isVisible = false;

    [SerializeField] public Renderer objectRenderer;

    private void Start()
    {
        objectRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        objectRenderer.enabled = isVisible;
    }

}
