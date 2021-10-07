using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonInteracting : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	[SerializeField] private RectTransform _rectTransform;
    private bool _isOnButton = false;
	private float _x;
	private float _y;
	private float _minSize;
	private float _maxSize = 1.2f;
	private float _stepChange = 0.01f;
	private float _frequencyAnimation = 0.03f;



	private void Start()
    {
		_x = _rectTransform.localScale.x;
		_y = _rectTransform.localScale.y;
		_minSize = _x;
	}

    private void Update()
    {
		var animationButton = IsAnimating();
		StartCoroutine(animationButton);
	}

    public void OnPointerEnter(PointerEventData eventData)
	{
		_isOnButton = true;

	}

	public void OnPointerExit(PointerEventData eventData)
	{
		_isOnButton = false;
	}

	private IEnumerator IsAnimating()
    {
		if (_isOnButton == true)
		{
			while (_x < _maxSize && _y < _maxSize)
			{
				_x = Mathf.MoveTowards(_x, _maxSize, _stepChange);
				_y = Mathf.MoveTowards(_y, _maxSize, _stepChange);
				_rectTransform.localScale = new Vector2(_x, _y);
				yield return new WaitForSeconds(_frequencyAnimation);
			}
		}
        else
        {
			while (_x > _minSize && _y > _minSize)
			{
				_x = Mathf.MoveTowards(_x, _minSize, _stepChange);
				_y = Mathf.MoveTowards(_y, _minSize, _stepChange);
				_rectTransform.localScale = new Vector2(_x, _y);
				yield return new WaitForSeconds(_frequencyAnimation);
			}
		}
    }

}



