using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;
using System.Collections;

public class GameOverScreen : MonoBehaviour {
    
    public float appearDelay;
    public Canvas canvas;
    
    public Text text;
    
    private void Awake() {
        Assert.IsNotNull(canvas);
        canvas.enabled = false;
    }
    
    private IEnumerator ShowWinCanvas(Player player) {
        yield return new WaitForSeconds(appearDelay);
        canvas.enabled = true;
        text.text = string.Format("Player {0} wins", player.id + 1);
    }
    
    public void SetWinningPlayer(Player player) {
        StartCoroutine(ShowWinCanvas(player));
    }
}