using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateEnemies : MonoBehaviour
{
    public GameObject enemies = null;
    void Start()
    {
        Instantiate(enemies, transform.position, Quaternion.identity);
    }

}
