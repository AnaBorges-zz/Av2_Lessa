using UnityEngine;
using System.Collections;

public sealed class Bullet : MonoBehaviour
{
    public Rigidbody2D bulletRigidbody;

    public Vector2 impulse;

	public AudioClip Explosion;

    public GameObject ExplosionS;
    private void Start()
    {
        bulletRigidbody.AddForce(impulse, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        Camera.main.GetComponent<CameraShake>().Shake();
        Destroy(gameObject);
		AudioSource.PlayClipAtPoint (Explosion, transform.position);
        Instantiate(ExplosionS, transform.position, Quaternion.identity);
        
    }
}
