using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovingCement : MonoBehaviour
{
    public float speedX = 0.01f;
    public float speedY = 0.01f;
    
    private float curX;
    private float curY;
    public float movingY;
    // Start is called before the first frame update
    void Start()
    {
        curX = GetComponent<Renderer>().material.mainTextureOffset.x;
        curY = GetComponent<Renderer>().material.mainTextureOffset.y;
        movingY = 0.05f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        curX += Time.deltaTime * speedX;
        curY += Time.deltaTime * speedY;
        GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(curX, curY));
        transform.Translate((Vector3.up * movingY *Time.deltaTime));
    }

    void OnCollisionEnter(Collision col)
    {
        // if player collides with rising cement (Wet Concrete Level)
        if (col.gameObject.name == "dropguy")
        {
            SoundManager.PlaySound("Byebye");
            Debug.Log("Eliminated");
            StartCoroutine(DelayReturnMenu());
           // dropguy.GetComponentInChildren<Renderer>().enabled = false;
        }
    }

    IEnumerator DelayReturnMenu()
    {
        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene("MainMenu"); // returns to main menu
    }

    
}
