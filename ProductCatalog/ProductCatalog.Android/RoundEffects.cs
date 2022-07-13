using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;


[assembly: ResolutionGroupName("Xamarin")]
[assembly: ExportEffect(typeof(ProductCatalog.Droid.RoundImageEffects), nameof(ProductCatalog.Droid.RoundImageEffects))]
namespace ProductCatalog.Droid
{
    
        public class RoundImageEffects : PlatformEffect
        {
            ViewOutlineProvider originalProvider;
            Android.Views.View effectTarget;

            protected override void OnAttached()
            {
                try
                {
                    effectTarget = Control ?? Container;
                    originalProvider = effectTarget.OutlineProvider;
                    effectTarget.OutlineProvider = new CornerRadiusOutlineProvider(Element);
                    effectTarget.ClipToOutline = true;
                }
                catch (Exception ex)
                {
                   
                }
            }

            protected override void OnDetached()
            {
                if (effectTarget != null)
                {
                    effectTarget.OutlineProvider = originalProvider;
                    effectTarget.ClipToOutline = false;
                }
            }

            class CornerRadiusOutlineProvider : ViewOutlineProvider
            {
                Element element;

                public CornerRadiusOutlineProvider(Element formsElement)
                {
                    element = formsElement;
                }

                public override void GetOutline(Android.Views.View view, Outline outline)
                {
                    float scale = view.Resources.DisplayMetrics.Density;
                    double width = (double)element.GetValue(VisualElement.WidthProperty) * scale;
                    double height = (double)element.GetValue(VisualElement.HeightProperty) * scale;
                    float minDimension = (float)Math.Min(height, width);
                    float radius = minDimension / 2f;
                    Android.Graphics.Rect rect = new Android.Graphics.Rect(0, 0, (int)width, (int)height);
                    outline.SetRoundRect(rect, radius);
                }
            }
        }
    
}