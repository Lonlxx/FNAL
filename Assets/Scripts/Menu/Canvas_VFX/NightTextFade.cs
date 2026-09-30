using UnityEngine;
using TMPro;

public class NightTextFade : MonoBehaviour {
    public float fadeDuration = 1f;
    public TextMeshProUGUI txt;
    private float timer = 0f;
    private bool fading = false;

    void Start() {
        txt = GetComponent<TextMeshProUGUI>();
    }

    public void StartFade() {
        fading = true;
        timer = 0f;
    }

    void Update() {
        if(!fading)
            return;

        timer += Time.deltaTime;
        float alpha = Mathf.Lerp(1f, 0f, timer / fadeDuration);

        txt.color = new Color(txt.color.r, txt.color.g, txt.color.b, alpha);

        if(alpha <= 0f)
            fading = false;
    }
}

