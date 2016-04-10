using UnityEngine;
using System.Linq;

public class BounceHandler : MonoBehaviour
{
    public GameObject particlePrefab;
    
    public AudioSource bounceSound;

    public float particleDestroyDelay;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var particlePosition = collision.contacts.Select(p => p.point).Aggregate((a, b) => a + b) / collision.contacts.Length;
        var particles = Instantiate(particlePrefab, particlePosition, Quaternion.identity);
        bounceSound.Play();
        Destroy(particles, particleDestroyDelay);
    }
}