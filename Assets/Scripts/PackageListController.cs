using UnityEngine;
using UnityEngine.UI;

public class PackageListController : MonoBehaviour {
    public Level Level;
    public GameObject Container;
    public Object ButtonPrefab;
    public Object PackagePrefab;
    public Vector3 SelectedPackagePosition;
    public PalletController PalletController;
    public CameraController cameraController;
    public GameObject ConfirmPackageSelectionMenu;
    private PackageButtonController[] PackageButtonControllers;
    private int SelectedButtonIndex = -1;
    

	// Use this for initialization
	void Start () {
        PackageButtonControllers = new PackageButtonController[Level.Packages.Length];        
        for (int i = 0; i < PackageButtonControllers.Length; i++) {
            var index = i;
            var packageModel = Level.Packages[i];
            if (packageModel.Quantity <= 0)
                continue;           
            var button = ((GameObject)Instantiate(ButtonPrefab, Container.transform, false)).GetComponent<Button>();                                                
            button.onClick.AddListener(() => OnButtonClick(index));
            var packageButtonController = button.GetComponent<PackageButtonController>();            
            packageButtonController.PackageQuantity = packageModel.Quantity;
            PackageButtonControllers[i] = packageButtonController;
        }        
        var confirmButton = ConfirmPackageSelectionMenu.transform.FindChild("Confirm Package").gameObject;       
        var cancelButton = ConfirmPackageSelectionMenu.transform.FindChild("Cancel Package").gameObject;
        confirmButton.GetComponent<Button>().onClick.AddListener(OnConfirmClick);
        cancelButton.GetComponent<Button>().onClick.AddListener(OnCancelClick);
    }

    private void OnButtonClick(int index) {
        if (index == SelectedButtonIndex) {
            UnselectButton(index, true);            
        } else {
            if (SelectedButtonIndex != -1)
                UnselectButton(SelectedButtonIndex, true);            
            SelectButton(index);            
        }
        cameraController.SwitchCameraState();       
}

    private void SelectButton(int index) {       
        var button = PackageButtonControllers[index];
        button.Selected = true;
        if (button.Package == null) {
            var package = (GameObject)Instantiate(PackagePrefab);
            var packageModel = Level.Packages[index];
            package.GetComponent<Rigidbody>().isKinematic = true;
            package.transform.position = SelectedPackagePosition;
            package.transform.localScale = packageModel.Scale;
            package.transform.rotation = packageModel.Rotation;
            package.GetComponent<PackageMoveController>().Enabled = false;
            package.GetComponent<PackageRotationController>().Enabled = true;
            button.Package = package;            
        }
        button.Package.SetActive(true);
        ConfirmPackageSelectionMenu.SetActive(true);
        SelectedButtonIndex = index;      
    }

    private void UnselectButton(int index, bool deactivatePackage) {
        var button = PackageButtonControllers[index];
        button.Selected = false;     
        if (deactivatePackage)   
            button.Package.SetActive(false);
        ConfirmPackageSelectionMenu.SetActive(false);
        SelectedButtonIndex = -1;

    }

    private void PlaceSelectedPackage() {        
        var button = PackageButtonControllers[SelectedButtonIndex];
        if (button.PackageQuantity > 1) {
            button.PackageQuantity -= 1;            
        } else {
            button.PackageQuantity = 0;
            button.gameObject.SetActive(false);
        }
        UnselectButton(SelectedButtonIndex, false);
        var package = button.Package;
        var packageMoveController = package.GetComponent<PackageMoveController>();
        packageMoveController.Enabled = true;
        SetButtonsEnabled(false);
        packageMoveController.InitiallyMoved += () => SetButtonsEnabled(true);
        package.GetComponent<PackageRotationController>().Enabled = false;
        PalletController.Add(packageMoveController);
        button.Package = null;
        CheckCameraAndPackage.isPackageSelected = false;
    }

    private void OnConfirmClick() {
        PlaceSelectedPackage();
    }

    private void OnCancelClick() {
        UnselectButton(SelectedButtonIndex, true);
    }

    private void SetButtonsEnabled(bool enabled) {
        foreach (var packageButtonController in PackageButtonControllers)
            packageButtonController.Enabled = enabled;

    }
}
