using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLevel : MonoBehaviour
{
    int Rand;
    List<int> RandBonusList = new List<int> { 1,2,3,4,5,6 };
    
    void Start()
    {
        Rand = Random.Range(0, 7);

        while (RandBonusList.Contains(Rand))
        {
            Rand = Random.Range(0, 7);
        }

        RandBonusList[Rand] = Rand;

        print(RandBonusList[Rand]);
    }
    // public void RandomLevel(){
    //     n = Random.Range(0,7);
    //     Debug.Log(n);
        
    //     if(n == 1)
    //     {
    //         Scaffallding.SetActive(true);
    //         all.SetActive(false);
    //     }
    // }public void Btn()
    // {
    //     RandomLevel();
    // }
} 