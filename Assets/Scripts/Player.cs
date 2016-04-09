using UnityEngine;

public class Player : MonoBehaviour {
    
    public int id;
    
    public Sprite winSprite;
    
    public bool IsDead { get; set; }
    
    private void Awake() {
        IsDead = false;
    }
}