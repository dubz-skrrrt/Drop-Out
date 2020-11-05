using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortarProjectile : MonoBehaviour
{

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "ProjectileDeath")
        {
            Destroy(this.gameObject, 5);
        }
    }
}
