#pragma checksum "E:\SEM 6\OOSE\project\FarmerCropMarketing\FarmerCropMarketing\Views\Admin\CropList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7ed289bd905fdb591545d0da55ddcba53fd5b78d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_CropList), @"mvc.1.0.view", @"/Views/Admin/CropList.cshtml")]
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
#line 1 "E:\SEM 6\OOSE\project\FarmerCropMarketing\FarmerCropMarketing\Views\_ViewImports.cshtml"
using FarmerCropMarketing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\SEM 6\OOSE\project\FarmerCropMarketing\FarmerCropMarketing\Views\_ViewImports.cshtml"
using FarmerCropMarketing.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\SEM 6\OOSE\project\FarmerCropMarketing\FarmerCropMarketing\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7ed289bd905fdb591545d0da55ddcba53fd5b78d", @"/Views/Admin/CropList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"42d94237e918fd8f61a02fe5c558a70efcbe393c", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_CropList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<FarmerCropMarketing.Models.Crops>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Crops", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "E:\SEM 6\OOSE\project\FarmerCropMarketing\FarmerCropMarketing\Views\Admin\CropList.cshtml"
  
    ViewData["Title"] = "CropList";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>CropList</h1>\r\n\r\n\r\n\r\n");
#nullable restore
#line 12 "E:\SEM 6\OOSE\project\FarmerCropMarketing\FarmerCropMarketing\Views\Admin\CropList.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 16 "E:\SEM 6\OOSE\project\FarmerCropMarketing\FarmerCropMarketing\Views\Admin\CropList.cshtml"
  
    var i = 0;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container\">\r\n");
#nullable restore
#line 21 "E:\SEM 6\OOSE\project\FarmerCropMarketing\FarmerCropMarketing\Views\Admin\CropList.cshtml"
     foreach (var item in Model)
    {
        var crop_image_path = "/CropImage/" + item.Crops_image;

        

#line default
#line hidden
#nullable disable
#nullable restore
#line 25 "E:\SEM 6\OOSE\project\FarmerCropMarketing\FarmerCropMarketing\Views\Admin\CropList.cshtml"
         if (!item.itComplited)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div style=\"display:inline-block\">\r\n                <div class=\"card\" style=\"width: 18rem;\">\r\n                    <img class=\"card-img-top\"");
            BeginWriteAttribute("src", " src=\"", 574, "\"", 596, 1);
#nullable restore
#line 29 "E:\SEM 6\OOSE\project\FarmerCropMarketing\FarmerCropMarketing\Views\Admin\CropList.cshtml"
WriteAttributeValue("", 580, crop_image_path, 580, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"Card image cap\">\r\n                    <div class=\"card-body\">\r\n                        <h5 class=\"card-title\">");
#nullable restore
#line 31 "E:\SEM 6\OOSE\project\FarmerCropMarketing\FarmerCropMarketing\Views\Admin\CropList.cshtml"
                                          Write(Html.DisplayFor(modelItem => item.Crops_name));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                        <p class=\"card-text\"> ");
#nullable restore
#line 32 "E:\SEM 6\OOSE\project\FarmerCropMarketing\FarmerCropMarketing\Views\Admin\CropList.cshtml"
                                         Write(Html.DisplayNameFor(model => model.Crops_price));

#line default
#line hidden
#nullable disable
            WriteLiteral(" : ");
#nullable restore
#line 32 "E:\SEM 6\OOSE\project\FarmerCropMarketing\FarmerCropMarketing\Views\Admin\CropList.cshtml"
                                                                                            Write(Html.DisplayFor(modelItem => item.Crops_price));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        <p class=\"card-text\"> ");
#nullable restore
#line 33 "E:\SEM 6\OOSE\project\FarmerCropMarketing\FarmerCropMarketing\Views\Admin\CropList.cshtml"
                                         Write(Html.DisplayNameFor(model => model.Crops_quantity));

#line default
#line hidden
#nullable disable
            WriteLiteral(" : ");
#nullable restore
#line 33 "E:\SEM 6\OOSE\project\FarmerCropMarketing\FarmerCropMarketing\Views\Admin\CropList.cshtml"
                                                                                               Write(Html.DisplayFor(modelItem => item.Crops_quantity));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\r\n                        <p class=\"card-text\"> ");
#nullable restore
#line 35 "E:\SEM 6\OOSE\project\FarmerCropMarketing\FarmerCropMarketing\Views\Admin\CropList.cshtml"
                                         Write(Html.DisplayNameFor(model => model.Crops_description));

#line default
#line hidden
#nullable disable
            WriteLiteral(" : ");
#nullable restore
#line 35 "E:\SEM 6\OOSE\project\FarmerCropMarketing\FarmerCropMarketing\Views\Admin\CropList.cshtml"
                                                                                                  Write(Html.DisplayFor(modelItem => item.Crops_description));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\r\n\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7ed289bd905fdb591545d0da55ddcba53fd5b78d8848", async() => {
                WriteLiteral("Delete");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 38 "E:\SEM 6\OOSE\project\FarmerCropMarketing\FarmerCropMarketing\Views\Admin\CropList.cshtml"
                                                                        WriteLiteral(item.Crops_id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 43 "E:\SEM 6\OOSE\project\FarmerCropMarketing\FarmerCropMarketing\Views\Admin\CropList.cshtml"

            i++;
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 45 "E:\SEM 6\OOSE\project\FarmerCropMarketing\FarmerCropMarketing\Views\Admin\CropList.cshtml"
         
    }

#line default
#line hidden
#nullable disable
            WriteLiteral(" </div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<FarmerCropMarketing.Models.Crops>> Html { get; private set; }
    }
}
#pragma warning restore 1591