namespace HackAndChangeApi.Models
{
    public class Message
    {
        public int DialogId { get; set; }
        public string Text { get; set; }
        public string MessageType { get; set; }
        public string Data { get; set; }
        public string MediaUrl { get; set; }
    }
}
