using ProductCatalog.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace System.Threading.Tasks
{
    public static class UtilityExtensionMethod
    {
        public  async static void AwaitMethods(this Task<List<Product>> task, Action<List<Product>> OnSucess,  Action<Exception> onFailure)
        {
            try
            {
               var result =  await task;
                OnSucess?.Invoke(result);
            }
            catch (Exception ex)
            {
                onFailure?.Invoke(ex);
            }
        }
    }
}
