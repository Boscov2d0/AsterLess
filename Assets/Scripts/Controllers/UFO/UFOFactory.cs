using UnityEngine;

public class UFOFactory : IFactory<UFOController>
{
    ViewServices viewServices;

    public UFOFactory()
    {
        viewServices = new ViewServices();   
    }
    public UFOController Create()
    {
        UFO ufo = viewServices.Instantiate<UFO>(Resources.Load<GameObject>("UFO"));
        UFOController ufoController = new UFOController(ufo);
        ufoController.Destroy += Death;
        ufoController.Init();
        return ufoController;
    }
    private void Death(GameObject objcet)
    {
        viewServices.Destroy(objcet);
    }
}