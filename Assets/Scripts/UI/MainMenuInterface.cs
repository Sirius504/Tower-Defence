public class MainMenuInterface : InterfaceBase
{
    public override void Open()
    {
        gameObject.SetActive(true);
    }
    
    public override void Close()
    {
        gameObject.SetActive(false);
    }
}
