using UnityEngine;
using UnityEngine.SceneManagement;		
using System.Collections;

public class LevelManager : MonoBehaviour {
    public void LoadLevel(string name)
    {
        /*Debug.Log("New Level load: " + name);
        //	Application.LoadLevel (name);    -- This method was deprecated a long time ago*/
        SceneManager.LoadScene(name);
    }

    public void QuitRequest()
    {
        
        Application.Quit();
    }

}
