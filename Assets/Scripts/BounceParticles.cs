using UnityEngine;
using System.Linq;

public class BounceParticles : MonoBehaviour
{

    public GameObject particlePrefab;

    public float particleDestroyDelay;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var particlePosition = collision.contacts.Select(p => p.point).Aggregate((a, b) => a + b) / collision.contacts.Length;
        var particles = Instantiate(particlePrefab, particlePosition, Quaternion.identity);
        Destroy(particles, particleDestroyDelay);
    }
}