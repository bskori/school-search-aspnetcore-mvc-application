#pragma checksum "D:\PROJECTS\FutureStage\FutureStage\Views\Shared\Components\QuotoVC\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fb596efc6c2579707a859d7538d76db75721350f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_QuotoVC_Default), @"mvc.1.0.view", @"/Views/Shared/Components/QuotoVC/Default.cshtml")]
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
#line 1 "D:\PROJECTS\FutureStage\FutureStage\Views\_ViewImports.cshtml"
using FutureStage.Data.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\PROJECTS\FutureStage\FutureStage\Views\_ViewImports.cshtml"
using FutureStage.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fb596efc6c2579707a859d7538d76db75721350f", @"/Views/Shared/Components/QuotoVC/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"000366dd25247948f6a9bec422887e56d8ceab80", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_QuotoVC_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<QuotoVM>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\PROJECTS\FutureStage\FutureStage\Views\Shared\Components\QuotoVC\Default.cshtml"
 foreach (var item in Model)
{


#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"row align-items-center mb-3\">\r\n    <div class=\"col\">\r\n        <input class=\"form-check-input\" type=\"checkbox\"");
            BeginWriteAttribute("value", " value=\"", 187, "\"", 206, 1);
#nullable restore
#line 8 "D:\PROJECTS\FutureStage\FutureStage\Views\Shared\Components\QuotoVC\Default.cshtml"
WriteAttributeValue("", 195, item.Value, 195, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" name=\"Quotos\" id=\"quoto\">\r\n        <label class=\"form-check-label\" for=\"quoto\">\r\n            ");
#nullable restore
#line 10 "D:\PROJECTS\FutureStage\FutureStage\Views\Shared\Components\QuotoVC\Default.cshtml"
       Write(item.Text);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        </label>
    </div>

    <div class=""col"">
        <div class=""row"">
            
                <input class=""form-control noofseats w-25"" name=""NoOfSeats"" id=""NoOfSeat"">
            
            <div class=""col-auto"">
                <label for=""NoOfSeat"" class=""col-form-label"">Number of Seats</label>
            </div>
        </div>
    </div>

</div>
");
#nullable restore
#line 26 "D:\PROJECTS\FutureStage\FutureStage\Views\Shared\Components\QuotoVC\Default.cshtml"

}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<QuotoVM>> Html { get; private set; }
    }
}
#pragma warning restore 1591