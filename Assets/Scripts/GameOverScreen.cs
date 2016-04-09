using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;
using System.Collections;

public class GameOverScreen : MonoBehaviour {
    
    public float appearDelay;
    
    public Canvas winCanvas;
    public Canvas leakCanvas;
    
    public Image leakImage;
    public Text text;
    
    private void Awake() {
        Assert.IsNotNull(winCanvas);
        Assert.IsNotNull(leakCanvas);
        winCanvas.enabled = false;
        leakCanvas.enabled = false;
    }
    
    private IEnumerator ShowWinCanvas(Player player) {
        yield return ShowCanvas(player, winCanvas, appearDelay);
        text.text = string.Format("Player {0} wins", player.id + 1);
    }
    
    private static IEnumerator ShowCanvas(Player player, Canvas canvas, float delay) {
        yield return new WaitForSeconds(delay);
        canvas.enabled = true;
    }
    
    private IEnumerator ShowLeakCanvas(Player player) {
        leakImage.sprite = player.leakSprite;
        yield return ShowCanvas(player, leakCanvas, appearDelay);
    }
    
    public IEnumerator SetWinningPlayer(Player player) {
        yield return ShowWinCanvas(player);
    }
    
    public IEnumerator SetLeakedPlayer(Player player) {
        yield return ShowLeakCanvas(player);
    }
}