//using Android.Support.V4.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
//using AndroidX.Fragment.App;
using Android.App;
using Android.Support.V7.App;

namespace WhatsApp
{
    using Fragment = Android.Support.V4.App.Fragment;
    using FragmentActivity = Android.Support.V4.App.FragmentActivity;

    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : FragmentActivity
    {
        SearchView searchView;
        bool is_show = false;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            // Установка режима навигации 
            this.ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
            // Добавление вкладок 
            AddTabCamera();
            //var fragments = new Android.Support.V4.App.Fragment[]
            //    {
            //        new FragmentChats(),
            //        new FragmentStatus(),
            //        new FragmentCall()
            //    };
            AddTab("Чаты", new FragmentChats());
            AddTab("Статус", new FragmentStatus());
            AddTab("Звонки", new FragmentCall());
            // Выбор фрагмента "Чат" 
            this.ActionBar.SelectTab(this.ActionBar.GetTabAt(1));
            is_show = true;
        }
        void AddTab(string title, Fragment fragment)
        {
            var tab = this.ActionBar.NewTab();

            tab.SetText(title);

            SupportFragmentManager
                .BeginTransaction()
                .Replace(Resource.Id.container, fragment)
                .AddToBackStack(fragment.GetType().Name)
                .Commit();
            
            this.ActionBar.AddTab(tab);
        }
        void AddTabCamera()
        {
            var tab = this.ActionBar.NewTab();
            // Установка значка камеры 
            tab.SetIcon(Android.Resource.Drawable.IcMenuCamera);
            tab.TabSelected += (o, e) =>
            {
                // Измените этот код на код, запускающий камеру 
                if (is_show) Toast.MakeText(this, "Запуск камеры", ToastLength.Long).Show();
            };
            this.ActionBar.AddTab(tab);
        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            // Настройка поиска 
            var actionView = menu.FindItem(Resource.Id.action_search).ActionView;
            searchView = actionView.JavaCast<Android.Widget.SearchView>();
            searchView.QueryTextSubmit += (o, e) =>
            {
                Toast.MakeText(this, "Текст для поиска: " + e.Query,
                ToastLength.Long).Show();
            };
            searchView.QueryTextChange += (o, e) =>
            {
            };
            searchView.Close += (o, e) =>
            {
            };
            return base.OnCreateOptionsMenu(menu);
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.action_exit:
                    Java.Lang.JavaSystem.Exit(0);
                    break;
            }
            return base.OnOptionsItemSelected(item);
        }
        public override void OnBackPressed()
        {
        }
    }
}

