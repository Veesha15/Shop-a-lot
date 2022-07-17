using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// TODO: protected instead of public?
[RequireComponent(typeof(AudioSource))]
public class MainSlot : MonoBehaviour, IPointerClickHandler
{
    private AudioSource audioSource;

    [Header("Set in Prefab")]
    [SerializeField] private Image itemImage;
    [SerializeField] protected AudioClip buttonClickSound;
    /* had an issue with this being assigned in Start
     * other methods (that were dependant) got called before Start
     Start was only called when the slot was set as active * */

    [Header("Set in Scene")]
    public ItemObject item;

    


    public void PlaySound() // add to button in inspector 
    {
        audioSource.PlayOneShot(buttonClickSound);
    }

    protected virtual void Start()
    {
        audioSource = GetComponent<AudioSource>();

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
                PlaySound();
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
