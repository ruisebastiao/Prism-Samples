﻿using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Factory.Infrastructure.Adapters
{
    public class GridRegionAdapter : RegionAdapterBase<Grid>
    {
        public GridRegionAdapter(IRegionBehaviorFactory behaviorFactory) :
            base(behaviorFactory)
        {
        }

        protected override void Adapt(IRegion region, Grid regionTarget)
        {
            region.Views.CollectionChanged += (s, e) =>
            {
                //Add
                if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
                    foreach (FrameworkElement element in e.NewItems)
                        regionTarget.Children.Add(element);

                //Removal
                if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
                    foreach (FrameworkElement element in e.OldItems)
                        if (regionTarget.Children.Contains(element))
                            regionTarget.Children.Remove(element);
            };
        }

        protected override IRegion CreateRegion()
        {
            return new AllActiveRegion();
        }

    }
}
