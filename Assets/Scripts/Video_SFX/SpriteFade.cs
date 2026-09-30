using UnityEngine;

public class SpriteFade : MonoBehaviour {
    public float fadeDuration = 1f;
    private SpriteRenderer sr;
    private float timer = 0f;
    private bool fading = false;

    void Start() {
        sr = GetComponent<SpriteRenderer>();
    }

    public void StartFade() {
        fading = true;
        timer = 0f;
    }

    void Update() {
        
        if(!fading)
            return;

        UpdateFade();

    }

    void UpdateFade() {
        timer += Time.deltaTime;

        float alpha = Mathf.Lerp(
            1f,
            0f,
            timer / fadeDuration
        );

        sr.color = new Color(
            sr.color.r,
            sr.color.g,
            sr.color.b,
            alpha
        );

        if(alpha <= 0f)
            fading = false;
    }
}
