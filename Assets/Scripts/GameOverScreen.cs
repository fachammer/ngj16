using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour {
    
    public Canvas canvas;
    
    public Text text;
    
    private void Awake() {
        Assert.IsNotNull(canvas);
        canvas.enabled = false;
    }
    
    public void SetWinningPlayer(Player player) {
        canvas.enabled = true;
        text.text = string.Format("Player {0} wins", player.id + 1);
    }
}