using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitApplication : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
      if(Input.GetKeyDown(KeyCode.Escape)) //this script should be attached to the player
      {
        Debug.Log("We pushed escape !");
        Application.Quit();
      }
    }
}
