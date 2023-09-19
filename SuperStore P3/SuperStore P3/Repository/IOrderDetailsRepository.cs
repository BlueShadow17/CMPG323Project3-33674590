using Models;

namespace EcoPower_Logistics.Repository
{
    public interface IOrderDetailsRepository : IGenericRepository<OrderDetail>
    {
        IEnumerable<OrderDetail> GetAllOrderDetail();
        Task<OrderDetail> GetOrderDetailByIdAsync(int orderDetailId);
        Task AddOrderDetailAsync(OrderDetail orderDetail);
        void UpdateOrderDetail(OrderDetail orderDetail);
        bool OrderDetailExists(int productId);
        Task DeleteOrderDetailAsync(int orderDetailId);
    }
}