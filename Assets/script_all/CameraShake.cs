using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPos = transform.localPosition;
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            // Generate small, subtle random movements for mild vibration
            float x = Random.Range(-0.1f, 0.1f) * magnitude; // Small horizontal shake
            float y = Random.Range(-0.05f, 0.05f) * magnitude; // Smaller vertical shake

            transform.localPosition = new Vector3(originalPos.x + x, originalPos.y + y, originalPos.z);

            elapsed += Time.deltaTime;
            yield return null;
        }

        // Reset to the original position after the shake
        transform.localPosition = originalPos;
    }
}
