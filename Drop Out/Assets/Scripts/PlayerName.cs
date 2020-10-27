using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerName : MonoBehaviour
{
    public Text nameLabel;
    public Text playername;
    public static string playernamestr;

    // Start is called before the first frame update
    void Start()
    {
        playername.text = playernamestr; // receiver of name input from MainMenu
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 namePosition = Camera.main.WorldToScreenPoint(this.transform.position);
        nameLabel.transform.position = namePosition;
    }
}
