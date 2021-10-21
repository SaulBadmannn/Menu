using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonInteracting : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	[SerializeField] private RectTransform _rectTransform;
	private float _x;
	private float _y;
	private float _minSize;
	private float _maxSize = 1.2f;
	private float _stepChange = 0.01f;
	private float _frequencyAnimation = 0.03f;
	private IEnumerator _increaseAnimating = null;
	private IEnumerator _decreaseAnimating = null;

	private void Start()
    {
		_x = _rectTransform.localScale.x;
		_y = _rectTransform.localScale.y;
		_minSize = _x;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		Debug.Log("Курсор в кнопке");

        if (_decreaseAnimating != null)
        {
			StopCoroutine(_decreaseAnimating);
			_decreaseAnimating = null;
		}

		_increaseAnimating = IsIncrease();
		StartCoroutine(_increaseAnimating);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		Debug.Log("Курсор вышел из кнопки");

		if (_increaseAnimating != null)
		{
			StopCoroutine(_increaseAnimating);
			_increaseAnimating = null;
		}

		_decreaseAnimating = IsDecrease();
		StartCoroutine(_decreaseAnimating);
	}

	private IEnumerator IsIncrease()
    {
			while (_x < _maxSize && _y < _maxSize)
			{
				_x = Mathf.MoveTowards(_x, _maxSize, _stepChange);
				_y = Mathf.MoveTowards(_y, _maxSize, _stepChange);
				_rectTransform.localScale = new Vector2(_x, _y);
				yield return new WaitForSeconds(_frequencyAnimation);
			}
	}

	private IEnumerator IsDecrease()
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



