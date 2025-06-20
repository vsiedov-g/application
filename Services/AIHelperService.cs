using System;
using System.Text;
using System.Text.Json;
using application.Models;
using application.Models.DTO;
using application.Repositories.IRepositories;
using application.Services.IService;

namespace application.Services
{
    public class AIHelperService : IAIHelperService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpClientFactory _httpFactory;

        public AIHelperService(IUnitOfWork unitOfWork, IHttpClientFactory httpFactory)
        {
            _unitOfWork = unitOfWork;
            _httpFactory = httpFactory;
        }

        public async Task<string> SendPrompt(string message)
        {
            var bookings = await GetAllBookings();
            var formattedBookings = FormatBookings(bookings);
            var data = new
            {
                model = "llama-3.3-70b-versatile",
                messages = new[]
                {
                    new
                    {
                        role = "system",
                        content = @"You are a helpful and friendly assistant for a coworking space booking system 
                        who answers questions about booking dates, times, rooms, capacities, workspace types and locations, 
                        providing clear and concise guidance based on the information provided. 
                        Try to make short, straight answers without extra explanation.
                        Please use mardown format ",

                    },
                    new
                    {
                        role="user",
                        content = $"Here is the booking information {formattedBookings}. {message}"
                    }


                }
            };

            var request = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");
            var client = _httpFactory.CreateClient("groqAi");

            var response = await client.PostAsync("/openai/v1/chat/completions", request);

            if (response.IsSuccessStatusCode)
            {
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var content = JsonSerializer.Deserialize<ChatCompletionResponse>(await response.Content.ReadAsStringAsync(), options)!;
                return content.Choices.FirstOrDefault()?.Message.Content;
            }
            else
            {
                throw new ArgumentException("Something went wrong");
            }

        }

        private async Task<IEnumerable<Booking>> GetAllBookings()
        {
            var bookings = await _unitOfWork.Booking.GetAllAsync(includeProperties: "Workspace.WorkspaceType.CoworkingSpace");
            return bookings;
        }
        
        private string FormatBookings(IEnumerable<Booking> bookings)
        {
            var sb = new StringBuilder();
            foreach (var booking in bookings)
            {
                sb.AppendLine($"- Booking: {booking.Workspace.WorkspaceType.Name} at {booking.Workspace.WorkspaceType.CoworkingSpace.Name}");
                sb.AppendLine($"  Capacity: {booking.Workspace.Capacity}");
                sb.AppendLine($"  From {booking.StartDate:yyyy-MM-dd} to {booking.EndDate:yyyy-MM-dd} at {booking.StartTime:hh\\:mm}-{booking.EndTime:hh\\:mm}");
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}
