using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonImageSwap : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Sprite normalImage;
    public Sprite hoverImage;
    public Sprite clickImage;
    public AudioClip clickSound;

    private Image buttonImage;
    private Button button;
    private AudioSource audioSource;

    void Start()
    {
        buttonImage = GetComponent<Image>();
        button = GetComponent<Button>();
        audioSource = GetComponent<AudioSource>();

        buttonImage.sprite = normalImage;

        button.onClick.AddListener(OnClick);

        audioSource.playOnAwake = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonImage.sprite = hoverImage;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonImage.sprite = normalImage;
    }

    public void OnClick()
    {
        
        buttonImage.sprite = clickImage;

    
        if (clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
        }
    }
}
