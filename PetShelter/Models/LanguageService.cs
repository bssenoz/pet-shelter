using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Reflection;

namespace PetShelter.Models
{
    public class LanguageService
    {
        private readonly IStringLocalizer _localizer;

        public LanguageService(IStringLocalizerFactory factory)
        {
            var type = typeof(Resource);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            _localizer = factory.Create("Resource", assemblyName.Name);
        }
        public LocalizedString GetKey(string key)
        {
            return _localizer[key];
        }
    }
}
