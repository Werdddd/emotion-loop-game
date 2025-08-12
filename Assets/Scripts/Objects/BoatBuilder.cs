using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatBuilder : MonoBehaviour
{
    public int plankCtr;
    public int paddleCtr;
    public bool boatCreated;
    [SerializeField] public Plank plank;
    [SerializeField] public Plank2 plank2;
    [SerializeField] public Plank3 plank3;
    [SerializeField] public Paddle paddle;

    [SerializeField] public BoatVisibility boatVisible;

    void Start()
    {
        plankCtr = 0;
        paddleCtr = 0;
        boatCreated = false;
    }
    void Update()
    {

        if (plankCtr == 3 && paddleCtr == 1)
        {
            boatVisible.isVisible = true;
            boatCreated = true;
        }
    }
}
