using UnityEngine;

public class BuildManager : MonoBehaviour {

	public static BuildManager instance;

	void Awake ()
	{
		if (instance != null)
		{
			Debug.LogError("More than one BuildManager in scene!");
			return;
		}
		instance = this;
	}

	private TurretBlueprint turretToBuild;
	private Node selectedNode;

	public NodeUI nodeUI;

	public bool CanBuild { get { return turretToBuild != null; } }
	public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

	public void SelectNode (Node node)
	{
		if (selectedNode == node)
		{
            node.UnHighlight();
			DeselectNode();
            return;
		}

        if (selectedNode != null)
        {
            selectedNode.UnHighlight();
        }
        node.Highlight();

		selectedNode = node;
		turretToBuild = null;

		nodeUI.SetTarget(node);
	}

	public void DeselectNode()
	{
		selectedNode = null;
		nodeUI.Hide();
	}

	public void SelectTurretToBuild (TurretBlueprint turret)
	{
		turretToBuild = turret;

        selectedNode.AttemptBuildTurret();
		nodeUI.SetTarget(selectedNode);
	}

	public TurretBlueprint GetTurretToBuild ()
	{
		return turretToBuild;
	}

    public void SellTurret()
    {
        selectedNode.SellTurret();
        nodeUI.SetTarget(selectedNode);
    }

    public void UpgradeTurret()
    {
        selectedNode.UpgradeTurret();
        nodeUI.SetTarget(selectedNode);
    }

}
