public interface IController
{
    bool IsActive { get; set; }
    void Execute();
}