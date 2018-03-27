using System;
using System.Collections.Generic;

namespace BankAccountOperations
{
    public static class BonusCoefficients
    {
        public static readonly Dictionary<AccountBenefitsType, decimal> WithdrawalBonuses = new Dictionary<AccountBenefitsType, decimal>
        {
            { AccountBenefitsType.Base, 1.7m },
            { AccountBenefitsType.Silver, 2.8m },
            { AccountBenefitsType.Gold, 3.9m },
            { AccountBenefitsType.Platinum, 5.95m }
        };

        public static readonly Dictionary<AccountBenefitsType, decimal> AddingBonuses = new Dictionary<AccountBenefitsType, decimal>
        {
            { AccountBenefitsType.Base, 0.7m },
            { AccountBenefitsType.Silver, 0.8m },
            { AccountBenefitsType.Gold, 0.9m },
            { AccountBenefitsType.Platinum, 0.95m }
        };
    }
}