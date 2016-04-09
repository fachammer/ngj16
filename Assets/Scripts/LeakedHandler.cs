using UnityEngine;
using UnityEngine.Assertions;

public class LeakedHandler : MonoBehaviour {
    
    public LeakedNotificationAnimation leakedAnimation;
    public AudioSource leakedSound;
    
    private void Awake() {
        Assert.IsNotNull(leakedAnimation);
        Assert.IsNotNull(leakedSound);
    }
    
    public void Trigger() {
        leakedAnimation.Trigger();
        leakedSound.Play();
    }
}