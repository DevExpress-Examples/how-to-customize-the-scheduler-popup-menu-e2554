using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraScheduler;

namespace PopupMenuCustomization {
    class MySchedulerHelper {
        public static string[] Users = new string[] { "Peter Dolan", "Ryan Fischer", "Andrew Miller", "Tom Hamlett",
                                                        "Jerry Campbell", "Carl Lucas", "Mark Hamilton", "Steve Lee" };
        public static void FillResources(SchedulerDataStorage storage, int count) {
            ResourceCollection resources = storage.Resources.Items;
            int cnt = Math.Min(count, Users.Length);
            for(int i = 1; i <= cnt; i++) {
                Resource resource = storage.CreateResource(i);
                resource.Caption = Users[i - 1];
                resources.Add(resource);
            }
        }
    }
}
