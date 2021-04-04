using System;

namespace Norbit.CRM.Tyganov.FinalTask.DbLibrary
{
    /// <summary>
    /// Объект сделки.
    /// </summary>

    public class Trade
    {
        public decimal Amount { get; set; }
        public DateTime Created { get; set; }

        public override string ToString()
        {
            return $"{Created.ToLocalTime()}  {Amount}";
        }
    }
}
