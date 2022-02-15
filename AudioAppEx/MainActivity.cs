using Android.App;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using static Android.Icu.Text.Transliterator;

namespace AudioAppEx
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Button btn1, btn2, btn3, btn4;
        private ImageButton imgbtn;
        int position;
        private MediaPlayer mediaPlayer;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            btn1 = FindViewById<Button>(Resource.Id.btn1);
            btn2 = FindViewById<Button>(Resource.Id.btn2);
            btn3 = FindViewById<Button>(Resource.Id.btn3);
            btn4 = FindViewById<Button>(Resource.Id.btn4);

            imgbtn = FindViewById<ImageButton>(Resource.Id.img1);

            btn1.Click += btna_Click;
            btn2.Click += btnb_Click;
            btn3.Click += btnc_Click;
            btn4.Click += btnd_Click;

        }

        private void btnd_Click(object sender, EventArgs e)
        {
            mediaPlayer.Stop();
            Toast.MakeText(this, "Stop Song", ToastLength.Short).Show();
        }

        private void btnc_Click(object sender, EventArgs e)
        {
            mediaPlayer.SeekTo(position);
            mediaPlayer.Start();
            Toast.MakeText(this, "Resume Song", ToastLength.Short).Show();
        }

        private void btnb_Click(object sender, EventArgs e)
        {
            mediaPlayer.Pause();
            position = mediaPlayer.CurrentPosition;
            Toast.MakeText(this, "Pause Song", ToastLength.Short).Show();
        }

        private void btna_Click(object sender, EventArgs e)
        {
            mediaPlayer = MediaPlayer.Create(this, Resource.Raw.A1);
            mediaPlayer.Start();
            Toast.MakeText(this, "Start Song", ToastLength.Short).Show();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}