using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeItem : MonoBehaviour
{
    private AnimationPlayer _animPlayer;
    private CharacterPlayer _characterPlayer;

    [SerializeField] private GameObject _light;
    [SerializeField] private GameObject _lampa;
    [SerializeField] private GameObject _textHintLampa;
    private void Awake() {
        _animPlayer = GetComponent<AnimationPlayer>();
        _characterPlayer = GetComponent<CharacterPlayer>();
    }
    void OnTriggerStay2D(Collider2D collider2D)
    {
        if(collider2D.tag == "Lampa")
        {
            _textHintLampa.SetActive(true);
            if(Input.GetButton("E"))
            {
                _animPlayer.NoLight(false);
                _light.SetActive(true);
                _characterPlayer.DontEnter = false;
                Destroy(_lampa, .1f);
            }

        }
    }
}
