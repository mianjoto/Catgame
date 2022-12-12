using UnityEngine;
using UnityEngine.UI;

public class AudioIconUpdate : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Sprite[] _audioIconSprites;
    SpriteRenderer _audioIcon;
    private float _lvl3thresh = 0.7f, _lvl2thresh = 0.4f, _lvl1thresh = 0.1f, _lvl0thresh = 0f;
    float _oldSliderValue;

    private void Awake() {
        _oldSliderValue = _slider.value;
    }
    // Update is called once per frame
    void Update()
    {
        if (_slider.value == _oldSliderValue)
            return;
        assignSpriteToVolumeLevel(_slider.value);
        _oldSliderValue = _slider.value;
    }

    private void assignSpriteToVolumeLevel(float newVal)
    {
        if (newVal > _lvl3thresh) 
            _audioIcon.sprite = _audioIconSprites[0];
        else if (newVal > _lvl2thresh)
            _audioIcon.sprite = _audioIconSprites[1];
        else if (newVal > _lvl1thresh)
            _audioIcon.sprite = _audioIconSprites[2];
        else if (newVal == 0)
            _audioIcon.sprite = _audioIconSprites[3];
        _oldSliderValue = newVal;
    }
}
