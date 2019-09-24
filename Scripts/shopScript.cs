using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopScript : MonoBehaviour {

    BuildManagerScript buildManagerScript;

    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;

    private void Start() {
        buildManagerScript = BuildManagerScript.instance;
    }

    public void SelectStandardTurret() {
        buildManagerScript.SelectTurretToBuild(standardTurret);
    }

    public void SelectMissileLauncher() {
        buildManagerScript.SelectTurretToBuild(missileLauncher);
    }
}
