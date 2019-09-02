using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaTecnologica
{
    public class DictionaryModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
                throw new ArgumentNullException(nameof(bindingContext));

            var result = new Dictionary<string, object> { };
            var form = bindingContext.HttpContext.Request.Form;
            if (form == null)
            {
                bindingContext.ModelState.AddModelError("FormData", "The data is null");
                return Task.CompletedTask;
            }
            foreach (var k in form.Keys)
            {
                Microsoft.Extensions.Primitives.StringValues v = string.Empty;
                var flag = form.TryGetValue(k, out v);
                if (flag)
                {
                    result.Add(k, v);
                }
            }

            bindingContext.Result = ModelBindingResult.Success(result);
            return Task.CompletedTask;
        }
    }
}
