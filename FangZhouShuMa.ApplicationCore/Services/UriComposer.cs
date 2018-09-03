using FangZhouShuMa.ApplicationCore.Settings;
using System;
using System.Collections.Generic;
using System.Text;

namespace FangZhouShuMa.ApplicationCore.Services
{
    public class UriComposer
    {
        private readonly ProductSettings _productSettings;

        public UriComposer(ProductSettings productSettings) => _productSettings = productSettings;

        public string ComposePicUri(string uriTemplate)
        {
            return uriTemplate.Replace("http://catalogbaseurltobereplaced", _productSettings.CatalogBaseUrl);
        }
    }
}
