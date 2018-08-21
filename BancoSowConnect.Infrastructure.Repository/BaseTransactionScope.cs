using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BancoSowConnect.Infrastructure.Repository
{
    public class BaseTransactionScope
    {
        public static void WapperWrapper(Action action)
        {
            using (var transactionScope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                action.Invoke();

                transactionScope.Complete();
            }
        }
    }
}
