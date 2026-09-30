using UnityEngine;

public class CanvasFade : MonoBehaviour {
    public float fadeDuration = 1f;

    private CanvasGroup canvasGroup;
    private float timer;
    private bool fading;

    void Awake() {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void StartFade() {
        canvasGroup.blocksRaycasts = false;
        canvasGroup.interactable = false;

        fading = true;
        timer = 0f;
    }

    void Update() {
        if(!fading)
            return;

        Fade();
    }

    void Fade() {
        timer += Time.deltaTime;

        canvasGroup.alpha = Mathf.Lerp(
            1f,
            0f,
            timer / fadeDuration
        );

        if(canvasGroup.alpha <= 0f)
            fading = false;
    }
}