using UnityEngine;

public class DeathTrigger : MonoBehaviour {

    public LayerMask killObjectsOnLayers;

    public void OnTriggerEnter2D(Collider2D collider){
        var incomingGameObject = collider.gameObject;
        var incomingLayerMask = (1 << incomingGameObject.layer);
        var layerIntersection = incomingLayerMask & killObjectsOnLayers.value;
        if(layerIntersection == incomingLayerMask)
        {
            Destroy(incomingGameObject);
        }
    }
}
