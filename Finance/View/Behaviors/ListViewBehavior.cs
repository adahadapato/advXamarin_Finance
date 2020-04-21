using System;
using Finance.Model;
using Xamarin.Forms;

namespace Finance.View.Behaviors
{
    public class ListViewBehavior : Behavior<ListView>
    {
        ListView listView;

        protected override void OnAttachedTo(ListView bindable)
        {
            base.OnAttachedTo(bindable);

            listView = bindable;
            listView.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Item selectItem = (listView.SelectedItem) as Item;
            Application.Current.MainPage.Navigation.PushAsync(new PostPage(selectItem));
        }

        protected override void OnDetachingFrom(ListView bindable)
        {
            base.OnDetachingFrom(bindable);
            listView.ItemSelected -= ListView_ItemSelected;
        }
    }
}
