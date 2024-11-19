using ETicaretAPI.Application.DTOs.Order;
using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Abstractions
{
    public interface IOrderService
    {
        Task CreateOrderAsync(CreateOrder createOrder);
        Task<ListOrder> GetAllOrdersAsync(int page, int size);
        Task<SingleOrder> GetOrderByIdAsync(string id);
        Task<(bool, CompletedOrderDTO)> CompleteOrderAsync(string id);
    }
}
