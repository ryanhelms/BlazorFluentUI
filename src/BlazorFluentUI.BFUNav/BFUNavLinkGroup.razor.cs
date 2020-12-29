﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Threading.Tasks;

namespace BlazorFluentUI
{
    public partial class BFUNavLinkGroup : BFUComponentBase
    {
        [Parameter] public bool CollapseByDefault { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public RenderFragment<string> GroupHeaderTemplate { get; set; }
        [Parameter] public string Name { get; set; }

        [CascadingParameter] protected string ExpandButtonAriaLabel { get; set; }

        [Parameter] public EventCallback<BFUNavLinkGroup> OnClick { get; set; }

        protected bool isExpanded = true;
        private bool hasRenderedOnce;

        protected async Task ClickHandler(MouseEventArgs args)
        {
            isExpanded = !isExpanded;
            await OnClick.InvokeAsync(this);
            //return Task.CompletedTask;
        }

        protected override Task OnInitializedAsync()
        {
            //System.Diagnostics.Debug.WriteLine("Initializing NavLinkGroupBase");
            return base.OnInitializedAsync();
        }

        protected override Task OnParametersSetAsync()
        {
            if (!hasRenderedOnce)
                isExpanded = !CollapseByDefault;
            return base.OnParametersSetAsync();
        }

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                hasRenderedOnce = true;
            }

            base.OnAfterRender(firstRender);
        }

    }
}
