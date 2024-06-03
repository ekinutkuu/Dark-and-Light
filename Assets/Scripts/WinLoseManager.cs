using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseManager : MonoBehaviour
{   

    private GUIStyle guiStyle = new GUIStyle();
    
    static bool hasPlayerWon = false;
    static bool isDead = false;

    public static bool HasPlayerWon
    {
        get { return hasPlayerWon; }
    }

    public static void winGame()
    {
        hasPlayerWon = true;
    }

    public static void loseGame()
    {
        isDead = true;
    }


    private void OnGUI()
    {
        if (hasPlayerWon)
        {
            infoScreen();

            float x = (Screen.width) / 2;
            float y = (Screen.height) / 2;

            string message = "YOU WON !\n\nYou've restored your memories";
            GUI.Box(new Rect(x - 300, y - 300, 600, 600), message, guiStyle);

            StartCoroutine(toMainMenu());
        }

        else if (isDead)
        {
            infoScreen();

            float x = (Screen.width) / 2;
            float y = (Screen.height) / 2;

            string message = "YOU LOSE !\n\nTry Again";
            GUI.Box(new Rect(x - 300, y - 300, 600, 600), message, guiStyle);

            StartCoroutine(toMainMenu());
        }
    }

    public void infoScreen()
    {
        Texture2D blackTexture = new Texture2D(1, 1);
        blackTexture.SetPixel(0, 0, Color.black);
        blackTexture.Apply();
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), blackTexture);

        guiStyle.fontSize = 64;
        guiStyle.normal.textColor = Color.white;
        guiStyle.alignment = TextAnchor.MiddleCenter;
        guiStyle.wordWrap = true;
    }

    private IEnumerator toMainMenu()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("MainMenu");
    }

}
