using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Practics.DemoExam.Extensions;
using Practics.DemoExam.Models;
using Practics.DemoExam.Services;

namespace Practics.DemoExam.Windows
{
    public partial class ProductWindow : Window
    {
        private readonly ProductService _productService;
        
        public ProductWindow(ProductService productService)
        {
            _productService = productService;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Closed += ClosedEventHandler;
            
            InitializeComponent();
            
            ProductsPanel.CanUserAddRows = false;
            ProductsPanel.CanUserDeleteRows = false;
            
            List<Product> products = _productService.Read().ToList();
            ProductsPanel.ItemsSource = products;
        }

        private void ClosedEventHandler(object sender, EventArgs args)
        {
            Application.Current.Shutdown();
        }

        private void AddProductButton_OnClick(object sender, RoutedEventArgs e)
        {
            this.OpenWindow<AddProductWindow>(_productService, this);
        }

        private void EditProductButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void DeleteProductButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void RefreshProducts()
        {
            List<Product> products = _productService.Read().ToList();
            
            ProductsPanel.ItemsSource = products;
        }
    }
}