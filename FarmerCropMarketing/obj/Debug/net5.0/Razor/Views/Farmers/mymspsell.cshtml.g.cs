#pragma checksum "E:\SEM 6\OOSE\project\FarmerCropMarketing\FarmerCropMarketing\Views\Farmers\mymspsell.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "67083d62184c620a2e7f8f866cde1964c9227ae9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Farmers_mymspsell), @"mvc.1.0.view", @"/Views/Farmers/mymspsell.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"67083d62184c620a2e7f8f866cde1964c9227ae9", @"/Views/Farmers/mymspsell.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"42d94237e918fd8f61a02fe5c558a70efcbe393c", @"/Views/_ViewImports.cshtml")]
    public class Views_Farmers_mymspsell : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<FarmerCropMarketing.Models.Class.MSPSellCrops>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "E:\SEM 6\OOSE\project\FarmerCropMarketing\FarmerCropMarketing\Views\Farmers\mymspsell.cshtml"
   ViewData["Title"] = "My MSP Sell";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>MY MSP Sell</h1>\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 12 "E:\SEM 6\OOSE\project\FarmerCropMarketing\FarmerCropMarketing\Views\Farmers\mymspsell.cshtml"
           Write(Html.DisplayNameFor(model => model.MSPCropsDetail.Crops_name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 15 "E:\SEM 6\OOSE\project\FarmerCropMarketing\FarmerCropMarketing\Views\Farmers\mymspsell.cshtml"
           Write(Html.DisplayNameFor(model => model.MSPCropsDetail.Crops_price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 18 "E:\SEM 6\OOSE\project\FarmerCropMarketing\FarmerCropMarketing\Views\Farmers\mymspsell.cshtml"
           Write(Html.DisplayNameFor(model => model.Crops_quantity));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 21 "E:\SEM 6\OOSE\project\FarmerCropMarketing\FarmerCropMarketing\Views\Farmers\mymspsell.cshtml"
           Write(Html.DisplayNameFor(model => model.MSPCropsDetail.Crops_description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 24 "E:\SEM 6\OOSE\project\FarmerCropMarketing\FarmerCropMarketing\Views\Farmers\mymspsell.cshtml"
           Write(Html.DisplayNameFor(model => model.MSPCropsDetail.Crops_image));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n           \r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 30 "E:\SEM 6\OOSE\project\FarmerCropMarketing\FarmerCropMarketing\Views\Farmers\mymspsell.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 34 "E:\SEM 6\OOSE\project\FarmerCropMarketing\FarmerCropMarketing\Views\Farmers\mymspsell.cshtml"
           Write(Html.DisplayFor(modelItem => item.MSPCropsDetail.Crops_name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 37 "E:\SEM 6\OOSE\project\FarmerCropMarketing\FarmerCropMarketing\Views\Farmers\mymspsell.cshtml"
           Write(Html.DisplayFor(modelItem => item.MSPCropsDetail.Crops_price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 40 "E:\SEM 6\OOSE\project\FarmerCropMarketing\FarmerCropMarketing\Views\Farmers\mymspsell.cshtml"
           Write(Html.DisplayFor(modelItem => item.Crops_quantity));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            \r\n            <td>\r\n                ");
#nullable restore
#line 44 "E:\SEM 6\OOSE\project\FarmerCropMarketing\FarmerCropMarketing\Views\Farmers\mymspsell.cshtml"
           Write(Html.DisplayFor(modelItem => item.MSPCropsDetail.Crops_description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n");
#nullable restore
#line 47 "E:\SEM 6\OOSE\project\FarmerCropMarketing\FarmerCropMarketing\Views\Farmers\mymspsell.cshtml"
                  
                    var imagepath = "../CropImage/" + (item.MSPCropsDetail.Crops_image);
                

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <img");
            BeginWriteAttribute("src", " src=\"", 1577, "\"", 1593, 1);
#nullable restore
#line 51 "E:\SEM 6\OOSE\project\FarmerCropMarketing\FarmerCropMarketing\Views\Farmers\mymspsell.cshtml"
WriteAttributeValue("", 1583, imagepath, 1583, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"img-thumbnail\">\r\n                \r\n");
            WriteLiteral("            </td>\r\n\r\n            \r\n        </tr>\r\n");
#nullable restore
#line 59 "E:\SEM 6\OOSE\project\FarmerCropMarketing\FarmerCropMarketing\Views\Farmers\mymspsell.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<FarmerCropMarketing.Models.Class.MSPSellCrops>> Html { get; private set; }
    }
}
#pragma warning restore 1591
