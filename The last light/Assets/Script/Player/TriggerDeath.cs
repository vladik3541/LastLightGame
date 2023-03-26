using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDeath : MonoBehaviour
{
    private AnimationPlayer _animPlayer;
    private CharacterPlayer _characterPlayer;
    private void Start()
    {
        _animPlayer = GetComponent<AnimationPlayer>();
        _characterPlayer = GetComponent<CharacterPlayer>();
    }
    public void  DeathNip() {
        _animPlayer.Nip();
        _characterPlayer.Death = true;
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Trap")
        {
            _animPlayer.Trap();
            _characterPlayer.Death = true;
        }
        if(coll.tag == "Spikes") {
            _animPlayer.Spikes();
            _characterPlayer.Death = true;
        }
        if(coll.gameObject.name.Equals("FlyPlatforms"))
        {
            this.transform.parent = coll.transform;
        }
    }
    void OnTriggerExit2D(Collider2D coll)
    {
        if(coll.gameObject.name.Equals("FlyPlatforms"))
        {
            this.transform.parent = null;
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "DeathObject")
        {
            _animPlayer.Spikes();
            _characterPlayer.Death = true;

        }
    }
}
