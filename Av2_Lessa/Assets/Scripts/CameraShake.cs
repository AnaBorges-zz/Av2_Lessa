using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float force = 0.2f;
    public int count = 5;
    public float offsetDuration = 0.05f;

    public void Shake()
    {
        StopAllCoroutines();
        StartCoroutine(ShakeCoroutine());
    }

    private IEnumerator ShakeCoroutine()
    {
        Vector3 originalPosition = transform.position;

        for( int i = 0; i < count; i++)
        {
            Vector3 offset = Vector3.zero;
            offset.x = Random.Range(-force, force);
            offset.y = Random.Range(-force, force);

            transform.position = originalPosition + offset;

            yield return new WaitForSeconds(offsetDuration);
        }

        transform.position = originalPosition;
    }
}
