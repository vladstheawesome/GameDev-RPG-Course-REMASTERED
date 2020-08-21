using UnityEngine;
using TMPro;
using RPG.Inventories;
using UnityEngine.UI;

namespace RPG.UI.Inventories
{
    /// <summary>
    /// Root of the tooltip prefab to expose properties to other classes.
    /// </summary>
    public class ItemTooltip : MonoBehaviour
    {
        // CONFIG DATA
        [SerializeField] TextMeshProUGUI titleText = null;
        [SerializeField] TextMeshProUGUI bodyText = null;
        [SerializeField] TextMeshProUGUI statsText = null;
        [SerializeField] TextMeshProUGUI subLeft = null;
        [SerializeField] TextMeshProUGUI subRight = null;
        [SerializeField] Image itemType = null;

        // PUBLIC

        public void Setup(InventoryItem item)
        {
            titleText.text = item.GetDisplayName();
            bodyText.text = item.GetDescription();
            subLeft.text = item.GetSubTitleLeft();
            subRight.text = item.GetSubTitleRight();
            statsText.text = item.GetStatsInfo();
            titleText.color = SetTitleColorRarity(item);
            itemType.sprite = item.GetToolTipTypeImage();
        }

        // PRIVATE

        private Color SetTitleColorRarity(InventoryItem item)
        {
            Color titleColor = Color.white;

            if (item.itemRarity.ToString() == ItemRarity.Generic.ToString()
                                        || item.itemRarity.ToString() == ItemRarity.White.ToString())
            {
                titleColor = Color.white;
            }

            if (item.itemRarity.ToString() == ItemRarity.Green.ToString())
            {
                Color greenHexColor;
                ColorUtility.TryParseHtmlString("#08ac27", out greenHexColor);
                titleColor = greenHexColor;
            }

            if (item.itemRarity.ToString() == ItemRarity.Blue.ToString())
            {
                Color blueHexColor;
                ColorUtility.TryParseHtmlString("#035bde", out blueHexColor);
                titleColor = blueHexColor;
            }

            if (item.itemRarity.ToString() == ItemRarity.Purple.ToString())
            {
                Color purpleHexColor;
                ColorUtility.TryParseHtmlString("#701da9", out purpleHexColor);
                titleColor = Color.magenta;
            }

            return titleColor;
        }
    }
}
