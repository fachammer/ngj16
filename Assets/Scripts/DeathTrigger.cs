using UnityEngine;
using UnityEngine.Assertions;

public class DeathTrigger : MonoBehaviour
{
    public LayerMask killObjectsOnLayers;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(!enabled) 
        {
            return;
        }
        
        var collider = collision.collider;
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
