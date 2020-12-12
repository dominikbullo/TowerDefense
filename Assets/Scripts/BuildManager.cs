using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    [Range(3, 256)]
    public int numSegments = 128;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }

    private TurretHandler turretToBuild;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public void BuildTurretOn(Node node)
    {
        Debug.Log("i am here");
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

    public void drawRadius(Node node)
    {
        // var newTurret = turretToBuild.prefab.GetComponent<Turret>();
        // LineRenderer lineRenderer = newTurret.GetComponent<LineRenderer>();
        // Color c1 = new Color(0.5f, 0.5f, 0.5f, 1);
        // // lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
        // lineRenderer.SetColors(c1, c1);
        // lineRenderer.SetWidth(0.5f, 0.5f);
        // lineRenderer.SetVertexCount(numSegments + 1);
        // lineRenderer.useWorldSpace = false;

        // float deltaTheta = (float)(2.0 * Mathf.PI) / numSegments;
        // float theta = 0f;
        // float radius = newTurret.range;

        // for (int i = 0; i < numSegments + 1; i++)
        // {
        //     float x = radius * Mathf.Cos(theta);
        //     float z = radius * Mathf.Sin(theta);
        //     Vector3 pos = new Vector3(x, 0, z);
        //     lineRenderer.SetPosition(i, pos);
        //     theta += deltaTheta;
        // }
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

    public void SelectTurretToBuild(TurretHandler turret)
    {
        turretToBuild = turret;
    }
}
