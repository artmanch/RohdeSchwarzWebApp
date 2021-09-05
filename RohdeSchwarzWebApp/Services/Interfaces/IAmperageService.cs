namespace RohdeSchwarzWebApp.Services.Interfaces
{
    public interface IAmperageService
    {
        /// <summary>
        /// Получаем силу тока из источника
        /// </summary>
        /// <returns>сила тока</returns>
        public double GetAmperage();

        /// <summary>
        /// Установить силу тока источника
        /// </summary>
        /// <returns>сила тока</returns>
        public bool SetAmperage(double amperage);
    }
}
