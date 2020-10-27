using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public InputField playername;

    public void StartGame()
    {
        PlayerName.playernamestr = playername.text; // pases the name to the PlayerName script
        if (playername.text == "")
        {
            PlayerName.playernamestr = "Player";
        }
        SceneManager.LoadScene("Sca-fall-ding"); // loads game
    }
}
