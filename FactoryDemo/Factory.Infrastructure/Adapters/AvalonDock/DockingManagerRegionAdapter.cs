﻿using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Wpf.AvalonDock;

namespace Factory.Infrastructure.Adapters
{
    public class DockingManagerRegionAdapter : RegionAdapterBase<DockingManager>
    {
        public DockingManagerRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory)
            : base(regionBehaviorFactory)
        {

        }

        protected override void Adapt(IRegion region, DockingManager regionTarget)
        {

        }

        protected override IRegion CreateRegion()
        {
            return new Region();
        }

        protected override void AttachBehaviors(IRegion region, DockingManager regionTarget)
        {
            if (region == null)
                throw new System.ArgumentNullException("region");

            // Add the behavior that syncs the items source items with the rest of the items
            region.Behaviors.Add(DockingManagerDocumentsSourceSyncBehavior.BehaviorKey, new DockingManagerDocumentsSourceSyncBehavior()
            {
                HostControl = regionTarget
            });

            base.AttachBehaviors(region, regionTarget);
        }
    }

}
