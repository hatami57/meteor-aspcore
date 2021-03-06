using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NodaTime;

namespace Meteor.AspNetCore.ModelBinders
{
    public class ModelBinderProvider : IModelBinderProvider
    {
        private static readonly LocalDateModelBinder LocalDateModelBinder = new();

        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            var modelType = context.Metadata.UnderlyingOrModelType;

            if (modelType == typeof(LocalDate))
                return LocalDateModelBinder;

            return null;
        }
    }
}