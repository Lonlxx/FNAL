using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImageFade : MonoBehaviour {
    public Image img;
    public float fadeSpeed = 1f;

    void Start() {
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut() {
        Color c = img.color;
        c.a = 1f;
        img.color = c;

        while(c.a > 0f) {
            c.a -= Time.deltaTime * fadeSpeed;
            img.color = c;
            yield return null;
        }

        // garantir que fica totalmente transparente
        c.a = 0f;
        img.color = c;

        // desativar o objeto depois do fade
        gameObject.SetActive(false);
    }
}
