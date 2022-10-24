using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    private string _playerTag = "Player";
    private string _fadeableTag = "Fadeable";
    private float _fadedAlphaValue = 0.5f;

    void OnTriggerEnter2D(Collider2D other)
    {
        print("Entered");
        if (other.gameObject.tag == _playerTag && this.gameObject.tag == _fadeableTag) 
        {
            Color currentColor = this.gameObject.GetComponent<SpriteRenderer>().color;
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(currentColor.r, currentColor.b, currentColor.g, _fadedAlphaValue);
        }
    }

    
    void OnTriggerExit2D(Collider2D other)
    {
        print("Exited");
        if (other.gameObject.tag == _playerTag && this.gameObject.tag == _fadeableTag) 
        {
            Color currentColor = this.gameObject.GetComponent<SpriteRenderer>().color;
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(currentColor.r, currentColor.b, currentColor.g, 1);
        }
    }
}
