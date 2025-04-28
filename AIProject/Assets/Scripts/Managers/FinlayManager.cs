using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinlayManager : MonoBehaviour
{
    public int _hunger;

    private void Awake()
    {
        _hunger = 10;
    }

    public bool Hunger()
    {
        _hunger -= 1;
        bool isHungery = _hunger <= 0;

        return isHungery;
    }
}
