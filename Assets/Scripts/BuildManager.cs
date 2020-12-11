using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }

	public GameObject standardTurretPrefab;
	public GameObject missileLauncherPrefab;
    
    private TurretHandler turretToBuild;

	public bool CanBuild { get { return turretToBuild != null; } }
	public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

	public void BuildTurretOn (Node node)
	{
		if (PlayerStats.Money < turretToBuild.cost)
		{
			Debug.Log("Not enough money to build that!");
			return;
		}

		PlayerStats.Money -= turretToBuild.cost;

		GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
		node.turret = turret;

		Debug.Log("Turret build! Money left: " + PlayerStats.Money);
	}

	public void drawRadius (Node node)
	{
		var newTurret = turretToBuild.prefab.GetComponent<Turret>();
		
		// Debug.Log("node.GetBuildPosition()");
		// Debug.Log(node.GetBuildPosition());
		// Debug.Log("newTurret.range");
		// Debug.Log(newTurret.range);
		// var increment = 10;
		// Vector3 position = node.GetBuildPosition();
		// float radius = newTurret.range;

        // for (int angle = 0; angle < 360; angle = angle + increment)
        //  {
        //     var heading = Vector3.forward - position;
        //     var direction = heading / heading.magnitude;
        //     var point = position + Quaternion.Euler(0, angle, 0) * Vector3.forward * radius;
 		// 	var point2 = position + Quaternion.Euler(0, angle + increment, 0) * Vector3.forward * radius;
        //     lineRenderer.SetPosition(i, pos);
        //  }
		// Handles.color = Color.red;
    	// Drawing.bezierLine(position, new Vector3(0, 1, 0), radius); // position
       	
		   // Handles.DrawWireDisc(node.GetBuildPosition(), new Vector3(0, 1, 0),   newTurret.range); // position
       	// Handles.DrawWireDisc(new Vector3(35, 0, 70), new Vector3(0, 1, 0), 2f); // position
	}
	
	public void SelectTurretToBuild (TurretHandler turret)
	{
		turretToBuild = turret;
	}
}
