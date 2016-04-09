using UnityEngine;
using UnityEngine.Assertions;

public class DeathTrigger : MonoBehaviour
{
    public LayerMask killObjectsOnLayers;

    private GameplayManager gameplayManager;

    private void Awake()
    {
        gameplayManager = GameplayManager.Instance;
        gameplayManager.PlayerWins += _ => enabled = false;
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if(!enabled) 
        {
            return;
        }
        
        var incomingGameObject = collider.gameObject;
        var incomingLayerMask = (1 << incomingGameObject.layer);
        var layerIntersection = incomingLayerMask & killObjectsOnLayers.value;

        if (layerIntersection != incomingLayerMask)
        {
            return;
        }

        var player = incomingGameObject.GetComponent<Player>();
        Assert.IsNotNull(player);
        player.IsDead = true;
        incomingGameObject.SetActive(false);
    }
}
