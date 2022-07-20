using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// TODO: protected instead of public?
public class MainSlot : MonoBehaviour, IPointerClickHandler
{
    [Header("Set in Prefab")]
    [SerializeField] private Image itemImage;
    /* had an issue with image being assigned in Start
     * other methods (that were dependant) got called before Start
     Start was only called when the slot was set as active * */

    [Header("Set in Scene")]
    public ItemObject item;

    
    protected virtual void Start()
    {
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
        itemImage.sprite = item.icon;
        itemImage.enabled = true;
    }


    public void RemoveItem()
    {
        itemImage.enabled = false;
        item = null;
    }


}
