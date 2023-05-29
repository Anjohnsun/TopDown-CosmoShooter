using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class NoteRenderer : MonoBehaviour
{
    [HideInInspector] public static NoteRenderer Renderer;

    [SerializeField] private RectTransform _notePanel;
    [SerializeField] private CanvasGroup _noteCanvasGroup;
    [SerializeField] private Button _closeButton;

    [SerializeField] private float _openCloseDuration;

    [SerializeField] private TextMeshProUGUI _headerField;
    [SerializeField] private TextMeshProUGUI _contentField;
    [SerializeField] private TextMeshProUGUI _dateField;
    [SerializeField] private TextMeshProUGUI _authorField;


    private void Start()
    {
        Renderer = this;
        _closeButton.onClick.AddListener(HideNote);
    }

    public void ShowNote(Note note)
    {
        _headerField.text = note.Header;
        _contentField.text = note.Content;
        _dateField.text = note.Date;
        _authorField.text = note.Author;

        DOTween.To(() => _noteCanvasGroup.alpha, (x) => _noteCanvasGroup.alpha = x, 1, _openCloseDuration);
    }

    public void HideNote()
    {
        DOTween.To(() => _noteCanvasGroup.alpha, (x) => _noteCanvasGroup.alpha = x, 0, _openCloseDuration);
    }

}
