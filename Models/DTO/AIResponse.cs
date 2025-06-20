using System;

namespace application.Models.DTO
{
    public class ChatCompletionResponse
    {
        public string Id { get; set; } = null!;
        public List<Choice> Choices { get; set; } = new();
    }

    public class Choice
    {
        public Message Message { get; set; } = null!;
    }

    public class Message
    {
        public string Role { get; set; } = null!;
        public string Content { get; set; } = null!;
    }
}
