using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonChangeColor : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Color _defaultColor;
    [SerializeField] private Color _toColor;
    private float _runningTime;
    private float _duration = 0.1f;
    public void ClickOnButton()
    {
        var changeColor = IsChangeColor();
        StartCoroutine(changeColor);
    }

    private IEnumerator IsChangeColor()
    {
        _runningTime = 0;

        while (_runningTime <= _duration)
        {
            _runningTime += Time.deltaTime;

            float normalizeRunningTime = _runningTime / _duration;

            _image.color = Color.Lerp(_defaultColor, _toColor, normalizeRunningTime);

            yield return new WaitForSeconds(Time.deltaTime);

        }

        _runningTime = 0;

        while (_runningTime <= _duration)
        {
            _runningTime += Time.deltaTime;

            float normalizeRunningTime = _runningTime / _duration;

            _image.color = Color.Lerp(_toColor, _defaultColor, normalizeRunningTime);

            yield return new WaitForSeconds(Time.deltaTime);
        }

    }

}
