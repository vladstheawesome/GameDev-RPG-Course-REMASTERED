using UnityEngine;
using TMPro;
using RPG.Inventories;

namespace RPG.UI.Inventories
{
    /// <summary>
    /// Root of the tooltip prefab to expose properties to other classes.
    /// </summary>
    public class ItemTooltipSub : MonoBehaviour
    {
        // CONFIG DATA
        [SerializeField] TextMeshProUGUI subLeft = null;
        [SerializeField] TextMeshProUGUI subRight = null;

        // PUBLIC

        public void Setup(InventoryItem item)
        {
            subLeft.text = item.GetSubTitleLeft();
            subRight.text = item.GetSubTitleRight();
        }
    }
}
