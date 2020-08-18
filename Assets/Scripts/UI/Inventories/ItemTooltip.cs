using UnityEngine;
using TMPro;
using RPG.Inventories;

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

        // PUBLIC

        public void Setup(InventoryItem item)
        {
            titleText.text = item.GetDisplayName();
            bodyText.text = item.GetDescription();
            subLeft.text = item.GetSubTitleLeft();
            subRight.text = item.GetSubTitleRight();
            statsText.text = item.GetStatsInfo();
            //titleText.color = ItemRarityTitle(item);

            if (item.itemRarity.ToString() == ItemRarity.Generic.ToString()
                            || item.itemRarity.ToString() == ItemRarity.White.ToString())
            {
                titleText.color = Color.white;
            }

            if (item.itemRarity.ToString() == ItemRarity.Green.ToString())
            {
                Color greenHexColor;
                ColorUtility.TryParseHtmlString("#08ac27", out greenHexColor);
                titleText.color = greenHexColor;
            }

            if (item.itemRarity.ToString() == ItemRarity.Blue.ToString())
            {
                Color blueHexColor;
                ColorUtility.TryParseHtmlString("#035bde", out blueHexColor);
                titleText.color = blueHexColor;
            }

            if (item.itemRarity.ToString() == ItemRarity.Purple.ToString())
            {
                Color purpleHexColor;
                ColorUtility.TryParseHtmlString("#701da9", out purpleHexColor);
                titleText.color = Color.magenta;
            }
        }

        #region
        //private Color ItemRarityTitle(InventoryItem item)
        //{
        //    Color color = Color.white; // Default Color

        //    if (item.itemRarity.ToString() == ItemRarity.Generic.ToString()
        //                    || item.itemRarity.ToString() == ItemRarity.White.ToString())
        //    {
        //        var whiteColor = Color.white;
        //        return whiteColor;
        //    }

        //    else if (item.itemRarity.ToString() == ItemRarity.Green.ToString())
        //    {
        //        var greenColor = Color.green;
        //        return greenColor;
        //    }

        //    else if (item.itemRarity.ToString() == ItemRarity.Blue.ToString())
        //    {
        //        var blueColor = new Color(3, 91, 222);
        //        return blueColor;
        //    }

        //    else if (item.itemRarity.ToString() == ItemRarity.Purple.ToString())
        //    {
        //        //color = Color.purple;
        //    }
        //    else
        //    {
        //        return color;
        //    }

        //    return color;
        //}
        #endregion
    }
}
