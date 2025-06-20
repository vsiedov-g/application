using System;
using application.Models;
using application.Models.DTO;

namespace application.Services.IService
{
    public interface IAIHelperService
    {
        public Task<string> SendPrompt(string message);
    }
}
