using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    private void Awake()
    {
        Invoke("Kill", 0.5f);
    }
    private void Kill()
    {
        Destroy(this.gameObject);
    }
}
