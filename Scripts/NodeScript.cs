using UnityEngine;
using UnityEngine.EventSystems;

public class NodeScript : MonoBehaviour {

    public Color mouseHoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 turretPositionOffset;

    private Renderer _renderer;
    private Color startColor;
    

    [Header("Optional")]
    public GameObject turret;

    BuildManagerScript buildManagerScript;
    
    // Start is called before the first frame update
    void Start() {
        _renderer = GetComponent<Renderer>();
        startColor = _renderer.material.color;
        buildManagerScript = BuildManagerScript.instance;
    }

    // Called when mouse hovers over this object
    private void OnMouseEnter() {

        // Only highlight node if its not blocked by another object (i.e. the turret ui elements)
        //if (EventSystem.current.IsPointerOverGameObject()) {
        //    return;
        //}

        // Only mouseover this stuff if the turrets have been loaded
        if (!buildManagerScript.canBuild) {
            return;
        }
        if (buildManagerScript.hasMoney) {
            _renderer.material.color = mouseHoverColor;
        } else {
            _renderer.material.color = notEnoughMoneyColor;
        }

        
    }

    // Called when no longer hovering
    private void OnMouseExit() {
        _renderer.material.color = Color.white;
    }

    // Called when clicked
    private void OnMouseDown() {

        // Only highlight node if its not blocked by another object (i.e. the turret ui elements)
        if (EventSystem.current.IsPointerOverGameObject()) {
            return;
        }

        if (!buildManagerScript.canBuild) {
            return;
        }

        // Prevents us from placing a turret if there is already one on this node
        if (turret != null) {
            Debug.Log("Cant build there! - TODO: Display on screen");
            return;
        }

        buildManagerScript.BuildTurretOn(this);

    }

    public Vector3 GetBuildPosition() {
        return transform.position + turretPositionOffset;
    }

}
