using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.InAppBilling;
using Xamarin.Forms;

namespace TestPayment
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            try
            {
                var userId = "my-test-id";
                var billing = CrossInAppBilling.Current;

                var productId = "hieptestpaymentsubscription";

                // billing.InTestingMode = true;

                var connected = await billing.ConnectAsync();

                if (!connected)
                {
                }

                var subs = await billing.GetProductInfoAsync(ItemType.Subscription, productId);
                var mySubs = subs.ToList();

                var purchases = await billing.GetPurchasesAsync(ItemType.Subscription);
                foreach (var item in purchases.ToList())
                {
                    Console.WriteLine("Item id: " + item.Id);
                }

                var purchase = await billing.PurchaseAsync(productId, ItemType.Subscription);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            finally
            {
                await CrossInAppBilling.Current.DisconnectAsync();
            }
        }
    }
}