using Android.App;
using Android.Widget;
using Android.OS;
using EstimoteSdk;
using System;

namespace Silver_BI
{
    [Activity(Label = "Silver BI", Icon = "@drawable/icon")]
    public class MainActivity : Activity, BeaconManager.IServiceReadyCallback
    {

        BeaconManager beaconManager;
        string scanId;
        bool isScanning;

        public void OnServiceReady ()
        {
            isScanning = true;
            scanId = beaconManager.StartNearableDiscovery ();
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            beaconManager = new BeaconManager (this);

            beaconManager.Nearable  += (sender, e) => {
                ActionBar.Subtitle = string.Format ("Found {0} eddystones.", e.Nearables.Count);
            };

            beaconManager.Connect (this);
        }

        protected override void OnDestroy ()
        {
            base.OnDestroy ();
            beaconManager.Disconnect ();
        }

        protected override void OnStop ()
        {
            base.OnStop ();
            if (!isScanning)
                return;

            isScanning = false;
            beaconManager.StopNearableDiscovery (scanId);
        }
    }



}

