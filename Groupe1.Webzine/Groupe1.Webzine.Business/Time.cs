using Groupe1.Webzine.Business.Contracts;

namespace Groupe1.Webzine.Business
{
    public class Time : ITime
    {
        /// <summary>
        /// Permet de modifier un int de secondes en string heures:minutes:secondes
        /// </summary>
        /// <param name="time">Secondes</param>
        /// <returns>String minutes:secondes</returns>
        public string SecondsConverter(int time)
        {
            var hours = 00;
            var minutes = 00;
            var seconds = time;
            if (seconds >= 60)
            {
                minutes = seconds / 60;
                seconds = seconds % 60;
                if (minutes >= 60)
                {
                    hours = minutes / 60;
                    minutes = minutes % 60;
                }
            }

            var min = "";
            if (minutes < 10)
            {
                min  = "0" + minutes;
            }
            return $"{min}:{seconds}";
        }
    }
}
