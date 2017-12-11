using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public sealed class Cannon : MonoBehaviour
{
    public Bullet bulletPrefab;
    public float instantiateOffset = 10.0f;
    public float shootImpulse = 30.0f;

    public Vector3 startingDirection = Vector3.left;
    public int balas = 5;

    public AudioClip atirando;
    public TextMesh municao;
    public Text aperte;

    private void Start()
    {
        aperte.enabled = false;
    }


    private void Update()
    {
        
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 mouseDirection = Input.mousePosition - screenPosition;
        mouseDirection.z = 0.0f;

        var rotation = Quaternion.FromToRotation(startingDirection, mouseDirection);
        transform.localRotation = rotation;

        if (Input.GetMouseButtonDown(0) && balas > 0)
        {
            balas -= 1;
            Vector2 direction = ((Vector2)mouseDirection).normalized;
            Vector3 position = transform.position + (Vector3)direction * instantiateOffset;
            AudioSource.PlayClipAtPoint(atirando, transform.position);
            var bullet = Instantiate(bulletPrefab.gameObject, position, Quaternion.identity).GetComponent<Bullet>();
            bullet.impulse = direction * shootImpulse;
        }

        municao.text = balas.ToString();

        if(balas == 0)
        {
            aperte.enabled = true;
        }

        if (Input.GetMouseButtonDown(1) && balas < 5)
        {
            balas = 5;
            aperte.enabled = false;
        }

           
        }
    }

