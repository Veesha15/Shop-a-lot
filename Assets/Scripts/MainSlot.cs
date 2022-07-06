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
        
        if (item != null) //
        {
            itemImage.sprite = item.icon;
        }
    }

    public void OnPointerClick(PointerEventData eventData) 
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            InteractWithSlot();
        }
    }


    public virtual void InteractWithSlot()
    {

    }


    public void AddItem(ItemObject _receivedItem)
    {
        item = _receivedItem;
        itemImage.sprite = _receivedItem.icon;
    }


    public void RemoveItem()
    {
        itemImage.enabled = false;
        item = null;

    }

}
