#pragma checksum "C:\Users\bseno\OneDrive\Masaüstü\yeni2\AnimalShelter\Views\Panel\Approve.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9d7d628c04aed6244ad714ed04d9386a7de1ee6c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Panel_Approve), @"mvc.1.0.view", @"/Views/Panel/Approve.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\bseno\OneDrive\Masaüstü\yeni2\AnimalShelter\Views\_ViewImports.cshtml"
using AnimalShelter;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\bseno\OneDrive\Masaüstü\yeni2\AnimalShelter\Views\_ViewImports.cshtml"
using AnimalShelter.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9d7d628c04aed6244ad714ed04d9386a7de1ee6c", @"/Views/Panel/Approve.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a016a510558946b500fd5150033ad421d4d04944", @"/Views/_ViewImports.cshtml")]
    public class Views_Panel_Approve : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AnimalShelter.Models.Adoption>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\bseno\OneDrive\Masaüstü\yeni2\AnimalShelter\Views\Panel\Approve.cshtml"
  
    Layout = "/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("<h1>onaylandı</h1>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 8 "C:\Users\bseno\OneDrive\Masaüstü\yeni2\AnimalShelter\Views\Panel\Approve.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AnimalShelter.Models.Adoption> Html { get; private set; }
    }
}
#pragma warning restore 1591
