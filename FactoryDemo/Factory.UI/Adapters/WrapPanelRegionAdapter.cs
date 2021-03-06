﻿using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Factory.UI.Adapters
{
    public class WrapPanelRegionAdapter : RegionAdapterBase<WrapPanel>
    {
        public WrapPanelRegionAdapter(IRegionBehaviorFactory factory)
            : base(factory)
        {
        }

        protected override void Adapt(IRegion region, WrapPanel regionTarget)
        {
            region.Views.CollectionChanged += (s, e) =>
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (FrameworkElement element in e.NewItems)
                    {

                        regionTarget.Children.Add(element);
                    }
                }
                else if (e.Action == NotifyCollectionChangedAction.Remove)
                {
                    foreach (FrameworkElement element in e.OldItems)
                    {
                        regionTarget.Children.Remove(element);
                    }
                }

                regionTarget.UpdateLayout();
                //implement remove
            };
        }

        protected override IRegion CreateRegion()
        {
            return new AllActiveRegion();
        }
    }

}
