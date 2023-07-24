using AntDesign;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using TTestFramework.Shared.Clients;
using TTestFramework.Shared.Models;

namespace TTestFramework.WebClient.Pages.Products
{
    public partial class CreateProduct
    {
        [Inject]
        IProductClient ProductClient { get; set; }

        [Inject]
        NavigationManager Navigation { get; set; }

        [Inject]
        MessageService Message { get; set; }

        CreateProductModel model;
        bool loading;

        public CreateProduct()
        {
            model = new CreateProductModel();
        }

        async Task OnFinish(EditContext context)
        {
            try
            {
                loading = true;

                CreateProductModel model = context.Model as CreateProductModel;

                await ProductClient.CreateProduct(model);

                _ = Message.Success("Created product successfully");

                loading = false;

                Navigation.NavigateTo("/products");
            }
            catch (Exception ex)
            {
                loading = false;

                Console.Error.WriteLine(ex);

                _ = Message.Error("Failed to create product");
            }
        }

        void OnFinishFailed(EditContext context)
        {
            Console.WriteLine("Invalid data");
        }
    }
}
