using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberOfplayers : MonoBehaviour
{
    public Randomizer1 players = null;
    public GameObject numb;
    private Vector3 newPos;
    void Start()
    {
        for (int i = players.DropGuys; i > 0; i--){
            Debug.Log("Create");
            newPos = new Vector3(transform.position.x + (i*2), transform.position.y, transform.position.z);
            Instantiate(numb, newPos, Quaternion.identity);
            
        }
    }

}
