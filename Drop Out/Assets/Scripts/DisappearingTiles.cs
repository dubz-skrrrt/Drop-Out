using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingTiles : MonoBehaviour
{
    
    void OnCollisionEnter(Collision col){
        
        if (col.gameObject.tag == "disappear"){
            GameObject tile = col.gameObject;
            Debug.Log(col.gameObject.name);
            StartCoroutine(ChangeColor(tile));
        }   
    }

    IEnumerator ChangeColor(GameObject tiles){
        yield return new WaitForSeconds(0.5f);
        
        tiles.GetComponent<Renderer>().material.color = Color.white;
        StartCoroutine(TileDisappear(tiles));
        
    }

    IEnumerator TileDisappear(GameObject tiling){
        yield return new WaitForSeconds(0.5f);
        tiling.SetActive(false);
    }
}
