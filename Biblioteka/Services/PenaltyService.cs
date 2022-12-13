using Biblioteka.Entities;
using Biblioteka.Exception;
using Biblioteka.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Services
{
    public sealed class PenaltyService
    {
        /// <summary>
        /// Oblicza karę za przekroczenie terminu wypożyczenia zgodznie z wytycznymi
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="dueDate"></param>
        /// <param name="deliveryDate"></param>
        /// <returns></returns>
        /// <exception cref="ReaderNotFoundException"></exception>
        /// <exception cref="InvalidDateException"></exception>
        public int CalculatePenalty(Reader reader, DateTime dueDate, DateTime deliveryDate)
        {
            if (reader is null)
            {
                throw new ReaderNotFoundException();
            }
            if (dueDate.Date > DateTime.Today || deliveryDate.Date > DateTime.Today || dueDate.Date >= deliveryDate.Date)
            {
                throw new InvalidDateException();
            }
            TimeSpan timeSpan = deliveryDate.Subtract(dueDate);
            int delay = (int)timeSpan.TotalDays;
            string role = reader.Role;
            int penalty=0;
            switch (role)
            {
                case "lecturer":
                    switch (delay)
                    {
                        case <=3:
                            penalty = 0;
                            break;
                        case > 3 and <= 14:
                            penalty = 2 * delay;
                            break;
                        case > 14 and <= 28:
                            penalty = 5 * delay;
                            break;
                        case > 28:
                            penalty = 10 * delay;
                            break;
                    }
                    break;
                case "student":
                    switch (delay)
                    {
                        case <= 7:
                            penalty = 1 * delay;
                            break;
                        case > 7 and <= 14:
                            penalty = 2 * delay;
                            break;
                        case > 14 and <= 28:
                            penalty = 5 * delay;
                            break;
                        case > 28:
                            penalty = 10 * delay;
                            break;
                    }
                    break;
                case "employee":
                    switch (delay)
                    {
                        case <= 28:
                            penalty = 0;
                            break;
                        case > 28:
                            penalty = 5 * delay;
                            break;                        
                    }
                    break;
            }

            return penalty;
        }
    }
}
