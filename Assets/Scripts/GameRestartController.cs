using UnityEngine;
using UnityEngine.Assertions;

public class GameRestartController : MonoBehaviour {
    
    public GameRestarter gameRestarter;
    
    private void Awake() {
        Assert.IsNotNull(gameRestarter);
    }
    
    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            gameRestarter.Restart();
        }
    }
}