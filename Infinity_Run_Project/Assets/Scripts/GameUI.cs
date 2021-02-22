using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    private Animator animator;
    private CanvasGroup canvas;

    void Start()
    {
        animator = GetComponent<Animator>();
        canvas = GetComponent<CanvasGroup>();

        canvas.interactable = false;
        canvas.blocksRaycasts = false;
    }

    public void Show()
    {
        Start();
        animator.Play("FadeInUI");

        canvas.interactable = true;
        canvas.blocksRaycasts = true;
    }

    public void Hide()
    {
        animator.Play("FadeOutUI");

        canvas.interactable = false;
        canvas.blocksRaycasts = false;
    }
}
