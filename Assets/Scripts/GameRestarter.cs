using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRestarter : MonoBehaviour {
    
    public void Restart() 
    {
        //SceneManager.LoadScene("main_scene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}