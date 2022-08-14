using UnityEngine;

public class AmoFactory
{
    ViewServices viewServices;

    public AmoFactory()
    {
        viewServices = new ViewServices();
    }

    public TorpedoController CreateTorpedo(Transform startPosition)
    {
        Torpedo torpedo = viewServices.Instantiate<Torpedo>(Resources.Load<GameObject>("Torpedo"));
        torpedo.Transform.position = startPosition.position;
        torpedo.Transform.rotation = startPosition.rotation;
        TorpedoController torpedoController = new TorpedoController(torpedo);
        torpedoController.Destroy += Death;
        torpedoController.Init();
        return torpedoController;
    }
    public LazerContoller CreateLazer(Transform startPosition)
    {
        Lazer lazer = viewServices.Instantiate<Lazer>(Resources.Load<GameObject>("Lazer"));
        lazer.Transform.position = startPosition.position;
        lazer.Transform.rotation = startPosition.rotation;
        LazerContoller lazerContoller = new LazerContoller(lazer);
        lazerContoller.Destroy += Death;
        lazerContoller.Init();
        return lazerContoller;
    }
    private void SetAmo(Transform startPosition) 
    {
        //lazer.Transform.position = startPosition.position;
        //lazer.Transform.rotation = startPosition.rotation;
        //LazerContoller lazerContoller = new LazerContoller(lazer);
        //lazerContoller.Destroy += Death;
        //lazerContoller.Init();
        //return lazerContoller;
    }
    private void Death(GameObject objcet)
    {
        viewServices.Destroy(objcet);
    }
}