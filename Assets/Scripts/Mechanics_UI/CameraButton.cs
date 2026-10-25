
using UnityEngine;
using System.Collections;

public class CameraButton : MonoBehaviour {
    [Header("Referências")]
    public OfficeLook officeLook;
    public NightManager nightManager;
    public SpriteRenderer buttonRenderer;
    public SpriteRenderer animationRenderer;
    public Collider2D buttonCollider;

    [Header("Animação")]
    public Sprite[] hoverFrames;
    public float framesPerSecond = 12f;

    private bool isAnimating;
    private bool isOpen;
    private Coroutine animationCoroutine;

    void Awake() {
        if(officeLook == null && Camera.main != null)
            officeLook = Camera.main.GetComponent<OfficeLook>();

        if(buttonRenderer == null)
            buttonRenderer = GetComponent<SpriteRenderer>();

        if(buttonCollider == null)
            buttonCollider = GetComponent<Collider2D>();

        if(nightManager == null)
            nightManager = FindAnyObjectByType<NightManager>();

        if(buttonRenderer != null)
            buttonRenderer.enabled = true;

        if(animationRenderer != null)
            animationRenderer.enabled = false;
    }

    void Update() {
        bool shouldShow =
            nightManager != null &&
            nightManager.CanPlay &&
            officeLook != null &&
            officeLook.state == OfficeLook.PanState.Office &&
            !officeLook.isNearLeft &&
            !officeLook.isNearRight;

        if(!shouldShow) {
            buttonRenderer.enabled = false;
            animationRenderer.enabled = false;

            if(buttonCollider != null)
                buttonCollider.enabled = false;

            if(animationCoroutine != null) {
                StopCoroutine(animationCoroutine);
                animationCoroutine = null;
            }

            isAnimating = false;
            isOpen = false;
            return;
        }

        if(!isAnimating) {
            buttonRenderer.enabled = true;

            if(buttonCollider != null)
                buttonCollider.enabled = true;

            animationRenderer.enabled = isOpen; //mudar para false se for necessário
        }
    }

    void OnMouseEnter() {
        if(isAnimating)
            return;

        if(hoverFrames == null || hoverFrames.Length == 0) {
            Debug.LogWarning("Ainda não adicionaste os frames!");
            return;
        }

        if(animationRenderer == null || buttonRenderer == null) {
            Debug.LogWarning(
                "Falta associar os SpriteRenderers no Inspector!");
            return;
        }

        animationCoroutine = StartCoroutine(PlayMonitorAnimation());
    }



    IEnumerator PlayMonitorAnimation() {
        isAnimating = true;

        if(officeLook != null)
            officeLook.SetMonitorOpen(true);

        buttonRenderer.enabled = false;

        if(buttonCollider != null)
            buttonCollider.enabled = false;

        animationRenderer.enabled = true;

        float delay = 1f / Mathf.Max(1f, framesPerSecond);

        if(!isOpen) {
            // Abrir: primeiro frame até ao último.
            for(int i = 0;i < hoverFrames.Length;i++) {
                animationRenderer.sprite = hoverFrames[i];

                if(i < hoverFrames.Length - 1)
                    yield return new WaitForSeconds(delay);
            }

            isOpen = true;
        } else {
            // Fechar: último frame até ao primeiro.
            for(int i = hoverFrames.Length - 1;i >= 0;i--) {
                animationRenderer.sprite = hoverFrames[i];

                if(i > 0)
                    yield return new WaitForSeconds(delay);
            }

            isOpen = false;
        }


        // A animação desaparece sempre quando os frames terminam.
        animationRenderer.enabled = false;

        // O estado da câmara acompanha o estado final do monitor.
        if(officeLook != null)
            officeLook.SetMonitorOpen(isOpen);

        // Esperar antes de voltar a mostrar o botão (^).
        yield return new WaitForSeconds(0.25f);

        buttonRenderer.enabled = true;

        if(buttonCollider != null)
            buttonCollider.enabled = true;

        isAnimating = false;
        animationCoroutine = null;

    }


}
