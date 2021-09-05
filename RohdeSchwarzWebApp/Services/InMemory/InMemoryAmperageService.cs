using Microsoft.Extensions.Logging;
using RohdeSchwarzWebApp.Data;
using RohdeSchwarzWebApp.Services.Interfaces;

namespace RohdeSchwarzWebApp.Services.InMemory
{
    public class InMemoryAmperageService : IAmperageService
    {
        private readonly ILogger<InMemoryAmperageService> _Logger;

        public InMemoryAmperageService(ILogger<InMemoryAmperageService> Logger) => _Logger = Logger;

        public double GetAmperage() => AmperageData.CurrentAmperage;

        public bool SetAmperage(double amperage)
        {
            if(amperage < 0 || amperage > double.MaxValue)
            {
                _Logger.LogError($"Введено значение {amperage} вне диапозона силы тока");
                return false;
            }

            AmperageData.CurrentAmperage = amperage;
            _Logger.LogInformation($"Установлено новое значение силы тока устройства {amperage}");

            return true;
        }
    }
}
