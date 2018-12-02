using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{

    public GameObject buildMenu;
    public GameObject turretMenu;

    public Text upgradeCost;

    public Text sellAmount;

    private Node target;

    public void SetTarget(Node _target)
    {
        target = _target;

        if (target.turret == null)
        {
            buildMenu.SetActive(true);
            turretMenu.SetActive(false);
        }
        else
        {
            buildMenu.SetActive(false);
            turretMenu.SetActive(true);

            if (!target.isUpgraded)
            {
                upgradeCost.text = "Upgrade for: $" + target.turretBlueprint.upgradeCost;
            }
            else
            {
                upgradeCost.text = "No more upgrades";
            }

            sellAmount.text = "Sell for: $" + target.turretBlueprint.GetSellAmount();
        }
    }

    public void Hide()
    {
        buildMenu.SetActive(false);
        turretMenu.SetActive(false);
    }
}
