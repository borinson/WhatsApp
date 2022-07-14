using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;

namespace WhatsApp
{
    public class FragmentCall : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container,
        Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.fragment_call, container, false);
        }
    }
}