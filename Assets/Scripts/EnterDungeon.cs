using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnterDungeon : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.tag == "Player")
        {
            //print("entered dungeon!");
            SceneManager.LoadScene("Dungeon");
        }
    }

}
