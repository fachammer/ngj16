using UnityEngine;
using UnityEngine.Assertions;
using System.Collections;

public class LeakedHandler : MonoBehaviour {
    
    public LeakedNotificationAnimation leakedAnimation;
    public AudioSource leakedSound;
    public float gameObjectDisableDelay;
    
    private void Awake() {
        Assert.IsNotNull(leakedAnimation);
        Assert.IsNotNull(leakedSound);
    }
    
    public void Trigger(bool killingTrigger) {
        leakedAnimation.Trigger();

        if(killingTrigger)
        {
            leakedSound.Play();

            StartCoroutine(DisableGameObjectAfterDelay(gameObjectDisableDelay));
        }
    }
    
    private IEnumerator DisableGameObjectAfterDelay(float delay) {
        yield return new WaitForSeconds(delay);
        print("disabling"+gameObject.name);
        gameObject.SetActive(false);
    }
}