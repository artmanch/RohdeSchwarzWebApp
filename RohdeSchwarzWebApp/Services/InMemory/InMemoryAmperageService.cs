using Microsoft.Extensions.Logging;
using RohdeSchwarzWebApp.Services.Interfaces;

namespace RohdeSchwarzWebApp.Services.InMemory
{
    public class InMemoryAmperageService : IAmperageService
    {
        private readonly ILogger<InMemoryAmperageService> _Logger;
        private double Amperage { get; set; }

        public InMemoryAmperageService(ILogger<InMemoryAmperageService> Logger) => _Logger = Logger;

        public double GetAmperage() => Amperage;

        public bool SetAmperage(double amperage)
        {
            if(amperage < 0 || amperage > double.MaxValue)
            {
                _Logger.LogError($"Введено значение {amperage} вне диапозона силы тока");
                return false;
            }

            Amperage = amperage;
            _Logger.LogInformation($"Установлено новое значение силы тока устройства {amperage}");

            return true;
        }
    }
}
