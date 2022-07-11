using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// TODO: protected instead of public?
public class MainSlot : MonoBehaviour, IPointerClickHandler
{
    private Image itemImage;
    public ItemObject item;

    

    protected virtual void Start()
    {
        itemImage = transform.GetChild(0).GetComponent<Image>();
        
        if (item != null) // TODO: editor script
        {
            itemImage.sprite = item.icon;
            itemImage.enabled = true;
        }
    }

    public void OnPointerClick(PointerEventData eventData) 
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (item != null)
            {
                InteractWithSlot();
            }   
        }

        else if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (item != null)
            {
                OtherSlotAction();
            }
        }
    }


    public virtual void InteractWithSlot()
    {
        // overridden by different slot types
    }


    public virtual void OtherSlotAction()
    {
        // overridden by different slot types
    }


    public void AddItem(ItemObject _item)
    {
        item = _item;
        itemImage.sprite = _item.icon;
        itemImage.enabled = true;
    }


    public void RemoveItem()
    {
        itemImage.enabled = false;
        item = null;
    }


}
