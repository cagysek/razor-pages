#pragma checksum "/Users/cagy/Documents/Škola/NET/AccountingApp/AccountingApp/Pages/Accountant/Invoices/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "906abea358d3fc1cf8196bf98ded0e2bd5730374"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AccountingApp.Pages.Accountant.Invoices.Pages_Accountant_Invoices_Index), @"mvc.1.0.razor-page", @"/Pages/Accountant/Invoices/Index.cshtml")]
namespace AccountingApp.Pages.Accountant.Invoices
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
#line 1 "/Users/cagy/Documents/Škola/NET/AccountingApp/AccountingApp/Pages/_ViewImports.cshtml"
using AccountingApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/cagy/Documents/Škola/NET/AccountingApp/AccountingApp/Pages/Accountant/Invoices/Index.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/Users/cagy/Documents/Škola/NET/AccountingApp/AccountingApp/Pages/Accountant/Invoices/Index.cshtml"
using AccountingApp.Enum;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/Users/cagy/Documents/Škola/NET/AccountingApp/AccountingApp/Pages/Accountant/Invoices/Index.cshtml"
using AccountingApp.Services;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"906abea358d3fc1cf8196bf98ded0e2bd5730374", @"/Pages/Accountant/Invoices/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bd7ed9d5f248d2b50256c6b63640f583cafe5f92", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Accountant_Invoices_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onclick", new global::Microsoft.AspNetCore.Html.HtmlString("return confirm(\'Opravdu chcete odstranit fakturu?\')"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 7 "/Users/cagy/Documents/Škola/NET/AccountingApp/AccountingApp/Pages/Accountant/Invoices/Index.cshtml"
  
    ViewData["Title"] = "Faktury";
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral("<h2>Seznam faktur</h2>\r\n\r\n");
#nullable restore
#line 13 "/Users/cagy/Documents/Škola/NET/AccountingApp/AccountingApp/Pages/Accountant/Invoices/Index.cshtml"
 if (@HttpContext.Session.GetString(SessionService.ROLE) != null && @HttpContext.Session.GetString(SessionService.ROLE).Equals(ERole.Accountant))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "906abea358d3fc1cf8196bf98ded0e2bd57303745832", async() => {
                WriteLiteral("<button type=\"button\" class=\"btn btn-success\">Nový <i class=\"fas fa-plus\"></i></button>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 16 "/Users/cagy/Documents/Škola/NET/AccountingApp/AccountingApp/Pages/Accountant/Invoices/Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"table-wrapper\">\r\n    <table class=\"table\" xmlns:th=\"http://www.w3.org/1999/xhtml\">\r\n        <thead>\r\n            <tr>\r\n                <th scope=\"col\">");
#nullable restore
#line 22 "/Users/cagy/Documents/Škola/NET/AccountingApp/AccountingApp/Pages/Accountant/Invoices/Index.cshtml"
                           Write(Html.DisplayNameFor(model => model.InvoiceList[0].ID));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <th scope=\"col\">");
#nullable restore
#line 23 "/Users/cagy/Documents/Škola/NET/AccountingApp/AccountingApp/Pages/Accountant/Invoices/Index.cshtml"
                           Write(Html.DisplayNameFor(model => model.InvoiceList[0].Suppliercompany.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <th scope=\"col\">");
#nullable restore
#line 24 "/Users/cagy/Documents/Škola/NET/AccountingApp/AccountingApp/Pages/Accountant/Invoices/Index.cshtml"
                           Write(Html.DisplayNameFor(model => model.InvoiceList[0].BillToCompany.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <th scope=\"col\">");
#nullable restore
#line 25 "/Users/cagy/Documents/Škola/NET/AccountingApp/AccountingApp/Pages/Accountant/Invoices/Index.cshtml"
                           Write(Html.DisplayNameFor(model => model.InvoiceList[0].PublishDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <th scope=\"col\">");
#nullable restore
#line 26 "/Users/cagy/Documents/Škola/NET/AccountingApp/AccountingApp/Pages/Accountant/Invoices/Index.cshtml"
                           Write(Html.DisplayNameFor(model => model.InvoiceList[0].PaymentDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <th scope=\"col\">Stav</th>    \r\n                <th scope=\"col\"></th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 32 "/Users/cagy/Documents/Škola/NET/AccountingApp/AccountingApp/Pages/Accountant/Invoices/Index.cshtml"
             foreach (var item in Model.InvoiceList)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 35 "/Users/cagy/Documents/Škola/NET/AccountingApp/AccountingApp/Pages/Accountant/Invoices/Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.ID));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 36 "/Users/cagy/Documents/Škola/NET/AccountingApp/AccountingApp/Pages/Accountant/Invoices/Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Suppliercompany.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 37 "/Users/cagy/Documents/Škola/NET/AccountingApp/AccountingApp/Pages/Accountant/Invoices/Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.BillToCompany.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 38 "/Users/cagy/Documents/Škola/NET/AccountingApp/AccountingApp/Pages/Accountant/Invoices/Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.PublishDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 39 "/Users/cagy/Documents/Škola/NET/AccountingApp/AccountingApp/Pages/Accountant/Invoices/Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.PaymentDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>\r\n");
#nullable restore
#line 41 "/Users/cagy/Documents/Škola/NET/AccountingApp/AccountingApp/Pages/Accountant/Invoices/Index.cshtml"
                     if (item.IsStorno)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span>Storno</span>\r\n");
#nullable restore
#line 44 "/Users/cagy/Documents/Škola/NET/AccountingApp/AccountingApp/Pages/Accountant/Invoices/Index.cshtml"
                    }
                    else
                    {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 47 "/Users/cagy/Documents/Škola/NET/AccountingApp/AccountingApp/Pages/Accountant/Invoices/Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Type));

#line default
#line hidden
#nullable disable
#nullable restore
#line 47 "/Users/cagy/Documents/Škola/NET/AccountingApp/AccountingApp/Pages/Accountant/Invoices/Index.cshtml"
                                                                
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\r\n                <td>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "906abea358d3fc1cf8196bf98ded0e2bd573037412346", async() => {
                WriteLiteral("<i class=\"fas fa-info-circle\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 51 "/Users/cagy/Documents/Škola/NET/AccountingApp/AccountingApp/Pages/Accountant/Invoices/Index.cshtml"
                                              WriteLiteral(item.ID);

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
            WriteLiteral("\r\n");
#nullable restore
#line 52 "/Users/cagy/Documents/Škola/NET/AccountingApp/AccountingApp/Pages/Accountant/Invoices/Index.cshtml"
                     if (@HttpContext.Session.GetString(SessionService.ROLE) != null && @HttpContext.Session.GetString(SessionService.ROLE).Equals(ERole.Accountant))
                    {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 54 "/Users/cagy/Documents/Škola/NET/AccountingApp/AccountingApp/Pages/Accountant/Invoices/Index.cshtml"
                         if (!item.IsStorno)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "906abea358d3fc1cf8196bf98ded0e2bd573037415216", async() => {
                WriteLiteral("<i class=\"far fa-edit\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 56 "/Users/cagy/Documents/Škola/NET/AccountingApp/AccountingApp/Pages/Accountant/Invoices/Index.cshtml"
                                                   WriteLiteral(item.ID);

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
            WriteLiteral("\r\n");
#nullable restore
#line 57 "/Users/cagy/Documents/Škola/NET/AccountingApp/AccountingApp/Pages/Accountant/Invoices/Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "906abea358d3fc1cf8196bf98ded0e2bd573037417643", async() => {
                WriteLiteral("<i class=\"far fa-trash-alt\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 59 "/Users/cagy/Documents/Škola/NET/AccountingApp/AccountingApp/Pages/Accountant/Invoices/Index.cshtml"
                                                 WriteLiteral(item.ID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 60 "/Users/cagy/Documents/Škola/NET/AccountingApp/AccountingApp/Pages/Accountant/Invoices/Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\r\n            </tr>\r\n");
#nullable restore
#line 63 "/Users/cagy/Documents/Škola/NET/AccountingApp/AccountingApp/Pages/Accountant/Invoices/Index.cshtml"

            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AccountingApp.Pages.Accountant.Invoices.IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<AccountingApp.Pages.Accountant.Invoices.IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<AccountingApp.Pages.Accountant.Invoices.IndexModel>)PageContext?.ViewData;
        public AccountingApp.Pages.Accountant.Invoices.IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
