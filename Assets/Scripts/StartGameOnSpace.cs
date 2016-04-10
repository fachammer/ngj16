using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameOnSpace : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("game_scene");
        }
    }
}