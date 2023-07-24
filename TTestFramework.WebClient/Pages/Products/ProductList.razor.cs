using AntDesign.TableModels;
using Microsoft.AspNetCore.Components;
using TTestFramework.Shared.Clients;
using TTestFramework.Shared.Models;

namespace TTestFramework.WebClient.Pages.Products
{
    public partial class ProductList
    {
        [Inject]
        IProductClient ProductClient { get; set; }

        IEnumerable<ProductListModel> list { get; set; }
        bool loading { get; set; }


        protected override async Task OnInitializedAsync()
        {
            await FetchProducts();
        }

        void OnRowClick(RowData<ProductListModel> row)
        {
            Console.WriteLine($"Row {row.Data.Name} was clicked.");
        }

        private async Task FetchProducts()
        {
            loading = true;

            var response = await ProductClient.GetProducts();

            list = response;

            loading = false;
        }
    }
}
