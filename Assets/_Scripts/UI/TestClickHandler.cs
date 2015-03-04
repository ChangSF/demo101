using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TestClickHandler : MonoBehaviour,IPointerClickHandler,IPointerDownHandler,IPointerEnterHandler,IPointerExitHandler,
IInitializePotentialDragHandler,IBeginDragHandler,IEndDragHandler,IDragHandler,IDropHandler,IScrollHandler,ISelectHandler,
IDeselectHandler,IUpdateSelectedHandler,IMoveHandler,ISubmitHandler,ICancelHandler
{
	#region ICancelHandler implementation

	public void OnCancel (BaseEventData eventData)
	{
		throw new System.NotImplementedException ();
	}

	#endregion

	#region ISubmitHandler implementation

	public void OnSubmit (BaseEventData eventData)
	{
		throw new System.NotImplementedException ();
	}

	#endregion

	#region IMoveHandler implementation

	public void OnMove (AxisEventData eventData)
	{
		throw new System.NotImplementedException ();
	}

	#endregion

	#region IUpdateSelectedHandler implementation

	public void OnUpdateSelected (BaseEventData eventData)
	{
		throw new System.NotImplementedException ();
	}

	#endregion

	#region IDeselectHandler implementation

	public void OnDeselect (BaseEventData eventData)
	{
		throw new System.NotImplementedException ();
	}

	#endregion

	#region ISelectHandler implementation

	public void OnSelect (BaseEventData eventData)
	{
		throw new System.NotImplementedException ();
	}

	#endregion

	#region IScrollHandler implementation

	public void OnScroll (PointerEventData eventData)
	{
		throw new System.NotImplementedException ();
	}

	#endregion

	#region IDropHandler implementation

	public void OnDrop (PointerEventData eventData)
	{
		throw new System.NotImplementedException ();
	}

	#endregion

	#region IDragHandler implementation

	public void OnDrag (PointerEventData eventData)
	{
		throw new System.NotImplementedException ();
	}

	#endregion

	#region IEndDragHandler implementation

	public void OnEndDrag (PointerEventData eventData)
	{
		throw new System.NotImplementedException ();
	}

	#endregion

	#region IBeginDragHandler implementation

	public void OnBeginDrag (PointerEventData eventData)
	{
		throw new System.NotImplementedException ();
	}

	#endregion

	#region IInitializePotentialDragHandler implementation

	public void OnInitializePotentialDrag (PointerEventData eventData)
	{
		throw new System.NotImplementedException ();
	}

	#endregion

	#region IPointerExitHandler implementation

	public void OnPointerExit (PointerEventData eventData)
	{
		throw new System.NotImplementedException ();
	}

	#endregion

	#region IPointerEnterHandler implementation

	public void OnPointerEnter (PointerEventData eventData)
	{
		throw new System.NotImplementedException ();
	}

	#endregion

	#region IPointerDownHandler implementation

	public void OnPointerDown (PointerEventData eventData)
	{
		throw new System.NotImplementedException ();
	}

	#endregion

	#region IPointerClickHandler implementation

	public void OnPointerClick (PointerEventData eventData)
	{
		throw new System.NotImplementedException ();
	}

	#endregion


}

