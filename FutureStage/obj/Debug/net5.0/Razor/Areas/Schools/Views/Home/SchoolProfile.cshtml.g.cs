#pragma checksum "D:\PROJECTS\FutureStage\FutureStage\Areas\Schools\Views\Home\SchoolProfile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6e234b282d832475cf99528daf179dbfa51d679f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Schools_Views_Home_SchoolProfile), @"mvc.1.0.view", @"/Areas/Schools/Views/Home/SchoolProfile.cshtml")]
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
#line 2 "D:\PROJECTS\FutureStage\FutureStage\Areas\Schools\Views\_ViewImports.cshtml"
using FutureStage.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\PROJECTS\FutureStage\FutureStage\Areas\Schools\Views\_ViewImports.cshtml"
using FutureStage.Data.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6e234b282d832475cf99528daf179dbfa51d679f", @"/Areas/Schools/Views/Home/SchoolProfile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3d7c6c4a54d62771218cf4adefb37d61a05f87d4", @"/Areas/Schools/Views/_ViewImports.cshtml")]
    public class Areas_Schools_Views_Home_SchoolProfile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FutureStage.Models.School>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger my-3"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "UpdateSchoolProfile", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\PROJECTS\FutureStage\FutureStage\Areas\Schools\Views\Home\SchoolProfile.cshtml"
  
    ViewData["Title"] = "SchoolProfile";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"text-center\">\r\n        <h2 class=\"alert alert-primary mt-2\">Shool Profile</h2>\r\n    </div>\r\n    <div class=\"col-md-12\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6e234b282d832475cf99528daf179dbfa51d679f4293", async() => {
                WriteLiteral("Update School Profile");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 12 "D:\PROJECTS\FutureStage\FutureStage\Areas\Schools\Views\Home\SchoolProfile.cshtml"
                                                                          WriteLiteral(Model.ID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        <table class=\"table table-striped table-hover\">\r\n            <tbody>\r\n                <tr>\r\n                    <td class=\"fs-6\">School Name</td>\r\n                    <td>:</td>\r\n                    <td>");
#nullable restore
#line 18 "D:\PROJECTS\FutureStage\FutureStage\Areas\Schools\Views\Home\SchoolProfile.cshtml"
                   Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <td class=\"fs-6\">Email</td>\r\n                    <td>:</td>\r\n                    <td>");
#nullable restore
#line 23 "D:\PROJECTS\FutureStage\FutureStage\Areas\Schools\Views\Home\SchoolProfile.cshtml"
                   Write(Model.EmailID);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr> \r\n                <tr>\r\n                    <td class=\"fs-6\">Address</td>\r\n                    <td>:</td>\r\n                    <td>");
#nullable restore
#line 28 "D:\PROJECTS\FutureStage\FutureStage\Areas\Schools\Views\Home\SchoolProfile.cshtml"
                   Write(Model.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <td class=\"fs-6\">Establishment Date</td>\r\n                    <td>:</td>\r\n                    <td>");
#nullable restore
#line 33 "D:\PROJECTS\FutureStage\FutureStage\Areas\Schools\Views\Home\SchoolProfile.cshtml"
                   Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <td class=\"fs-6\">Area</td>\r\n                    <td>:</td>\r\n                    <td>");
#nullable restore
#line 38 "D:\PROJECTS\FutureStage\FutureStage\Areas\Schools\Views\Home\SchoolProfile.cshtml"
                   Write(Model.Area.AreaName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n            </tbody>\r\n        </table>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FutureStage.Models.School> Html { get; private set; }
    }
}
#pragma warning restore 1591