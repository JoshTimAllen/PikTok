#pragma checksum "C:\Users\admin\Documents\repos\PikTok\PikTok\Views\Profile\Profile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bbd445bc6d331293fdb90e3b8e22b481f37ef813"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Profile_Profile), @"mvc.1.0.view", @"/Views/Profile/Profile.cshtml")]
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
#line 2 "C:\Users\admin\Documents\repos\PikTok\PikTok\Views\Profile\Profile.cshtml"
using PikTok.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\admin\Documents\repos\PikTok\PikTok\Views\Profile\Profile.cshtml"
using PikTok.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\admin\Documents\repos\PikTok\PikTok\Views\Profile\Profile.cshtml"
using PikTok.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\admin\Documents\repos\PikTok\PikTok\Views\Profile\Profile.cshtml"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bbd445bc6d331293fdb90e3b8e22b481f37ef813", @"/Views/Profile/Profile.cshtml")]
    public class Views_Profile_Profile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PikTok.Models.ProfileViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("flex h-full items-center justify-center pl-5 pr-5"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/Messages"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CreatePost", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("bg-gray-400 h-screen w-screen sm:px-8 md:px-16 sm:py-8"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 7 "C:\Users\admin\Documents\repos\PikTok\PikTok\Views\Profile\Profile.cshtml"
  
    ViewData["Title"] = @Model.userAccountToView.profile.UserName;
    Layout = "~/Pages/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<!--
(//await Html.RenderComponentAsync<Card>(RenderMode.ServerPrerendered, new { str = ""jjjjjjjjjjjjj"" })
        )-->
<!-- component -->

<div class=""items-center justify-center mx-auto overflow-hidden rounded-lg shadow-sm w-full"">
    <div class=""relative h-40"">
        <img class=""absolute h-full w-full object-cover"" src=""https://images.unsplash.com/photo-1448932133140-b4045783ed9e?ixlib=rb-1.2.1&auto=format&fit=crop&w=400&q=80"">
    </div>
    <div class=""relative shadow mx-auto h-24 w-24 -my-12 border-white rounded-full overflow-hidden border-4"">
        <img class=""object-cover w-full h-full""");
            BeginWriteAttribute("src", " src=\"", 947, "\"", 1004, 1);
#nullable restore
#line 21 "C:\Users\admin\Documents\repos\PikTok\PikTok\Views\Profile\Profile.cshtml"
WriteAttributeValue("", 953, Model.userAccountToView.profile.ProfilePicture.url, 953, 51, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n    </div>\r\n    <div class=\"mt-16\">\r\n        <h1 class=\"text-lg text-center font-semibold\">\r\n            ");
#nullable restore
#line 25 "C:\Users\admin\Documents\repos\PikTok\PikTok\Views\Profile\Profile.cshtml"
       Write(Model.userAccountToView.profile.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </h1>\r\n        <div class=\"border-t flex flex-wrap h-16 items-center justify-center\">\r\n            <p class=\"text-sm text-gray-600 text-center pl-5 pr-5\"> Followers: ");
#nullable restore
#line 28 "C:\Users\admin\Documents\repos\PikTok\PikTok\Views\Profile\Profile.cshtml"
                                                                          Write(Model.userAccountToView.Followers.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("  </p>\r\n            <p class=\"text-sm text-gray-600 text-center pl-5 pr-5\"> Following: ");
#nullable restore
#line 29 "C:\Users\admin\Documents\repos\PikTok\PikTok\Views\Profile\Profile.cshtml"
                                                                          Write(Model.userAccountToView.Following.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 32 "C:\Users\admin\Documents\repos\PikTok\PikTok\Views\Profile\Profile.cshtml"
     if (!Model.profileNotfound) {

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"border-t flex flex-wrap h-16 items-center justify-center w-full\">\r\n");
#nullable restore
#line 34 "C:\Users\admin\Documents\repos\PikTok\PikTok\Views\Profile\Profile.cshtml"
           if (!Model.isOwner) {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <div onclick=""FollowUser(ProfileUserName)"" class=""flex h-full items-center justify-center pl-5 pr-5"">  <button class=""h-10 px-5 text-yellow-700 transition-colors duration-150 border border-yellow-500 rounded-lg focus:shadow-outline hover:bg-yellow-500 hover:text-yellow-100"">Follow</button>  </div>
            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bbd445bc6d331293fdb90e3b8e22b481f37ef8139300", async() => {
                WriteLiteral(" <input type=\"hidden\" name=\"ExId\"");
                BeginWriteAttribute("value", " value=\"", 2125, "\"", 2172, 1);
#nullable restore
#line 36 "C:\Users\admin\Documents\repos\PikTok\PikTok\Views\Profile\Profile.cshtml"
WriteAttributeValue("", 2133, Model.userAccountToView.externalUserId, 2133, 39, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" id=\"messageButonValue\" /> <button type=\"submit\" class=\"h-10 px-5 text-yellow-700 transition-colors duration-150 border border-yellow-500 rounded-lg focus:shadow-outline hover:bg-yellow-500 hover:text-yellow-100\">Message</button>  ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 37 "C:\Users\admin\Documents\repos\PikTok\PikTok\Views\Profile\Profile.cshtml"
            }
            else {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <div onclick=""DisplayCreatePost()"" class=""flex h-full items-center justify-center pl-5 pr-5"">  <button class=""h-10 px-5 text-yellow-700 transition-colors duration-150 border border-yellow-500 rounded-lg focus:shadow-outline hover:bg-yellow-500 hover:text-yellow-100"">Settings</button>  </div>
");
#nullable restore
#line 40 "C:\Users\admin\Documents\repos\PikTok\PikTok\Views\Profile\Profile.cshtml"
            }
            

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </div>
    <div class=""border-gray-100 border-t flex flex-wrap h-16 items-stretch justify-center w-full"">
        <a onclick=""DisplayPosts()"" class=""border-gray-100 border-r flex flex-1 h-full items-center justify-center"">  <i class=""border-gray-200 fa fa-film fa-photo-video far text-4xl text-gray-700""></i>  </a>
");
#nullable restore
#line 45 "C:\Users\admin\Documents\repos\PikTok\PikTok\Views\Profile\Profile.cshtml"
         if (Model.isOwner) {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <a onclick=\"DisplayCreatePost()\" class=\"border-gray-100 border-r flex flex-1 h-full items-center justify-center\">  <i class=\"border-gray-200 fa fa-photo-video fa-upload far text-4xl text-gray-700\"></i>  </a>");
#nullable restore
#line 46 "C:\Users\admin\Documents\repos\PikTok\PikTok\Views\Profile\Profile.cshtml"
                                                                                                                                                                                                                           }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n");
#nullable restore
#line 48 "C:\Users\admin\Documents\repos\PikTok\PikTok\Views\Profile\Profile.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
#nullable restore
#line 50 "C:\Users\admin\Documents\repos\PikTok\PikTok\Views\Profile\Profile.cshtml"
  
    if (!Model.profileNotfound) {
        if (Model.isOwner) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div id=\"Create-Post-Section\" style=\"display:none\">\r\n\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bbd445bc6d331293fdb90e3b8e22b481f37ef81313850", async() => {
                WriteLiteral(@"
                <!-- file upload modal -->
                <article aria-label=""File Upload Modal"" class=""relative h-full flex flex-col bg-white shadow-xl rounded-md"" ondrop=""dropHandler(event);"" ondragover=""dragOverHandler(event);"" ondragleave=""dragLeaveHandler(event);"" ondragenter=""dragEnterHandler(event);"">
                    <!-- overlay -->
                    <div id=""overlay"" class=""w-full h-full absolute top-0 left-0 pointer-events-none z-50 flex flex-col items-center justify-center rounded-md"">
                        <i>
                            <svg class=""fill-current w-12 h-12 mb-3 text-blue-700"" xmlns=""http://www.w3.org/2000/svg"" width=""24"" height=""24"" viewBox=""0 0 24 24"">
                                <path d=""M19.479 10.092c-.212-3.951-3.473-7.092-7.479-7.092-4.005 0-7.267 3.141-7.479 7.092-2.57.463-4.521 2.706-4.521 5.408 0 3.037 2.463 5.5 5.5 5.5h13c3.037 0 5.5-2.463 5.5-5.5 0-2.702-1.951-4.945-4.521-5.408zm-7.479-1.092l4 4h-3v4h-2v-4h-3l4-4z"" />
                            </");
                WriteLiteral(@"svg>
                        </i>
                        <p class=""text-lg text-blue-700"">Drop files to upload</p>
                    </div>

                    <!-- scroll area -->
                    <section class=""h-full overflow-auto p-8 w-full h-full flex flex-col"">
                        <header class=""border-dashed border-2 border-gray-400 py-12 flex flex-col justify-center items-center"">
                            <p class=""mb-3 font-semibold text-gray-900 flex flex-wrap justify-center"">
                                <span>Drag and drop your</span>&nbsp;<span>files anywhere or</span>
                            </p>
                            <input name=""Files"" id=""hidden-input"" type=""file"" multiple class=""hidden"" />
                            <button type=""button"" id=""button"" class=""mt-2 rounded-sm px-3 py-1 bg-gray-200 hover:bg-gray-300 focus:shadow-outline focus:outline-none"">
                                Upload a file
                            </button>
             ");
                WriteLiteral(@"           </header>

                        <h1 class=""pt-8 pb-3 font-semibold sm:text-lg text-gray-900"">
                            To Upload
                        </h1>

                        <ul id=""gallery"" class=""flex flex-1 flex-wrap -m-1"">
                            <li id=""empty"" class=""h-full w-full text-center flex flex-col items-center justify-center items-center"">
                                <img class=""mx-auto w-32"" src=""https://user-images.githubusercontent.com/507615/54591670-ac0a0180-4a65-11e9-846c-e55ffce0fe7b.png"" alt=""no data"" />
                                <span class=""text-small text-gray-500"">No files selected</span>
                            </li>
                        </ul>
                    </section>
                    <label class=""block p-3"">
                        <span class=""text-gray-700"">Description:</span>
                        <textarea name=""Description"" class=""form-textarea mt-1 block w-full border-2 border-black rounded-md"" rows=""3");
                WriteLiteral(@""" placeholder=""Description.""></textarea>
                    </label>
                    <!-- sticky footer -->
                    <footer class=""flex justify-end px-8 pb-8 pt-4"">
                        <button type=""submit"" class=""rounded-sm px-3 py-1 bg-blue-700 hover:bg-blue-500 text-white focus:shadow-outline focus:outline-none"">
                            Upload
                        </button>
                    </footer>
                </article>
            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

            <!-- using two similar templates for simplicity in js code -->
            <template id=""file-template"">
                <li class=""block p-1 w-1/2 sm:w-1/3 md:w-1/4 lg:w-1/6 xl:w-1/8 h-24"">
                    <article tabindex=""0"" class=""group w-full h-full rounded-md focus:outline-none focus:shadow-outline elative bg-gray-100 cursor-pointer relative shadow-sm"">
                        <img alt=""upload preview"" class=""img-preview hidden w-full h-full sticky object-cover rounded-md bg-fixed"" />

                        <section class=""flex flex-col rounded-md text-xs break-words w-full h-full z-20 absolute top-0 py-2 px-3"">
                            <h1 class=""flex-1 group-hover:text-blue-800""></h1>
                            <div class=""flex"">
                                <span class=""p-1 text-blue-800"">
                                    <i>
                                        <svg class=""fill-current w-4 h-4 ml-auto pt-1"" xmlns=""http://www.w3.org/2000/svg"" width=""24"" ");
            WriteLiteral(@"height=""24"" viewBox=""0 0 24 24"">
                                            <path d=""M15 2v5h5v15h-16v-20h11zm1-2h-14v24h20v-18l-6-6z"" />
                                        </svg>
                                    </i>
                                </span>
                                <p class=""p-1 size text-xs text-gray-700""></p>
                                <button class=""delete ml-auto focus:outline-none hover:bg-gray-300 p-1 rounded-md text-gray-800"">
                                    <svg class=""pointer-events-none fill-current w-4 h-4 ml-auto"" xmlns=""http://www.w3.org/2000/svg"" width=""24"" height=""24"" viewBox=""0 0 24 24"">
                                        <path class=""pointer-events-none"" d=""M3 6l3 18h12l3-18h-18zm19-4v2h-20v-2h5.711c.9 0 1.631-1.099 1.631-2h5.316c0 .901.73 2 1.631 2h5.711z"" />
                                    </svg>
                                </button>
                            </div>
                        </section>
                    <");
            WriteLiteral(@"/article>
                </li>
            </template>

            <template id=""image-template"">
                <li class=""block p-1 w-1/2 sm:w-1/3 md:w-1/4 lg:w-1/6 xl:w-1/8 h-24"">
                    <article tabindex=""0"" class=""group hasImage w-full h-full rounded-md focus:outline-none focus:shadow-outline bg-gray-100 cursor-pointer relative text-transparent hover:text-white shadow-sm"">
                        <img alt=""upload preview"" class=""img-preview w-full h-full sticky object-cover rounded-md bg-fixed"" />

                        <section class=""flex flex-col rounded-md text-xs break-words w-full h-full z-20 absolute top-0 py-2 px-3"">
                            <h1 class=""flex-1""></h1>
                            <div class=""flex"">
                                <span class=""p-1"">
                                    <i>
                                        <svg class=""fill-current w-4 h-4 ml-auto pt-"" xmlns=""http://www.w3.org/2000/svg"" width=""24"" height=""24"" viewBox=""0 0 24 24""");
            WriteLiteral(@">
                                            <path d=""M5 8.5c0-.828.672-1.5 1.5-1.5s1.5.672 1.5 1.5c0 .829-.672 1.5-1.5 1.5s-1.5-.671-1.5-1.5zm9 .5l-2.519 4-2.481-1.96-4 5.96h14l-5-8zm8-4v14h-20v-14h20zm2-2h-24v18h24v-18z"" />
                                        </svg>
                                    </i>
                                </span>

                                <p class=""p-1 size text-xs""></p>
                                <button class=""delete ml-auto focus:outline-none hover:bg-gray-300 p-1 rounded-md"">
                                    <svg class=""pointer-events-none fill-current w-4 h-4 ml-auto"" xmlns=""http://www.w3.org/2000/svg"" width=""24"" height=""24"" viewBox=""0 0 24 24"">
                                        <path class=""pointer-events-none"" d=""M3 6l3 18h12l3-18h-18zm19-4v2h-20v-2h5.711c.9 0 1.631-1.099 1.631-2h5.316c0 .901.73 2 1.631 2h5.711z"" />
                                    </svg>
                                </button>
                            </d");
            WriteLiteral(@"iv>
                        </section>
                    </article>
                </li>
            </template>

            <script>
                document.addEventListener('DOMContentLoaded', function () {
                    const fileTempl = document.getElementById(""file-template""),
                        imageTempl = document.getElementById(""image-template""),
                        empty = document.getElementById(""empty"");

                    // use to store pre selected files
                    let FILES = {};

                    // check if file is of type image and prepend the initialied
                    // template to the target element
                    function addFile(target, file) {
                        const isImage = file.type.match(""image.*""),
                            objectURL = URL.createObjectURL(file);

                        const clone = isImage
                            ? imageTempl.content.cloneNode(true)
                            : fil");
            WriteLiteral(@"eTempl.content.cloneNode(true);

                        clone.querySelector(""h1"").textContent = file.name;
                        clone.querySelector(""li"").id = objectURL;
                        clone.querySelector("".delete"").dataset.target = objectURL;
                        clone.querySelector("".size"").textContent =
                            file.size > 1024
                                ? file.size > 1048576
                                    ? Math.round(file.size / 1048576) + ""mb""
                                    : Math.round(file.size / 1024) + ""kb""
                                : file.size + ""b"";

                        isImage &&
                            Object.assign(clone.querySelector(""img""), {
                                src: objectURL,
                                alt: file.name
                            });

                        empty.classList.add(""hidden"");
                        target.prepend(clone);

                        FILES[objectURL");
            WriteLiteral(@"] = file;
                    }

                    const gallery = document.getElementById(""gallery""),
                        overlay = document.getElementById(""overlay"");

                    // click the hidden input of type file if the visible button is clicked
                    // and capture the selected files
                    const hidden = document.getElementById(""hidden-input"");
                    document.getElementById(""button"").onclick = () => hidden.click();
                    hidden.onchange = (e) => {
                        for (const file of e.target.files) {
                            addFile(gallery, file);
                        }
                    };

                    // use to check if a file is being dragged
                    const hasFiles = ({ dataTransfer: { types = [] } }) =>
                        types.indexOf(""Files"") > -1;

                    // use to drag dragenter and dragleave events.
                    // this is to know if the oute");
            WriteLiteral(@"rmost parent is dragged over
                    // without issues due to drag events on its children
                    let counter = 0;

                    // reset counter and append file to gallery when file is dropped
                    function dropHandler(ev) {
                        ev.preventDefault();
                        for (const file of ev.dataTransfer.files) {
                            addFile(gallery, file);
                            overlay.classList.remove(""draggedover"");
                            counter = 0;
                        }
                    }

                    // only react to actual files being dragged
                    function dragEnterHandler(e) {
                        e.preventDefault();
                        if (!hasFiles(e)) {
                            return;
                        }
                        ++counter && overlay.classList.add(""draggedover"");
                    }

                    function dragLeaveHand");
            WriteLiteral(@"ler(e) {
                        1 > --counter && overlay.classList.remove(""draggedover"");
                    }

                    function dragOverHandler(e) {
                        if (hasFiles(e)) {
                            e.preventDefault();
                        }
                    }

                    // event delegation to caputre delete events
                    // fron the waste buckets in the file preview cards
                    gallery.onclick = ({ target }) => {
                        if (target.classList.contains(""delete"")) {
                            const ou = target.dataset.target;
                            document.getElementById(ou).remove(ou);
                            gallery.children.length === 1 && empty.classList.remove(""hidden"");
                            delete FILES[ou];
                        }
                    };

                    // clear entire selection
                    document.getElementById(""cancel"").onclick = () => {");
            WriteLiteral(@"
                        while (gallery.children.length > 0) {
                            gallery.lastChild.remove();
                        }
                        FILES = {};
                        empty.classList.remove(""hidden"");
                        gallery.append(empty);
                    };
                }, false);
            </script>


        </div>
        <style>
            .hasImage:hover section {
                background-color: rgba(5, 5, 5, 0.4);
            }

            .hasImage:hover button:hover {
                background: rgba(5, 5, 5, 0.45);
            }

            #overlay.draggedover {
                background-color: rgba(255, 255, 255, 0.7);
            }

                #overlay.draggedover p,
                #overlay.draggedover i {
                    opacity: 1;
                }

            .group:hover .group-hover\:text-blue-800 {
                color: #2b6cb0;
            }
        </style>
");
#nullable restore
#line 299 "C:\Users\admin\Documents\repos\PikTok\PikTok\Views\Profile\Profile.cshtml"
            }
        }
    

#line default
#line hidden
#nullable disable
            WriteLiteral("<div id=\"CardsContainer\" class=\"CardsContainer bg-gray-50 dark:bg-black flex flex-col items-stretch justify-center\">\r\n\r\n</div>\r\n<p id=\"ProfileUserName\" style=\"display:none;\">");
#nullable restore
#line 305 "C:\Users\admin\Documents\repos\PikTok\PikTok\Views\Profile\Profile.cshtml"
                                         Write(Model.userAccountToView.profile.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
<script>
    function DisplayCreatePost() {
        document.getElementById(""Create-Post-Section"").style.display = ""block"";
        document.getElementById(""CardsContainer"").style.display = ""none"";
    }
    function DisplayPosts() {
        document.getElementById(""Create-Post-Section"").style.display = ""none"";
        document.getElementById(""CardsContainer"").style.display = ""block"";
    }
    document.addEventListener('DOMContentLoaded', function () {
        ProfileUserName = document.getElementById(""ProfileUserName"").innerHTML; GetProfilePost(ProfileUserName, 0);
    }, false);
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PikTok.Models.ProfileViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
