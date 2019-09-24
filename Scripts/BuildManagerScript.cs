using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManagerScript : MonoBehaviour {

    // The C# version of the singleton pattern
    public static BuildManagerScript instance;
    void Awake() {
        if (instance != null) {
            Debug.LogError("Why do we have more than 1 build manager???");
            return;
        }
        instance = this;
    }

    public GameObject standardTurretPrefab;
    public GameObject missileLauncherPrefab;

    private TurretBlueprint turretBlueprint;

    // A 'property' basically an anonymous function?
    public bool canBuild { get { return turretBlueprint != null; } }
    public bool hasMoney { get { return PlayerStatsScript.money >= turretBlueprint.cost; } }

    public void BuildTurretOn(NodeScript nodeScript) {

        if (PlayerStatsScript.money < turretBlueprint.cost) {
            Debug.Log("You're broke bitch!");
            return;
        }

        PlayerStatsScript.money -= turretBlueprint.cost;

        GameObject turret = Instantiate(turretBlueprint.prefab, nodeScript.GetBuildPosition(), Quaternion.identity);
        nodeScript.turret = turret;

        Debug.Log("turret build!  you have $" + PlayerStatsScript.money);
    }

    public void SelectTurretToBuild(TurretBlueprint turretBlueprint) {
        this.turretBlueprint = turretBlueprint;
    }

}
