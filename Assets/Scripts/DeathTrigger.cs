using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class DeathTrigger : MonoBehaviour
{
    public LayerMask killObjectsOnLayers;

    public float delay = 0f;

    public bool TriggerDeath = true;

    private readonly Dictionary<Collider2D, Coroutine> delayCoroutines = new Dictionary<Collider2D, Coroutine>();

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!enabled)
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

        var deactivateCoroutine = StartCoroutine(DeactivateAfterDelay(incomingGameObject, collider));
        delayCoroutines[collider] = deactivateCoroutine;
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        Coroutine delayCoroutine;
        if (delayCoroutines.TryGetValue(collider, out delayCoroutine))
        {
            StopCoroutine(delayCoroutine);
            delayCoroutines.Remove(collider);
        }
    }

    private IEnumerator DeactivateAfterDelay(GameObject incomingGameObject, Collider2D collider)
    {
        yield return new WaitForSeconds(delay);
        var player = incomingGameObject.GetComponent<Player>();
        Assert.IsNotNull(player);
        player.IsDead = TriggerDeath;
        
        var leakedHandler = incomingGameObject.GetComponent<LeakedHandler>();
        if(leakedHandler != null) 
        {
            leakedHandler.Trigger(TriggerDeath);
        }
        
        delayCoroutines.Remove(collider);
    }
}
