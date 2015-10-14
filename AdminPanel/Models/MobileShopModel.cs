using System;
using System.Collections.Generic;

namespace AdminPanel.Models
{
    public class ClientUser
    {
        public string ClientUserId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string password { get; set; }
        public string emailAddress { get; set; }
        public string phoneNumber { get; set; }
        public DateTime birthday { get; set; }
        public string address { get; set; }

        public List<Order> orderList { get; set; }

    }

    public class Image
    {
        public string ImageId { get; set; }
        public Product product { get; set; }
        public string titleImage { get; set; }
        public string previewImage { get; set; }
    }

    public class Product
    {
        public string ProductId { get; set; }
        public string mTitle { get; set; }
        public float mPrice { get; set; }
        public float mQuantity { get; set; }
        public string mManufacture { get; set; }

        public float salePrice { get; set; }
        public float oldPrice { get; set; }

        public string mScreenSize { get; set; }
        public string mScreenResolution { get; set; }
        public string mCPU { get; set; }
        public string mRAM { get; set; }
        public string mROM { get; set; }
        public string mMemoryCard { get; set; }
        public string mCamera { get; set; }
        public string mSim { get; set; }
        public string mOS { get; set; }
        public string mPin { get; set; }
        public string mWeight { get; set; }
        public string mSize { get; set; }
        public string mConnectionPort { get; set; }
        public string mGuarantee { get; set; }
        public Image image { get; set; }
    }

    public class ReturningOrder
    {
        public string ReturningOrderId { get; set; }
        public float quantity { get; set; }        
    }

    public class ReturningOrderDetail
    {
        public string ReturningOrderDetailId { get; set; }
        public List<Product> productList { get; set; }
        public List<ReturningOrder> returningOrderList { get; set; }
    }

    public class BestSeller
    {
        public string BestSellerId { get; set; }
        public List<Product> productList { get; set; }
    
    }

    public class Order
    {
        public string OrderId { get; set; }
        public string customerType { get; set; }
        public ClientUser customerId { get; set; }
        public string orderStatus { get; set; }
        public float totalAmount { get; set; }
        public string orderShipper { get; set; }
        public string shippingAddress { get; set; }
        public string orderNote { get; set; }

        public List<OrderDetail> orderDetailList { get; set; }
    }

    public class OrderDetail
    {
        public string OrderDetailId { get; set; }
        public Order order { get; set; }
        public List<Product> productList { get; set; }
        public float quantity { get; set; }
    }

    public class Division
    {
        public string DivisionId { get; set; }
        public List<ServerUserModel> shipperId { get; set; }
        public List<Order> orderDivision { get; set; }
        public string statusShip { get; set; }
        
    }
    public class News
    {
        public string NewsId { get; set; }
        public string title { get; set; }
        public string content { get; set; }

    }
}