using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    [SerializeField] private string _header;
    [SerializeField] private string _content;
    [SerializeField] private string _date;
    [SerializeField] private string _author;
    [SerializeField] private GameObject _tutorialInteract;

    [SerializeField] private LayerMask _playerLayer;

    public string Header => _header;
    public string Content => _content;
    public string Date => _date;
    public string Author => _author;

    private PlayerInput _playerInput;
    delegate void InteractingNote();
    InteractingNote _interactNote;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerInput.Player.Interact.performed += context => _interactNote();
    }
    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((_playerLayer & 1 << other.gameObject.layer) == 1 << other.gameObject.layer)
        {
            _interactNote += ReadNote;
            _tutorialInteract.SetActive(true);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if ((_playerLayer & 1 << other.gameObject.layer) == 1 << other.gameObject.layer)
        {
            _interactNote = null;
            _tutorialInteract.SetActive(false);
        }
    }

    private void ReadNote()
    {
        //активировать паузу
        NoteRenderer.Renderer.ShowNote(this);
        _interactNote -= ReadNote;
        _interactNote += NoteRenderer.Renderer.HideNote;
    }
}
