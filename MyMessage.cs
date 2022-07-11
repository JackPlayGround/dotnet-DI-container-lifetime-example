public class MyMessage : IMessage {
    public MyMessage() {
        Console.WriteLine("MyMessage: instance created.");
    }
    public void Write() {
        Console.WriteLine("Write message...");
    }
}