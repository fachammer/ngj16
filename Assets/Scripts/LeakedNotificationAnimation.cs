using UnityEngine;
using UnityEngine.Assertions;

public class LeakedNotificationAnimation : MonoBehaviour {
    
    public Animator leakedNotificationAnimator;
    
    private void Awake() {
        Assert.IsNotNull(leakedNotificationAnimator);
    }
    
    public void Trigger() {
        leakedNotificationAnimator.SetTrigger("Show");
    }
}

public static class ColorExtensions {
    public static Color WithAlpha(this Color color, float alpha) {
        color.a = alpha;
        return color;
    }
}