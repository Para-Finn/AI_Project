using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirendlayManager : MonoBehaviour
{
    public GameObject _lillay;

    public void SpawnLitllay()
    {
        Instantiate(_lillay, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    public bool Spawned()
    {
        SpawnLitllay();
        return true;
    }

}
