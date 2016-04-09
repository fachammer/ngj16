using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;
using System.Collections;

public class GameOverScreen : MonoBehaviour {
    
    public float appearDelay;
    
    public float soundDelay;
    
    public Canvas winCanvas;
    public Image leakImage;
    public Text text;
    
    public Animator fadeAnimator;
    
    public AudioSource newspaperAppearSound;
    
    private void Awake() {
        Assert.IsNotNull(winCanvas);
        Assert.IsNotNull(fadeAnimator);
        Assert.IsNotNull(leakImage);
        Assert.IsNotNull(text);
        winCanvas.enabled = false;
    }
   
    public void SetWinningPlayer(Player player) {
        StartCoroutine(SetWinningPlayerDelayed(player, appearDelay));
    }
 
    private IEnumerator SetWinningPlayerDelayed(Player player, float delay) {
        newspaperAppearSound.PlayDelayed(soundDelay);
        yield return new WaitForSeconds(delay);
        winCanvas.enabled = true;
        text.text = string.Format("Player {0} wins", player.id + 1);
        leakImage.sprite = player.winSprite;
        fadeAnimator.SetTrigger("FadeIn");
    }   
}