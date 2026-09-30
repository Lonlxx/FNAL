using UnityEngine;

public class LightBlink : MonoBehaviour {
    public SpriteRenderer sr;

    [Range(0f, 1f)]
    public float minAlpha = 0.4f;

    [Range(0f, 1f)]
    public float maxAlpha = 1f;    

    public float speed = 2f;        

    void Update() {

    
        float sinValue = (Mathf.Sin(Time.time * speed) + 1f) * 0.5f; // (-1 -> 1) + 1 = (0 -> 2) * 0.5f = (0 -> 1)

        float alpha = Mathf.Lerp(minAlpha, maxAlpha, sinValue);

        sr.color = new Color(maxAlpha, maxAlpha, maxAlpha, alpha);
    }
}
