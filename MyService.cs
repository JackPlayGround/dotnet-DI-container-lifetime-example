public class MyService {
    private IMessage _message;
    public MyService(IMessage message)
    {
        Console.WriteLine("MyService: instance created.");
        _message = message;
    }

    public void WriteMessage() {
        _message.Write();
    }
}