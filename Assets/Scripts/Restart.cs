using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour {

    public void QuitApplication()
    {
        Application.Quit();
    }

    public void RestartAplication()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
